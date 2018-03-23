using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QUANLYCOFFEE
{
    public partial class frmManager : Form
    {
        // Binding
        private BindingSource danhSachSanPham = new BindingSource();
        // Biến nhận giá trị TaiKhoanDTO từ frmLogin gửi lên
        private DTO.TaiKhoanDTO taiKhoanLogin;
        private bool trangThaiBan;
        public frmManager(DTO.TaiKhoanDTO taiKhoan)
        {
            
            InitializeComponent();
            this.TaiKhoanLogin = taiKhoan;
            LoadManager();
        }
        // getter setter taiKhoanLogin
        public TaiKhoanDTO TaiKhoanLogin
        {
            get
            {
                return taiKhoanLogin;
            }

            set
            {
                taiKhoanLogin = value;
                QuyenTruyCap(taiKhoanLogin.QuyenHan);
            }
        }

        private void QuyenTruyCap(bool type)
        {
            quyenQuanTriToolStripMenuItem.Enabled = type == true;
        }
        #region Event
        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Thực Sự Muốn Thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void thongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinTaiKhoan f = new frmThongTinTaiKhoan(TaiKhoanLogin.UserName);
            f.ShowDialog();
            this.Show();
        }
        private void timKiemSanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiem f = new frmTimKiem();
            f.ShowDialog();
            this.Show();
        }
        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cbbSoLuong.Text.Length >0 && txtMaBan.Text.Length >0)
            {
                if (trangThaiBan == true)
                {
                    // Update CTHD
                    BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
                    DTO.HoaDonDTO hoaDonDTO = hoaDon.GetHoaDonChuaThanhToanByMaBan(txtMaBan.Text);
                    BLL.CTHDBLL cthd = new BLL.CTHDBLL();
                    if (cthd.KiemTraSanPhamTrongCTHD(hoaDonDTO.MaHD, txtMaSP.Text))
                    {
                        // Đã có sản phẩm => Update CTHD
                        if(cthd.UpdateSoLuongByMaHDAndMaSp(hoaDonDTO.MaHD, txtMaSP.Text, Int32.Parse(cbbSoLuong.Text)))
                        {
                            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                            int soLuong = sanPham.GetSoLuongTonKhoByMaSP(txtMaSP.Text);
                            sanPham.UpdateSoLuongTonKhoByMaSP(txtMaSP.Text, soLuong, Int32.Parse(cbbSoLuong.Text));
                            MessageBox.Show("Thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thất bại");
                        }
                    }
                    else
                    {
                        // Chưa có sản phẩm => Tạo mới CTHD
                        // Thêm 1 CTHD
                        CreateCTHD(txtMaSP.Text, hoaDonDTO.MaHD, Int32.Parse(cbbSoLuong.Text));
                        // Update số lượng sau khi thêm CTHD
                        BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                        int soLuong = sanPham.GetSoLuongTonKhoByMaSP(txtMaSP.Text);
                        sanPham.UpdateSoLuongTonKhoByMaSP(txtMaSP.Text, soLuong, Int32.Parse(cbbSoLuong.Text));
                        MessageBox.Show("Thành công");
                    }
                }
                else
                {
                    // Insert HD và thêm 1 bảng CTHD
                    // Update trạng thái bàn
                    bool check = CreateHoaDon(txtMaBan.Text);
                    if (check == true)
                    {
                        BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
                        DTO.HoaDonDTO hoaDonDTO = hoaDon.GetHoaDonChuaThanhToanByMaBan(txtMaBan.Text);
                        // Thêm 1 CTHD
                        CreateCTHD(txtMaSP.Text, hoaDonDTO.MaHD, Int32.Parse(cbbSoLuong.Text));
                        // Update số lượng sau khi thêm CTHD
                        BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                        int soLuong = sanPham.GetSoLuongTonKhoByMaSP(txtMaSP.Text);
                        sanPham.UpdateSoLuongTonKhoByMaSP(txtMaSP.Text, soLuong, Int32.Parse(cbbSoLuong.Text));
                        // thay đỗi trạng thái bàn => Có người
                        BLL.BanBLL ban = new BLL.BanBLL();
                        ban.UpdateBanKhiLapHoaDon(txtMaBan.Text);
                        MessageBox.Show("Thành công");
                    }
                }
                BLL.BanBLL ban1 = new BLL.BanBLL();
                trangThaiBan = ban1.LoadTrangThaiBanByMaBan(txtMaBan.Text);
                if(trangThaiBan == true)
                {
                    listViewHoaDon.Items.Clear();
                    ShowHoaDon(txtMaBan.Text);
                }
            }
            else
            {
                MessageBox.Show("Chọn bàn và số lượng trước khi thêm dữ liệu", "Thông báo");
            }
            // Load lại ds sản phẩm và bàn
            LoadDanhSachSanPham();
            LoadTableList();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int soLuong = 0;
            string maSP = "";
            // Khi bàn có người 
            if(this.trangThaiBan == true)
            {
                BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
                DTO.HoaDonDTO hoaDonDTO = hoaDon.GetHoaDonChuaThanhToanByMaBan(txtMaBan.Text);
                for (int i = 0; i < listViewHoaDon.Items.Count; i++)
                {
                    // Khi sản phẩm được check 
                    if (listViewHoaDon.Items[i].Checked)
                    {
                        if (MessageBox.Show("Xóa sản phẩm "+listViewHoaDon.Items[i].SubItems[1].Text.ToString()+" ra khỏi hóa đơn thanh toán ??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            BLL.CTHDBLL cthd = new BLL.CTHDBLL();
                            maSP = listViewHoaDon.Items[i].SubItems[0].Text.ToString();
                            soLuong = Int32.Parse(listViewHoaDon.Items[i].SubItems[2].Text.ToString());
                            if (cthd.DeleteCTHDByMaHDAndMaSP(hoaDonDTO.MaHD, maSP))
                            {
                                // Update lại 
                                BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                                int soLuongTonKho = sanPham.GetSoLuongTonKhoByMaSP(maSP);
                                sanPham.UpdateSoLuongTonKhoKhiXoa(maSP, soLuongTonKho, soLuong);
                                MessageBox.Show("Thành công");
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                            listViewHoaDon.Items.Clear();
                            ShowHoaDon(txtMaBan.Text);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy lập hóa đơn trước khi xóa !!", "Thông báo");
            }
            //Load lại danh sách sản phẩm
            LoadDanhSachSanPham();
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            LoadComboboxSoLuong();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(trangThaiBan == true)
            {
                // Kiểm tra Danh sách CTHD có không
                // Nếu không có thì xóa Hóa đơn 
                // Nếu có Update Trạng thái Hóa đơn : đã thanh toán
                // Xóa listView ---> Load lại listView
                // Đỗi trạng thái Bàn ----> Load lại bàn
                if(MessageBox.Show("Thanh toán hóa đơn bàn số : "+txtMaBan.Text,"Thông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
                    DTO.HoaDonDTO hoaDonDTO = hoaDon.GetHoaDonChuaThanhToanByMaBan(txtMaBan.Text);
                    if (listViewHoaDon.Items.Count > 0)
                    {
                        // có CTHD -> đỗi trạng thái hóa đơn và trạng thái bàn
                        if (hoaDon.UpdateHoaDonKhiThanhToan(hoaDonDTO.MaHD))
                        {
                            // Update lại trạng thái bàn
                            BLL.BanBLL ban = new BLL.BanBLL();
                            if (ban.UpdateBanKhiThanhToan(txtMaBan.Text))
                            {
                                MessageBox.Show("Thanh toán thành công \n Đơn giá : " + labelTongTien.Text + "vnđ");
                            }
                        }
                    }
                    else
                    {
                        // không có CTHD
                        hoaDon.DeleteHoaDon(hoaDonDTO.MaHD);
                        BLL.BanBLL ban = new BLL.BanBLL();
                        ban.UpdateBanKhiThanhToan(txtMaBan.Text);
                    }
                    // Xóa danh sách trong list view
                    listViewHoaDon.Items.Clear();
                    // Load lại tổng tiền
                    LoadTongTien();
                    // Load lại danh sách bàn
                    LoadTableList();
                }
            }
            else
            {
                MessageBox.Show("Hãy lập hóa đơn trước khi thanh toán !!", "Thông báo");
            }
        }
        private void quyenQuanTriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        #region Methob
        public void LoadManager()
        {
            LoadDanhSachSanPham();
            BindingProduct();
            LoadTableList();
            LoadListView();
        }
        public void LoadTableList()
        {
            BLL.BanBLL tableBLL = new BLL.BanBLL();
            List<DTO.BanDTO> tableList = tableBLL.LoadTableList();
            flpTable.Controls.Clear();
            foreach (DTO.BanDTO item in tableList)
            {
                Button btn = new Button() { Width = tableBLL.WidthTable(), Height = tableBLL.HeighTable() };
                btn.Text = item.MaBan;
                btn.Click += Btn_Click;
                btn.Tag = item;
                if (item.TrangThai == false)
                {
                    btn.Text += Environment.NewLine + "Trống";
                    btn.BackColor = Color.Aqua;
                }
                else
                {
                    btn.Text += Environment.NewLine + "Có người";
                    btn.BackColor = Color.Orange;
                }
                flpTable.Controls.Add(btn);
            }
        }
        #region Hàm xử lí sự kiện khi click vào bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            string maBan = ((sender as Button).Tag as DTO.BanDTO).MaBan;
            bool trangThai = ((sender as Button).Tag as DTO.BanDTO).TrangThai;
            this.trangThaiBan = trangThai;
            listViewHoaDon.Items.Clear();

            if (trangThai == true)
            {
                ShowHoaDon(maBan);
            }
            LoadTongTien();
            txtMaBan.Text = maBan;
        }
        #endregion

        private bool CreateHoaDon(string maBan)
        {
            if (MessageBox.Show("Tạo hóa đơn cho bàn :"+maBan, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
                return hoaDon.InsertHoaDon(this.TaiKhoanLogin.UserName, maBan);
            }
            return false;
        }
        public bool CreateCTHD(string maSp,string maHD,int soLuong)
        {
            BLL.CTHDBLL cthd = new BLL.CTHDBLL();
            return cthd.InsertCTHD(maHD, maSp, soLuong);
        }
        private void ShowHoaDon(string maBan)
        {
            BLL.CTHDBLL cthd = new BLL.CTHDBLL();
            BLL.HoaDonBLL hoaDon = new BLL.HoaDonBLL();
            DTO.HoaDonDTO hoaDonDTO = hoaDon.GetHoaDonChuaThanhToanByMaBan(maBan);
            List<DTO.CTHDDTO> cthdList = cthd.LoadChiTietHoaDonByMaHD(hoaDonDTO.MaHD);
            foreach(DTO.CTHDDTO item in cthdList)
            {
                BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
                DTO.SanPhamDTO sanPhamDTO = sanPham.GetSanPhamByMaSP(item.MaSP);
                ListViewItem lsvItem = new ListViewItem(item.MaSP);
                lsvItem.SubItems.Add(sanPhamDTO.TenSP);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(sanPhamDTO.DonGia.ToString());
                lsvItem.SubItems.Add((item.SoLuong * sanPhamDTO.DonGia).ToString());
                listViewHoaDon.Items.Add(lsvItem);
            }
            // Load tổng tiền các CTHD
            LoadTongTien();
        }
        public void LoadDanhSachSanPham()
        {
            dgvDanhSachSanPham.DataSource = danhSachSanPham;
            BLL.SanPhamBLL dsSanPham = new BLL.SanPhamBLL();
            danhSachSanPham.DataSource = dsSanPham.LoadDanhSachSanPham();
        }

        public void LoadComboboxSoLuong()
        {
            BLL.SanPhamBLL sanPham = new BLL.SanPhamBLL();
            int soLuong = sanPham.GetSoLuongTonKhoByMaSP(txtMaSP.Text);
            cbbSoLuong.Items.Clear();
            for(int i=1;i<=soLuong;i++)
            {
                cbbSoLuong.Items.Add(i);
            }
        }
        public void LoadListView()
        {
            listViewHoaDon.CheckBoxes = true;
            listViewHoaDon.Columns.Add("Mã SP", 70);
            listViewHoaDon.Columns.Add("Tên sản phẩm", 110);
            listViewHoaDon.Columns.Add("SL", 25);
            listViewHoaDon.Columns.Add("Đơn giá", 65);
            listViewHoaDon.Columns.Add("Thành tiền", 80);
        }
        public void BindingProduct()
        {
            txtMaSP.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "MASP",true, DataSourceUpdateMode.Never));
            txtSanPham.DataBindings.Add(new Binding("Text", dgvDanhSachSanPham.DataSource, "TENSP", true, DataSourceUpdateMode.Never));
        }

        public void LoadTongTien()
        {
            int tongTien = 0;
            labelTongTien.Text = "";
            for(int i=0;i<listViewHoaDon.Items.Count;i++)
            {
                tongTien += Int32.Parse(listViewHoaDon.Items[i].SubItems[4].Text.ToString());
            }
            labelTongTien.Text = tongTien.ToString();
        }





        #endregion

        
    }
}
