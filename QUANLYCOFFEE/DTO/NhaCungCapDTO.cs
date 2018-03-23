using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        private string maNCC;
        private string tenNCC;
        private string dienThoai;

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

        public string TenNCC
        {
            get
            {
                return tenNCC;
            }

            set
            {
                tenNCC = value;
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
        public NhaCungCapDTO()
        {
            this.maNCC = "";
            this.tenNCC = "";
            this.dienThoai = "";
        }
        public NhaCungCapDTO(string maNCC,string tenNCC,string dienThoai)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.dienThoai = dienThoai;
        }
        public NhaCungCapDTO(DataRow row)
        {
            this.maNCC = (string)row["MANCC"];
            this.tenNCC = (string)row["TENNCC"];
            this.dienThoai = (string)row["DIENTHOAI"];
        }
    }
}
