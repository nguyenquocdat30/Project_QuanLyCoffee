using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTHDDAL
    {
        private static CTHDDAL instance;

        public static CTHDDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CTHDDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private CTHDDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXECT LOAD_CTHD");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.CTHDDTO chiTietHoaDon)
        {
            string query = string.Format("EXEC UPDATE_SOLUONG_MASP_MAHD @MAHD = '{0}',@MASP ='{1}',@SOLUONG = {2}", chiTietHoaDon.MaHD, chiTietHoaDon.MaSP, chiTietHoaDon.SoLuong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maHD,string maSP)
        {
            //string query = string.Format("DELETE FROM dbo.CTHD WHERE MAHD ='{0}' AND MASP ='{1}'",maHD,maSP);
            string query = string.Format("EXEC DELETE_CTHD @MAHD = '{0}' ,@MASP = '{1}'", maHD, maSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.CTHDDTO chiTietHoaDon)
        {
            //string query = string.Format("INSERT INTO dbo.CTHD( MAHD, MASP, SOLUONG )VALUES  ( '{0}','{1}',{2})",chiTietHoaDon.MaHD,chiTietHoaDon.MaSP,chiTietHoaDon.SoLuong);
            string query = string.Format("EXEC dbo.INSERT_CTHD @MAHD = '{0}',@MASP = '{1}',@SOLUONG = {2}", chiTietHoaDon.MaHD, chiTietHoaDon.MaSP, chiTietHoaDon.SoLuong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<DTO.CTHDDTO> LoadChiTietHoaDonByMaHD(string maHD)
        {
            List<DTO.CTHDDTO> cthdList = new List<DTO.CTHDDTO>();
            //string query = string.Format("SELECT * FROM dbo.CTHD WHERE MAHD = '{0}'",maHD);
            string query = string.Format("EXEC dbo.LOAD_CTHD_MAHD @MAHD = '{0}'", maHD);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.CTHDDTO cthd = new DTO.CTHDDTO(item);
                cthdList.Add(cthd);
            }
            return cthdList;
        }
        public bool KiemTraSanPhamTrongCTHD(string maHD,string maSP)
        {
            //string query = string.Format("SELECT * FROM dbo.CTHD WHERE MAHD = '{0}' AND MASP = '{1}'",maHD,maSP);
            string query = string.Format("EXEC KIEMTRASANPHAM_CTHD_MAHD_MASP @MAHD ='{0}',@MASP='{1}'", maHD, maSP);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
        public bool UpdateSoLuongByMaHDAndMaSp(string maHD, string maSP,int soLuong)
        {
            //string query = string.Format("UPDATE dbo.CTHD SET SOLUONG = {2} WHERE MAHD = '{0}' AND MASP = '{1}'", maHD, maSP,soLuong);
            string query = string.Format("EXEC UPDATE_SOLUONG_MASP_MAHD @MAHD = '{0}',@MASP ='{1}',@SOLUONG = {2}", maHD, maSP, soLuong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int GetSoLuongByMaSPAndMaHD(string maSP,string maHD)
        {
            //string query = string.Format("SELECT * FROM CTHD WHERE MASP = '{0}' AND MAHD='{1}'", maSP,maHD);
            string query = string.Format("EXEC LOAD_CTHD_BYMASP_MAHD @MASP = '{0}', @MAHD ='{1}'", maSP, maHD);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.CTHDDTO cthd = new DTO.CTHDDTO(item);
                return cthd.SoLuong;
            }
            return 0;
        }
    }
}
