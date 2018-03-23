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
    public partial class frmTimKiem : Form
    {
        private BindingSource danhSachSanPham = new BindingSource();
        public frmTimKiem()
        {
            InitializeComponent();
            LoadTimKiem();
        }

        private void frmTimKiem_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdTimKiemTuongDoi.Checked == true)
            {
                BLL.SanPhamBLL dsSanPham = new BLL.SanPhamBLL();
                danhSachSanPham.DataSource = dsSanPham.SearchDataEquivalent(txtMaSanPham.Text, txtTenSanPham.Text, txtSoLuong.Text, dtpNgaySanXuat.Text, dtpHanSuDung.Text, txtDonGia.Text, txtMoTa.Text, txtNhaSanXuat.Text, txtNhaCungCap.Text);
            }
            else if (rdTimKiemTuyetDoi.Checked == true)
            {
                if ((txtMaSanPham.Text == "") || (txtTenSanPham.Text == "") || (txtSoLuong.Text == "") || (dtpNgaySanXuat.Text == "") || (dtpHanSuDung.Text == "") || (txtDonGia.Text == "") || (txtNhaSanXuat.Text == "") || (txtNhaCungCap.Text == ""))
                {
                    MessageBox.Show("Các thông tin tìm kiếm chưa được nhập đầy đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BLL.SanPhamBLL dsSanPham = new BLL.SanPhamBLL();
                    danhSachSanPham.DataSource = dsSanPham.SearchDataAbsolute(txtMaSanPham.Text, txtTenSanPham.Text,Int32.Parse(txtSoLuong.Text), dtpNgaySanXuat.Text, dtpHanSuDung.Text, Int32.Parse(txtDonGia.Text), txtMoTa.Text, txtNhaSanXuat.Text, txtNhaCungCap.Text);
                }
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }
        public void LoadTimKiem()
        {
            LoadDanhSachSanPham();
            BindingProduct();
        }

        public void LoadDanhSachSanPham()
        {
            dgvDanhSachSanPham.DataSource = danhSachSanPham;
            BLL.SanPhamBLL dsSanPham = new BLL.SanPhamBLL();
            danhSachSanPham.DataSource = dsSanPham.LoadData();
        }
        public void BindingProduct()
        {
            txtMaSanPham.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "MASP", true, DataSourceUpdateMode.Never));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "TENSP", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "SOLUONGTONKHO", true, DataSourceUpdateMode.Never));
            dtpNgaySanXuat.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "NGAYSX", true, DataSourceUpdateMode.Never));
            dtpHanSuDung.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "HANSUDUNG", true, DataSourceUpdateMode.Never));
            txtDonGia.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "DONGIA", true, DataSourceUpdateMode.Never));
            txtMoTa.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "MOTA", true, DataSourceUpdateMode.Never));
            txtNhaSanXuat.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "MANSX", true, DataSourceUpdateMode.Never));
            txtNhaCungCap.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "MANCC", true, DataSourceUpdateMode.Never));
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void rdTimKiemTuongDoi_CheckedChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = "";
            txtNhaSanXuat.Text = "";
            txtNhaCungCap.Text = "";
            txtMoTa.Text = "";
            txtMaSanPham.Text = "";
            txtDonGia.Text = "";
            txtTenSanPham.Text = "";
            dtpHanSuDung.Text = "";
            dtpNgaySanXuat.Text = "";
        }
    }
}
