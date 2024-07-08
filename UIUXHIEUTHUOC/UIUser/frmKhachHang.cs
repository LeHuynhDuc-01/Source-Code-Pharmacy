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

namespace UIUXHIEUTHUOC.UIUser
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

 
        bool _them;
        int _id;
        KhachHangBLL _khachHang;
       
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            try
            {

                _khachHang = new KhachHangBLL();
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
                gcKhachHang.DataSource = _khachHang.GetLists();
                gvKhachHang.OptionsBehavior.Editable = false;
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
            txtTen.Enabled = !kt;
            txtDiaChi.Enabled = !kt;
            txtSDT.Enabled = !kt;
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
                    string ten = txtTen.Text;
                    if (ten != null)
                    {
                        tbl_KHACHHANG dt = new tbl_KHACHHANG();
                        dt.DiaChi = txtDiaChi.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenKH = txtTen.Text;
                        _khachHang.AddItem(dt);
                    }
                }
                else
                {
                    string ten = txtTen.Text;
                    if (_id == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (ten != null)
                    {
                        tbl_KHACHHANG dt = new tbl_KHACHHANG();
                        dt.MaKH = _id;
                        dt.DiaChi = txtDiaChi.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenKH = txtTen.Text;
                        _khachHang.UpdateItem(dt);
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
            txtTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            txtTen.Focus();
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
                if (_id == null)
                {
                    MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                }
                else
                {
                    _khachHang.DeleteItem(_id);
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



     
        private void gcKhachHang_Click(object sender, EventArgs e)
        {

            try
            {
                int focusedRowHandle = gvKhachHang.FocusedRowHandle;
                if (gvKhachHang.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvKhachHang.GetDataRow(gvKhachHang.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _id = int.Parse(row["MaKH"].ToString());
                        var item = _khachHang.GetItem(_id);
                        txtTen.Text = item.TenKH;
                        txtDiaChi.Text = item.DiaChi;
                        txtSDT.Text = item.SDT;
                    }
                }
                else
                {
                    if (gvKhachHang.RowCount > 0)
                    {
                        _id = int.Parse(gvKhachHang.GetFocusedRowCellValue("MaKH").ToString());
                        var item = _khachHang.GetItem(_id);
                        txtTen.Text = item.TenKH;
                        txtDiaChi.Text = item.DiaChi;
                        txtSDT.Text = item.SDT;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}