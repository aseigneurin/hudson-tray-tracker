using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hudson.TrayTracker.BusinessComponents;
using Spring.Context.Support;
using Hudson.TrayTracker.Entities;
using DevExpress.XtraBars;

namespace Hudson.TrayTracker.UI.Controls
{
    public class ServersSettingsController
    {
        ConfigurationService configurationService;
        HudsonService hudsonService;

        ServerListControl serverListControl;
        ProjectListControl projectListControl;
        BarStaticItem statusTextItem;
        BarEditItem statusProgressItem;

        public ServersSettingsController(ServerListControl serverListControl,
            ProjectListControl projectListControl,
            BarStaticItem statusTextItem, 
            BarEditItem statusProgressItem)
        {
            this.serverListControl = serverListControl;
            this.projectListControl = projectListControl;
            this.statusTextItem = statusTextItem;
            this.statusProgressItem = statusProgressItem;

            configurationService = (ConfigurationService)ContextRegistry.GetContext().GetObject("ConfigurationService");
            hudsonService = (HudsonService)ContextRegistry.GetContext().GetObject("HudsonService");
            serverListControl.ConfigurationService = configurationService;
            projectListControl.ConfigurationService = configurationService;
            projectListControl.HudsonService = hudsonService;
        }

        public void Initialize()
        {
            serverListControl.Initialize();
            projectListControl.Initialize();
        }

        public void UpdateProjectList(Server server)
        {
            projectListControl.UpdateProjectList(server);
        }

        internal void SetStatus(string status, bool updating)
        {
            statusTextItem.Caption = status;
            statusProgressItem.Visibility = updating ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}
