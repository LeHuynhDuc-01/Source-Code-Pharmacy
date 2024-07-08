namespace UIUXHIEUTHUOC.UIAdmin
{
    partial class frmThongKeTonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeTonKho));
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.gcTonKho = new DevExpress.XtraGrid.GridControl();
            this.gvTonKho = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MACTSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhogb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.spSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnTatCa = new DevExpress.XtraEditors.SimpleButton();
            this.btnBaoCao = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhaphang = new DevExpress.XtraEditors.SimpleButton();
            this.btnTonKho = new DevExpress.XtraEditors.SimpleButton();
            this.slkKhoHang = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkKhoHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ClientControl = this.gcTonKho;
            this.documentManager1.View = this.noDocumentsView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.noDocumentsView1,
            this.tabbedView1});
            // 
            // gcTonKho
            // 
            this.gcTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTonKho.Location = new System.Drawing.Point(0, 0);
            this.gcTonKho.MainView = this.gvTonKho;
            this.gcTonKho.Name = "gcTonKho";
            this.gcTonKho.Size = new System.Drawing.Size(876, 361);
            this.gcTonKho.TabIndex = 1;
            this.gcTonKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTonKho});
            // 
            // gvTonKho
            // 
            this.gvTonKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MACTSP,
            this.TenSP,
            this.SoLuong,
            this.GiaNhap,
            this.GiaBan,
            this.NSX,
            this.HSD,
            this.NgayNhap,
            this.MaPN,
            this.TenKhogb});
            this.gvTonKho.GridControl = this.gcTonKho;
            this.gvTonKho.Name = "gvTonKho";
            // 
            // MACTSP
            // 
            this.MACTSP.Caption = "Mã Sản Phẩm";
            this.MACTSP.FieldName = "MACTSP";
            this.MACTSP.Name = "MACTSP";
            this.MACTSP.Visible = true;
            this.MACTSP.VisibleIndex = 2;
            this.MACTSP.Width = 155;
            // 
            // TenSP
            // 
            this.TenSP.Caption = "Tên Sản phẩm";
            this.TenSP.FieldName = "TenSP";
            this.TenSP.Name = "TenSP";
            this.TenSP.Visible = true;
            this.TenSP.VisibleIndex = 3;
            this.TenSP.Width = 298;
            // 
            // SoLuong
            // 
            this.SoLuong.Caption = "Số lượng";
            this.SoLuong.FieldName = "SoLuong";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Visible = true;
            this.SoLuong.VisibleIndex = 5;
            this.SoLuong.Width = 107;
            // 
            // GiaNhap
            // 
            this.GiaNhap.Caption = "Giá Nhập";
            this.GiaNhap.FieldName = "GiaNhap";
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.Visible = true;
            this.GiaNhap.VisibleIndex = 6;
            this.GiaNhap.Width = 155;
            // 
            // GiaBan
            // 
            this.GiaBan.Caption = "Giá Bán";
            this.GiaBan.FieldName = "GiaBan";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Visible = true;
            this.GiaBan.VisibleIndex = 7;
            this.GiaBan.Width = 142;
            // 
            // NSX
            // 
            this.NSX.Caption = "Ngày Sản Xuất";
            this.NSX.FieldName = "NSX";
            this.NSX.Name = "NSX";
            this.NSX.Visible = true;
            this.NSX.VisibleIndex = 9;
            this.NSX.Width = 115;
            // 
            // HSD
            // 
            this.HSD.Caption = "Hạn sử dụng";
            this.HSD.FieldName = "HSD";
            this.HSD.Name = "HSD";
            this.HSD.Visible = true;
            this.HSD.VisibleIndex = 8;
            this.HSD.Width = 117;
            // 
            // NgayNhap
            // 
            this.NgayNhap.Caption = "Ngày Nhập";
            this.NgayNhap.FieldName = "NgayNhap";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Visible = true;
            this.NgayNhap.VisibleIndex = 4;
            this.NgayNhap.Width = 158;
            // 
            // MaPN
            // 
            this.MaPN.Caption = "Mã Phiếu Nhập";
            this.MaPN.FieldName = "MaPN";
            this.MaPN.Name = "MaPN";
            this.MaPN.Visible = true;
            this.MaPN.VisibleIndex = 0;
            this.MaPN.Width = 160;
            // 
            // TenKhogb
            // 
            this.TenKhogb.Caption = "Tên kho";
            this.TenKhogb.FieldName = "TenKho";
            this.TenKhogb.Name = "TenKhogb";
            this.TenKhogb.Visible = true;
            this.TenKhogb.VisibleIndex = 1;
            this.TenKhogb.Width = 207;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.FloatVertical = true;
            this.dockPanel1.ID = new System.Guid("8c058325-a644-4a40-9860-ecf57914629c");
            this.dockPanel1.Location = new System.Drawing.Point(0, 361);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 152);
            this.dockPanel1.Size = new System.Drawing.Size(876, 152);
            this.dockPanel1.Text = "Thông tin";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 32);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(870, 117);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.spSoLuong);
            this.layoutControl1.Controls.Add(this.btnTatCa);
            this.layoutControl1.Controls.Add(this.btnBaoCao);
            this.layoutControl1.Controls.Add(this.btnNhaphang);
            this.layoutControl1.Controls.Add(this.btnTonKho);
            this.layoutControl1.Controls.Add(this.slkKhoHang);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(870, 117);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // spSoLuong
            // 
            this.spSoLuong.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spSoLuong.Location = new System.Drawing.Point(589, 24);
            this.spSoLuong.Name = "spSoLuong";
            this.spSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spSoLuong.Size = new System.Drawing.Size(100, 22);
            this.spSoLuong.StyleController = this.layoutControl1;
            this.spSoLuong.TabIndex = 7;
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(358, 24);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(165, 22);
            this.btnTatCa.StyleController = this.layoutControl1;
            this.btnTatCa.TabIndex = 6;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBaoCao.ImageOptions.SvgImage")));
            this.btnBaoCao.Location = new System.Drawing.Point(717, 24);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(129, 69);
            this.btnBaoCao.StyleController = this.layoutControl1;
            this.btnBaoCao.TabIndex = 5;
            this.btnBaoCao.Text = "Xuất báo cáo";
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnNhaphang
            // 
            this.btnNhaphang.Location = new System.Drawing.Point(358, 50);
            this.btnNhaphang.Name = "btnNhaphang";
            this.btnNhaphang.Size = new System.Drawing.Size(331, 22);
            this.btnNhaphang.StyleController = this.layoutControl1;
            this.btnNhaphang.TabIndex = 5;
            this.btnNhaphang.Text = "Sản phẩm cần nhập";
            this.btnNhaphang.Click += new System.EventHandler(this.btnNhaphang_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.Location = new System.Drawing.Point(24, 50);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(330, 22);
            this.btnTonKho.StyleController = this.layoutControl1;
            this.btnTonKho.TabIndex = 5;
            this.btnTonKho.Text = "Báo cáo tồn kho";
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // slkKhoHang
            // 
            this.slkKhoHang.Location = new System.Drawing.Point(86, 24);
            this.slkKhoHang.Name = "slkKhoHang";
            this.slkKhoHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkKhoHang.Properties.PopupView = this.searchLookUpEdit1View;
            this.slkKhoHang.Size = new System.Drawing.Size(268, 22);
            this.slkKhoHang.StyleController = this.layoutControl1;
            this.slkKhoHang.TabIndex = 4;
            this.slkKhoHang.EditValueChanged += new System.EventHandler(this.slkKhoHang_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaKho,
            this.TenKho});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // MaKho
            // 
            this.MaKho.Caption = "Mã Kho";
            this.MaKho.FieldName = "MaKho";
            this.MaKho.Name = "MaKho";
            this.MaKho.Visible = true;
            this.MaKho.VisibleIndex = 0;
            // 
            // TenKho
            // 
            this.TenKho.Caption = "Tên Kho";
            this.TenKho.FieldName = "TenKho";
            this.TenKho.Name = "TenKho";
            this.TenKho.Visible = true;
            this.TenKho.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(870, 117);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 76);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(693, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(693, 76);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.slkKhoHang;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(334, 26);
            this.layoutControlItem1.Text = "Kho hàng";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnTonKho;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(334, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnNhaphang;
            this.layoutControlItem3.Location = new System.Drawing.Point(334, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(335, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.spSoLuong;
            this.layoutControlItem6.Location = new System.Drawing.Point(503, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(166, 26);
            this.layoutControlItem6.Text = "Số lượng";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnTatCa;
            this.layoutControlItem5.Location = new System.Drawing.Point(334, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(169, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(693, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(157, 97);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnBaoCao;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(113, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(133, 73);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmThongKeTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 513);
            this.Controls.Add(this.gcTonKho);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmThongKeTonKho";
            this.Text = "Thống kê tồn kho";
            this.Load += new System.EventHandler(this.frmThongKeTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkKhoHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraGrid.GridControl gcTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTonKho;
        private DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView noDocumentsView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnBaoCao;
        private DevExpress.XtraEditors.SimpleButton btnNhaphang;
        private DevExpress.XtraEditors.SimpleButton btnTonKho;
        private DevExpress.XtraEditors.SearchLookUpEdit slkKhoHang;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.SimpleButton btnTatCa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn MaKho;
        private DevExpress.XtraGrid.Columns.GridColumn TenKho;
        private DevExpress.XtraGrid.Columns.GridColumn MACTSP;
        private DevExpress.XtraGrid.Columns.GridColumn TenSP;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn GiaNhap;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn NSX;
        private DevExpress.XtraGrid.Columns.GridColumn HSD;
        private DevExpress.XtraGrid.Columns.GridColumn NgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn MaPN;
        private DevExpress.XtraEditors.SpinEdit spSoLuong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhogb;
    }
}