using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangDAO();
                return KhachHangDAO.instance;
            }
            private set { KhachHangDAO.instance = value; }
        }
        public KhachHangDAO() { }

        public bool insertKhachHang(int ma, string ten, DateTime ns, string gt, string quequan, int sdt, int cm, int stt, string maphong)
        {
            int i = 0;
            string query = string.Format("insert into KhachHang values('{0}',N'{1}','{2}',N'{3}',N'{4}','{5}','{6}','{7}',N'{8}')", ma, ten, ns, gt, quequan, sdt,cm,stt,maphong);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateKhachHang(int ma, string ten, DateTime ns, string gt, string quequan, int sdt, int cm, int stt, string maphong)
        {
            int i = 0;
            string query = string.Format("update KhachHang set HoTen = N'{0}', NgaySinh = '{1}' , GioiTinh = N'{2}', QueQuan =N'{3}', SDT = '{4}',CMND = '{5}',Status = '{6}',MaPhong = N'{7}' where MaKhachHang = '{8}'", ten, ns, gt, quequan, sdt, cm, stt, maphong,ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        // xoa khach hang
        public bool deleteKhachHang(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_KhachHang '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public DataTable searchKhachHang(string ten)
        {
            DataTable table = new DataTable();
            string query = string.Format("Search_KhachHang '{0}'", ten);
            table = SQL.ThuVienSQL.Instance.Execute_Query(query);
            return table;
            
        }
    }
}
