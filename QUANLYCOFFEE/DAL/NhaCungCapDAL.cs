using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhaCungCapDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private NhaCungCapDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_NCC");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.NhaCungCapDTO nhaCungCap)
        {
            string query = string.Format("EXEC dbo.UPDATE_NHACUNGCAP @MANCC = '{0}', @TENNCC = N'{1}',@DIENTHOAI = '{2}'",nhaCungCap.MaNCC,nhaCungCap.TenNCC,nhaCungCap.DienThoai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maNCC)
        {
            string query = string.Format("EXEC dbo.DELETE_NHACUNGCAP @MANCC = '{0}' ",maNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.NhaCungCapDTO nhaCungCap)
        {
            string query = string.Format("EXEC dbo.INSERT_NHACUNGCAP @MANCC = '{0}',@TENNCC = N'{1}', @DIENTHOAI = '{2}'",nhaCungCap.MaNCC,nhaCungCap.TenNCC,nhaCungCap.DienThoai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
