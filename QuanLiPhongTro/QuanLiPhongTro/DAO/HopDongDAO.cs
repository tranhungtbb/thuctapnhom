using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class HopDongDAO
    {
        private static HopDongDAO instance;

        public static HopDongDAO Instance
        {
            get
            {
                if (instance == null) instance = new HopDongDAO();
                return HopDongDAO.instance;
            }
            private set { HopDongDAO.instance = value; }
        }
        public HopDongDAO() { }

        public bool insertHopDong(int ma, DateTime ngaybd, int tg, int tiencoc, string ghichu, string maphong,int makh)
        {
            int i = 0;
            string query = string.Format("insert into HopDong values('{0}','{1}','{2}','{3}',N'{4}',N'{5}','{6}')", ma, ngaybd, tg, tiencoc, ghichu, maphong, makh);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateHopDong(int ma, DateTime ngaybd, int tg, int tiencoc, string ghichu, string maphong, int makh)
        {
            int i = 0;
            string query = string.Format("update HopDong set NgayBatDau = '{0}', ThoiGianThue = '{1}' , TienCoc = '{2}', GhiChu =N'{3}', MaPhong = '{4}',MaKhachHang = '{5}' where MaHopDong = '{6}'", ngaybd, tg, tiencoc, ghichu, maphong, makh,ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteHopDong(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_HopDong '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
    }
}
