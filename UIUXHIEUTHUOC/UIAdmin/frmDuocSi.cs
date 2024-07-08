using BLL;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid.Frames;
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
    public partial class frmDuocSi : DevExpress.XtraEditors.XtraForm
    {
        public frmDuocSi()
        {
            InitializeComponent();
        }
        bool _them;
        string _TaiKhoan;
        NguoiDungBLL _nguoiDung;
        DuocSiBLL _duocSi;
        int _id;
        private void frmDuocSi_Load(object sender, EventArgs e)
        {
            try
            {

                _nguoiDung = new NguoiDungBLL();
                _duocSi = new DuocSiBLL();
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
            var lst = _nguoiDung.GetLists();
            slkTaiKhoan.Properties.DataSource = lst;
            slkTaiKhoan.Properties.DisplayMember= "TenDangNhap";
            slkTaiKhoan.Properties.ValueMember = "TenDangNhap";
            slkTaiKhoan.EditValue = lst.First().TenDangNhap;
        }
        private void _LoadData()
        {
            try
            {
                gcDuocSi.DataSource = _duocSi.GetLists();
                gvDuocSi.OptionsBehavior.Editable = false;
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
            txtMail.Enabled = !kt;
            slkTaiKhoan.Enabled = !kt;
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
                        tbl_DUOCSI dt = new tbl_DUOCSI();
                        dt.TenDangNhap = slkTaiKhoan.EditValue.ToString(); 
                        dt.DiaChi = txtDiaChi.Text;
                        dt.Email = txtMail.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenDuocSi = txtTen.Text;
                        _duocSi.AddItem(dt);
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
                        tbl_DUOCSI dt = new tbl_DUOCSI();
                        dt.MaDuocSi = _id;
                        dt.TenDangNhap = slkTaiKhoan.EditValue.ToString();
                        dt.DiaChi = txtDiaChi.Text;
                        dt.Email = txtMail.Text;
                        dt.SDT = txtSDT.Text;
                        dt.TenDuocSi = txtTen.Text;
                        _duocSi.UpdateItem(dt);
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
            txtMail.Text = string.Empty;
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
                    _duocSi.DeleteItem(_id);
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

        private void gcDuocSi_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvDuocSi.FocusedRowHandle;
                if (gvDuocSi.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvDuocSi.GetDataRow(gvDuocSi.GetChildRowHandle(focusedRowHandle, 0));
                    if (row != null)
                    {
                        _id = Convert.ToInt32(row["MaDuocSi"]);
                        var item = _duocSi.GetItem(_id);
                        txtTen.Text = item.TenDuocSi;
                        txtMail.Text = item.Email;
                        txtSDT.Text = item.SDT;
                        txtDiaChi.Text = item.DiaChi;
                        slkTaiKhoan.EditValue = item.TenDangNhap;
                    }
                }
                else
                {
                    if (gvDuocSi.RowCount > 0)
                    {
                        _id = Convert.ToInt32(gvDuocSi.GetFocusedRowCellValue("MaDuocSi"));
                        var item = _duocSi.GetItem(_id);
                        txtTen.Text = item.TenDuocSi;
                        txtMail.Text = item.Email;
                        txtSDT.Text = item.SDT;
                        txtDiaChi.Text = item.DiaChi;
                        slkTaiKhoan.EditValue = item.TenDangNhap;
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