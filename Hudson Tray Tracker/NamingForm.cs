using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Hudson.TrayTracker
{
    public partial class NamingForm : DevExpress.XtraEditors.XtraForm
    {
        public NamingForm()
        {
            InitializeComponent();
            nameTextBox.TextChanged += delegate { ValidateForm(); };
        }

        public string CaptionText
        {
            get { return Text; }
            set { Text = value; }
        }

        public string QuestionText
        {
            get { return questionLabel.Text; }
            set { questionLabel.Text = value; }
        }

        public string EditedName
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