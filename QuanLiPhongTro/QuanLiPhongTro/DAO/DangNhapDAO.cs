using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;

        public static DangNhapDAO Instance
        {
            get
            {
                if (instance == null) instance = new DangNhapDAO();
                return DangNhapDAO.instance;
            }
            private set { DangNhapDAO.instance = value; }
        }
        public DangNhapDAO() { }
        public bool DangNhap(string ten, string mk)
        {
            int i = 0;
            string query = string.Format("DangNhap N'{0}', N'{1}'", ten, mk);
            DataTable t = new DataTable();
            t = SQL.ThuVienSQL.Instance.Execute_Query(query);
            i = t.Rows.Count;
            return i > 0;
        }
    }
}
