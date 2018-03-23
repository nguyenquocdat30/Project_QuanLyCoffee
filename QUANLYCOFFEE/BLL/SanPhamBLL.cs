using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SanPhamBLL() { }
        /// <summary>
        /// Hàm load toàn bộ dữ liệu từ bảng sản phẩm
        /// </summary>
        /// <returns></returns>
        public DataTable LoadData()
        {
            return DAL.SanPhamDAL.Instance.LoadData();
        }
        /// <summary>
        /// Hàm Update sản phẩm trong csdl
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="tenSP"></param>
        /// <param name="soLuongTonKho"></param>
        /// <param name="ngaySX"></param>
        /// <param name="hanSuDung"></param>
        /// <param name="donGia"></param>
        /// <param name="moTa"></param>
        /// <param name="maNSX"></param>
        /// <param name="maNCC"></param>
        /// <returns></returns>
        public bool UpdateData(string maSP, string tenSP, int soLuongTonKho, string ngaySX,
            string hanSuDung, int donGia, string moTa, string maNSX, string maNCC)
        {
            if(maSP.Length == 0 || tenSP.Length == 0 || ngaySX.Length == 0 || hanSuDung.Length == 0|| moTa.Length == 0
                || maNSX.Length == 0 || maNCC.Length == 0 || soLuongTonKho.ToString().Length == 0 || donGia.ToString().Length == 0)
            {
                return false;
            }
            else
            {
                DTO.SanPhamDTO sanPham = new DTO.SanPhamDTO(maSP, tenSP, soLuongTonKho, ngaySX, hanSuDung, donGia, moTa, maNSX, maNCC);
                return DAL.SanPhamDAL.Instance.UpdateData(sanPham);
            }
        }
        /// <summary>
        /// Hàm Xóa dữ liệu trong csdl
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public bool DeleteData(string maSP)
        {
            if(maSP.Length == 0)
            {
                return false;
            }
            else
            {
                return DAL.SanPhamDAL.Instance.DeleteData(maSP);
            }
        }
        /// <summary>
        /// Hàm thêm dữ liệu vào csdl
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="tenSP"></param>
        /// <param name="soLuongTonKho"></param>
        /// <param name="ngaySX"></param>
        /// <param name="hanSuDung"></param>
        /// <param name="donGia"></param>
        /// <param name="moTa"></param>
        /// <param name="maNSX"></param>
        /// <param name="maNCC"></param>
        /// <returns></returns>
        public bool InsertData(string maSP, string tenSP, int soLuongTonKho, string ngaySX,
            string hanSuDung, int donGia, string moTa, string maNSX, string maNCC)
        {
            if (maSP.Length == 0 || tenSP.Length == 0 || ngaySX.Length == 0 || hanSuDung.Length == 0 || moTa.Length == 0
                || maNSX.Length == 0 || maNCC.Length == 0 || soLuongTonKho.ToString().Length == 0 || donGia.ToString().Length == 0)
            {
                return false;
            }
            else if(true)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm load danh sách sản phẩm . với Mã sản phẩm , tên sản phẩm , số lượng
        /// </summary>
        /// <returns></returns>
        public DataTable LoadProductListData()
        {
            return DAL.SanPhamDAL.Instance.LoadProductListData();
        }
        /// <summary>
        /// Hàm tìm kiếm tương đối
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="tenSP"></param>
        /// <param name="soLuongTonKho"></param>
        /// <param name="ngaySX"></param>
        /// <param name="hanSuDung"></param>
        /// <param name="donGia"></param>
        /// <param name="moTa"></param>
        /// <param name="maNSX"></param>
        /// <param name="maNCC"></param>
        /// <returns></returns>
        public DataTable SearchDataEquivalent(string maSP, string tenSP, string soLuongTonKho, string ngaySX,
            string hanSuDung, string donGia, string moTa, string maNSX, string maNCC)
        {
            return DAL.SanPhamDAL.Instance.SearchDataEquivalent(maSP, tenSP, soLuongTonKho, ngaySX, hanSuDung, donGia, moTa, maNSX, maNCC);
        }
        /// <summary>
        /// Hàm tìm kiếm tuyệt đối
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="tenSP"></param>
        /// <param name="soLuongTonKho"></param>
        /// <param name="ngaySX"></param>
        /// <param name="hanSuDung"></param>
        /// <param name="donGia"></param>
        /// <param name="moTa"></param>
        /// <param name="maNSX"></param>
        /// <param name="maNCC"></param>
        /// <returns></returns>
        public DataTable SearchDataAbsolute(string maSP, string tenSP, int soLuongTonKho, string ngaySX,
            string hanSuDung, int donGia, string moTa, string maNSX, string maNCC)
        {
            if (maSP.Length == 0 || tenSP.Length == 0 || ngaySX.Length == 0 || hanSuDung.Length == 0 || moTa.Length == 0
                || maNSX.Length == 0 || maNCC.Length == 0 || soLuongTonKho.ToString().Length == 0 || donGia.ToString().Length == 0)
            {
                return null;
            }
            else
            {
                DTO.SanPhamDTO sanPham = new DTO.SanPhamDTO(maSP, tenSP, soLuongTonKho, ngaySX, hanSuDung, donGia, moTa, maNSX, maNCC);
                return DAL.SanPhamDAL.Instance.SearchDataAbsolute(sanPham);
            }
        }
        public DataTable LoadDanhSachSanPham()
        {
            return DAL.SanPhamDAL.Instance.LoadProductListData();
        }

        public DTO.SanPhamDTO GetSanPhamByMaSP(string maSP)
        {
            return DAL.SanPhamDAL.Instance.GetSanPhamByMaSP(maSP);
        }
        public int GetSoLuongTonKhoByMaSP(string maSP)
        {
            return DAL.SanPhamDAL.Instance.GetSoLuongTonKhoByMaSP(maSP);
        }
        public bool UpdateSoLuongTonKhoByMaSP(string maSP,int soLuongTonKho, int soLuongMoi)
        {
            int soLuong = soLuongTonKho - soLuongMoi;
            if (soLuong >= 0)
                return DAL.SanPhamDAL.Instance.UpdateSoLuongTonKhoByMaSP(maSP, soLuong);
            else
                return false;
        }
        public bool UpdateSoLuongTonKhoKhiXoa(string maSP,int soLuongTonKho,int soLuongMoi)
        {
            int soLuong = soLuongTonKho + soLuongMoi;
            if (soLuong >= 0)
                return DAL.SanPhamDAL.Instance.UpdateSoLuongTonKhoByMaSP(maSP, soLuong);
            else
                return false;
        }
    }
}
