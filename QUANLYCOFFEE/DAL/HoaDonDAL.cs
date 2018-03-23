using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new HoaDonDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private HoaDonDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_HOADON");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.HoaDonDTO hoaDon)
        {
            string query = string.Format("EXEC dbo.UPDATE_HOADON @MAHD = '{0}',@NGAYLAPHD = '{1}',@TRANGTHAI = {2},@USERNAME = '{3}', @MABAN = '{4}'",
                hoaDon.MaHD,hoaDon.NgayLapHD,hoaDon.TrangThai,hoaDon.UserName,hoaDon.MaBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maHD)
        {
            string query = string.Format(" EXEC dbo.DELETE_HOADON @MAHD = '{0}'", maHD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.HoaDonDTO hoaDon)
        {
            //string query = string.Format("INSERT INTO dbo.HOADON( MAHD ,NGAYLAPHD ,TRANGTHAI ,USERNAME ,MABAN)VALUES  ( '{0}' ,GETDATE() ,{1} ,'{2}' ,'{3}')",
            //    hoaDon.MaBan,hoaDon.TrangThai,hoaDon.UserName,hoaDon.MaBan);
            string query = string.Format("EXEC dbo.INSERT_HOADON_TUSINHMA @NGAYLAPHD = '{0}',@TRANGTHAI =  {1},@USERNAME = '{2}',  @MABAN = '{3}'",
                hoaDon.NgayLapHD, hoaDon.TrangThai, hoaDon.UserName, hoaDon.MaBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertHoaDon(string UserName,string maBan)
        {
            //string query = string.Format("INSERT INTO dbo.HOADON( MAHD ,NGAYLAPHD ,TRANGTHAI ,USERNAME ,MABAN)VALUES  ( '{0}' ,GETDATE() ,0 ,'{1}' ,'{2}')",
            //    maHD, UserName, maBan);
            string query = string.Format("DECLARE @NGAYLAPHOADON DATETIME SET @NGAYLAPHOADON = GETDATE() EXEC dbo.INSERT_HOADON_TUSINHMA @NGAYLAPHD = @NGAYLAPHOADON,@TRANGTHAI =  0,@USERNAME = '{0}',  @MABAN = '{1}'",UserName, maBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHoaDonKhiThanhToan(string maHoaDon)
        {
            //string query = string.Format("UPDATE dbo.HOADON SET TRANGTHAI = 1 WHERE MAHD = '{0}'",maHoaDon);
            string query = string.Format("EXEC UPDATE_HOADON_THANHTOAN @MAHD='{0}'", maHoaDon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DTO.HoaDonDTO GetHoaDonChuaThanhToanByMaBan(string maBan)
        {
            //string query = string.Format("SELECT MAHD,CONVERT(VARCHAR(10),NGAYLAPHD)AS NGAYLAPHD,TRANGTHAI,USERNAME,MABAN FROM dbo.HOADON WHERE MABAN = '{0}' AND TRANGTHAI = 0", maBan);
            string query = string.Format("EXEC GET_HOADON_CHUATHANHTOAN_BYMABAN @MABAN ='{0}'", maBan);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new DTO.HoaDonDTO(item);
            }
            return null;
        }
    }
}
