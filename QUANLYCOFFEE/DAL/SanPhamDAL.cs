using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private SanPhamDAL() { }
        /// <summary>
        /// Hàm thực hiện Load toàn bộ dữ liệu trong bảng SANPHAM
        /// </summary>
        /// <returns></returns>
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_SANPHAM");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Hàm thực hiện Update dữ liệu trong bảng SANPHAM
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns></returns>
        public bool UpdateData(DTO.SanPhamDTO sanPham)
        {
            string query = string.Format("EXEC INSERT_SANPHAM_TUSINHMA @TENSP='{0}',@SOLUONGTONKHO ={1} ,@NGAYSX ='{2}',@HANSUDUNG ='{3}',@DONGIA = {4},@MOTA ='{5}',@MANSX ='{6}',@MANCC ='{7}'",
                sanPham.TenSP,sanPham.SoLuongTonKho,sanPham.NgaySX,sanPham.HanSuDung,sanPham.DonGia,sanPham.MoTa,sanPham.MaNSX,sanPham.MaNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// Hàm thực hiện xóa dữ liệu trong bảng SANPHAM
        /// </summary>
        /// <param name="maSanPham"></param>
        /// <returns></returns>
        public bool DeleteData(string maSanPham)
        {
            string query = string.Format("EXEC dbo.DELETE_SANPHAN @MASP = '{0}'",maSanPham);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// Hàm thực hiện thêm dữ liệu trong bảng SANPHAM
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns></returns>
        public bool InsertData(DTO.SanPhamDTO sanPham)
        {
            string query = string.Format("EXEC UPDATE_SANPHAM @MASP= '{8}',@TENSP='{0}',@SOLUONGTONKHO ={1} ,@NGAYSX ='{2}',@HANSUDUNG ='{3}',@DONGIA = {4},@MOTA ='{5}',@MANSX ='{6}',@MANCC ='{7}'",
                sanPham.TenSP, sanPham.SoLuongTonKho, sanPham.NgaySX, sanPham.HanSuDung, sanPham.DonGia, sanPham.MoTa, sanPham.MaNSX, sanPham.MaNCC,sanPham.MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// Hàm thực hiện Load Mã Sản Phẩm, Tên Sản phẩm, Số lượng trong csdl 
        /// </summary>
        /// <returns></returns>
        public DataTable LoadProductListData()
        {
            string query = string.Format("SELECT MASP,TENSP,SOLUONGTONKHO AS SOLUONG FROM dbo.SANPHAM WHERE SOLUONGTONKHO >0");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Hàm tìm kiếm tương đối với bảng sản phẩm trong csdl
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public DataTable SearchDataEquivalent(string maSP, string tenSP, string soLuongTonKho, string ngaySX,
            string hanSuDung, string donGia, string moTa, string maNSX, string maNCC)
        {
            string query = string.Format("EXEC TIMKIEM_SANPHAM_TUONGDOI @MASP = '{0}',@TENSP =N'{1}',@SOLUONGTONKHO = '{2}',@NGAYSX='{3}',@HANSUDUNG='{4}',@DONGIA ='{5}',@MOTA=N'{6}',@MANSX='{7}',@MANCC='{8}'",
                maSP, tenSP, soLuongTonKho, ngaySX, hanSuDung, donGia, moTa, maNSX, maNCC);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Hàm tìm kiếm tuyệt đối với bảng sản phẩm trong csdl
        /// </summary>
        /// <param name="sanPham"></param>
        /// <returns></returns>
        public DataTable SearchDataAbsolute(DTO.SanPhamDTO sanPham)
        {
            string query = string.Format("EXEC TIMKIEM_SANPHAM_TUYETDOI @MASP = '{0}',@TENSP =N'{1}',@SOLUONGTONKHO = {2},@NGAYSX='{3}',@HANSUDUNG='{4}',@DONGIA ={5},@MOTA=N'{6}',@MANSX='{7}',@MANCC='{8}'",
                sanPham.MaSP,sanPham.TenSP,sanPham.SoLuongTonKho,sanPham.NgaySX,sanPham.HanSuDung,sanPham.DonGia,sanPham.MoTa,sanPham.MaNSX,sanPham.MaNCC);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Hàm thực hiện lấy dữ liệu từ bảng SANPHAM thông qua mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public DTO.SanPhamDTO GetSanPhamByMaSP(string maSP)
        {
            string query = string.Format("SELECT MASP,TENSP,SOLUONGTONKHO,CONVERT(VARCHAR(10),NGAYSX)AS NGAYSX,CONVERT(VARCHAR(10),HANSUDUNG)AS HANSUDUNG,DONGIA,MOTA,MANSX,MANCC FROM dbo.SANPHAM WHERE MASP = '{0}'", maSP);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new DTO.SanPhamDTO(item);
            }
            return null;
        }
        public int GetSoLuongTonKhoByMaSP(string maSP)
        {
            string query = string.Format("SELECT MASP,TENSP,SOLUONGTONKHO,CONVERT(VARCHAR(10),NGAYSX)AS NGAYSX,CONVERT(VARCHAR(10),HANSUDUNG)AS HANSUDUNG,DONGIA,MOTA,MANSX,MANCC FROM SANPHAM WHERE MASP = '{0}'", maSP);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.SanPhamDTO sanPham = new DTO.SanPhamDTO(item);
                return sanPham.SoLuongTonKho;
            }
            return 0;
        }
        public bool UpdateSoLuongTonKhoByMaSP(string maSP,int soLuongMoi)
        {
            string query = string.Format("UPDATE dbo.SANPHAM SET SOLUONGTONKHO = {0} WHERE MASP = '{1}'", soLuongMoi, maSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
