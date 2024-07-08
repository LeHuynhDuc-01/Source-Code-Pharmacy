using BLL;
using DAL;
using DevExpress.XtraEditors;
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
    public partial class frmChiTietSanPham : DevExpress.XtraEditors.XtraForm
    {
        ChiTietHangHoaBLL _chiTietHangHoa;
        ChiTietPhieuNhapBLL _chiTietPhieuNhap;
        public frmChiTietSanPham()
        {
            InitializeComponent();
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            _chiTietHangHoa = new ChiTietHangHoaBLL();
            _chiTietPhieuNhap = new ChiTietPhieuNhapBLL();
            LoadData();

        }
        void LoadData()
        {
            gcChiTietSanPham.DataSource = _chiTietPhieuNhap.GetListDTOs();
            gvChiTietSanPham.OptionsBehavior.Editable = false;

        }
    }
}