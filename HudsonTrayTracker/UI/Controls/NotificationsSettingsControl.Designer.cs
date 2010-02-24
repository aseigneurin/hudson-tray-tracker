namespace Hudson.TrayTracker.UI.Controls
{
    partial class NotificationsSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.notificationSettingsControl1 = new Hudson.TrayTracker.UI.Controls.NotificationSettingsControl();
            this.notificationSettingsControl2 = new Hudson.TrayTracker.UI.Controls.NotificationSettingsControl();
            this.notificationSettingsControl3 = new Hudson.TrayTracker.UI.Controls.NotificationSettingsControl();
            this.notificationSettingsControl4 = new Hudson.TrayTracker.UI.Controls.NotificationSettingsControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treatUnstableAsFailedCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatUnstableAsFailedCheckBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.notificationSettingsControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.notificationSettingsControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.notificationSettingsControl3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.notificationSettingsControl4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treatUnstableAsFailedCheckBox, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 340);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // notificationSettingsControl1
            // 
            this.notificationSettingsControl1.AutoSize = true;
            this.notificationSettingsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notificationSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationSettingsControl1.Location = new System.Drawing.Point(3, 34);
            this.notificationSettingsControl1.Name = "notificationSettingsControl1";
            this.notificationSettingsControl1.Size = new System.Drawing.Size(471, 48);
            this.notificationSettingsControl1.SoundPath = "";
            this.notificationSettingsControl1.Status = "Failed";
            this.notificationSettingsControl1.TabIndex = 0;
            // 
            // notificationSettingsControl2
            // 
            this.notificationSettingsControl2.AutoSize = true;
            this.notificationSettingsControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notificationSettingsControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationSettingsControl2.Location = new System.Drawing.Point(3, 88);
            this.notificationSettingsControl2.Name = "notificationSettingsControl2";
            this.notificationSettingsControl2.Size = new System.Drawing.Size(471, 48);
            this.notificationSettingsControl2.SoundPath = "";
            this.notificationSettingsControl2.Status = "Fixed";
            this.notificationSettingsControl2.TabIndex = 1;
            // 
            // notificationSettingsControl3
            // 
            this.notificationSettingsControl3.AutoSize = true;
            this.notificationSettingsControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notificationSettingsControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationSettingsControl3.Location = new System.Drawing.Point(3, 142);
            this.notificationSettingsControl3.Name = "notificationSettingsControl3";
            this.notificationSettingsControl3.Size = new System.Drawing.Size(471, 48);
            this.notificationSettingsControl3.SoundPath = "";
            this.notificationSettingsControl3.Status = "StillFailing";
            this.notificationSettingsControl3.TabIndex = 2;
            // 
            // notificationSettingsControl4
            // 
            this.notificationSettingsControl4.AutoSize = true;
            this.notificationSettingsControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notificationSettingsControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationSettingsControl4.Location = new System.Drawing.Point(3, 196);
            this.notificationSettingsControl4.Name = "notificationSettingsControl4";
            this.notificationSettingsControl4.Size = new System.Drawing.Size(471, 48);
            this.notificationSettingsControl4.SoundPath = "";
            this.notificationSettingsControl4.Status = "Succeeded";
            this.notificationSettingsControl4.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 9, 3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(275, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Configure the sound to play when an event occur";
            // 
            // treatUnstableAsFailedCheckBox
            // 
            this.treatUnstableAsFailedCheckBox.Location = new System.Drawing.Point(3, 250);
            this.treatUnstableAsFailedCheckBox.Name = "treatUnstableAsFailedCheckBox";
            this.treatUnstableAsFailedCheckBox.Properties.Caption = "Treat unstable as failed";
            this.treatUnstableAsFailedCheckBox.Size = new System.Drawing.Size(139, 19);
            this.treatUnstableAsFailedCheckBox.TabIndex = 5;
            this.treatUnstableAsFailedCheckBox.CheckedChanged += new System.EventHandler(this.treatUnstableAsFailedCheckBox_CheckedChanged);
            // 
            // NotificationsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NotificationsSettingsControl";
            this.Size = new System.Drawing.Size(477, 340);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatUnstableAsFailedCheckBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NotificationSettingsControl notificationSettingsControl1;
        private NotificationSettingsControl notificationSettingsControl2;
        private NotificationSettingsControl notificationSettingsControl3;
        private NotificationSettingsControl notificationSettingsControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit treatUnstableAsFailedCheckBox;
    }
}
