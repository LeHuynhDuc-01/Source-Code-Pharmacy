using BLL;
using DAL;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
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
    public partial class frmChiTietPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        frmNhapHang _frmNhapHang;
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public string _maPN;
        public string _maKho;
        bool _them;
        ChiTietPhieuNhapBLL _ctPhieuNhap;
        PhieuNhapBLL _phieuNhap;
        ChiTietHangHoaBLL _chiTietHangHoa;
        SanPhamBLL _sanPham;
        string _maCTPN;
        string _maCTSP;
        public void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Chi Tiết Phiếu Nhập - " + _maPN + " - " + _maKho;
                dockPanel1.Text = $"Phiếu Nhập - {_maPN} - Kho: {_maKho}";
                _ctPhieuNhap = new ChiTietPhieuNhapBLL();
                _chiTietHangHoa = new ChiTietHangHoaBLL();
                _sanPham = new SanPhamBLL();
                lbTongTien.Text = "Tổng Tiền: 0VNĐ";
                _phieuNhap = new PhieuNhapBLL();
                _LoadSKL();
                _them = false;
                _ShowHide(true);
                _LoadData();
                _frmNhapHang = (frmNhapHang)Application.OpenForms["frmNhapHang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _LoadSKL()
        {
            var lst = _sanPham.GetLists();
            slkSanPham.Properties.DataSource = lst;
            slkSanPham.Properties.DisplayMember = "TenSP";
            slkSanPham.Properties.ValueMember = "MaSP";
            var item = lst.First();
            slkSanPham.EditValue = item.MaSP;
            spGiaNhap.Value = Convert.ToDecimal(item.Gia);
            _CalGiaBan();
        }
        private void _LoadData()
        {
            try
            {
                gcChiTietPhieuNhap.DataSource = _ctPhieuNhap.GetListDTObyPhieuNhap(_maPN);
                gvChiTietPhieuNhap.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void _ShowHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            slkSanPham.Enabled = !kt;
            spGiaBan.Enabled = !kt;
            spGiaNhap.Enabled = !kt;
            spHSD.Enabled = !kt;
            spSoLuong.Enabled = !kt;
            dateNgayNhap.Enabled = !kt;
            dateNgaySanXuat.Enabled = !kt;
            spHeSo.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
        }

        private void _SaveData()
        {
            try
            {
                if (_them)
                {
                    tbl_CHITIETHANGHOA itemSP = new tbl_CHITIETHANGHOA();
                    int masp = int.Parse(slkSanPham.EditValue.ToString());
                     _maCTSP = itemSP.MACTSP = _chiTietHangHoa.MaCTHangHoa(masp);
                    itemSP.MASP = masp;
                    itemSP.MaKho = _maKho;
                    itemSP.GiaNhap = float.Parse( spGiaNhap.Value.ToString());
                    itemSP.GiaBan = float.Parse(spGiaBan.Value.ToString());
                    itemSP.HSD = float.Parse(spHSD.Value.ToString());
                    itemSP.NSX = dateNgaySanXuat.DateTime;
                    itemSP.SoLuong = int.Parse(spSoLuong.Value.ToString());
                    _chiTietHangHoa.AddItem(itemSP);

                    tbl_CTPHIEUNHAP itemCTPN = new tbl_CTPHIEUNHAP();
                    itemCTPN.MaCTPN = _maPN + _maCTSP;
                    itemCTPN.MACTSP = _maCTSP;
                    itemCTPN.MaPN = _maPN;
                    itemCTPN.NgayNhap =dateNgayNhap.DateTime;
                    itemCTPN.TongTien = double.Parse(spGiaNhap.Value.ToString()) * double.Parse(spSoLuong.Value.ToString());
                    _ctPhieuNhap.AddItem(itemCTPN);
                }
                else
                {
                    if (_maCTPN == null && _maCTSP != null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (_maCTPN != null && _maCTSP != null)
                    {
                        tbl_CHITIETHANGHOA itemSP = new tbl_CHITIETHANGHOA();
                        int masp = int.Parse(slkSanPham.EditValue.ToString());
                        itemSP.MACTSP = _maCTSP;
                        itemSP.MASP = masp;
                        itemSP.MaKho = _maKho;
                        itemSP.GiaNhap = float.Parse(spGiaNhap.Value.ToString());
                        itemSP.GiaBan = float.Parse(spGiaBan.Value.ToString());
                        itemSP.HSD = float.Parse(spHSD.Value.ToString());
                        itemSP.NSX = dateNgaySanXuat.DateTime;
                        itemSP.SoLuong = int.Parse(spSoLuong.Value.ToString());
                        _chiTietHangHoa.UpdateItem(itemSP);

                        tbl_CTPHIEUNHAP itemCTPN = new tbl_CTPHIEUNHAP();
                        itemCTPN.MaCTPN = _maCTPN;
                        itemCTPN.MACTSP = _maCTSP;
                        itemCTPN.MaPN = _maPN;
                        itemCTPN.NgayNhap = dateNgayNhap.DateTime;
                        itemCTPN.TongTien = double.Parse(spGiaNhap.Value.ToString()) * double.Parse(spSoLuong.Value.ToString());
                        _ctPhieuNhap.UpdateItem(itemCTPN);
                        MessageBox.Show("Sửa thành công");

                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        void _ClearInput()
        {
            _LoadSKL();
            spHSD.Value = 12;
            dateNgayNhap.DateTime = DateTime.Now;
            dateNgaySanXuat.DateTime = DateTime.Now;
            _CalGiaBan();

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ClearInput();
            _them = true;
            dateNgayNhap.Focus();
            _ShowHide(false);
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _ShowHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_maCTPN == null && _maCTSP == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần Xóa");
                }
                else
                {
                    _ctPhieuNhap.DeleteItem(_maCTPN);
                    _chiTietHangHoa.DeleteItem(_maCTSP);
                    _LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _SaveData();
            _them = false;
            _LoadData();
            _ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _ShowHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gcChiTietPhieuNhap_Click(object sender, EventArgs e)
        {

            try
            {
                int focusedRowHandle = gvChiTietPhieuNhap.FocusedRowHandle;
                // Kiểm tra nếu dòng đang được nhóm
                if (gvChiTietPhieuNhap.IsGroupRow(focusedRowHandle))
                {
                    // Nếu dòng là dòng nhóm, lấy dữ liệu của dòng con đầu tiên
                    DataRow row = gvChiTietPhieuNhap.GetDataRow(gvChiTietPhieuNhap.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _maCTPN = row["MaCTPN"].ToString();
                        var item = _ctPhieuNhap.GetItemDTO(_maCTPN);
                        spGiaBan.Text = item.GiaBan.ToString();
                        spGiaNhap.Text = item.GiaNhap.ToString();
                        spHSD.Text = item.SoLuong.ToString()    ;
                        spSoLuong.Text = item.SoLuong.ToString();
                        slkSanPham.EditValue = item.MaSP;
                        dateNgayNhap.DateTime = item.NgayNhap;
                        dateNgaySanXuat.DateTime = item.NSX.Value;
                        _maCTSP = item.MACTSP;
                        _maCTPN = item.MaCTPN;

                    }
                }
                else
                {
                    if (gvChiTietPhieuNhap.RowCount > 0)
                    {
                        _maCTPN = gvChiTietPhieuNhap.GetFocusedRowCellValue("MaCTPN").ToString();
                        var item = _ctPhieuNhap.GetItemDTO(_maCTPN);
                        spGiaBan.Text = item.GiaBan.ToString();
                        spGiaNhap.Text = item.GiaNhap.ToString();
                        spHSD.Text = item.SoLuong.ToString();
                        spSoLuong.Text = item.SoLuong.ToString();
                        slkSanPham.EditValue = item.MaSP;
                        dateNgayNhap.DateTime = item.NgayNhap;
                        dateNgaySanXuat.DateTime = item.NSX.Value;
                        _maCTSP = item.MACTSP;
                        _maCTPN = item.MaCTPN;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void slkSanPham_EditValueChanged(object sender, EventArgs e)
        {
            var item = _sanPham.GetItem(int.Parse(slkSanPham.EditValue.ToString()));
            if (item != null)
            {
                spGiaNhap.Value = Convert.ToDecimal(item.Gia);
                _CalGiaBan();
            }
        }

        private  void _CalGiaBan() {
            if (spGiaNhap.Value != null && spHeSo.Value!= null)
            {
                spGiaBan.Value = spGiaNhap.Value * spHeSo.Value;
            }
        }
        private void spHeSo_EditValueChanged(object sender, EventArgs e)
        {
            _CalGiaBan();
        }
        private void TongTien()
        {
            float temp = float.Parse(spGiaNhap.Value.ToString()) * float.Parse(spSoLuong.Value.ToString());
            lbTongTien.Text = $"Tổng Tiền: {temp}VNĐ";
        }
        private void spSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            TongTien();
        }

        private void frmChiTietPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            _phieuNhap.TongTienNhap(_maPN);
            _frmNhapHang._PreLoadData();
        }
    }
}