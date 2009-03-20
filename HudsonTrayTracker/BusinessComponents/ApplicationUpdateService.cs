using System;
using System.Collections.Generic;
using System.Text;
using Dotnet.Commons.Logging;
using System.Reflection;
using System.Threading;
using Hudson.TrayTracker.Utils.Logging;
using System.ComponentModel;
using System.Net;
using Hudson.TrayTracker.Utils.IO;
using Hudson.TrayTracker.Utils.Collections;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class ApplicationUpdateService
    {
        public enum UpdateSource
        {
            User,
            Timer,
            Program
        }

        public delegate void NewVersionAvailableHandler(Version version, string installerUrl);
        public event NewVersionAvailableHandler NewVersionAvailable;

        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // every 10 minutes
        static readonly int DEFAULT_UPDATE_PERIOD = 10 * 60 * 1000;

        static readonly String URL = "http://hudson-tray-tracker.googlecode.com/svn/trunk/scripts/version.properties";

        static readonly String PROPERTY_VERSION_NUMBER = "version.number";
        static readonly String PROPERTY_INSTALLER_URL = "version.installerUrl";

        Timer timer;
        int updatePeriod = DEFAULT_UPDATE_PERIOD;
        bool updating;

        public ApplicationUpdateService()
        {
        }

        public void Initialize()
        {
            timer = new Timer(CheckForUpdates, null, 0, updatePeriod);
        }

        public void CheckForUpdates_Asynchronous(UpdateSource source)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                DoCheckForUpdates(source);
            };
            worker.RunWorkerAsync();
        }

        public bool CheckForUpdates_Synchronous(UpdateSource source)
        {
            return DoCheckForUpdates(source);
        }

        private void CheckForUpdates(object state)
        {
            // ignore errors
            try
            {
                DoCheckForUpdates(UpdateSource.Timer);
            }
            catch { }
        }

        // returns true if an update was found, false otherwise
        private bool DoCheckForUpdates(UpdateSource source)
        {
            logger.Info("Running update check from " + source);

            lock (this)
            {
                if (updating)
                {
                    logger.Info("Already in update: skipping");
                    return false;
                }
                updating = true;
            }

            bool res;
            try
            {
                res = DoCheckForUpdatesInternal();
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(logger, ex);
                throw;
            }
            finally
            {
                lock (this)
                {
                    updating = false;
                }
            }

            logger.Info("Done");
            return res;
        }

        // returns true if an update was found, false otherwise
        private bool DoCheckForUpdatesInternal()
        {
            logger.Info("Checking for updates from " + URL);

            // download the properties file
            WebClient webClient = new WebClient();
            String versionProperties = webClient.DownloadString(URL);

            // extract version details
            IPropertiesContainer properties = PropertiesFile.ReadProperties(versionProperties, "version.properties");
            string versionStr = properties[PROPERTY_VERSION_NUMBER];
            string installerUrl = properties[PROPERTY_INSTALLER_URL];

            Version version = new Version(versionStr);
            Version currentVersion = GetCurrentVersion();

            logger.Info("Current version: " + currentVersion);
            logger.Info("Last version: " + version);
            logger.Info("Installer URL: " + installerUrl);

            if (version <= currentVersion)
            {
                logger.Info("No updates");
                return false;
            }

            logger.Info("An update is available");

            // disable the timer
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            if (NewVersionAvailable != null)
                NewVersionAvailable(version, installerUrl);

            return true;
        }

        private Version GetCurrentVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
