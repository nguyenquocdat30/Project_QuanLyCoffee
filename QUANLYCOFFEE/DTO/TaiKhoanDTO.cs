using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Class TaiKhoanDTO
    /// Quản lý quán coffee Team DCH
    /// </summary>
    public class TaiKhoanDTO
    {
        private string userName;
        private string passWord;
        private bool quyenHan;

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

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public bool QuyenHan
        {
            get
            {
                return quyenHan;
            }

            set
            {
                quyenHan = value;
            }
        }

        public TaiKhoanDTO()
        {
            this.UserName = "";
            this.PassWord = "";
            this.QuyenHan = false;
        }
        public TaiKhoanDTO(string userName,string passWord,bool quyenHan)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            this.QuyenHan = quyenHan;
        }
        public TaiKhoanDTO(DataRow row)
        {
            this.UserName = (string)row["USERNAME"];
            this.PassWord = (string)row["PASSWORD"];
            this.QuyenHan = (bool)row["QUYENHAN"];
        }
    }
}
