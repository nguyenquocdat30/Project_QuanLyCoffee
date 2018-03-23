using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private string maHD;
        private string ngayLapHD;
        private string userName;
        private bool trangThai;
        private string maBan;

        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public string NgayLapHD
        {
            get
            {
                return ngayLapHD;
            }

            set
            {
                ngayLapHD = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

        public string MaBan
        {
            get
            {
                return maBan;
            }

            set
            {
                maBan = value;
            }
        }

        public HoaDonDTO()
        {
            this.maHD = "";
            this.ngayLapHD = "";
            this.userName = "";
            this.TrangThai = false;
            this.MaBan = "";
        }
        public HoaDonDTO(string maHD,string ngayLapHD,bool trangThai,string userName,string maBan)
        {
            this.maHD = maHD;
            this.ngayLapHD = ngayLapHD;
            this.userName = userName;
            this.TrangThai = trangThai;
            this.MaBan = maBan;
        }
        public HoaDonDTO(DataRow row)
        {
            this.maHD = (string)row["MAHD"];
            this.ngayLapHD = (string)row["NGAYLAPHD"];
            this.MaBan = (string)row["MABAN"];
            this.userName = (string)row["USERNAME"];
            this.TrangThai = (bool)row["TRANGTHAI"];
        }
    }
}
