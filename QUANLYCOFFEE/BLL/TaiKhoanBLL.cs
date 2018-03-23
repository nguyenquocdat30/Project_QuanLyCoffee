using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BLL
{
    public class TaiKhoanBLL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TaiKhoanBLL(){ }
        /// <summary>
        /// Hàm Load dữ liệu từ csdl đổ vào DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable LoadData()
        {
            return DAL.TaiKhoanDAL.Instance.LoadData();
        }
        /// <summary>
        /// Hàm Update dữ liệu trong csdl với quyền user
        /// Chỉ thay đỗi được mật khẩu
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool UpdateDataWithUser(string userName,string passWord,string matKhauMoi)
        {
            if(userName.Length == 0 || passWord.Length == 0 || matKhauMoi.Length == 0)
            {
                return false;
            }
            else
            {
                DTO.TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO(userName, passWord, false);
                return DAL.TaiKhoanDAL.Instance.UpdateDataNotQuyenHan(taiKhoanDTO, matKhauMoi);
            }
        }
        /// <summary>
        /// Hàm Update dữ liệu trong csdl với quyền admin
        /// Thay đỗi được mật khẩu và quyền hạn
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="quyenHan"></param>
        /// <returns></returns>
        public bool UpdateDataWithAdmin(string userName, string passWord, bool quyenHan)
        {
            if (userName.Length == 0 || passWord.Length == 0)
            {
                return false;
            }
            else
            {
                DTO.TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO(userName, passWord, quyenHan);
                return DAL.TaiKhoanDAL.Instance.UpdateData(taiKhoanDTO);
            }
        }
        /// <summary>
        /// Hàm thêm dữ liệu vào csdl
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="quyenHan"></param>
        /// <returns></returns>
        public bool InsertData(string userName, string passWord, bool quyenHan)
        {
            if(userName.Length == 0 || passWord.Length == 0)
            {
                return false;
            }
            else if (GetDataByUserName(userName) == null)
            {
                return false;
            }
            else
            {
                DTO.TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO(userName, passWord, quyenHan);
                return DAL.TaiKhoanDAL.Instance.InsertData(taiKhoanDTO);
            }
        }
        /// <summary>
        /// Hàm xóa csdl với dữ liệu vào : userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteData(string userName)
        {
            if(userName.Length == 0)
            {
                return false;
            }
            else
            {
                return DAL.TaiKhoanDAL.Instance.DeleteData(userName);
            }
        }
        /// <summary>
        ///  Hàm xử lí kiểm tra Login với dữ liệu vào : userName và passWord
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool CheckLogin(string userName, string passWord)
        {
            if(userName.Length == 0 || passWord.Length == 0)
            {
                return false;
            }
            else
            {
                return DAL.TaiKhoanDAL.Instance.CheckLogin(userName,passWord);
            }
        }
        /// <summary>
        /// Hàm xử lí lấy dữ liệu từ csdl đưa vào TaiKhoanDTO bằng userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DTO.TaiKhoanDTO GetDataByUserName(string userName)
        {
            if(userName.Length == 0)
            {
                return null;
            }
            else
            {
                return DAL.TaiKhoanDAL.Instance.GetAccountByUserName(userName);
            }
        }
    }
}
