using DevExpress.DirectX.Common.Direct2D;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIUXHIEUTHUOC.UIAdmin;
using UIUXHIEUTHUOC.UIUser;

namespace UIUXHIEUTHUOC
{
    public partial class frmQuanLyThuoc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmQuanLyThuoc()
        {
            InitializeComponent();
            IsMdiContainer = true;
            documentManager1.MdiParent = this;
            documentManager1.View = tabbedView1; // Set the tabbed view
        }
        public static string _maDuocSiMain;
    
        void openForm(Type typeForm)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
                foreach (var frm in MdiChildren)
                {
                    if (frm.GetType() == typeForm)
                    {
                        frm.Activate();
                        SplashScreenManager.CloseForm();
                        return;
                    }
                }
                Form f = (Form)Activator.CreateInstance(typeForm);
                f.MdiParent = this;
                SplashScreenManager.CloseForm();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhaSanXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            openForm(typeof(frmNhaSanXuat));
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmNhaSanXuat));

        }

        private void btnNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmNhaCungCap));
        }

        private void btnLoai_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmLoai));
        }

        private void btnNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmNguoiDung));
        }

        private void btnDuocSi_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmDuocSi));
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmKhachHang));
        }

        private void btnSanPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmSanPham));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmChiTietSanPham));

        }

        private void btnKhoHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmKhoHang));
        }

        private void btnNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmNhapHang));
        }

        private void frmQuanLyThuoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangNhap loginForm = Application.OpenForms["frmDangNhap"] as frmDangNhap;
            loginForm?.Close();
        }

        private void frmQuanLyThuoc_Load(object sender, EventArgs e)
        {

        }

        private void frmAmin_Click(object sender, EventArgs e)
        {

        }

        private void btnBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmSelling));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmBaoCao));
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmThongKeTonKho));

        }
    }
}