using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYCOFFEE
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            BLL.TaiKhoanBLL taiKhoan = new BLL.TaiKhoanBLL();
            if (txtPassWord.Text.Length == 0 || txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Text = "";
                txtUserName.Text = "";
                txtUserName.Focus();
            }
            else if (taiKhoan.CheckLogin(userName,passWord))
            {
                DTO.TaiKhoanDTO taiKhoanDTO = taiKhoan.GetDataByUserName(userName);
                frmManager f = new frmManager(taiKhoanDTO);
                this.Hide();
                f.ShowDialog();
                txtPassWord.Text = "";
                txtPassWord.Focus();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Đã Nhập Sai Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Text = "";
                txtPassWord.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
