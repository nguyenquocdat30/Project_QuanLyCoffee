using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTHDBLL
    {
        public List<DTO.CTHDDTO> LoadChiTietHoaDonByMaHD(string maHD)
        {
            return DAL.CTHDDAL.Instance.LoadChiTietHoaDonByMaHD(maHD);
        }
        public bool InsertCTHD(string maHD,string maSP,int soLuong)
        {
            DTO.CTHDDTO cthd = new DTO.CTHDDTO(maHD, maSP, soLuong);
            return DAL.CTHDDAL.Instance.InsertData(cthd);
        }
        public bool KiemTraSanPhamTrongCTHD(string maHD, string maSP)
        {
            return DAL.CTHDDAL.Instance.KiemTraSanPhamTrongCTHD(maHD, maSP);
        }
        public bool UpdateSoLuongByMaHDAndMaSp(string maHD,string maSP,int soLuong)
        {
            int soLuongMoi = DAL.CTHDDAL.Instance.GetSoLuongByMaSPAndMaHD(maSP, maHD) + soLuong; 
            return DAL.CTHDDAL.Instance.UpdateSoLuongByMaHDAndMaSp(maHD, maSP, soLuongMoi);
        }
        public bool DeleteCTHDByMaHDAndMaSP(string maHD,string maSP)
        {
            return DAL.CTHDDAL.Instance.DeleteData(maHD, maSP);
        }
    }
}
