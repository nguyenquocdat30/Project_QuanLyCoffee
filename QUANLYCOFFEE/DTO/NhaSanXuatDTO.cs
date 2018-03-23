using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaSanXuatDTO
    {
        private string maNSX;
        private string tenNSX;
        private string quocGia;

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

        public string TenNSX
        {
            get
            {
                return tenNSX;
            }

            set
            {
                tenNSX = value;
            }
        }

        public string QuocGia
        {
            get
            {
                return quocGia;
            }

            set
            {
                quocGia = value;
            }
        }
        public NhaSanXuatDTO()
        {
            this.maNSX = "";
            this.tenNSX = "";
            this.quocGia = "";
        }
        public NhaSanXuatDTO(string maNSX,string tenNSX,string quocGia)
        {
            this.maNSX = maNSX;
            this.tenNSX = tenNSX;
            this.quocGia = quocGia;
        }
        public NhaSanXuatDTO(DataRow row)
        {
            this.maNSX = (string)row["MANSX"];
            this.tenNSX = (string)row["TENNSX"];
            this.quocGia = (string)row["QUOCGIA"];
        }
    }
}
