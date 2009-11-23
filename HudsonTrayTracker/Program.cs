using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hudson.TrayTracker.BusinessComponents;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using Hudson.TrayTracker.UI;
using Hudson.TrayTracker.Utils.Logging;
using System.Reflection;
using System.Diagnostics;
using Dotnet.Commons.Logging;
using Hudson.TrayTracker.Utils;
using System.Threading;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors;

namespace Hudson.TrayTracker
{
    static class Program
    {
        private static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ThreadExceptionHandler handler = new ThreadExceptionHandler();
                Application.ThreadException += new ThreadExceptionEventHandler(handler.Application_ThreadException);

                // skinning         
                SkinManager.EnableFormSkins();
                OfficeSkins.Register();
                UserLookAndFeel.Default.ActiveLookAndFeel.SkinName = "Office 2007 Blue";

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += new EventHandler(Application_Exit);
                Application_Prepare();

                ///////
                ConfigurationService configurationService = new ConfigurationService();
                HudsonService hudsonService = new HudsonService();
                ProjectsUpdateService projectsUpdateService = new ProjectsUpdateService();
                ApplicationUpdateService applicationUpdateService = new ApplicationUpdateService();
                NotificationService notificationService = new NotificationService(configurationService.NotificationSounds);
                projectsUpdateService.ConfigurationService = configurationService;
                projectsUpdateService.HudsonService = hudsonService;

                MainForm mainForm = MainForm.Instance;
                mainForm.ConfigurationService = configurationService;
                mainForm.HudsonService = hudsonService;
                mainForm.ProjectsUpdateService = projectsUpdateService;
                mainForm.ApplicationUpdateService = applicationUpdateService;

                SettingsForm settingsForm = SettingsForm.Instance;
                settingsForm.ConfigurationService = configurationService;
                settingsForm.HudsonService = hudsonService;
                settingsForm.Initialize();

                TrayNotifier notifier = TrayNotifier.Instance;
                notifier.ConfigurationService = configurationService;
                notifier.HudsonService = hudsonService;
                notifier.UpdateService = projectsUpdateService;
                notifier.NotificationService = notificationService;
                notifier.Initialize();
                notifier.UpdateNotifier();

                applicationUpdateService.NewVersionAvailable += applicationUpdateService_NewVersionAvailable;

                projectsUpdateService.Initialize();
                applicationUpdateService.Initialize();
                ///////

                ApplicationContext appContext = new ApplicationContext();
                Application.Run(appContext);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(logger, ex);
                MessageBox.Show(ex.ToString(), "Program exception handler");
            }
        }

        private static void Application_Prepare()
        {
            logger.Info("Log4net ready.");
            logger.Info(Assembly.GetExecutingAssembly().GetName().Name
                + " v" + Assembly.GetExecutingAssembly().GetName().Version);
            logger.Info(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location));
        }

        static void Application_Exit(object sender, EventArgs e)
        {
            try
            {
                TrayNotifier.Instance.Dispose();
            }
            catch (Exception ex)
            {
                logger.Error("Failed dispoing tray notifier", ex);
            }

            logger.Info(Assembly.GetExecutingAssembly().GetName().Name
                + " v" + Assembly.GetExecutingAssembly().GetName().Version + " Exit");
        }

        static void applicationUpdateService_NewVersionAvailable(Version version, string installerUrl)
        {
            string message = string.Format(HudsonTrayTrackerResources.ApplicationUpdates_NewVersion_Text, version);
            DialogResult res = XtraMessageBox.Show(message, HudsonTrayTrackerResources.ApplicationUpdates_Caption,
                MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes)
            {
                logger.Info("Update refused by user");
                return;
            }
            logger.Info("Update accepted by user");
            Process.Start(installerUrl);
            Application.Exit();
        }
    }
}