namespace Hudson.TrayTracker.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.statusGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.nameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.urlGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastSuccessGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastFailureGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).BeginInit();
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
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
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
            this.aboutButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.aboutButtonItem_ItemClick);
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
            this.repositoryItemPictureEdit3});
            this.projectsGridControl.Size = new System.Drawing.Size(879, 361);
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.serverGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.projectsGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.projectsGridView_CustomUnboundColumnData);
            this.projectsGridView.DoubleClick += new System.EventHandler(this.projectsGridView_DoubleClick);
            this.projectsGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.projectsGridView_MouseMove);
            // 
            // serverGridColumn
            // 
            this.serverGridColumn.Caption = "Server";
            this.serverGridColumn.FieldName = "Server";
            this.serverGridColumn.Name = "serverGridColumn";
            this.serverGridColumn.OptionsColumn.AllowEdit = false;
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
            this.statusGridColumn.Width = 58;
            // 
            // repositoryItemPictureEdit3
            // 
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            // 
            // nameGridColumn
            // 
            this.nameGridColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nameGridColumn.AppearanceCell.Options.UseFont = true;
            this.nameGridColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nameGridColumn.AppearanceHeader.Options.UseFont = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 412);
            this.Controls.Add(this.projectsGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainForm";
            this.Text = "Hudson Tray Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HudsonTrayTrackerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).EndInit();
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
        private DevExpress.XtraBars.BarStaticItem lastCheckBarStaticItem;
        private DevExpress.XtraGrid.Columns.GridColumn statusGridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit3;
        private System.Windows.Forms.ToolTip toolTip;
    }
}