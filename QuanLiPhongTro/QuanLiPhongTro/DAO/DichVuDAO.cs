using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get
            {
                if (instance == null) instance = new DichVuDAO();
                return DichVuDAO.instance;
            }
            private set { DichVuDAO.instance = value; }
        }
        public DichVuDAO() { }

        public bool insertDichVu(int ma, string ten, int dongia, string dvt) //insert into ThietBi values('1', N'Quạt trần','',''),
        {
            int i = 0;
            string query = string.Format("insert into DichVu values('{0}',N'{1}','{2}',N'{3}')", ma, ten, dongia, dvt);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateDichVu(int ma, string ten, int dongia, string dvt)
        {
            int i = 0;
            string query = string.Format("update DichVu set TenDichVu = N'{0}', DonGia = '{1}' , DVT = N'{2}' where MaDichVu = '{3}'", ten, dongia, dvt, ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteDichVu(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_DichVu '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
    }
}
