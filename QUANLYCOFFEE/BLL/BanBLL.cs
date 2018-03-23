using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class BanBLL
    {

        public DataTable LoadData()
        {
            return DAL.BanDAL.Instance.LoadData();
        }
        public List<DTO.BanDTO> LoadTableList()
        {
             return DAL.BanDAL.Instance.LoadTableList();
        }
        public int WidthTable()
        {
            return DAL.BanDAL.tableWidth;
        }
        public int HeighTable()
        {
            return DAL.BanDAL.tableHeight;
        }
        public bool UpdateBanKhiLapHoaDon(string maBan)
        {
            DTO.BanDTO ban = new DTO.BanDTO(maBan,true);
            return DAL.BanDAL.Instance.UpdateData(ban);
        }
        public bool UpdateBanKhiThanhToan(string maBan)
        {
            DTO.BanDTO ban = new DTO.BanDTO(maBan, false);
            return DAL.BanDAL.Instance.UpdateData(ban);
        }
        public bool LoadTrangThaiBanByMaBan(string maBan)
        {
            return DAL.BanDAL.Instance.LoadTrangThaiBanByMaBan(maBan);
        }
    }
}
