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

namespace Hudson.TrayTracker
{
    public partial class HudsonTrayTrackerSettingsForm : DevExpress.XtraEditors.XtraForm
    {
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

        public HudsonTrayTrackerSettingsForm()
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
            configurationService.RemoveServer(server);
        }

        private void serversGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Server server = GetSelectedServer();

            // update the project list
            UpdateProjectList(server);

            // update the toolbar
            removeServerButtonItem.Enabled = server != null;
        }

        private void UpdateProjectList(Server server)
        {
            IList<Project> projects = hudsonService.LoadProjects(server);

            projectsDataSource = new List<Project>();

            if (server != null)
            {
                foreach (Project project in projects)
                    projectsDataSource.Add(project);
            }

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