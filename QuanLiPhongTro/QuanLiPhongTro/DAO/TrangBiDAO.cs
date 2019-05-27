using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class TrangBiDAO
    {
        private static TrangBiDAO instance;

        public static TrangBiDAO Instance
        {
            get
            {
                if (instance == null) instance = new TrangBiDAO();
                return TrangBiDAO.instance;
            }
            private set { TrangBiDAO.instance = value; }
        }
        public TrangBiDAO() { }

        public bool insertTrangBi(string maphong, int matb, int sl) //insert into ThietBi values('1', N'Quạt trần','',''),
        {
            int i = 0;
            string query = string.Format("insert into TrangBi values('{0}','{1}','{2}')", maphong, matb, sl);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateTrangBi(string maphong, int matb, int sl)
        {
            int i = 0;
            string query = string.Format("update TrangBi set Soluong = '{0}' where MaPhong = '{1}' and MaThietBi = '{2}'", sl,maphong,matb);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteTrangBi(string maphong, int matb)
        {
            int i = 0;
            string query = string.Format("delete TrangBi where MaPhong ='{0}' and MaThietBi ='{1}'", maphong,matb);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
    }
}
