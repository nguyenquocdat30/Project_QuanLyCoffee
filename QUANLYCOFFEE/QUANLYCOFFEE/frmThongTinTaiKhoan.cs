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
    public partial class frmThongTinTaiKhoan : Form
    {
        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public frmThongTinTaiKhoan(string userName)
        {
            this.UserName = userName;
            InitializeComponent();
            LoadThongTinTaiKhoan();
        }

        private void frmThongTinTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //============================
        private void LoadThongTinTaiKhoan()
        {
            BLL.NhanVienBLL nhanVienBLL = new BLL.NhanVienBLL();
            DTO.NhanVienDTO nhanVien = nhanVienBLL.LoadThongTinTaiKhoan(this.UserName);
            txtHoNhanVien.Text = nhanVien.HoNV;
            txtTenNhanVien.Text = nhanVien.TenNV;
            dtpNgaySinhNhanVien.Text = nhanVien.NgaySinh;
            dtpNgayVaoLamNhanVien.Text = nhanVien.NgayVaoLam;
            if(nhanVien.GioiTinh == true)
            {
                rbNamNhanVien.Checked = true;
            }
            else
            {
                rbNuNhanVien.Checked = true;
            }
            txtUserName.Text = nhanVien.UserName;
            txtMaNV.Text = nhanVien.MaNV;
            txtCMNDNhanVien.Text = nhanVien.CmndNV;
            txtDienThoaiNhanVien.Text = nhanVien.DienThoai;
            txtUserName1.Text = nhanVien.UserName;
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.Text.Length >0 && txtMatKhauMoi1.Text.Length >0 && txtMatKhauMoi2.Text.Length >0)
            {
                if(txtMatKhauMoi1.Text == txtMatKhauMoi2.Text)
                {
                    BLL.TaiKhoanBLL taiKhoan = new BLL.TaiKhoanBLL();
                    if(taiKhoan.UpdateDataWithUser(txtUserName1.Text,txtMatKhau.Text,txtMatKhauMoi1.Text))
                    {
                        MessageBox.Show("Mật khẩu đã được thay đỗi !", "Thông báo");
                        txtMatKhau.Text = "";
                        txtMatKhauMoi1.Text = "";
                        txtMatKhauMoi2.Text = "";
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá trình thực hiện. Kiểm tra mật khẩu !", "Thông báo");
                        txtMatKhau.Text = "";
                        txtMatKhauMoi1.Text = "";
                        txtMatKhauMoi2.Text = "";
                        txtMatKhau.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu mới trùng nhau !", "Thông báo");
                    txtMatKhauMoi2.Text = "";
                    txtMatKhauMoi2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !","Thông báo");
            }
        }
    }
}
