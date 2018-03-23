using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private NhanVienDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_NHANVIEN");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.NhanVienDTO nhanVien)
        {
            string query = string.Format("EXEC dbo.UPDATE_NHANVIEN @USERNAME = '{0}', @MANV = '{1}', @HONV = N'{2}', @TENNV = N'{3}', @NGAYSINH = '{4}', @GIOITINH = {5},@DIENTHOAI = '{6}',@CMND = '{7}',@NGAYVAOLAM = '{8}'",
                nhanVien.UserName,nhanVien.MaNV,nhanVien.HoNV,nhanVien.TenNV,nhanVien.NgaySinh,nhanVien.GioiTinh,nhanVien.DienThoai,nhanVien.CmndNV,nhanVien.NgayVaoLam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maNV)
        {
            string query = string.Format("EXEC dbo.DELETE_NHANVIEN @USERNAME = '{0}'",maNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.NhanVienDTO nhanVien)
        {
            string query = string.Format("EXEC dbo.INSERT_NHANVIEN @USERNAME = '{0}', @MANV = '{1}', @HONV = N'{2}', @TENNV = N'{3}', @NGAYSINH = '{4}', @GIOITINH = {5},@DIENTHOAI = '{6}',@CMND = '{7}',@NGAYVAOLAM = '{8}'",
                nhanVien.UserName, nhanVien.MaNV, nhanVien.HoNV, nhanVien.TenNV, nhanVien.NgaySinh, nhanVien.GioiTinh, nhanVien.DienThoai, nhanVien.CmndNV, nhanVien.NgayVaoLam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DTO.NhanVienDTO LoadNhanVienByUserName(string userName)
        {
            string query = string.Format("EXEC LOAD_NHANVIEN_BYUSERNAME @USERNAME ='{0}'", userName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                return new DTO.NhanVienDTO(item);
            }
            return null;
        }
    }
}
