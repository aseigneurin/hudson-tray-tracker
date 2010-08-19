using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using Hudson.TrayTracker.Entities;

namespace Hudson.TrayTracker.UI
{
    public partial class EditServerForm : DevExpress.XtraEditors.XtraForm
    {
        public EditServerForm()
        {
            InitializeComponent();
            urlTextBox.TextChanged += delegate { ValidateForm(); };
        }

        public EditServerForm(Server server)
            : this()
        {
            ServerAddress = server.Url;
            IgnoreUntrustedCertificate = server.IgnoreUntrustedCertificate;
            if (server.Credentials != null)
            {
                RequiresAuthentication = true;
                Username = server.Credentials.Username;
                Password = server.Credentials.Password;
            }
        }

        public string ServerAddress
        {
            get { return urlTextBox.Text; }
            set { urlTextBox.Text = value; }
        }

        public bool RequiresAuthentication
        {
            get { return authenticationCheckBox.CheckState == CheckState.Checked; }
            set { authenticationCheckBox.CheckState = value ? CheckState.Checked : CheckState.Unchecked; }
        }

        public string Username
        {
            get
            {
                if (RequiresAuthentication == false)
                    return null;
                return usernameTextBox.Text;
            }
            set { usernameTextBox.Text = value; }
        }

        public string Password
        {
            get
            {
                if (RequiresAuthentication == false)
                    return null;
                return passwordTextBox.Text;
            }
            set { passwordTextBox.Text = value; }
        }

        public bool IgnoreUntrustedCertificate
        {
            get { return ignoreUntrustedCertificateCheckBox.CheckState == CheckState.Checked; }
            set { ignoreUntrustedCertificateCheckBox.CheckState = value ? CheckState.Checked : CheckState.Unchecked; }
        }

        protected virtual bool IsNameValid(string name)
        {
            return String.IsNullOrEmpty(name) == false;
        }

        private void ValidateForm()
        {
            string name = urlTextBox.Text;
            bool nameValid = IsNameValid(name);

            validateButton.Enabled = nameValid;
        }

        private void authenticationCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            usernameLabel.Enabled
                = usernameTextBox.Enabled
                = passwordLabel.Enabled
                = passwordTextBox.Enabled
                = RequiresAuthentication;
        }
    }
}