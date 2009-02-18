using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hudson.TrayTracker.BusinessComponents;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using Hudson.TrayTracker.UI;

namespace Hudson.TrayTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // skinning         
            SkinManager.EnableFormSkins();
            OfficeSkins.Register();
            UserLookAndFeel.Default.ActiveLookAndFeel.SkinName = "Office 2007 Blue";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigurationService configurationService = new ConfigurationService();
            HudsonService hudsonService = new HudsonService();
            UpdateService updateService = new UpdateService();
            updateService.ConfigurationService = configurationService;
            updateService.HudsonService = hudsonService;
            updateService.UpdateProjects();

            MainForm mainForm = new MainForm();
            mainForm.ConfigurationService = configurationService;
            mainForm.HudsonService = hudsonService;
            mainForm.UpdateService = updateService;
            mainForm.UpdateGlobalStatus();

            ApplicationContext appContext = new ApplicationContext();
            Application.Run(appContext);
        }
    }
}