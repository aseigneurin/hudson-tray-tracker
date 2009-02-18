namespace Hudson.TrayTracker
{
    partial class HudsonTrayTrackerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HudsonTrayTrackerForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.settingsButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.refreshButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.exitButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.aboutButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lastCheckBarStaticItem = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.projectsGridControl = new DevExpress.XtraGrid.GridControl();
            this.projectsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serverGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.statusGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.nameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.urlGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastSuccessGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastFailureGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.notifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.settingsButtonItem,
            this.aboutButtonItem,
            this.refreshButtonItem,
            this.exitButtonItem,
            this.lastCheckBarStaticItem});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 5;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.settingsButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.refreshButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.exitButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.aboutButtonItem)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // settingsButtonItem
            // 
            this.settingsButtonItem.Caption = "Settings";
            this.settingsButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("settingsButtonItem.Glyph")));
            this.settingsButtonItem.Id = 0;
            this.settingsButtonItem.Name = "settingsButtonItem";
            this.settingsButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.settingsButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.settingsButtonItem_ItemClick);
            // 
            // refreshButtonItem
            // 
            this.refreshButtonItem.Caption = "Refresh";
            this.refreshButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("refreshButtonItem.Glyph")));
            this.refreshButtonItem.Id = 2;
            this.refreshButtonItem.Name = "refreshButtonItem";
            this.refreshButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.refreshButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refreshButtonItem_ItemClick);
            // 
            // exitButtonItem
            // 
            this.exitButtonItem.Caption = "Exit";
            this.exitButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("exitButtonItem.Glyph")));
            this.exitButtonItem.Id = 3;
            this.exitButtonItem.Name = "exitButtonItem";
            this.exitButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.exitButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exitButtonItem_ItemClick);
            // 
            // aboutButtonItem
            // 
            this.aboutButtonItem.Caption = "About";
            this.aboutButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("aboutButtonItem.Glyph")));
            this.aboutButtonItem.Id = 1;
            this.aboutButtonItem.Name = "aboutButtonItem";
            this.aboutButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lastCheckBarStaticItem)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lastCheckBarStaticItem
            // 
            this.lastCheckBarStaticItem.Caption = "Last check: -";
            this.lastCheckBarStaticItem.Id = 4;
            this.lastCheckBarStaticItem.Name = "lastCheckBarStaticItem";
            this.lastCheckBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // projectsGridControl
            // 
            this.projectsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsGridControl.Location = new System.Drawing.Point(0, 26);
            this.projectsGridControl.MainView = this.projectsGridView;
            this.projectsGridControl.Name = "projectsGridControl";
            this.projectsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemPictureEdit3});
            this.projectsGridControl.Size = new System.Drawing.Size(675, 210);
            this.projectsGridControl.TabIndex = 4;
            this.projectsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.projectsGridView});
            // 
            // projectsGridView
            // 
            this.projectsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serverGridColumn,
            this.statusGridColumn,
            this.nameGridColumn,
            this.urlGridColumn,
            this.lastSuccessGridColumn,
            this.lastFailureGridColumn});
            this.projectsGridView.GridControl = this.projectsGridControl;
            this.projectsGridView.GroupCount = 1;
            this.projectsGridView.Name = "projectsGridView";
            this.projectsGridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.projectsGridView.OptionsCustomization.AllowGroup = false;
            this.projectsGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.projectsGridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.projectsGridView.OptionsView.ShowGroupPanel = false;
            this.projectsGridView.OptionsView.ShowIndicator = false;
            this.projectsGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.serverGridColumn, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.nameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.projectsGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.projectsGridView_CustomUnboundColumnData);
            // 
            // serverGridColumn
            // 
            this.serverGridColumn.Caption = "Server";
            this.serverGridColumn.ColumnEdit = this.repositoryItemPictureEdit2;
            this.serverGridColumn.FieldName = "Server";
            this.serverGridColumn.Name = "serverGridColumn";
            this.serverGridColumn.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // statusGridColumn
            // 
            this.statusGridColumn.ColumnEdit = this.repositoryItemPictureEdit3;
            this.statusGridColumn.FieldName = "statusGridColumn";
            this.statusGridColumn.ImageIndex = 0;
            this.statusGridColumn.Name = "statusGridColumn";
            this.statusGridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.statusGridColumn.Visible = true;
            this.statusGridColumn.VisibleIndex = 0;
            this.statusGridColumn.Width = 39;
            // 
            // repositoryItemPictureEdit3
            // 
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            // 
            // nameGridColumn
            // 
            this.nameGridColumn.Caption = "Project";
            this.nameGridColumn.FieldName = "Name";
            this.nameGridColumn.Name = "nameGridColumn";
            this.nameGridColumn.OptionsColumn.AllowEdit = false;
            this.nameGridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.nameGridColumn.Visible = true;
            this.nameGridColumn.VisibleIndex = 1;
            this.nameGridColumn.Width = 157;
            // 
            // urlGridColumn
            // 
            this.urlGridColumn.Caption = "URL";
            this.urlGridColumn.FieldName = "Url";
            this.urlGridColumn.Name = "urlGridColumn";
            this.urlGridColumn.OptionsColumn.AllowEdit = false;
            this.urlGridColumn.Visible = true;
            this.urlGridColumn.VisibleIndex = 2;
            this.urlGridColumn.Width = 157;
            // 
            // lastSuccessGridColumn
            // 
            this.lastSuccessGridColumn.AppearanceCell.Options.UseTextOptions = true;
            this.lastSuccessGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lastSuccessGridColumn.Caption = "Last success";
            this.lastSuccessGridColumn.FieldName = "LastSuccessBuild";
            this.lastSuccessGridColumn.Name = "lastSuccessGridColumn";
            this.lastSuccessGridColumn.OptionsColumn.AllowEdit = false;
            this.lastSuccessGridColumn.Visible = true;
            this.lastSuccessGridColumn.VisibleIndex = 3;
            this.lastSuccessGridColumn.Width = 157;
            // 
            // lastFailureGridColumn
            // 
            this.lastFailureGridColumn.AppearanceCell.Options.UseTextOptions = true;
            this.lastFailureGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lastFailureGridColumn.Caption = "Last failure";
            this.lastFailureGridColumn.FieldName = "LastFailureBuild";
            this.lastFailureGridColumn.Name = "lastFailureGridColumn";
            this.lastFailureGridColumn.OptionsColumn.AllowEdit = false;
            this.lastFailureGridColumn.Visible = true;
            this.lastFailureGridColumn.VisibleIndex = 4;
            this.lastFailureGridColumn.Width = 161;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Successful.gif");
            this.imageList.Images.SetKeyName(1, "Successful_BuildInProgress.gif");
            this.imageList.Images.SetKeyName(2, "Indeterminate.gif");
            this.imageList.Images.SetKeyName(3, "Indeterminate_BuildInProgress.gif");
            this.imageList.Images.SetKeyName(4, "Unstable.gif");
            this.imageList.Images.SetKeyName(5, "Unstable_BuildInProgress.gif");
            this.imageList.Images.SetKeyName(6, "Failed.gif");
            this.imageList.Images.SetKeyName(7, "Failed_BuildInProgress.gif");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.notifyIcon.Text = "Hudson Tray Tracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(124, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // HudsonTrayTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 259);
            this.Controls.Add(this.projectsGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "HudsonTrayTrackerForm";
            this.Text = "Hudson Tray Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HudsonTrayTrackerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem settingsButtonItem;
        private DevExpress.XtraBars.BarButtonItem aboutButtonItem;
        private DevExpress.XtraGrid.GridControl projectsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView projectsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn urlGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn lastSuccessGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn lastFailureGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn serverGridColumn;
        private DevExpress.XtraBars.BarButtonItem refreshButtonItem;
        private DevExpress.XtraBars.BarButtonItem exitButtonItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private DevExpress.XtraBars.BarStaticItem lastCheckBarStaticItem;
        private DevExpress.XtraGrid.Columns.GridColumn statusGridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit3;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}