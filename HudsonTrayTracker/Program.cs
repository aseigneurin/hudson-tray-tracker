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
using Common.Logging;
using Hudson.TrayTracker.Utils;
using System.Threading;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors;
using Spring.Context.Support;

namespace Hudson.TrayTracker
{
    static class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

                // Spring
                ContextRegistry.GetContext();

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
    }
