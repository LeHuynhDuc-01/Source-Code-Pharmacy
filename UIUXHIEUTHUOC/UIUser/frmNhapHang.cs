using BLL;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUXHIEUTHUOC.UIUser
{
    public partial class frmNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
   
        bool _them;
        string _maPN;
        PhieuNhapBLL _phieuNhap;
        NhaCungCapBLL _nhaCungCap;
        public int _maDuocSi;
        KhoBLL _kho;
        DuocSiBLL _duocSi;
        string  _maKho;
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            try
            {

                 _phieuNhap = new PhieuNhapBLL();
                 _nhaCungCap = new NhaCungCapBLL();
                 _kho = new KhoBLL();
                _duocSi = new DuocSiBLL();
                _maKho = string.Empty;
                _maPN = string.Empty;
                _LoadSKL();
                _them = false;
                _ShowHide(true);
                _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _LoadSKL()
        {
            var lst = _nhaCungCap.GetLists();
            slkNhaCungCap.Properties.DataSource = lst;
            slkNhaCungCap.Properties.DisplayMember = "TenNCC";
            slkNhaCungCap.Properties.ValueMember = "MaNCC";
            slkNhaCungCap.EditValue = lst.First().MaNCC;

            var lst1 = _kho.GetLists();
            slkKhoHang.Properties.DataSource = lst1;
            slkKhoHang.Properties.DisplayMember = "TenKho";
            slkKhoHang.Properties.ValueMember = "MaKho";
            slkKhoHang.EditValue = lst1.First().MaKho;

            var lst2 = _duocSi.GetLists();
            slkDuocSi.Properties.DataSource = lst2;
            slkDuocSi.Properties.DisplayMember = "TenDuocSi";
            slkDuocSi.Properties.ValueMember = "MaDuocSi";
            slkDuocSi.EditValue = lst2.First().MaDuocSi;
        }
        public void _PreLoadData()
        {
            try
            {
                _phieuNhap = new PhieuNhapBLL();
                gcNhapHang.DataSource = _phieuNhap.GetLists();
                gvNhapHang.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void _LoadData()
        {
            try
            {
                gcNhapHang.DataSource = _phieuNhap.GetLists();
                gvNhapHang.OptionsBehavior.Editable = false;
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
            slkDuocSi.Enabled = !kt;
            slkNhaCungCap.Enabled = !kt;
            slkKhoHang.Enabled = !kt;
            spTongTien.Enabled = !kt;
            dateNgayNhap.Enabled = !kt;
            chkTrangThai.Enabled = !kt;
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
                    tbl_PHIEUNHAP dt = new tbl_PHIEUNHAP();
                    dt.MaPN = _phieuNhap.MaPhieuNhap();
                    dt.MaDuocSi = int.Parse(slkDuocSi.EditValue.ToString());
                    dt.MaKho = slkKhoHang.EditValue.ToString();
                    dt.MaNCC = int.Parse(slkNhaCungCap.EditValue.ToString());
                    dt.TongTien = 0;
                    dt.TrangThai = chkTrangThai.Checked;
                    dt.NgayNhapHang = dateNgayNhap.DateTime;
                    _phieuNhap.AddItem(dt);
                }
                else
                {
                    if (_maPN == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (_maPN != null)
                    {
                        tbl_PHIEUNHAP dt = new tbl_PHIEUNHAP();
                        dt.MaPN = _maPN;
                        dt.MaDuocSi = int.Parse(slkDuocSi.EditValue.ToString());
                        dt.MaKho = slkKhoHang.EditValue.ToString();
                        dt.MaNCC = int.Parse(slkNhaCungCap.EditValue.ToString());
                        dt.TongTien = 0;
                        dt.TrangThai = chkTrangThai.Checked;
                        dt.NgayNhapHang = dateNgayNhap.DateTime;
                        _phieuNhap.UpdateItem(dt);
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
            chkTrangThai.Checked = false;
            spTongTien.Value = 0;
            dateNgayNhap.DateTime = DateTime.Now;
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
                if (_maPN == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _phieuNhap.DeleteItem(_maPN);
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

        private void gcNhapHang_Click(object sender, EventArgs e)
        {

            try
            {
                int focusedRowHandle = gvNhapHang.FocusedRowHandle;

                // Kiểm tra nếu dòng đang được nhóm
                if (gvNhapHang.IsGroupRow(focusedRowHandle))
                {
                    // Nếu dòng là dòng nhóm, lấy dữ liệu của dòng con đầu tiên
                    DataRow row = gvNhapHang.GetDataRow(gvNhapHang.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _maPN = row["MaPN"].ToString();
                        var item = _phieuNhap.GetItem(_maPN);
                        slkDuocSi.EditValue = item.MaDuocSi;
                        slkKhoHang.EditValue = _maKho  = item.MaKho;
                        slkNhaCungCap.EditValue = item.MaNCC;
                        spTongTien.Text = item.TongTien.ToString();
                        chkTrangThai.Checked = item.TrangThai.Value;
                        dateNgayNhap.DateTime = item.NgayNhapHang.Value;
                    }
                }
                else
                {
                    if (gvNhapHang.RowCount > 0)
                    {
                        // Nếu dòng không phải là dòng nhóm, sử dụng thông tin như bình thường
                        _maPN = gvNhapHang.GetFocusedRowCellValue("MaPN").ToString();
                        var item = _phieuNhap.GetItem(_maPN);
                        slkDuocSi.EditValue = item.MaDuocSi;
                        slkKhoHang.EditValue = _maKho = item.MaKho;
                        slkNhaCungCap.EditValue = item.MaNCC;
                        spTongTien.Text = item.TongTien.ToString();
                        chkTrangThai.Checked = item.TrangThai.Value;
                        dateNgayNhap.DateTime = item.NgayNhapHang.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnChiTietPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_maKho != string.Empty && _maPN != string.Empty)
            {
                frmChiTietPhieuNhap frm = new frmChiTietPhieuNhap();
                frm._maKho = _maKho;
                frm._maPN = _maPN;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập!");
            }
        }

    }
}