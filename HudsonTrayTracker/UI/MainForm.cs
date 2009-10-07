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
using Hudson.TrayTracker.Utils.Logging;
using DevExpress.Utils.Controls;
using Hudson.TrayTracker.Utils;
using DevExpress.XtraGrid.Columns;

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
        ProjectsUpdateService projectsUpdateService;
        ApplicationUpdateService applicationUpdateService;
        BindingList<ProjectWrapper> projectsDataSource;
        bool exiting;
        int lastHoveredDSRowIndex = -1;
        IDictionary<BuildStatus, byte[]> icons;
        Font normalMenuItemFont;
        Font mainMenuItemFont;

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

        public ProjectsUpdateService ProjectsUpdateService
        {
            get { return projectsUpdateService; }
            set { projectsUpdateService = value; }
        }

        public ApplicationUpdateService ApplicationUpdateService
        {
            get { return applicationUpdateService; }
            set { applicationUpdateService = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            normalMenuItemFont = openProjectPageMenuItem.Font;
            mainMenuItemFont = new Font(openProjectPageMenuItem.Font, FontStyle.Bold);
        }

        private void Initialize()
        {
            configurationService.ConfigurationUpdated += configurationService_ConfigurationUpdated;
            projectsUpdateService.ProjectsUpdated += updateService_ProjectsUpdated;

            Disposed += delegate
            {
                configurationService.ConfigurationUpdated -= configurationService_ConfigurationUpdated;
                projectsUpdateService.ProjectsUpdated -= updateService_ProjectsUpdated;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Initialize();
            LoadIcons();
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
            projectsUpdateService.UpdateProjects();
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
                    byte[] imgBytes = icons[projectWrapper.Project.Status];
                    e.Value = imgBytes;
                }
            }
        }

        private void LoadIcons()
        {
            icons = new Dictionary<BuildStatus, byte[]>();

            foreach (BuildStatus buildStatus in Enum.GetValues(typeof(BuildStatus)))
            {
                try
                {
                    string resourceName = string.Format("Hudson.TrayTracker.Resources.StatusIcons.{0}.gif",
                        buildStatus.ToString());
                    Image img = ImageHelper.CreateImageFromResources(
                        resourceName, GetType().Assembly);
                    byte[] imgBytes = DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray(img, ImageFormat.Gif);
                    icons.Add(buildStatus, imgBytes);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(HudsonTrayTrackerResources.FailedLoadingIcons_Text,
                        HudsonTrayTrackerResources.FailedLoadingIcons_Caption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggingHelper.LogError(logger, ex);
                    throw new Exception("Failed loading icon: " + buildStatus, ex);
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
            Project project = GetSelectedProject();
            if (project == null)
                return;
            if (BuildStatusUtils.IsErrorBuild(project.Status))
                OpenProjectConsolePage(project);
            else
                OpenProjectPage(project);
        }

        private void OpenSelectedProjectPage()
        {
            Project project = GetSelectedProject();
            OpenProjectPage(project);
        }

        private void OpenProjectPage(Project project)
        {
            if (project == null)
                return;
            Process.Start(project.Url);
        }

        private void OpenSelectedProjectConsolePage()
        {
            Project project = GetSelectedProject();
            OpenProjectConsolePage(project);
        }

        private void OpenProjectConsolePage(Project project)
        {
            if (project == null)
                return;
            string url = hudsonService.GetConsolePage(project);
            Process.Start(url);
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
                get { return Uri.UnescapeDataString(project.Url); }
            }
            public BuildDetails LastSuccessBuild
            {
                get { return project.LastSuccessfulBuild; }
            }
            public string LastSuccessBuildStr
            {
                get { return FormatBuildDetails(LastSuccessBuild); }
            }
            public BuildDetails LastFailureBuild
            {
                get { return project.LastFailedBuild; }
            }
            public string LastFailureBuildStr
            {
                get { return FormatBuildDetails(LastFailureBuild); }
            }
            public string LastSuccessUsers
            {
                get { return FormatUsers(project.LastSuccessfulBuild); }
            }
            public string LastFailureUsers
            {
                get { return FormatUsers(project.LastFailedBuild); }
            }

            private string FormatBuildDetails(BuildDetails details)
            {
                if (details == null)
                    return "-";
                string res = string.Format(HudsonTrayTrackerResources.BuildDetails_Format_NumberDate,
                       details.Number, details.Time.ToLocalTime());
                return res;
            }
            private string FormatUsers(BuildDetails details)
            {
                if (details == null)
                    return "-";
                string res = StringUtils.Join(details.Users, HudsonTrayTrackerResources.BuildDetails_UserSeparator);
                return res;
            }
        }

        private void openProjectPageMenuItem_Click(object sender, EventArgs e)
        {
            OpenSelectedProjectPage();
        }

        private void openConsolePageMenuItem_Click(object sender, EventArgs e)
        {
            OpenSelectedProjectConsolePage();
        }

        private void runBuildMenuItem_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();
            if (project == null)
                return;
            try
            {
                hudsonService.SafeRunBuild(project);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(logger, ex);
                XtraMessageBox.Show(string.Format(HudsonTrayTrackerResources.RunBuildFailed_Text, ex.Message),
                    HudsonTrayTrackerResources.RunBuildFailed_Caption);
            }
        }

        private Project GetSelectedProject()
        {
            int[] rowHandles = projectsGridView.GetSelectedRows();
            if (rowHandles.Length != 1)
                return null;
            int rowHandle = rowHandles[0];
            int dsRowIndex = projectsGridView.GetDataSourceRowIndex(rowHandle);
            ProjectWrapper projectWrapper = projectsDataSource[dsRowIndex];
            return projectWrapper.Project;
        }

        public static void ShowOrFocus()
        {
            if (Instance.Visible)
                Instance.Focus();
            else
                Instance.Show();
        }

        private void checkUpdatesButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool hasUpdates;
            try
            {
                hasUpdates = applicationUpdateService.CheckForUpdates_Synchronous(
                    ApplicationUpdateService.UpdateSource.User);
            }
            catch (Exception ex)
            {
                string errorMessage = String.Format(HudsonTrayTrackerResources.ErrorBoxMessage, ex.Message);
                XtraMessageBox.Show(errorMessage, HudsonTrayTrackerResources.ErrorBoxCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (hasUpdates == false)
            {
                XtraMessageBox.Show(HudsonTrayTrackerResources.ApplicationUpdates_NoUpdate_Text,
                    HudsonTrayTrackerResources.ApplicationUpdates_Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void acknowledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();
            if (project == null)
                return;
            BuildStatus currentStatus = project.Status;
            if (currentStatus < BuildStatus.Indeterminate)
                return;
            TrayNotifier.Instance.AcknowledgeStatus(project, currentStatus);
        }

        private void stopAcknowledgingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();
            if (project == null)
                return;
            TrayNotifier.Instance.ClearAcknowledgedStatus(project);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            Project project = GetSelectedProject();
            bool isProjectSelected = project != null;

            if (project == null)
            {
                openProjectPageMenuItem.Enabled
                    = openConsolePageMenuItem.Enabled
                    = runBuildMenuItem.Enabled
                    = acknowledgeToolStripMenuItem.Enabled
                    = stopAcknowledgingToolStripMenuItem.Enabled
                    = false;
                return;
            }

            acknowledgeToolStripMenuItem.Enabled = project.Status >= BuildStatus.Indeterminate;
            stopAcknowledgingToolStripMenuItem.Enabled = TrayNotifier.Instance.IsAcknowledged(project);

            bool inError = BuildStatusUtils.IsErrorBuild(project.Status);
            if (inError)
            {
                openProjectPageMenuItem.Font = normalMenuItemFont;
                openConsolePageMenuItem.Font = mainMenuItemFont;
            }
            else
            {
                openConsolePageMenuItem.Font = normalMenuItemFont;
                openProjectPageMenuItem.Font = mainMenuItemFont;
            }
        }

        private void removeProjectMenuItem_Click(object sender, EventArgs e)
        {
            Project project = GetSelectedProject();
            if (project == null)
                return;
            configurationService.RemoveProject(project);
        }

        private void projectsGridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            int? res = DoCustomColumnSort(sender, e);
            if (res == null)
                return;
            e.Handled = true;
            e.Result = res.Value;
        }

        private int? DoCustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            DateTime? date1 = GetBuildDate(e.Column, e.ListSourceRowIndex1);
            DateTime? date2 = GetBuildDate(e.Column, e.ListSourceRowIndex2);
            if (date1 == null && date2 == null)
                return null;
            if (date1 == null)
                return -1;
            if (date2 == null)
                return 1;
            int res = date1.Value.CompareTo(date2.Value);
            return res;
        }

        private DateTime? GetBuildDate(GridColumn column, int listSourceRowIndex)
        {
            BuildDetails buildDetails = GetBuildDetails(column, listSourceRowIndex);
            if (buildDetails == null)
                return null;
            return buildDetails.Time;
        }

        private BuildDetails GetBuildDetails(GridColumn column, int listSourceRowIndex)
        {
            ProjectWrapper projectWrapper = (ProjectWrapper)projectsDataSource[listSourceRowIndex];
            if (column == lastSuccessGridColumn)
                return projectWrapper.LastSuccessBuild;
            if (column == lastFailureGridColumn)
                return projectWrapper.LastFailureBuild;
            throw new Exception("Column not supported: " + column.Caption);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                projectsUpdateService.UpdateProjects();
        }
    }
}