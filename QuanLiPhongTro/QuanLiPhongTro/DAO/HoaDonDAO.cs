using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDAO();
                return HoaDonDAO.instance;
            }
            private set { HoaDonDAO.instance = value; }
        }
        public HoaDonDAO() { }

        public bool insertHoaDon( DateTime ngaylap, int makhachhang) //insert into ThietBi values('1', N'Quạt trần','',''),
        {
            int i = 0;
            string query = string.Format("insert into HoaDon values('{0}','{1}')", ngaylap,makhachhang);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateHoaDon(int ma, DateTime ngaylap, int makhachhang)
        {
            int i = 0;
            string query = string.Format("update HoaDon set NgayLap = '{0}', MaKhachHang = '{1}' where MaHoaDon = '{2}'", ngaylap,makhachhang, ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteHoaDon(int ma)
        {
            int i = 0;
            string query = string.Format("Delete_HoaDon '{0}'", ma);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }

        //////////////////////////////////////////////////////

        public bool insertChiTietDienNuoc(int mahd, int madv, int chisocu, int chisomoi) //insert into ThietBi values('1', N'Quạt trần','',''),
        {
            int i = 0;
            string query = string.Format("insert into ChiTietDienNuoc values ('{0}','{1}','{2}','{3}')", madv, mahd,chisocu, chisomoi );
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool updateChiTietDienNuoc(int mahd, int madv, int chisocu, int chisomoi)
        {
            int i = 0;
            string query = string.Format("update ChiTietDienNuoc set ChiSoCu = '{0}', ChiSoMoi = '{1}' where MaHoaDon = '{2}' and MaDichVu = '{3}'", chisocu, chisomoi, mahd,madv);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }
        public bool deleteChiTietDienNuoc(int mahd, int madv)
        {
            int i = 0;
            string query = string.Format("Delete_ChiTietDienNuoc '{0}','{1}'", mahd,madv);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }

        /////////////////////////////////////////////////////

        public bool insertChiTietHoaDon(int mahd, int madv, int sl)
        {
            int i = 0;
            string query = string.Format("insert into ChiTietHoaDon values('{0}','{1}','{2}')", madv, mahd, sl);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }

        public bool updateChiTietHoaDon(int mahd, int madv, int sl)
        {
            int i = 0;
            string query = string.Format("update ChiTietHoaDon set SoLuong  = '{0}' where MaDichVu = '{1}' and MaHoaDon = {2}", sl, madv, mahd);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }

        public bool deleteChiTietHoaDon(int mahd, int madv)
        {
            int i = 0;
            string query = string.Format("Delete_ChiTietHoaDon '{0}','{1}'", mahd, madv);
            i = SQL.ThuVienSQL.Instance.Execute_NonQuery(query);
            return i > 0;
        }

    }
}
