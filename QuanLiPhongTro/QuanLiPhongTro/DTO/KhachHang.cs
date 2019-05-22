using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class KhachHang
    {
        private int MaKhachHang;
        private string TenKhachHang;
        private DateTime NgaySinh;
        private string GioiTinh;
        private string QueQuan;
        private int SDT;
        private int SCM;
        private string MaPhong;
        public KhachHang( int ma,string ten, DateTime ns, string gt,string qq, int sdt,int cmt, string maphong)
        {
            this.MaKhachHang = ma;
            this.TenKhachHang = ten;
            this.NgaySinh = ns;
            this.GioiTinh = gt;
            this.QueQuan = qq;
            this.SDT = sdt;
            this.SCM = cmt;
            this.MaPhong = maphong;
        }
        public KhachHang(DataRow row)
        {
            this.MaKhachHang = (int)row["MaKhachHang"];
            this.TenKhachHang = row["HoTen"].ToString();
            this.NgaySinh = Convert.ToDateTime(row["NgaySinh"].ToString());
            this.GioiTinh = row["GioiTinh"].ToString();
            this.QueQuan = row["QueQuan"].ToString();
            this.SDT = (int)row["SDT"];
            this.SCM = (int)row["CMND"];
            this.MaPhong = row["MaPhong"].ToString();
            
        }
        public int MAKHACHHANG
        {
            get
            {
                return this.MaKhachHang;
            }
            set
            {
                this.MaKhachHang = value;
            }
        }
        public string TENKHACHHANG
        {
            get
            {
                return this.TenKhachHang;
            }
            set
            {
                this.TenKhachHang = value;
            }
        }
        public DateTime NGAYSINH
        {
            get
            {
                return this.NgaySinh;
            }
            set
            {
                this.NgaySinh = value;
            }
        }
        public string GIOITINH
        {
            get
            {
                return this.GioiTinh;
            }
            set
            {
                this.GioiTinh = value;
            }
        }
        public string QUEQUAN
        {
            get
            {
                return this.QueQuan;
            }
            set
            {
                this.QueQuan = value;
            }
        }
        public int SDTHOAI
        {
            get
            {
                return this.SDT;
            }
            set
            {
                this.SDT = value;
            }
        }
        public int SOCM
        {
            get
            {
                return this.SCM;
            }
            set
            {
                this.SCM = value;
            }
        }
        public string MAPHONG
        {
            get
            {
                return this.MaPhong;
            }
            set
            {
                this.MaPhong = value;
            }
        }
        
    }
}
