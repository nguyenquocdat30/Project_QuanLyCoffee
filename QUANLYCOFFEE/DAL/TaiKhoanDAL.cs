using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;

        public static TaiKhoanDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TaiKhoanDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TaiKhoanDAL() { }
        /// <summary>
        /// Hàm thực hiện lấy toàn bộ dữ liệu trong csdl với bảng TAIKHOAN
        /// </summary>
        /// <returns></returns>
        public DataTable LoadData()
        {
            string query = string.Format("EXEC LOAD_DANHSACH_TAIKHOAN");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Hàm thực hiện update dữ liệu bảng TAIKHOAN
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool UpdateData(DTO.TaiKhoanDTO account)
        {
            string query = string.Format("EXEC dbo.UPDATE_TAIKHOAN @USERNAME = '{0}',@PASSWORD = '{1}',@QUYENHAN = {2}", account.UserName,account.PassWord,account.QuyenHan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDataNotQuyenHan(DTO.TaiKhoanDTO account,string matKhauMoi)
        {
            string query = string.Format("EXEC dbo.THAYDOI_MATKHAU_BYUSERNAME @USERNAME = '{0}',@PASSWORD = '{1}', @NEWPASSWORD = '{2}'", account.UserName, account.PassWord,matKhauMoi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// Hàm thực hiện xóa dữ liệu trong bảng TAIKHOAN
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteData(string userName)
        {
            string query = string.Format("EXEC dbo.DELETE_TAIKHOAN @USERNAME = '{0}'",userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 1;
        }
        /// <summary>
        ///  Hàm thực hiện thêm dữ liệu vào bảng TAIKHOAN
        /// </summary>
        /// <param name="taiKhoan"></param>
        /// <returns></returns>
        public bool InsertData(DTO.TaiKhoanDTO taiKhoan)
        {
            string query = string.Format("EXEC dbo.INSERT_TAIKHOAN @USERNAME = '{0}',@PASSWORD = '{1}',@QUYENHAN = {2}",taiKhoan.UserName,taiKhoan.PassWord,taiKhoan.QuyenHan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        /// <summary>
        /// Hàm kiểm tra tài khoản và mật khẩu có tồn tại trong csdl ?
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool CheckLogin(string userName,string passWord)
        {
            string query = string.Format("EXEC CHECK_LOGIN_TAIKHOAN @USERNAME = '{0}',@PASSWORD = '{1}'", userName,passWord);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
        /// <summary>
        /// Hàm thực hiện lấy dữ liệu từ bảng TAIKHOAN thông qua userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DTO.TaiKhoanDTO GetAccountByUserName(string userName)
        {
            string query = string.Format("EXEC THONGTIN_TAIKHOAN_BYUSERNAME @USERNAME ='{0}'", userName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                return new DTO.TaiKhoanDTO(item);
            }
            return null;
        }
    }
}
