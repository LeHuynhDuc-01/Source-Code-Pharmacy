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
    public partial class frmNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        bool _them;
        int _id;
        private NhaCungCapBLL _nhacungcapBLL;

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {

                _nhacungcapBLL = new NhaCungCapBLL();
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
                gcNhaCungCap.DataSource = _nhacungcapBLL.GetLists();
                gvNhaCungCap.OptionsBehavior.Editable = false;
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
            txtMail.Enabled = !kt;
            txtSDT.Enabled = !kt;
            txtDiaChi.Enabled = !kt;
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
                        tbl_NHACUNGCAP dt = new tbl_NHACUNGCAP();
                        dt.TenNCC = txtTen.Text;
                        dt.SDT = txtSDT.Text;
                        dt.DiaChi = txtDiaChi.Text;
                        dt.Email = txtMail.Text;
                        _nhacungcapBLL.AddItem(dt);
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
                        tbl_NHACUNGCAP dt = new tbl_NHACUNGCAP();
                        dt.MaNCC = _id;
                        dt.TenNCC = txtTen.Text;
                        dt.SDT = txtSDT.Text;
                        dt.DiaChi = txtDiaChi.Text;
                        dt.Email = txtMail.Text;
                        _nhacungcapBLL.UpdateItem(dt);
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
                _LoadData();
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
            txtMail.Text = string.Empty;  
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
                    _nhacungcapBLL.DeleteItem(_id);
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



        private void gcNhaCungCap_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvNhaCungCap.FocusedRowHandle;
                if (gvNhaCungCap.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvNhaCungCap.GetDataRow(gvNhaCungCap.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _id = int.Parse(row["MaNCC"].ToString());
                        var item = _nhacungcapBLL.GetItem(_id);
                        txtTen.Text = item.TenNCC;
                        txtDiaChi.Text = item.DiaChi;
                        txtSDT.Text = item.SDT;
                        txtMail.Text = item.Email;
                    }
                }
                else
                {
                    if (gvNhaCungCap.RowCount > 0)
                    {
                        _id = int.Parse(gvNhaCungCap.GetFocusedRowCellValue("MaNCC").ToString());
                        var item = _nhacungcapBLL.GetItem(_id);
                        txtTen.Text = item.TenNCC;
                        txtDiaChi.Text = item.DiaChi;
                        txtSDT.Text = item.SDT;
                        txtMail.Text = item.Email;
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
