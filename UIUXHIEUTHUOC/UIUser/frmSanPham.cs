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
using BLL;
using DevExpress.Internal;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.XtraPrinting.Native;

namespace UIUXHIEUTHUOC.UIUser
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        NhaSanXuatBLL _nhaSanXuat;
        SanPhamBLL _sanPham;
        LoaiBLL _loaiBLL;
        int _id;
        bool _them;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                _nhaSanXuat = new NhaSanXuatBLL();
                _loaiBLL = new LoaiBLL();
                _sanPham = new SanPhamBLL();
                _LoadSLK();
                _them = false;
                _ShowHide(true);
                _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void _LoadSLK()
        {
            var lstL = _loaiBLL.GetLists();
            slkLoai.Properties.DataSource = lstL;
            slkLoai.Properties.DisplayMember = "TenLoai";
            slkLoai.Properties.ValueMember = "MaLoai";
            slkLoai.EditValue = lstL.First().MaLoai;

            var lstNSX = _nhaSanXuat.GetLists();
            slkNhaSX.Properties.DataSource = lstNSX;
            slkNhaSX.Properties.DisplayMember = "TenNSX";
            slkNhaSX.Properties.ValueMember = "MaNSX";
            slkNhaSX.EditValue = lstNSX.First().MaNSX;
        }

 
        private void _LoadData()
        {
            try
            {
                gcSanPham.DataSource = _sanPham.GetLists();
                gvSanPham.OptionsBehavior.Editable = false;
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
            txtThanhPhan.Enabled = !kt;
            spGia.Enabled = !kt;
            slkNhaSX.Enabled = !kt;
            slkLoai.Enabled = !kt;
            ptSanPham.Enabled = !kt;
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
                        tbl_SANPHAM dt = new tbl_SANPHAM();
                        dt.TenSP = txtTen.Text;
                        dt.ThanhPhan = txtThanhPhan.Text;
                        dt.Gia = float.Parse(spGia.Text);
                        dt.MaLoai = int.Parse(slkLoai.EditValue.ToString());
                        dt.MaNSX = int.Parse(slkNhaSX.EditValue.ToString());
                        dt.HinhAnh = ImageToBase64(ptSanPham.Image, ImageFormat.Png);
                        _sanPham.AddItem(dt);
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
                        tbl_SANPHAM dt = new tbl_SANPHAM();
                        dt.MaSP = _id;
                        dt.TenSP = txtTen.Text;
                        dt.ThanhPhan = txtThanhPhan.Text;
                        dt.Gia = float.Parse(spGia.Text);
                        dt.MaLoai = int.Parse(slkLoai.EditValue.ToString());
                        dt.MaNSX = int.Parse(slkNhaSX.EditValue.ToString());
                        dt.HinhAnh = ImageToBase64(ptSanPham.Image, ImageFormat.Png);
                        _sanPham.UpdateItem(dt);
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
            txtThanhPhan.Text = string.Empty;
            spGia.Value = 0;
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
                    _sanPham.DeleteItem(_id);
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
        public byte[] ImageToBase64(Image image, ImageFormat format)
        {
            if (image == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public Image Base64ToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data, 0, data.Length))
            {
                ms.Write(data, 0, data.Length);
                Image img = Image.FromStream(ms, true);
                return img;
            }
        }

        private void gcSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                int focusedRowHandle = gvSanPham.FocusedRowHandle;

                if (gvSanPham.IsGroupRow(focusedRowHandle))
                {
                    DataRow row = gvSanPham.GetDataRow(gvSanPham.GetChildRowHandle(focusedRowHandle, 0));

                    if (row != null)
                    {
                        _id = int.Parse(row["MaSP"].ToString());
                        var item = _sanPham.GetItem(_id);
                        slkLoai.EditValue = item.MaLoai;
                        slkNhaSX.EditValue = item.MaNSX;
                        txtTen.Text = item.TenSP;
                        txtThanhPhan.Text = item.ThanhPhan;
                        spGia.EditValue = item.Gia;
                        ptSanPham.EditValue = item.HinhAnh;
                    }
                }
                else
                {
                    if (gvSanPham.RowCount > 0)
                    {
                        // Nếu dòng không phải là dòng nhóm, sử dụng thông tin như bình thường
                        _id =int.Parse( gvSanPham.GetFocusedRowCellValue("MaSP").ToString());
                        var item = _sanPham.GetItem(_id);
                        slkLoai.EditValue = item.MaLoai;
                        slkNhaSX.EditValue = item.MaNSX;
                        txtTen.Text = item.TenSP;
                        txtThanhPhan.Text = item.ThanhPhan;
                        spGia.EditValue = item.Gia;
                        ptSanPham.EditValue = item.HinhAnh;
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