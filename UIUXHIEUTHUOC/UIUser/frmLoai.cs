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
    public partial class frmLoai : DevExpress.XtraEditors.XtraForm
    {
        public frmLoai()
        {
            InitializeComponent();
        }

        bool _them;
        int _id;
        LoaiBLL _loai;
        private void frmLoai_Load(object sender, EventArgs e)
        {
            try
            {

                _loai = new LoaiBLL();
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
                gcLoai.DataSource = _loai.GetLists();
                gvLoai.OptionsBehavior.Editable = false;
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
                        tbl_LOAI dt = new tbl_LOAI();
                        dt.TenLoai = txtTen.Text;
                        _loai.AddItem(dt);
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
                        tbl_LOAI dt = new tbl_LOAI();
                        dt.MaLoai = _id;
                        dt.TenLoai = txtTen.Text;
                        _loai.UpdateItem(dt);
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
                    _loai.DeleteItem(_id);
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

        private void gcLoai_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvLoai.FocusedRowHandle;
                if (gvLoai.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvLoai.GetDataRow(gvLoai.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _id = int.Parse( row["MaLoai"].ToString());
                        var item = _loai.GetItem(_id);
                        txtTen.Text = item.TenLoai;
                    }
                }
                else
                {
                    _id = int.Parse(gvLoai.GetFocusedRowCellValue("MaLoai").ToString());
                    var item = _loai.GetItem(_id);
                    txtTen.Text = item.TenLoai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}