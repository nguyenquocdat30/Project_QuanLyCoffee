using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BanDAL
    {
        public static int tableWidth = 65;
        public static int tableHeight = 65;
        private static BanDAL instance;

        public static BanDAL Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BanDAL();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BanDAL() { }
        public DataTable LoadData()
        {
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_BAN");
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateData(DTO.BanDTO ban)
        {
            //string query = string.Format("UPDATE dbo.BAN SET TRANGTHAI = '{0}' WHERE MABAN = '{1}'",ban.TrangThai,ban.MaBan);
            string query = string.Format("EXEC dbo.UPDATE_TRANGTHAI_BAN @MABAN = '{0}',@TRANGTHAI = {1}", ban.MaBan, ban.TrangThai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteData(string maBan)
        {
            string query = string.Format("EXEC dbo.DELETE_BAN @MABAN = '{0}'",maBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertData(DTO.BanDTO ban)
        {
            string query = string.Format("EXEC dbo.INSERT_BAN @MABAN = '{0}', @TRANGTHAI = {1}",ban.MaBan,ban.TrangThai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<DTO.BanDTO> LoadTableList()
        {
            List<DTO.BanDTO> tableList = new List<DTO.BanDTO>();
            string query = string.Format("EXEC dbo.LOAD_DANHSACH_BAN");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.BanDTO table = new DTO.BanDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public bool LoadTrangThaiBanByMaBan(string maBan)
        {
            string query = string.Format("EXEC LOAD_TRANGTHAI_BY_MABAN @MABAN = '{0}'",maBan);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.BanDTO ban = new DTO.BanDTO(item);
                return ban.TrangThai;
            }
            return false;
        }
    }
}
