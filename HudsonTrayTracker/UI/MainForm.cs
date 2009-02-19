using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hudson.TrayTracker.BusinessComponents;
using Hudson.TrayTracker.Entities;
using Hudson.TrayTracker.Properties;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing.Imaging;
using Dotnet.Commons.Logging;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Diagnostics;

namespace Hudson.TrayTracker.UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static MainForm instance;
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainForm();
                return instance;
            }
        }

        ConfigurationService configurationService;
        HudsonService hudsonService;
        UpdateService updateService;
        BindingList<ProjectWrapper> projectsDataSource;
        bool exiting;
        int lastHoveredDSRowIndex = -1;

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

        public MainForm()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            configurationService.ConfigurationUpdated += configurationService_ConfigurationUpdated;
            updateService.ProjectsUpdated += updateService_ProjectsUpdated;

            Disposed += delegate
            {
                configurationService.ConfigurationUpdated -= configurationService_ConfigurationUpdated;
                updateService.ProjectsUpdated -= updateService_ProjectsUpdated;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Initialize();
            LoadProjects();
        }

        void configurationService_ConfigurationUpdated()
        {
            LoadProjects();
        }

        private delegate void ProjectsUpdatedDelegate();
        private void updateService_ProjectsUpdated()
        {
            Delegate del = new ProjectsUpdatedDelegate(OnProjectsUpdated);
            BeginInvoke(del);
        }
        private void OnProjectsUpdated()
        {
            LoadProjects();
        }

        private void settingsButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SettingsForm.Instance.ShowDialog();
        }

        private void LoadProjects()
        {
            projectsDataSource = new BindingList<ProjectWrapper>();

            foreach (Server server in configurationService.Servers)
            {
                foreach (Project project in server.Projects)
                {
                    ProjectWrapper wrapper = new ProjectWrapper(project);
                    projectsDataSource.Add(wrapper);
                }
            }

            projectsGridControl.DataSource = projectsDataSource;
            projectsGridView.BestFitColumns();

            lastCheckBarStaticItem.Caption = string.Format(HudsonTrayTrackerResources.LastCheck_Format, DateTime.Now);
        }

        private void refreshButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateService.UpdateProjects();
        }

        private void HudsonTrayTrackerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exiting == false)
            {
                Hide();
                e.Cancel = true;
            }
        }

        public void Exit()
        {
            exiting = true;
            Close();
            Application.Exit();
        }

        private void exitButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit();
        }

        private void projectsGridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == statusGridColumn)
                {
                    ProjectWrapper projectWrapper = (ProjectWrapper)projectsDataSource[e.ListSourceRowIndex];
                    string resourceName = string.Format("Hudson.TrayTracker.Resources.StatusIcons.{0}.gif",
                        projectWrapper.Project.Status.ToString());
                    Image img = DevExpress.Utils.Controls.ImageHelper.CreateImageFromResources(
                        resourceName, GetType().Assembly);
                    byte[] imgBytes = DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray(img, ImageFormat.Gif);
                    e.Value = imgBytes;
                }
            }
        }

        private void aboutButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AboutForm.Instance.ShowDialog();
        }

        private void projectsGridView_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            GridHitInfo ghi = projectsGridView.CalcHitInfo(pt);
            if (ghi.InRow)
            {
                int dsRowIndex = projectsGridView.GetDataSourceRowIndex(ghi.RowHandle);
                if (lastHoveredDSRowIndex != dsRowIndex)
                {
                    ProjectWrapper project = projectsDataSource[dsRowIndex];
                    string message = HudsonTrayTrackerResources.ResourceManager
                        .GetString("BuildStatus_" + project.Project.Status.ToString());
                    toolTip.SetToolTip(projectsGridControl, message);
                }
                lastHoveredDSRowIndex = dsRowIndex;
            }
            else
            {
                lastHoveredDSRowIndex = -1;
            }
        }

        private void projectsGridView_DoubleClick(object sender, EventArgs e)
        {
            Point pt = projectsGridControl.PointToClient(Cursor.Position);
            GridHitInfo ghi = projectsGridView.CalcHitInfo(pt);
            if (ghi.InRow == false)
                return;
            int dsRowIndex = projectsGridView.GetDataSourceRowIndex(ghi.RowHandle);
            ProjectWrapper project = projectsDataSource[dsRowIndex];
            Process.Start(project.Project.Url);
        }

        private class ProjectWrapper
        {
            Project project;

            public ProjectWrapper(Project project)
            {
                this.project = project;
            }

            public Project Project
            {
                get { return project; }
            }

            public string Server
            {
                get { return project.Server.Url; }
            }
            public string Name
            {
                get { return project.Name; }
            }
            public string Url
            {
                get { return project.Url; }
            }
            public string LastSuccessBuild
            {
                get { return FormatBuildDetails(project.LastSuccessfulBuild); }
            }
            public string LastFailureBuild
            {
                get { return FormatBuildDetails(project.LastFailedBuild); }
            }

            private string FormatBuildDetails(BuildDetails details)
            {
                if (details == null)
                    return "-";
                return string.Format(HudsonTrayTrackerResources.BuildDetails_Format,
                    details.Number, details.Time.ToLocalTime());
            }
        }
    }
}