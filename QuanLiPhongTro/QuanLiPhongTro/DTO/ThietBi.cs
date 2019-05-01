using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class ThietBi
    {
        private string MaThietBi;
        private string TenThietBi;
        private string TinhTrang;
        private string GhiChu;
        public ThietBi(string ma, string ten, string tt, string gc)
        {
            this.MaThietBi = ma;
            this.TenThietBi = ten;
            this.TinhTrang = tt;
            this.GhiChu = gc;
        }
        public ThietBi(DataRow row)
        {
            this.MaThietBi = row["MaThietBi"].ToString();
            this.TenThietBi = row["TenThietBi"].ToString();
            this.TinhTrang = row["TinhTrang"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
        public string MATHIETBI
        {
            get
            {
                return this.MaThietBi;
            }
            set
            {
                this.MaThietBi = value;
            }
        }
        public string TENTHIETBI
        {
            get
            {
                return this.TenThietBi;
            }
            set
            {
                this.TenThietBi = value;
            }
        }
        public string TINHTRANG
        {
            get
            {
                return this.TinhTrang;
            }
            set
            {
                this.TinhTrang = value;
            }
        }
        public string GHICHU
        {
            get
            {
                return this.GhiChu;
            }
            set
            {
                this.GhiChu = value;
            }
        }
    }
}
