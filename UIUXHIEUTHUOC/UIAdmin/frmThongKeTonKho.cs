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
    public partial class frmThongKeTonKho : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeTonKho()
        {
            InitializeComponent();
        }
        KhoBLL _kho;
        bool _tonKho;
        ChiTietPhieuNhapBLL _ctPhieuNhap;
        List<ChiTietPhieuNhapDTO> _datagv;

        private void frmThongKeTonKho_Load(object sender, EventArgs e)
        {
            _kho = new KhoBLL();
            _ctPhieuNhap = new ChiTietPhieuNhapBLL();
            
            LoadSLkData();
            LoadData();
            _tonKho = true;
        }

        void LoadSLkData()
        {
            var lst = _kho.GetLists();
            slkKhoHang.Properties.DataSource = lst;
            slkKhoHang.Properties.DisplayMember = "TenKho";
            slkKhoHang.Properties.ValueMember = "MaKho";
            slkKhoHang.EditValue = lst.First().MaKho; 
        }
        void LoadData()
        {
            if(_tonKho)
            {
                gcTonKho.DataSource = _datagv = _ctPhieuNhap.GetListDTOs();
                gvTonKho.OptionsBehavior.Editable = false;
            }else
            {
                gcTonKho.DataSource = _datagv = _ctPhieuNhap.GetListDTONhap(Convert.ToInt32(spSoLuong.Value));
                gvTonKho.OptionsBehavior.Editable = false;
            }    

        }
        private void btnTonKho_Click(object sender, EventArgs e)
        {
            _tonKho = true;
            LoadData();
        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {
            _tonKho = false;
            LoadData();
        }

        private void slkKhoHang_EditValueChanged(object sender, EventArgs e)
        {
            if (_tonKho)
            {
                _datagv = _ctPhieuNhap.GetListDTObyKho(slkKhoHang.EditValue.ToString());
                gcTonKho.DataSource = _datagv;

            }else
            {
                _datagv = _ctPhieuNhap.GetListDTONhap(Convert.ToInt32(spSoLuong.Value),slkKhoHang.EditValue.ToString());
                gcTonKho.DataSource = _datagv;
            }    

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
          
            _datagv = _ctPhieuNhap.GetListDTOs();
            gcTonKho.DataSource = _datagv;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            rptThongKeTonKho rpt = new rptThongKeTonKho();
            rpt.DataSource = _datagv;
            rpt.ngay = $"Ngày lập {DateTime.Now.ToString("dd/mm/yyyy")}";
            if(_tonKho)
            {
                rpt.header = "BÁO CÁO DANH SÁCH SẢN PHẨM TỒN KHO";
            }
            else
            {
                rpt.header = "BÁO CÁO DANH SÁCH SẢN PHẨM CẦN NHẬP";
            }
            rpt.LoadData();
            rpt.ShowRibbonPreviewDialog();
        }
    }
}