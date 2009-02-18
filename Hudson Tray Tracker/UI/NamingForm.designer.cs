namespace Hudson.TrayTracker.UI
{
    partial class NamingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param label="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NamingForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.validateButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.nameTextBox = new DevExpress.XtraEditors.TextEdit();
            this.questionLabel = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.validateButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.questionLabel, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // validateButton
            // 
            this.validateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.validateButton, "validateButton");
            this.validateButton.Name = "validateButton";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            // 
            // nameTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nameTextBox, 4);
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            // 
            // questionLabel
            // 
            this.questionLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.questionLabel.Appearance.Options.UseBackColor = true;
            this.questionLabel.Appearance.Options.UseForeColor = true;
            this.tableLayoutPanel1.SetColumnSpan(this.questionLabel, 4);
            resources.ApplyResources(this.questionLabel, "questionLabel");
            this.questionLabel.Name = "questionLabel";
            // 
            // AddServerForm
            // 
            this.AcceptButton = this.validateButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServerForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton validateButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.TextEdit nameTextBox;
        private DevExpress.XtraEditors.LabelControl questionLabel;
    }
}