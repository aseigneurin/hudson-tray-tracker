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
using Spring.Context.Support;

namespace Hudson.TrayTracker.UI
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public static SettingsForm Instance
        {
            get
            {
                SettingsForm instance = (SettingsForm)ContextRegistry.GetContext().GetObject("SettingsForm");
                return instance;
            }
        }

        public ConfigurationService ConfigurationService { get; set; }
        public HudsonService HudsonService { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        public static void ShowDialogOrFocus()
        {
            if (Instance.Visible)
                Instance.Focus();
            else
                Instance.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tabControl.SelectedTabPageIndex = 0;
        }
    }
}