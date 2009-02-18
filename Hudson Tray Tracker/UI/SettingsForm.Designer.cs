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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.projectsGridControl = new DevExpress.XtraGrid.GridControl();
            this.projectsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.projectSelectedGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.projectSelectedCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.projectNameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.serversGridControl = new DevExpress.XtraGrid.GridControl();
            this.serversGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serverGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.addServerButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.removeServerButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.statusTextItem = new DevExpress.XtraBars.BarStaticItem();
            this.statusProgressItem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectSelectedCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.projectsGridControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.serversGridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 289);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // projectsGridControl
            // 
            this.projectsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsGridControl.Location = new System.Drawing.Point(342, 3);
            this.projectsGridControl.MainView = this.projectsGridView;
            this.projectsGridControl.Name = "projectsGridControl";
            this.projectsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.projectSelectedCheckEdit});
            this.projectsGridControl.Size = new System.Drawing.Size(334, 283);
            this.projectsGridControl.TabIndex = 1;
            this.projectsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.projectsGridView});
            // 
            // projectsGridView
            // 
            this.projectsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.projectSelectedGridColumn,
            this.projectNameGridColumn});
            this.projectsGridView.GridControl = this.projectsGridControl;
            this.projectsGridView.Name = "projectsGridView";
            this.projectsGridView.OptionsCustomization.AllowGroup = false;
            this.projectsGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.projectsGridView.OptionsView.ShowGroupPanel = false;
            this.projectsGridView.OptionsView.ShowIndicator = false;
            this.projectsGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.projectNameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.projectsGridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.projectsGridView_CustomUnboundColumnData);
            // 
            // projectSelectedGridColumn
            // 
            this.projectSelectedGridColumn.ColumnEdit = this.projectSelectedCheckEdit;
            this.projectSelectedGridColumn.FieldName = "Selected";
            this.projectSelectedGridColumn.Name = "projectSelectedGridColumn";
            this.projectSelectedGridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.projectSelectedGridColumn.Visible = true;
            this.projectSelectedGridColumn.VisibleIndex = 0;
            this.projectSelectedGridColumn.Width = 28;
            // 
            // projectSelectedCheckEdit
            // 
            this.projectSelectedCheckEdit.AutoHeight = false;
            this.projectSelectedCheckEdit.Name = "projectSelectedCheckEdit";
            this.projectSelectedCheckEdit.EditValueChanged += new System.EventHandler(this.projectSelectedCheckEdit_EditValueChanged);
            // 
            // projectNameGridColumn
            // 
            this.projectNameGridColumn.Caption = "Projects";
            this.projectNameGridColumn.FieldName = "Name";
            this.projectNameGridColumn.Name = "projectNameGridColumn";
            this.projectNameGridColumn.OptionsColumn.AllowEdit = false;
            this.projectNameGridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.projectNameGridColumn.Visible = true;
            this.projectNameGridColumn.VisibleIndex = 1;
            this.projectNameGridColumn.Width = 302;
            // 
            // serversGridControl
            // 
            this.serversGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serversGridControl.Location = new System.Drawing.Point(3, 3);
            this.serversGridControl.MainView = this.serversGridView;
            this.serversGridControl.Name = "serversGridControl";
            this.serversGridControl.Size = new System.Drawing.Size(333, 283);
            this.serversGridControl.TabIndex = 0;
            this.serversGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.serversGridView});
            // 
            // serversGridView
            // 
            this.serversGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serverGridColumn});
            this.serversGridView.GridControl = this.serversGridControl;
            this.serversGridView.Name = "serversGridView";
            this.serversGridView.OptionsCustomization.AllowGroup = false;
            this.serversGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.serversGridView.OptionsView.ShowGroupPanel = false;
            this.serversGridView.OptionsView.ShowIndicator = false;
            this.serversGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.serverGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.serversGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.serversGridView_FocusedRowChanged);
            // 
            // serverGridColumn
            // 
            this.serverGridColumn.Caption = "Servers";
            this.serverGridColumn.FieldName = "Url";
            this.serverGridColumn.Name = "serverGridColumn";
            this.serverGridColumn.OptionsColumn.AllowEdit = false;
            this.serverGridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.serverGridColumn.Visible = true;
            this.serverGridColumn.VisibleIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.addServerButtonItem,
            this.removeServerButtonItem,
            this.statusTextItem,
            this.statusProgressItem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1});
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addServerButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.removeServerButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // addServerButtonItem
            // 
            this.addServerButtonItem.Caption = "Add server";
            this.addServerButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("addServerButtonItem.Glyph")));
            this.addServerButtonItem.Id = 0;
            this.addServerButtonItem.Name = "addServerButtonItem";
            this.addServerButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addServerButtonItem_ItemClick);
            // 
            // removeServerButtonItem
            // 
            this.removeServerButtonItem.Caption = "Remove server";
            this.removeServerButtonItem.Enabled = false;
            this.removeServerButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("removeServerButtonItem.Glyph")));
            this.removeServerButtonItem.Id = 1;
            this.removeServerButtonItem.Name = "removeServerButtonItem";
            this.removeServerButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.removeServerButtonItem_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Status bar";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.statusProgressItem, "", false, true, true, 50),
            new DevExpress.XtraBars.LinkPersistInfo(this.statusTextItem)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.AllowRename = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Status bar";
            // 
            // statusTextItem
            // 
            this.statusTextItem.Id = 2;
            this.statusTextItem.Name = "statusTextItem";
            this.statusTextItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // statusProgressItem
            // 
            this.statusProgressItem.Edit = this.repositoryItemMarqueeProgressBar1;
            this.statusProgressItem.Id = 3;
            this.statusProgressItem.Name = "statusProgressItem";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SettingsForm";
            this.Text = "Hudson Tray Tracker - Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectSelectedCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl serversGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView serversGridView;
        private DevExpress.XtraGrid.GridControl projectsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView projectsGridView;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem addServerButtonItem;
        private DevExpress.XtraBars.BarButtonItem removeServerButtonItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn projectNameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn serverGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn projectSelectedGridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit projectSelectedCheckEdit;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem statusTextItem;
        private DevExpress.XtraBars.BarEditItem statusProgressItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
    }
}