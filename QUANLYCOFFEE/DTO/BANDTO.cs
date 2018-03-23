using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanDTO
    {
        private string maBan;
        private bool trangThai;

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

        public BanDTO()
        {
            MaBan = "";
            TrangThai = false;
        }
        public BanDTO(string maBan,bool trangThai)
        {
            this.MaBan = maBan;
            this.TrangThai = trangThai;
        }
        public BanDTO(DataRow row)
        {
            this.MaBan = (string)row["MABAN"];
            this.TrangThai = (bool)row["TRANGTHAI"];
        }
    }
}
