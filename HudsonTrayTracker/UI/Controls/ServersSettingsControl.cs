using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hudson.TrayTracker.BusinessComponents;
using Hudson.TrayTracker.Entities;
using DevExpress.XtraBars;
using Hudson.TrayTracker.Utils.BackgroundProcessing;
using Spring.Context.Support;

namespace Hudson.TrayTracker.UI.Controls
{
    public partial class ServersSettingsControl : DevExpress.XtraEditors.XtraUserControl
    {
        ConfigurationService configurationService;
        HudsonService hudsonService;
        BindingList<Server> serversDataSource;
        List<Project> projectsDataSource;

        bool initialized;

        public ServersSettingsControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // designer mode
            if (DesignMode)
                return;

            if (configurationService == null)
                configurationService = (ConfigurationService)ContextRegistry.GetContext().GetObject("ConfigurationService");
            if (hudsonService == null)
                hudsonService = (HudsonService)ContextRegistry.GetContext().GetObject("HudsonService");

            initialized = false;

            serversDataSource = new BindingList<Server>();
            foreach (Server server in configurationService.Servers)
                serversDataSource.Add(server);
            serversGridControl.DataSource = serversDataSource;

            initialized = true;

            serversGridView_FocusedRowChanged(null, null);
        }

        private void addServerButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditServerForm namingForm = new EditServerForm();
            if (namingForm.ShowDialog() != DialogResult.OK)
                return;

            Server server = configurationService.AddServer(namingForm.ServerAddress,
                namingForm.Username, namingForm.Password);
            if (server == null)
                return;

            serversDataSource.Add(server);
        }

        private void editServerButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Server server = GetSelectedServer();
            if (server == null)
                return;

            EditServerForm namingForm = new EditServerForm(server);
            if (namingForm.ShowDialog() != DialogResult.OK)
                return;

            configurationService.UpdateServer(server,
                   namingForm.ServerAddress, namingForm.Username, namingForm.Password);

            UpdateProjectList(server);
        }

        private void removeServerButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Server server = GetSelectedServer();
            serversDataSource.Remove(server);
            configurationService.RemoveServer(server);
        }

        private void serversGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (initialized == false)
                return;

            Server server = GetSelectedServer();

            // update the toolbar
            editServerButtonItem.Enabled
                = removeServerButtonItem.Enabled
                = server != null;

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
                    var dataSource = new List<Project>();
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

        private void selectAllProjectsMenuItem_Click(object sender, EventArgs e)
        {
            if (projectsDataSource == null)
                return;
            configurationService.AddProjects(projectsDataSource);
            projectsGridView.RefreshData();
        }

        private void deselectAllProjectsMenuItem_Click(object sender, EventArgs e)
        {
            if (projectsDataSource == null)
                return;
            configurationService.RemoveProjects(projectsDataSource);
            projectsGridView.RefreshData();
        }
    }
}
