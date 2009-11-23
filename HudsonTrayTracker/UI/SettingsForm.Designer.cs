namespace Hudson.TrayTracker.UI
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.serversTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.serversSettingsControl = new Hudson.TrayTracker.UI.Controls.ServersSettingsControl();
            this.notificationsTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.notificationsSettingsControl = new Hudson.TrayTracker.UI.Controls.NotificationsSettingsControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.serversTabPage.SuspendLayout();
            this.notificationsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.serversTabPage;
            this.tabControl.Size = new System.Drawing.Size(746, 411);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.serversTabPage,
            this.notificationsTabPage});
            // 
            // serversTabPage
            // 
            this.serversTabPage.Controls.Add(this.serversSettingsControl);
            this.serversTabPage.Name = "serversTabPage";
            this.serversTabPage.Size = new System.Drawing.Size(715, 402);
            this.serversTabPage.Text = "Servers and projects";
            // 
            // serversSettingsControl
            // 
            this.serversSettingsControl.AutoSize = true;
            this.serversSettingsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.serversSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serversSettingsControl.Location = new System.Drawing.Point(0, 0);
            this.serversSettingsControl.Name = "serversSettingsControl";
            this.serversSettingsControl.Size = new System.Drawing.Size(715, 402);
            this.serversSettingsControl.TabIndex = 0;
            // 
            // notificationsTabPage
            // 
            this.notificationsTabPage.Controls.Add(this.notificationsSettingsControl);
            this.notificationsTabPage.Name = "notificationsTabPage";
            this.notificationsTabPage.Size = new System.Drawing.Size(715, 402);
            this.notificationsTabPage.Text = "Sound notifications";
            // 
            // notificationsSettingsControl
            // 
            this.notificationsSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationsSettingsControl.Location = new System.Drawing.Point(0, 0);
            this.notificationsSettingsControl.Name = "notificationsSettingsControl";
            this.notificationsSettingsControl.Size = new System.Drawing.Size(715, 402);
            this.notificationsSettingsControl.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 411);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Hudson Tray Tracker - Settings";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.serversTabPage.ResumeLayout(false);
            this.serversTabPage.PerformLayout();
            this.notificationsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage serversTabPage;
        private DevExpress.XtraTab.XtraTabPage notificationsTabPage;
        private Hudson.TrayTracker.UI.Controls.ServersSettingsControl serversSettingsControl;
        private Hudson.TrayTracker.UI.Controls.NotificationsSettingsControl notificationsSettingsControl;

    }
}