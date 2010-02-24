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

            treatUnstableAsFailedCheckBox.Checked = configurationService.IsTreadUnstableAsFailed();
        }

        private void treatUnstableAsFailedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            configurationService.SetTreadUnstableAsFailed(treatUnstableAsFailedCheckBox.Checked);
        }
    }
}
