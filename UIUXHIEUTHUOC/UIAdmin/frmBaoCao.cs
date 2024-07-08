using BLL;
using DAL.DTO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUXHIEUTHUOC.UIAdmin
{
    public partial class frmBaoCao : DevExpress.XtraEditors.XtraForm
    {
        HoaDonBLL _hoaDon;
        CTHoaDonBLL _ctHoaDon;
        DuocSiBLL _duocSiBLL;
        List<BaoCaoCTHoaDonDTO> _dataBaoCao;
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            _hoaDon = new HoaDonBLL();
            _ctHoaDon = new CTHoaDonBLL();
            _duocSiBLL = new DuocSiBLL();
            dateBatDau.DateTime = dateKetThuc.DateTime = DateTime.Now;
            //LoadData();
            LoadSLKdata();
        }

        void LoadData(List<BaoCaoCTHoaDonDTO> _dataBaoCao)
        {
            gcBaoCao.DataSource = _dataBaoCao;
            gvBaoCao.OptionsBehavior.Editable = false;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            _dataBaoCao = _ctHoaDon.GetListDTOsWithDay(dateBatDau.DateTime, dateKetThuc.DateTime, int.Parse(slkNhanVien.EditValue.ToString()));
            lbTongTien.Text = _ctHoaDon.GetTongTien(dateBatDau.DateTime, dateKetThuc.DateTime, int.Parse(slkNhanVien.EditValue.ToString())).ToString("#,##0") + "VNĐ";
            lbSoLuong.Text = _ctHoaDon.GetSoLuongDon(dateBatDau.DateTime, dateKetThuc.DateTime, int.Parse(slkNhanVien.EditValue.ToString())).ToString();
            LoadData(_dataBaoCao);
        }

        private void btnBaoCaoSanPham_Click(object sender, EventArgs e)
        {
            _dataBaoCao = _ctHoaDon.GetListDTOsWithDay(dateBatDau.DateTime, dateKetThuc.DateTime);
            LoadData(_dataBaoCao);
            lbTongTien.Text = _ctHoaDon.GetTongTien(dateBatDau.DateTime, dateKetThuc.DateTime).ToString("#,##0") + "VNĐ";
            lbSoLuong.Text = _ctHoaDon.GetSoLuongDon(dateBatDau.DateTime, dateKetThuc.DateTime).ToString();
        }
        void LoadSLKdata()
        {
            var lst2 = _duocSiBLL.GetLists();
            slkNhanVien.Properties.DataSource = lst2;
            slkNhanVien.Properties.DisplayMember = "TenDuocSi";
            slkNhanVien.Properties.ValueMember = "MaDuocSi";
            slkNhanVien.EditValue = lst2.First().MaDuocSi;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            rptBaoCao rpt = new rptBaoCao();
            rpt.DataSource = _dataBaoCao;
            rpt._NgayBatDau = dateBatDau.DateTime;
            rpt._NgayKetThuc = dateKetThuc.DateTime;
            rpt._SoLuong = lbSoLuong.Text;
            rpt._TongTien = lbTongTien.Text;
            rpt.loaData();
            rpt.ShowRibbonPreviewDialog();
        }
    }
}