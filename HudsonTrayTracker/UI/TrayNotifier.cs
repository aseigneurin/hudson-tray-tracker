using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Hudson.TrayTracker.BusinessComponents;
using Dotnet.Commons.Logging;
using System.Reflection;
using Hudson.TrayTracker.Entities;
using Hudson.TrayTracker.Properties;
using Hudson.TrayTracker.Utils.Logging;

namespace Hudson.TrayTracker.UI
{
    public partial class TrayNotifier : Component
    {
        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        ConfigurationService configurationService;
        HudsonService hudsonService;
        UpdateService updateService;

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

        public UpdateService UpdateService
        {
            get { return updateService; }
            set { updateService = value; }
        }

        public TrayNotifier()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            configurationService.ConfigurationUpdated += configurationService_ConfigurationUpdated;
            updateService.ProjectsUpdated += updateService_ProjectsUpdated;

            Disposed += delegate
            {
                configurationService.ConfigurationUpdated -= configurationService_ConfigurationUpdated;
                updateService.ProjectsUpdated -= updateService_ProjectsUpdated;
            };
        }

        void configurationService_ConfigurationUpdated()
        {
            UpdateGlobalStatus();
        }

#if false
        private delegate void ProjectsUpdatedDelegate();
        private void updateService_ProjectsUpdated()
        {
            Delegate del = new ProjectsUpdatedDelegate(OnProjectsUpdated);
            MainForm.Instance.BeginInvoke(del);
        }
        private void OnProjectsUpdated()
        {
            UpdateGlobalStatus();
        }
#else
        private void updateService_ProjectsUpdated()
        {
            UpdateGlobalStatus();
        }
#endif

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            updateService.UpdateProjects();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
            SettingsForm.Instance.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
            AboutForm.Instance.ShowDialog();
        }

        public void UpdateGlobalStatus()
        {
            BuildStatus worstBuildStatus = BuildStatus.Successful;
            bool hasProjects = false;

            foreach (Server server in configurationService.Servers)
            {
                foreach (Project project in server.Projects)
                {
                    if (project.Status > worstBuildStatus)
                    {
                        worstBuildStatus = project.Status;
                        hasProjects = true;
                    }
                }
            }

            if (hasProjects == false)
                worstBuildStatus = BuildStatus.Indeterminate;

#if test
            testStatus++;
            if (testStatus > BuildStatus.Failed_BuildInProgress)
                testStatus = 0;
            worstBuildStatus = testStatus;
            Console.WriteLine("tray:"+testStatus);
#endif

            UpdateGlobalStatus(worstBuildStatus);
        }
#if test
        BuildStatus testStatus;
#endif

        private void UpdateGlobalStatus(BuildStatus buildStatus)
        {
            Icon icon = GetIcon(buildStatus);
            if (icon != null)
                notifyIcon.Icon = icon;
        }

        private Icon GetIcon(BuildStatus buildStatus)
        {
            Bitmap bitmap;
            try
            {
                string resourceName = string.Format("Hudson.TrayTracker.Resources.TrayIcons.{0}.gif",
                    buildStatus.ToString());
                bitmap = DevExpress.Utils.Controls.ImageHelper.CreateBitmapFromResources(
                    resourceName, GetType().Assembly);
                bitmap.MakeTransparent();
            }
            catch (Exception ex)
            {
                // FIXME: warn
                LoggingHelper.LogError(logger, ex);
                return null;
            }

            IntPtr hicon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hicon);
            return icon;
        }
    }
}
