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

        public void Initialize()
        {
            serversSettingsControl.ConfigurationService = ConfigurationService;
            serversSettingsControl.HudsonService = HudsonService;

            notificationsSettingsControl.ConfigurationService = ConfigurationService;
            notificationsSettingsControl.Initialize();
        }

        public static void ShowDialogOrFocus()
        {
            if (Instance.Visible)
                Instance.Focus();
            else
                Instance.ShowDialog();
        }
    }
}