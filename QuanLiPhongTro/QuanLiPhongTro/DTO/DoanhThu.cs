using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
   public class DoanhThu
    {
        private string MaPhong;
        private string TenPhong;
        private string HoTen;
        private int DonGia;
        private int DVKhac;
        private int DienNuoc;
        private int ThanhTien;
        public DoanhThu(string ma, string tenp, string kh,int dongia, int dvk, int dien, int tt)
        {
            this.MaPhong = ma;
            this.TenPhong = tenp;
            this.HoTen = kh;
            this.DonGia = dongia;
            this.DVKhac = dvk;
            this.DienNuoc = dien;
            this.ThanhTien = tt;
        }
        public DoanhThu(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.TenPhong = row["TenPhong"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.DonGia = (int)row["DonGia"];
            this.DVKhac = (int)row["DVKhac"];
            this.DienNuoc = (int)row["DienNuoc"];
            this.ThanhTien = (int)row["TongTien"];
        }
        public string MA
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
        public string TENP
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
        public string KH
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
        public int DVKHAC
        {
            get
            {
                return this.DVKhac;
            }
            set
            {
                this.DVKhac = value;
            }
        }
        public int DIENNUOC
        {
            get
            {
                return this.DienNuoc;
            }
            set
            {
                this.DienNuoc = value;
            }
        }
        public int TT
        {
            get
            {
                return this.ThanhTien;
            }
            set
            {
                this.ThanhTien = value;
            }
        }



    }
}
