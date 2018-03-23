using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string userName;
        private string maNV;
        private string hoNV;
        private string tenNV;
        private string ngaySinh;
        private bool gioiTinh;
        private string dienThoai;
        private string cmndNV;
        private string ngayVaoLam;

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

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public string HoNV
        {
            get
            {
                return hoNV;
            }

            set
            {
                hoNV = value;
            }
        }

        public string TenNV
        {
            get
            {
                return tenNV;
            }

            set
            {
                tenNV = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string DienThoai
        {
            get
            {
                return dienThoai;
            }

            set
            {
                dienThoai = value;
            }
        }

        public string CmndNV
        {
            get
            {
                return cmndNV;
            }

            set
            {
                cmndNV = value;
            }
        }

        public string NgayVaoLam
        {
            get
            {
                return ngayVaoLam;
            }

            set
            {
                ngayVaoLam = value;
            }
        }
        public NhanVienDTO()
        {
            this.userName = "";
            this.maNV = "";
            this.hoNV = "";
            this.tenNV = "";
            this.ngaySinh = "";
            this.gioiTinh = true;
            this.dienThoai = "";
            this.cmndNV = "";
            this.ngayVaoLam = "";
        }
        public NhanVienDTO(string userName,string maNV,string hoNV,string tenNV,
            string ngaySinh,bool gioiTinh,string dienThoai,string cmndNV,string ngayVaoLam)
        {
            this.userName = userName;
            this.maNV = maNV;
            this.hoNV = hoNV;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.dienThoai = dienThoai;
            this.cmndNV = cmndNV;
            this.ngayVaoLam = ngayVaoLam;
        }
        public NhanVienDTO(DataRow row)
        {
            this.userName = (string)row["USERNAME"];
            this.maNV = (string)row["MANV"];
            this.hoNV = (string)row["HONV"];
            this.tenNV = (string)row["TENNV"];
            this.ngaySinh = (string)row["NGAYSINH"];
            this.gioiTinh = (bool)row["GIOITINH"];
            this.dienThoai = (string)row["DIENTHOAI"];
            this.cmndNV = (string)row["CMND"];
            this.ngayVaoLam = (string)row["NGAYVAOLAM"];
        }
    }
}
