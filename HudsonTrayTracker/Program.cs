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
                // skinning         
                SkinManager.EnableFormSkins();
                OfficeSkins.Register();
                UserLookAndFeel.Default.ActiveLookAndFeel.SkinName = "Office 2007 Blue";

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ThreadExceptionHandler handler = new ThreadExceptionHandler();
                Application.ThreadException += new ThreadExceptionEventHandler(handler.Application_ThreadException);

                ///////
                ConfigurationService configurationService = new ConfigurationService();
                HudsonService hudsonService = new HudsonService();
                UpdateService updateService = new UpdateService();
                updateService.ConfigurationService = configurationService;
                updateService.HudsonService = hudsonService;
                updateService.UpdateProjects();

                MainForm mainForm = MainForm.Instance;
                mainForm.ConfigurationService = configurationService;
                mainForm.HudsonService = hudsonService;
                mainForm.UpdateService = updateService;

                SettingsForm settingsForm = SettingsForm.Instance;
                settingsForm.ConfigurationService = configurationService;
                settingsForm.HudsonService = hudsonService;

                TrayNotifier notifier = new TrayNotifier();
                notifier.ConfigurationService = configurationService;
                notifier.HudsonService = hudsonService;
                notifier.UpdateService = updateService;
                notifier.Initialize();
                notifier.UpdateGlobalStatus();
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
            logger.Info(Assembly.GetExecutingAssembly().GetName().Name
                + " v" + Assembly.GetExecutingAssembly().GetName().Version + " Exit");
        }
    }
}