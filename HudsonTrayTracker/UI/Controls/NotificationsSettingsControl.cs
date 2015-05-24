using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hudson.TrayTracker.BusinessComponents;
using Spring.Context.Support;

namespace Hudson.TrayTracker.UI.Controls
{
    public partial class NotificationsSettingsControl : DevExpress.XtraEditors.XtraUserControl
    {
        ConfigurationService configurationService;

        public NotificationsSettingsControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // designer mode
            if (DesignMode)
                return;

            configurationService = (ConfigurationService)ContextRegistry.GetContext().GetObject("ConfigurationService");

            enableSoundCheckBox_CheckedChanged(null, null);
        }

        private void enableSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            notificationSettingsControl1.Enabled =
                notificationSettingsControl2.Enabled =
                notificationSettingsControl3.Enabled =
                notificationSettingsControl4.Enabled =
                enableSoundCheckBox.Checked;
        }

        public void InvalidateData()
        {
            notificationSettingsControl1.InvalidateData();
            notificationSettingsControl2.InvalidateData();
            notificationSettingsControl3.InvalidateData();
            notificationSettingsControl4.InvalidateData();
        }
    }
}
