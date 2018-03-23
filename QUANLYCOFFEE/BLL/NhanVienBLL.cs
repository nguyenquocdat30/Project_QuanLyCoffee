using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        public DTO.NhanVienDTO LoadThongTinTaiKhoan(string userName)
        {
            return DAL.NhanVienDAL.Instance.LoadNhanVienByUserName(userName);
        }
    }
}
