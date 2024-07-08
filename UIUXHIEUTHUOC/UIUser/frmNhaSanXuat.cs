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

namespace UIUXHIEUTHUOC
{
    public partial class frmNhaSanXuat : DevExpress.XtraEditors.XtraForm
    {
        public frmNhaSanXuat()
        {
            InitializeComponent();
        }
        bool _them;
        int _id;
        NhaSanXuatBLL _nhaSX;
        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            try
            {

            _nhaSX = new NhaSanXuatBLL();
            _them = false;
            _ShowHide(true);
            _LoadData();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _LoadData()
        {
            try
            {
                gcNhaSX.DataSource = _nhaSX.GetLists();
                gvNhaSX.OptionsBehavior.Editable = false;
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
            btnThemExcel.Enabled = kt;
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
                        tbl_NHASANXUAT dt = new tbl_NHASANXUAT();
                        dt.TenNSX = txtTen.Text;
                        _nhaSX.AddItem(dt);
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
                        tbl_NHASANXUAT dt = new tbl_NHASANXUAT();
                        dt.MaNSX = _id;
                        dt.TenNSX = txtTen.Text;
                        _nhaSX.UpdateItem(dt);
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
                    _nhaSX.DeleteItem(_id);
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

    

        private void gcNhaSX_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvNhaSX.FocusedRowHandle;
                if (gvNhaSX.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvNhaSX.GetDataRow(gvNhaSX.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _id = int.Parse(row["MaNSX"].ToString());
                        var item = _nhaSX.GetItem(_id);
                        txtTen.Text = item.TenNSX;
                    }
                }
                else
                {
                    if (gvNhaSX.RowCount > 0)
                    {
                        _id = int.Parse(gvNhaSX.GetFocusedRowCellValue("MaNSX").ToString());
                        var item = _nhaSX.GetItem(_id);
                        txtTen.Text = item.TenNSX;
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