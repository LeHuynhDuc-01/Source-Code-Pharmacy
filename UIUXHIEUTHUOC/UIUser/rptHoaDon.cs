namespace UIUXHIEUTHUOC
{
    public class rptHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell10;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRControlStyle ReportHeaderBandStyle;
        private DevExpress.XtraReports.UI.XRControlStyle ReportGroupHeaderBandStyle;
        private DevExpress.XtraReports.UI.XRControlStyle ReportDetailBandStyle;
        private DevExpress.XtraReports.UI.XRControlStyle ReportGroupFooterBandStyle;
        private DevExpress.XtraReports.UI.XRControlStyle ReportFooterBandStyle;
        private DevExpress.XtraReports.UI.XRControlStyle ReportOddStyle;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lbDuocSi;
        private DevExpress.XtraReports.UI.XRLabel lbKH;
        private DevExpress.XtraReports.UI.XRLabel lbTongSoluong;
        private DevExpress.XtraReports.UI.XRLabel lbTongTien;
        private DevExpress.XtraReports.UI.XRLabel lbNgaylap;
        private DevExpress.XtraReports.UI.XRControlStyle ReportEvenStyle;

        public string _SoLuong;
        public string _TongTien;
        public string _DuocSi;
        public string _KhachHang;
        public string _ngayLap;


        public rptHoaDon()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            this.lbNgaylap.Text = $"Ngày lập: {_ngayLap}";
            this.lbTongSoluong.Text = $"Tổng số lượng: {_SoLuong}";
            this.lbTongTien.Text = $"Tổng tiền: {_TongTien}";
            this.lbDuocSi.Text = $"Dược Sĩ: {_DuocSi}";
            this.lbKH.Text = $"Khách hàng: {_KhachHang}";
        }
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeaderBandStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportGroupHeaderBandStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportDetailBandStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportGroupFooterBandStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportFooterBandStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportOddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportEvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbNgaylap = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDuocSi = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKH = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbTongSoluong = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTongTien = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.Name = "TopMargin";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.HeightF = 63.5F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StyleName = "ReportHeaderBandStyle";
            // 
            // table1
            // 
            this.table1.Dpi = 254F;
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(126.4708F, 0F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(1320.8F, 63.5F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell2,
            this.tableCell3,
            this.tableCell4,
            this.tableCell5});
            this.tableRow1.Dpi = 254F;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 11.499995494453673D;
            // 
            // tableCell2
            // 
            this.tableCell2.Dpi = 254F;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "ReportHeaderBandStyle";
            this.tableCell2.Text = "Tên sản phẩm";
            this.tableCell2.Weight = 0.50800000473198059D;
            // 
            // tableCell3
            // 
            this.tableCell3.Dpi = 254F;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StyleName = "ReportHeaderBandStyle";
            this.tableCell3.Text = "Giá";
            this.tableCell3.Weight = 0.50800000473198059D;
            // 
            // tableCell4
            // 
            this.tableCell4.Dpi = 254F;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StyleName = "ReportHeaderBandStyle";
            this.tableCell4.Text = "Số lượng";
            this.tableCell4.Weight = 0.50800000473198059D;
            // 
            // tableCell5
            // 
            this.tableCell5.Dpi = 254F;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.StyleName = "ReportHeaderBandStyle";
            this.tableCell5.Text = "Đơn giá";
            this.tableCell5.Weight = 0.50800000473198059D;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.Detail.Dpi = 254F;
            this.Detail.EvenStyleName = "ReportEvenStyle";
            this.Detail.HeightF = 63.5F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "ReportOddStyle";
            this.Detail.StyleName = "ReportDetailBandStyle";
            // 
            // table2
            // 
            this.table2.Dpi = 254F;
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(126.4708F, 0F);
            this.table2.Name = "table2";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            this.table2.SizeF = new System.Drawing.SizeF(1320.8F, 63.5F);
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell7,
            this.tableCell8,
            this.tableCell9,
            this.tableCell10});
            this.tableRow2.Dpi = 254F;
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 11.499995494453673D;
            // 
            // tableCell7
            // 
            this.tableCell7.Dpi = 254F;
            this.tableCell7.EvenStyleName = "ReportEvenStyle";
            this.tableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TenSP]")});
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.OddStyleName = "ReportOddStyle";
            this.tableCell7.StyleName = "ReportDetailBandStyle";
            this.tableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell7.Weight = 0.50800000473198059D;
            this.tableCell7.WordWrap = false;
            // 
            // tableCell8
            // 
            this.tableCell8.Dpi = 254F;
            this.tableCell8.EvenStyleName = "ReportEvenStyle";
            this.tableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GiaBan]")});
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.OddStyleName = "ReportOddStyle";
            this.tableCell8.StyleName = "ReportDetailBandStyle";
            this.tableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell8.Weight = 0.50800000473198059D;
            this.tableCell8.WordWrap = false;
            // 
            // tableCell9
            // 
            this.tableCell9.Dpi = 254F;
            this.tableCell9.EvenStyleName = "ReportEvenStyle";
            this.tableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SoLuong]")});
            this.tableCell9.Name = "tableCell9";
            this.tableCell9.OddStyleName = "ReportOddStyle";
            this.tableCell9.StyleName = "ReportDetailBandStyle";
            this.tableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell9.Weight = 0.50800000473198059D;
            this.tableCell9.WordWrap = false;
            // 
            // tableCell10
            // 
            this.tableCell10.Dpi = 254F;
            this.tableCell10.EvenStyleName = "ReportEvenStyle";
            this.tableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DonGia]")});
            this.tableCell10.Name = "tableCell10";
            this.tableCell10.OddStyleName = "ReportOddStyle";
            this.tableCell10.StyleName = "ReportDetailBandStyle";
            this.tableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell10.Weight = 0.50800000473198059D;
            this.tableCell10.WordWrap = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 777.875F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeaderBandStyle
            // 
            this.ReportHeaderBandStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.ReportHeaderBandStyle.Name = "ReportHeaderBandStyle";
            this.ReportHeaderBandStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportHeaderBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportGroupHeaderBandStyle
            // 
            this.ReportGroupHeaderBandStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.ReportGroupHeaderBandStyle.Name = "ReportGroupHeaderBandStyle";
            this.ReportGroupHeaderBandStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 254F);
            this.ReportGroupHeaderBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportDetailBandStyle
            // 
            this.ReportDetailBandStyle.Name = "ReportDetailBandStyle";
            this.ReportDetailBandStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportDetailBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportGroupFooterBandStyle
            // 
            this.ReportGroupFooterBandStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.ReportGroupFooterBandStyle.Name = "ReportGroupFooterBandStyle";
            this.ReportGroupFooterBandStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportGroupFooterBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooterBandStyle
            // 
            this.ReportFooterBandStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.ReportFooterBandStyle.Name = "ReportFooterBandStyle";
            this.ReportFooterBandStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportFooterBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportOddStyle
            // 
            this.ReportOddStyle.Name = "ReportOddStyle";
            this.ReportOddStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportOddStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportEvenStyle
            // 
            this.ReportEvenStyle.Name = "ReportEvenStyle";
            this.ReportEvenStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.ReportEvenStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNgaylap,
            this.lbDuocSi,
            this.lbKH,
            this.xrLabel1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 254F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbNgaylap
            // 
            this.lbNgaylap.Dpi = 254F;
            this.lbNgaylap.Font = new DevExpress.Drawing.DXFont("Times New Roman", 12F);
            this.lbNgaylap.LocationFloat = new DevExpress.Utils.PointFloat(814.2292F, 96.28502F);
            this.lbNgaylap.Multiline = true;
            this.lbNgaylap.Name = "lbNgaylap";
            this.lbNgaylap.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbNgaylap.SizeF = new System.Drawing.SizeF(633.0417F, 58.42F);
            this.lbNgaylap.StylePriority.UseFont = false;
            // 
            // lbDuocSi
            // 
            this.lbDuocSi.Dpi = 254F;
            this.lbDuocSi.Font = new DevExpress.Drawing.DXFont("Times New Roman", 12F);
            this.lbDuocSi.LocationFloat = new DevExpress.Utils.PointFloat(126.4708F, 96.28502F);
            this.lbDuocSi.Multiline = true;
            this.lbDuocSi.Name = "lbDuocSi";
            this.lbDuocSi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbDuocSi.SizeF = new System.Drawing.SizeF(669.925F, 58.42F);
            this.lbDuocSi.StylePriority.UseFont = false;
            // 
            // lbKH
            // 
            this.lbKH.Dpi = 254F;
            this.lbKH.Font = new DevExpress.Drawing.DXFont("Times New Roman", 12F);
            this.lbKH.LocationFloat = new DevExpress.Utils.PointFloat(126.4708F, 170.58F);
            this.lbKH.Multiline = true;
            this.lbKH.Name = "lbKH";
            this.lbKH.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbKH.SizeF = new System.Drawing.SizeF(669.925F, 58.41998F);
            this.lbKH.StylePriority.UseFont = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 22F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(620.1829F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(296.3338F, 95.46167F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Hóa Đơn";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTongSoluong,
            this.lbTongTien});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 254F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbTongSoluong
            // 
            this.lbTongSoluong.Dpi = 254F;
            this.lbTongSoluong.Font = new DevExpress.Drawing.DXFont("Times New Roman", 14F);
            this.lbTongSoluong.LocationFloat = new DevExpress.Utils.PointFloat(126.4708F, 46.22578F);
            this.lbTongSoluong.Multiline = true;
            this.lbTongSoluong.Name = "lbTongSoluong";
            this.lbTongSoluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbTongSoluong.SizeF = new System.Drawing.SizeF(515.9375F, 58.42F);
            this.lbTongSoluong.StylePriority.UseFont = false;
            // 
            // lbTongTien
            // 
            this.lbTongTien.Dpi = 254F;
            this.lbTongTien.Font = new DevExpress.Drawing.DXFont("Times New Roman", 14F);
            this.lbTongTien.LocationFloat = new DevExpress.Utils.PointFloat(870.4792F, 46.22578F);
            this.lbTongTien.Multiline = true;
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbTongTien.SizeF = new System.Drawing.SizeF(576.7916F, 58.42F);
            this.lbTongTien.StylePriority.UseFont = false;
            // 
            // rptHoaDon
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.PageHeader,
            this.Detail,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.Dpi = 254F;
            this.Margins = new DevExpress.Drawing.DXMargins(108F, 34F, 100F, 777.875F);
            this.PageHeight = 2794;
            this.PageWidth = 1744;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.ReportHeaderBandStyle,
            this.ReportGroupHeaderBandStyle,
            this.ReportDetailBandStyle,
            this.ReportGroupFooterBandStyle,
            this.ReportFooterBandStyle,
            this.ReportOddStyle,
            this.ReportEvenStyle});
            this.Version = "22.2";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}