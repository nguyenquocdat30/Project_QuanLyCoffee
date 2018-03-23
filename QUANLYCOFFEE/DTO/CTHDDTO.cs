using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDDTO
    {
        private string maHD;
        private string maSP;
        private int soLuong;

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

        public string MaSP
        {
            get
            {
                return maSP;
            }

            set
            {
                maSP = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public CTHDDTO()
        {
            this.maHD = "";
            this.maSP = "";
            this.soLuong = 0;
        }
        public CTHDDTO(string maHD,string maSP,int soLuong)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
        }
        public CTHDDTO(DataRow row)
        {
            this.maHD = (string)row["MAHD"];
            this.maSP = (string)row["MASP"];
            this.soLuong = (int)row["SOLUONG"];
        }
    }
}
