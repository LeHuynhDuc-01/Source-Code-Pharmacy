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
    public partial class frmKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhoHang()
        {
            InitializeComponent();
        }

        bool _them;
        string _maKho;
        KhoBLL _kho;
        int _id;
        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            try
            {

                _kho = new KhoBLL();
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
                gcKho.DataSource = _kho.GetLists();
                gvKho.OptionsBehavior.Editable = false;
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
            txtTenKho.Enabled = !kt;
            txtViTri.Enabled = !kt;
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
                    string ten = txtTenKho.Text;
                    if (ten != null)
                    {
                        tbl_KHO dt = new tbl_KHO();
                        dt.TenKho = txtTenKho.Text;
                        dt.ViTri = txtViTri.Text;
                        dt.MaKho = _kho.MaKho();
                        _kho.AddItem(dt);
                    }
                }
                else
                {
                    string ten = txtTenKho.Text;
                    if (_maKho == null)
                    {
                        MessageBox.Show("Vui lòng chọn giá trị cần sửa");
                    }
                    else
                    if (ten != null)
                    {
                        tbl_KHO dt = new tbl_KHO();
                        dt.TenKho = txtTenKho.Text;
                        dt.ViTri = txtViTri.Text;
                        dt.MaKho = _kho.MaKho();
                        _kho.UpdateItem(dt);
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
            txtTenKho.Text = string.Empty;
            txtViTri.Text = string.Empty;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            txtTenKho.Focus();
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
                    _kho.DeleteItem(_maKho);
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

        private void gcKho_Click(object sender, EventArgs e)
        {
           
            try
            {
                int focusedRowHandle = gvKho.FocusedRowHandle;
                if (gvKho.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvKho.GetDataRow(gvKho.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _maKho = row["MaKho"].ToString();
                        var item = _kho.GetItem(_maKho);
                        txtTenKho.Text = item.TenKho;
                        txtViTri.Text = item.ViTri;
                    }
                }
                else
                {
                    _maKho = gvKho.GetFocusedRowCellValue("MaKho").ToString();
                    var item = _kho.GetItem(_maKho);
                    txtTenKho.Text = item.TenKho;
                    txtViTri.Text = item.ViTri;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}