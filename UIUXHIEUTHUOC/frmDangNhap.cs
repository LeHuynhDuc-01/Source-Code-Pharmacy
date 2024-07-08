using BLL;
using DevExpress.Xpo.Logger;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUXHIEUTHUOC
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthenticationBLL _authenticationBLL;
        private   bool _quyenHan;
        public frmDangNhap()
        {
            InitializeComponent();
            _authenticationBLL = new AuthenticationBLL();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lblMessage.Text = " \n  ";
            txtMatKhau.Properties.UseSystemPasswordChar = true;
            groupTaiKhoan.Enabled = chkChungChi.Checked;
            txtPassword.Properties.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            if (IsValidLogin(username, password))
            {
                if (_quyenHan == true)
                {
                    DuocSiBLL duocSiBLL = new DuocSiBLL();
                    var item = duocSiBLL.GetItemDS(username);
                    AccountManager.Instance.Login(username,item.TenDuocSi, item.MaDuocSi);
                    frmQuanLyThuoc quanLyHieuThuocForm = new frmQuanLyThuoc();
                    //quanLyHieuThuocForm._maDuocSi = item.TenDangNhap;
                    quanLyHieuThuocForm.FormClosed += MainForm_FormClosed;
                    this.Hide();
                    SplashScreenManager.CloseForm();
                    quanLyHieuThuocForm.Show();
                }
                else
                {
                    DuocSiBLL duocSiBLL = new DuocSiBLL();
                    var item = duocSiBLL.GetItemDS(username);
                    AccountManager.Instance.Login(username, item.TenDuocSi, item.MaDuocSi);
                    frmUser userForm = new frmUser();
                    userForm._maDuocSi = item.TenDangNhap;
                    userForm.FormClosed += MainForm_FormClosed;

                    this.Hide();
                    SplashScreenManager.CloseForm();
                    userForm.Show();
                }
            }
            else
            {
                lblMessage.Text = "Đăng nhập không thành công. \n Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private bool IsValidLogin(string username, string password)
        {
            try
            {
                NguoiDungBLL _nguoiDung = new NguoiDungBLL();
                var item = _nguoiDung.GetItem(username);
                _quyenHan = item.QuanTri;
                if (item != null && username == item.TenDangNhap && password == item.MatKhau)
                {
                    return true;
                }
                else
                {
                    lblMessage.Text = "Đăng nhập không thành công. \n Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnDangNhapSQL_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text;
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true);
            if (!chkChungChi.Checked)
            {
                // Đăng nhập chứng chỉ Windows
                if (_authenticationBLL.TestWindowsAuthenticationConnection(serverName))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    // Thực hiện các thao tác cần thiết sau khi đăng nhập
                }
                else
                {
                    MessageBox.Show("Lỗi đăng nhập chứng chỉ Windows.");
                }
            }
            else
            {
                // Đăng nhập bằng tên đăng nhập và mật khẩu
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                if (_authenticationBLL.TestSqlAuthenticationConnection(serverName, username, password))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi đăng nhập bằng tên đăng nhập và mật khẩu.");
                }
            }
            SplashScreenManager.CloseForm();

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.Properties.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void chkChungChi_CheckedChanged(object sender, EventArgs e)
        {
            groupTaiKhoan.Enabled = chkChungChi.Checked;
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.UseSystemPasswordChar = !checkButton1.Checked;
        }
    }
}
