using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class ThietBiDAO
    {
        private static ThietBiDAO instance;

        public static ThietBiDAO Instance
        {
            get
            {
                if (instance == null) instance = new ThietBiDAO();
                return ThietBiDAO.instance;
            }
            private set { ThietBiDAO.instance = value; }
        }
        public ThietBiDAO() { }

        public bool insertThietBi(int ma, string ten, string tinhtrang, string ghichu) //insert into ThietBi values('1', N'Quạt trần','',''),
        {
            int i = 0;
            string query = string.Format("insert into ThietBi values('{0}',N'{1}',N'{2}',N'{3}')", ma, ten,tinhtrang,ghichu);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateThietBi(int ma, string ten, string tinhtrang, string ghichu)
        {
            int i = 0;
            string query = string.Format("update ThietBi set TenThietBi = N'{0}', TinhTrang = N'{1}' , GhiChu = N'{2}' where MaThietBi = '{3}'", ten,tinhtrang,ghichu, ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteThietBi(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_ThietBi '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
    }
}
