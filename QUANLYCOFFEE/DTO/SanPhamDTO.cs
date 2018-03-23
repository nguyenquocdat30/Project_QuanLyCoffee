using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        private string maSP;
        private string tenSP;
        private int soLuongTonKho;
        private string ngaySX;
        private string hanSuDung;
        private int donGia;
        private string moTa;
        private string maNSX;
        private string maNCC;

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

        public string TenSP
        {
            get
            {
                return tenSP;
            }

            set
            {
                tenSP = value;
            }
        }

        public int SoLuongTonKho
        {
            get
            {
                return soLuongTonKho;
            }

            set
            {
                soLuongTonKho = value;
            }
        }

        public string NgaySX
        {
            get
            {
                return ngaySX;
            }

            set
            {
                ngaySX = value;
            }
        }

        public string HanSuDung
        {
            get
            {
                return hanSuDung;
            }

            set
            {
                hanSuDung = value;
            }
        }

        public int DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public string MoTa
        {
            get
            {
                return moTa;
            }

            set
            {
                moTa = value;
            }
        }

        public string MaNSX
        {
            get
            {
                return maNSX;
            }

            set
            {
                maNSX = value;
            }
        }

        public string MaNCC
        {
            get
            {
                return maNCC;
            }

            set
            {
                maNCC = value;
            }
        }
        public SanPhamDTO()
        {
            this.maSP = "";
            this.tenSP = "";
            this.soLuongTonKho = 0;
            this.ngaySX = "";
            this.hanSuDung = "";
            this.donGia = 0;
            this.moTa = "";
            this.maNSX = "";
            this.maNCC = "";
        }
        public SanPhamDTO(string maSP,string tenSP,int soLuongTonKho,string ngaySX,
            string hanSuDung,int donGia,string moTa,string maNSX,string maNCC)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.soLuongTonKho = soLuongTonKho;
            this.ngaySX = ngaySX;
            this.hanSuDung = hanSuDung;
            this.donGia = donGia;
            this.moTa = moTa;
            this.maNSX = maNSX;
            this.maNCC = maNCC;
        }
        public SanPhamDTO(DataRow row)
        {
            this.maSP = (string)row["MASP"];
            this.tenSP = (string)row["TENSP"];
            this.soLuongTonKho = (int)row["SOLUONGTONKHO"];
            this.ngaySX = (string)row["NGAYSX"];
            this.hanSuDung = (string)row["HANSUDUNG"];
            this.donGia = (int)row["DONGIA"];
            this.moTa = (string)row["MOTA"];
            this.maNSX = (string)row["MANSX"];
            this.maNCC = (string)row["MANCC"];
        }
    }
}
