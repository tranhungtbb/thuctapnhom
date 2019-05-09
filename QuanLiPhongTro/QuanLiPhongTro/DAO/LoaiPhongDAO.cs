using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instance;

        public static LoaiPhongDAO Instance
        {
            get
            {
                if (instance == null) instance = new LoaiPhongDAO();
                return LoaiPhongDAO.instance;
            }
            private set { LoaiPhongDAO.instance = value; }
        }
        public LoaiPhongDAO() { }

        public bool insertLoaiPhong(int ma, string ten, int dt, string mota, int dongia, int sl)
        {
            int i = 0;
            string query = string.Format("insert into LoaiPhong values('{0}',N'{1}','{2}',N'{3}','{4}','{5}')", ma, ten, dt, mota,dongia,sl);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateLoaiPhong(int ma, string ten, int dt, string mota, int dongia, int sl)
        {
            int i = 0;
            string query = string.Format("update LoaiPhong set TenLoaiPhong = N'{0}', DienTich = '{1}' , MoTa = N'{2}', DonGia ='{3}', SoLuongToiDa = '{4}' where MaLoaiPhong = '{5}'", ten, dt, mota, dongia, sl, ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteLoaiPhong(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_LoaiPhong '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
    }
}
