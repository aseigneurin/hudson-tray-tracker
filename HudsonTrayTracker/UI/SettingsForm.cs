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
using Hudson.TrayTracker.Utils.BackgroundProcessing;
using DevExpress.XtraBars;

namespace Hudson.TrayTracker.UI
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        static SettingsForm instance;
        public static SettingsForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new SettingsForm();
                return instance;
            }
        }

        ConfigurationService configurationService;
        HudsonService hudsonService;
        BindingList<Server> serversDataSource;
        List<Project> projectsDataSource;

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

        public SettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            serversDataSource = new BindingList<Server>();
            foreach (Server server in configurationService.Servers)
                serversDataSource.Add(server);
            serversGridControl.DataSource = serversDataSource;

            serversGridView_FocusedRowChanged(null, null);
        }

        private void addServerButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NamingForm namingForm = new NamingForm();
            namingForm.CaptionText = HudsonTrayTrackerResources.AddServer_Caption;
            namingForm.QuestionText = HudsonTrayTrackerResources.AddServer_Question;
            if (namingForm.ShowDialog() != DialogResult.OK)
                return;

            string url = namingForm.EditedName;
            Server server = configurationService.AddServer(url);
            if (server == null)
                return;

            serversDataSource.Add(server);
        }

        private void removeServerButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Server server = GetSelectedServer();
            serversDataSource.Remove(server);
            configurationService.RemoveServer(server);
        }

        private void serversGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Server server = GetSelectedServer();

            // update the toolbar
            removeServerButtonItem.Enabled = server != null;

            // update the project list
            UpdateProjectList(server);
        }

        private void UpdateProjectList(Server server)
        {
#if SYNCRHONOUS
            List<Project> dataSource = new List<Project>();

            if (server != null)
            {
                IList<Project> projects = hudsonService.LoadProjects(server);
                foreach (Project project in projects)
                    dataSource.Add(project);
            }

            SetProjectsDataSource(dataSource);
#else
            // clear the view
            projectsGridControl.DataSource = null;

            if (server == null)
                return;

            // disable the window, change the cursor, update the status
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            statusTextItem.Caption = string.Format(HudsonTrayTrackerResources.LoadingProjects_FormatString, server.Url);
            statusProgressItem.Visibility = BarItemVisibility.Always;

            // run the process in background
            Process process = new Process("Loading project " + server.Url);
            IList<Project> projects = null;
            process.DoWork += delegate
            {
                projects = hudsonService.LoadProjects(server);
            };
            process.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                string status = "";

                if (e.Error == null)
                {
                    List<Project> dataSource = new List<Project>();
                    foreach (Project project in projects)
                        dataSource.Add(project);
                    SetProjectsDataSource(dataSource);
                }
                else
                {
                    status = string.Format(
                        HudsonTrayTrackerResources.FailedLoadingProjects_FormatString, server.Url);
                }

                // enable the window, change the cursor, update the status
                Enabled = true;
                Cursor.Current = Cursors.Default;
                statusTextItem.Caption = status;
                statusProgressItem.Visibility = BarItemVisibility.Never;
            };
            BackgroundProcessExecutor.Execute(process);
#endif
        }

        private void SetProjectsDataSource(List<Project> dataSource)
        {
            projectsDataSource = dataSource;
            projectsGridControl.DataSource = projectsDataSource;
        }

        private void projectsGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                Project project = projectsDataSource[e.ListSourceRowIndex];
                bool selected = project.Server.Projects.Contains(project);
                e.Value = selected;
            }
            else if (e.IsSetData)
            {
                Project project = projectsDataSource[e.ListSourceRowIndex];
                bool selected = (bool)e.Value;
                if (selected)
                    configurationService.AddProject(project);
                else
                    configurationService.RemoveProject(project);
            }
        }

        private Server GetSelectedServer()
        {
            object row = serversGridView.GetFocusedRow();
            Server server = row as Server;
            return server;
        }

        private void projectSelectedCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            // validate the check box value as soon as it is clicked
            ((CheckEdit)sender).DoValidate();
            projectsGridView.CloseEditor();
        }
    }
}