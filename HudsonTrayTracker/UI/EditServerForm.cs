using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Hudson.TrayTracker.UI
{
    public partial class EditServerForm : DevExpress.XtraEditors.XtraForm
    {
        public EditServerForm()
        {
            InitializeComponent();
            nameTextBox.TextChanged += delegate { ValidateForm(); };
        }

        public string ServerAddress
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        protected virtual bool IsNameValid(string name)
        {
            return String.IsNullOrEmpty(name) == false;
        }

        private void ValidateForm()
        {
            string name = nameTextBox.Text;
            bool nameValid = IsNameValid(name);
            //ValidationTools.SetValid(nameTextBox, nameValid);

            validateButton.Enabled = nameValid;
        }
    }
}