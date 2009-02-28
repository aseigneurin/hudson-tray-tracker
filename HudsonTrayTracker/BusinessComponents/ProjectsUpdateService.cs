using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Dotnet.Commons.Logging;
using System.Reflection;
using Hudson.TrayTracker.Entities;
using System.ComponentModel;
using Hudson.TrayTracker.Utils.Logging;
using Iesi.Collections.Generic;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class ProjectsUpdateService
    {
        public enum UpdateSource
        {
            User,
            Timer,
            Program
        }

        public delegate void ProjectsUpdatedHandler();
        public event ProjectsUpdatedHandler ProjectsUpdated;

        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // every 15 seconds
        static readonly int DEFAULT_UPDATE_PERIOD = 15 * 1000;

        ConfigurationService configurationService;
        HudsonService hudsonService;

        Timer timer;
        int updatePeriod = DEFAULT_UPDATE_PERIOD;
        bool updating;

        public ConfigurationService ConfigurationService
        {
            get { return configurationService; }
            set { configurationService = value; }
        }

        public HudsonService HudsonService
        {
            get { return hudsonService; }
            set { hudsonService = value; }
        }

        public ProjectsUpdateService()
        {
        }

        public void Initialize()
        {
            timer = new Timer(UpdateProjects, null, 0, updatePeriod);
        }

        public void UpdateProjects()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                DoUpdateProjects(UpdateSource.User);
            };
            worker.RunWorkerAsync();
        }

        private void UpdateProjects(object state)
        {
            DoUpdateProjects(UpdateSource.Timer);
        }

        private void DoUpdateProjects(UpdateSource source)
        {
            logger.Info("Running update from " + source);

            lock (this)
            {
                if (updating)
                {
                    logger.Info("Already in update: skipping");
                    return;
                }
                updating = true;
            }

            try
            {
                DoUpdateProjectsInternal();
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
        }

        private void DoUpdateProjectsInternal()
        {
            ISet<Project> projects = configurationService.GetProjects();
            IDictionary<Project, AllBuildDetails> newBuildDetails = new Dictionary<Project, AllBuildDetails>();

            foreach (Project project in projects)
            {
                try
                {
                    AllBuildDetails newBuildDetail = hudsonService.UpdateProject(project);
                    newBuildDetails[project] = newBuildDetail;
                }
                catch (Exception ex)
                {
                    LoggingHelper.LogError(logger, ex);
                }
            }

            foreach (Project project in projects)
            {
                AllBuildDetails newStatus;
                newBuildDetails.TryGetValue(project, out newStatus);
                project.AllBuildDetails = newStatus;
            }

            if (ProjectsUpdated != null)
                ProjectsUpdated();
        }
    }
}
