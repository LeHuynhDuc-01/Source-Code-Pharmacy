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
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        bool _them;
        string _TaiKhoan;
        NguoiDungBLL _nguoiDung;
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {

                _nguoiDung = new NguoiDungBLL();
                _them = false;
                _ShowHide(true);
                _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _LoadData()
        {
            try
            {
                gcNguoiDung.DataSource = _nguoiDung.GetLists();
                gvNguoiDung.OptionsBehavior.Editable = false;
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
            txtTaiKhoan.Enabled = !kt;
            txtMatKhau.Enabled = !kt;
            chkQuanTri.Enabled = !kt;
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

                    string ten = txtTaiKhoan.Text;
                    string mk = txtMatKhau.Text;
                    if (ten != null && mk != null)
                    {
                        tbl_NGUOIDUNG dt = new tbl_NGUOIDUNG();
                        dt.TenDangNhap = ten;
                        dt.MatKhau = mk;
                        dt.QuanTri = chkQuanTri.Checked;
                        _nguoiDung.AddItem(dt);
                    }
                }
                else
                {
                    string ten = txtTaiKhoan.Text;
                    string mk = txtMatKhau.Text;
                    if (_TaiKhoan == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (ten != null && mk != null)
                    {
                        tbl_NGUOIDUNG dt = new tbl_NGUOIDUNG();
                        dt.TenDangNhap = _TaiKhoan;
                        dt.MatKhau = mk;
                        dt.QuanTri = chkQuanTri.Checked;
                        _nguoiDung.UpdateItem(dt);
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
                _LoadData();
                _ShowHide(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        void _ClearInput()
        {
            txtTaiKhoan.Text = string.Empty;
            layou.Text = string.Empty;
            chkQuanTri.Checked = false;

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            txtTaiKhoan.Focus();
            _ShowHide(false);
            _ClearInput();
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
                if (_TaiKhoan == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _nguoiDung.DeleteItem(_TaiKhoan);
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



        private void gcNguoiDung_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvNguoiDung.RowCount > 0)
                {
                    txtTaiKhoan.Text= _TaiKhoan = gvNguoiDung.GetFocusedRowCellValue("TenDangNhap").ToString();
                    txtMatKhau.Text = gvNguoiDung.GetFocusedRowCellValue("MatKhau").ToString();
                    chkQuanTri.Checked = Convert.ToBoolean(gvNguoiDung.GetFocusedRowCellValue("QuanTri"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            try
            {
                int focusedRowHandle = gvNguoiDung.FocusedRowHandle;
                if (gvNguoiDung.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvNguoiDung.GetDataRow(gvNguoiDung.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _TaiKhoan = row["MaLoai"].ToString();
                        var item = _nguoiDung.GetItem(_TaiKhoan);
                       txtTaiKhoan.Text = item.TenDangNhap;
                        txtMatKhau.Text = item.MatKhau;
                        chkQuanTri.Checked = item.QuanTri;
                    }
                }
                else
                {
                    _TaiKhoan = gvNguoiDung.GetFocusedRowCellValue("TenDangNhap").ToString();
                    var item = _nguoiDung.GetItem(_TaiKhoan);
                    txtTaiKhoan.Text = item.TenDangNhap;
                    txtMatKhau.Text = item.MatKhau;
                    chkQuanTri.Checked = item.QuanTri;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }

}
