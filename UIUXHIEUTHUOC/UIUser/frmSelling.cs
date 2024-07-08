using BLL;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace UIUXHIEUTHUOC.UIUser
{
    public partial class frmSelling : DevExpress.XtraEditors.XtraForm
    {
        public frmSelling()
        {
            InitializeComponent();
            spSoLuong.Value = 1;

        }
        bool _lapHoaDon;
        ChiTietHangHoaBLL _chiTietHangHoa;
        KhachHangBLL _khachHangBLL;
        CTHoaDonBLL _chiTHoaDonBLL;
        public  int _maDuocSi;
        HoaDonBLL _hoaDon;
        string _maHD;
        string _maCTSP;
        int _soLuong = 2;
        bool _them;
        private void frmSelling_Load(object sender, EventArgs e)
        {
            //_maDuocSi = _maDuocSiMain;
            _maDuocSi = AccountManager.Instance.GetID();
            this.Text = $"Bán hàng Nhân {AccountManager.Instance.GetFullName()} - {AccountManager.Instance.GetID()}";
            _chiTietHangHoa = new ChiTietHangHoaBLL();
            _khachHangBLL = new KhachHangBLL();
            _hoaDon = new HoaDonBLL();
            _chiTHoaDonBLL = new CTHoaDonBLL();
            _LoadSLK();
            LoadData();
            _lapHoaDon = false;
            dateNgayLap.DateTime = DateTime.Now;
            _ShowHide(true);
            _them = false;
            lbTongTien.Text = "0VNĐ";
            lbDuocSi.Text = $"Dược Sĩ: {AccountManager.Instance.GetFullName()}";
        }

        void _ShowHide(bool kt)
        {
            groupCongCu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            barCodeSP.Enabled = !kt;
            btnLapHD.Enabled = kt;
        }
        void _LoadSLK()
        {
            var lstKH = _khachHangBLL.GetLists();
            if (lstKH != null)
            {
                slkKhachHang.Properties.DataSource = lstKH;
                slkKhachHang.Properties.DisplayMember = "TenKH";
                slkKhachHang.Properties.ValueMember = "MaKH";
                slkKhachHang.EditValue = lstKH.First().MaKH;
                lbsdt.Text = $"Số điện thoại: {lstKH.First().SDT}";
            }

        }
        void _LoadHoaDon()
        {
            gcHoaDon.DataSource = _chiTHoaDonBLL.GetListDTOs(_maHD);
            gvHoaDon.OptionsBehavior.Editable = false;
            lbTongTien.Text = FormatCurrency(_chiTHoaDonBLL.GetTotalPriceByMaHD(_maHD));
        }
        static string FormatCurrency(double amount)
        {
            return string.Format("{0:N0}VND", amount);
        }
        void LoadData()
        {
            gcSanPham.DataSource = _chiTietHangHoa.GetListDTOs();
            gvSanPham.OptionsBehavior.Editable = false;
        }

        private void slkKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            var item = _khachHangBLL.GetItem(  int.Parse(slkKhachHang.EditValue.ToString() ));
            lbsdt.Text = $"Số điện thoại: {item.SDT}";
            txtHoTen.Text = item.TenKH;
            txtDiaChi.Text = item.DiaChi;
            txtSDT.Text = item.SDT;
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            _ShowHide(false);
            _lapHoaDon = true;
            _LapHoaDon();
        }
        void _LapHoaDon()
        {
           
                if(_lapHoaDon)
                {
                    tbl_HOADON dt = new tbl_HOADON();
                    _maHD = dt.MaHD = _hoaDon.MaHD();
                    dt.NgayLap = dateNgayLap.DateTime;
                    dt.MaDuocSi = _maDuocSi;
                    dt.MaKH = int.Parse(slkKhachHang.EditValue.ToString());
                    dt.Nam = dateNgayLap.DateTime.Year;
                    dt.Thang = dateNgayLap.DateTime.Month;
                    dt.TongTien = 0;
                    _hoaDon.AddItem(dt);
                    dockHoDon.Text = $"Hóa Đơn - {_maHD}";
                }else
                {
                    _hoaDon.DeleteHoaDonAndCTHD(_maHD);
                    lbTongTien.Text = "0VNĐ";
                    dockHoDon.Text = $"Hóa Đơn";
                    _maHD = null;
                gcHoaDon.DataSource = null;
                gvHoaDon.GridControl.RefreshDataSource();
            }


        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            _ShowHide(true);
            _lapHoaDon = false;
            _LapHoaDon();
            LoadData();
        }

        private void gcSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvSanPham.FocusedRowHandle;
                // Kiểm tra nếu dòng đang được nhóm
                if (gvSanPham.IsGroupRow(focusedRowHandle))
                {
                    // Nếu dòng là dòng nhóm, lấy dữ liệu của dòng con đầu tiên
                    DataRow row = gvSanPham.GetDataRow(gvSanPham.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _maCTSP = row["MACTSP"].ToString();
                        _soLuong = int.Parse(row["SoLuong"].ToString());
                        mkMaSP.Text = _maCTSP;
                    }
                }
                else
                {
                    if (gvSanPham.RowCount > 0)
                    {
                        _maCTSP = gvSanPham.GetFocusedRowCellValue("MACTSP").ToString();
                        _soLuong = int.Parse( gvSanPham.GetFocusedRowCellValue("SoLuong").ToString());
                        mkMaSP.Text = _maCTSP;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void spSoLuong_EditValueChanged(object sender, EventArgs e)
        {
           int sl = int.Parse(spSoLuong.Value.ToString());
            if(sl <= 0 || sl > _soLuong )
            {
                dxErrorProvider1.SetError(spSoLuong, $"Số lượng không được <=0 và lớn hơn {_soLuong}");
                MessageBox.Show($"Số lượng không được <=0 và lớn hơn {_soLuong}");
            }    
        }
        void _SaveDataHoaDon()
        {
            try
            {
                _maCTSP = mkMaSP.Text;
                if (_maCTSP != null && _maHD != null)
                {
                    if (_them)
                    {
                        tbl_CTHOADON dt = new tbl_CTHOADON();
                        dt.MaCTHD = _maHD + _maCTSP;
                        dt.MaCTSP = _maCTSP;
                        dt.MaHD = _maHD;
                        dt.SoLuong = int.Parse(spSoLuong.Value.ToString());
                        _chiTHoaDonBLL.AddItem(dt);
                    }
                    else
                    {
                        tbl_CTHOADON dt = new tbl_CTHOADON();
                        dt.MaCTHD = _maHD + _maCTSP;
                        dt.MaCTSP = _maCTSP;
                        dt.MaHD = _maHD;
                        dt.SoLuong = int.Parse(spSoLuong.Value.ToString());
                        _chiTHoaDonBLL.UpdateItem(dt);
                    }
                }
            }
            catch (Exception ex){ MessageBox.Show("Error :" + ex.Message); }
          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            _SaveDataHoaDon();
            _LoadHoaDon();
            LoadData();
            _them = false;

        }

        private void btnLua_Click(object sender, EventArgs e)
        {
            _them = false;
            _SaveDataHoaDon();
            LoadData();
            _LoadHoaDon();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {_maCTSP} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _chiTHoaDonBLL.DeleteItemWithMaCTSP(_maCTSP);
                MessageBox.Show($"Đã xóa sản phẩm {_maCTSP}");
                _LoadHoaDon();
                LoadData();
            }

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            rptHoaDon rpt = new rptHoaDon();
            var lst = _chiTHoaDonBLL.GetListDTOs(_maHD);
            rpt.DataSource = lst;
            rpt._SoLuong = lst.Count.ToString();
            rpt._ngayLap = dateNgayLap.DateTime.ToString();
            rpt._TongTien = lbTongTien.Text;
            rpt._KhachHang = slkKhachHang.Text;
            rpt._DuocSi = AccountManager.Instance.GetFullName();
            rpt.LoadData();
            rpt.ShowPreview();
        }

        private void gcHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvHoaDon.FocusedRowHandle;
                // Kiểm tra nếu dòng đang được nhóm
                if (gvHoaDon.IsGroupRow(focusedRowHandle))
                {
                    // Nếu dòng là dòng nhóm, lấy dữ liệu của dòng con đầu tiên
                    DataRow row = gvHoaDon.GetDataRow(gvHoaDon.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _maCTSP = row["MaCTSP"].ToString();
                        mkMaSP.Text = _maCTSP;
                    }
                }
                else
                {
                    if (gvHoaDon.RowCount > 0)
                    {
                        _maCTSP = gvHoaDon.GetFocusedRowCellValue("MaCTSP").ToString();
                        mkMaSP.Text = _maCTSP;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            _SaveDataKhachHang(true);

        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            _SaveDataKhachHang(false);
        }
        private void _SaveDataKhachHang(bool kt)
        {
            try
            {
                if (kt)
                {
                    string ten = txtHoTen.Text;
                    if (ten != null)
                    {
                        tbl_KHACHHANG dt = new tbl_KHACHHANG();
                        dt.DiaChi = txtDiaChi.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenKH = txtHoTen.Text;
                        _khachHangBLL.AddItem(dt);
                    }
                }
                else
                {
                    string ten = txtHoTen.Text;
                    if (slkKhachHang.EditValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (ten != null)
                    {
                        tbl_KHACHHANG dt = new tbl_KHACHHANG();
                        dt.MaKH = int.Parse(slkKhachHang.EditValue.ToString());
                        dt.DiaChi = txtDiaChi.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenKH = txtHoTen.Text;
                        _khachHangBLL.UpdateItem(dt);
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
                _LoadSLK();
                _ShowHide(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (slkKhachHang.EditValue == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _khachHangBLL.DeleteItem(int.Parse(slkKhachHang.EditValue.ToString()));
                    _LoadSLK();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _maHD = null;
            gcHoaDon.DataSource = null;
            lbTongTien.Text = "0 VND";
            dockHoDon.Text = "Hóa Đơn";
        }
    }
}