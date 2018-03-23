using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaSanXuatDAL
    {
        private static NhaSanXuatDAL instance;

        public static NhaSanXuatDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhaSanXuatDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private NhaSanXuatDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_NSX");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.NhaSanXuatDTO nhaSanXuat)
        {
            string query = string.Format("EXEC dbo.UPDATE_NHASANXUAT @MANSX = '{0}', @TENNSX = N'{1}', @QUOCGIA = N'{2}'",nhaSanXuat.MaNSX,nhaSanXuat.TenNSX,nhaSanXuat.QuocGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maNSX)
        {
            string query = string.Format("EXEC DBO.DELETE_NHASANXUAT @MANSX ='{0}' ",maNSX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.NhaSanXuatDTO nhaSanXuat)
        {
            string query = string.Format("EXEC dbo.INSERT_NHASANXUAT @MANSX = '{0}',@TENNSX = N'{1}',@QUOCGIA = N'{2}'",nhaSanXuat.MaNSX,nhaSanXuat.TenNSX,nhaSanXuat.QuocGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
