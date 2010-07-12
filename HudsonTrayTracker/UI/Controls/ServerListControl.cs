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
    public partial class ServerListControl : DevExpress.XtraEditors.XtraUserControl
    {
        ConfigurationService configurationService;
        BindingList<Server> serversDataSource;

        bool initialized;

        public ServersSettingsController Controller { get; set; }
        
        public ServerListControl()
        {
            InitializeComponent();
        }

        public void Initialize(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;

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

            Controller.UpdateProjectList(server);
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
            Controller.UpdateProjectList(server);
        }

        private Server GetSelectedServer()
        {
            object row = serversGridView.GetFocusedRow();
            Server server = row as Server;
            return server;
        }
    }
}
