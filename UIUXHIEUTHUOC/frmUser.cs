using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIUXHIEUTHUOC.UIAdmin;
using UIUXHIEUTHUOC.UIUser;

namespace UIUXHIEUTHUOC
{
    public partial class frmUser : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmUser()
        {
            InitializeComponent();
        }

    

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmKhachHang));
        }

        private  void OpenFormInContainer(Type formType)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            Form childForm = (Form)Activator.CreateInstance(formType);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            fromUserContainer.Controls.Clear();

            fromUserContainer.Controls.Add(childForm);
            SplashScreenManager.CloseForm();
            childForm.Show();
        }
        public string _maDuocSi;
        private void frmUser_Load(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmSelling));
        }



        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangNhap loginForm = Application.OpenForms["frmDangNhap"] as frmDangNhap;
            loginForm?.Close();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmSelling));
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmLoai));

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmSanPham));

        }

      

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmNhapHang));
        }

        private void btnNhaSanXuat_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmNhaSanXuat));
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(typeof(frmNhaCungCap));
        }
    }
}
