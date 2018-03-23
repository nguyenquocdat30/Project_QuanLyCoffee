using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        public bool InsertHoaDon(string userName,string maBan)
        {
            return DAL.HoaDonDAL.Instance.InsertHoaDon(userName,maBan);
        }
        public bool UpdateHoaDonKhiThanhToan(string maHD)
        {
            return DAL.HoaDonDAL.Instance.UpdateHoaDonKhiThanhToan(maHD);
        }
        public DTO.HoaDonDTO GetHoaDonChuaThanhToanByMaBan(string maBan)
        {
            return DAL.HoaDonDAL.Instance.GetHoaDonChuaThanhToanByMaBan(maBan);
        }
        public bool DeleteHoaDon(string maHD)
        {
            return DAL.HoaDonDAL.Instance.DeleteData(maHD);
        }
    }
}
