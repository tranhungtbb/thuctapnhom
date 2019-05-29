using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class PhongCoNguoi
    {
        private string MaPhong;
        private string TenPhong;
        private int DonGia;
        private int MaKH;
        private string HoTen;
        public PhongCoNguoi(string MaPhong, string TenPhong, int dg, int makh, string hten)
        {
            this.MaPhong = MaPhong;
            this.TenPhong = TenPhong;
            this.DonGia = dg;
            this.MaKH = makh;
            this.HoTen = hten;
        }
        public PhongCoNguoi(DataRow row)
        {
            
            this.MaPhong = row["MaPhong"].ToString();
            this.TenPhong = row["TenPhong"].ToString();
            this.DonGia = (int)row["DonGia"];
            this.MaKH = (int)row["MaKhachHang"];
            this.HoTen = row["HoTen"].ToString();
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
        public string TENPHONG
        {
            get
            {
                return this.TenPhong;
            }
            set
            {
                this.TenPhong = value;
            }
        }
        public int DONGIA
        {
            get
            {
                return this.DonGia;
            }
            set
            {
                this.DonGia = value;
            }
        }
        public int MAKH
        {
            get
            {
                return this.MaKH;
            }
            set
            {
                this.MaKH = value;
            }
        }
        public string HOTEN
        {
            get
            {
                return this.HoTen;
            }
            set
            {
                this.HoTen = value;
            }
        }
    }
}
