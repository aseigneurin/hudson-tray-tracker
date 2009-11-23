using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hudson.TrayTracker.BusinessComponents;

namespace Hudson.TrayTracker.UI.Controls
{
    public partial class NotificationsSettingsControl : DevExpress.XtraEditors.XtraUserControl
    {
        ConfigurationService configurationService;

        public ConfigurationService ConfigurationService
        {
            get { return configurationService; }
            set { configurationService = value; }
        }

        public NotificationsSettingsControl()
        {
            InitializeComponent();

            notificationSettingsControl1.Status = "Failed";
            notificationSettingsControl2.Status = "Fixed";
            notificationSettingsControl3.Status = "StillFailing";
            notificationSettingsControl4.Status = "Succeeded";
        }

        public void Initialize()
        {
            notificationSettingsControl1.ConfigurationService = ConfigurationService;
            notificationSettingsControl2.ConfigurationService = ConfigurationService;
            notificationSettingsControl3.ConfigurationService = ConfigurationService;
            notificationSettingsControl4.ConfigurationService = ConfigurationService;
        }
    }
}
