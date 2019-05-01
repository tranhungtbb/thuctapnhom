using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class PhongTrong
    {
        private string MaPhong;
        private string TenPhong;
        private int DienTich;
        private int DonGia;
        private int SoLuongToiDa;
        private string MoTa;
        public PhongTrong(string MaPhong, string TenPhong, int dt, int dg, int sl, string mota)
        {
            this.MaPhong = MaPhong;
            this.TenPhong = TenPhong;
            this.DienTich = dt;
            this.DonGia = dg;
            this.SoLuongToiDa = sl;
            this.MoTa = mota;
        }
        public PhongTrong(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.TenPhong = row["TenPhong"].ToString();
            this.DienTich = (int)row["DienTich"];
            this.DonGia = (int)row["DonGia"];
            this.SoLuongToiDa = (int)row["SoLuongToiDa"];
            this.MoTa = row["MoTa"].ToString();
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
        public int DIENTICH
        {
            get
            {
                return this.DienTich;
            }
            set
            {
                this.DienTich = value;
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
        public int SL
        {
            get
            {
                return this.SoLuongToiDa;
            }
            set
            {
                this.SoLuongToiDa = value;
            }
        }
        public string MOTA
        {
            get
            {
                return this.MoTa;
            }
            set
            {
                this.MoTa = value;
            }
        }

    }
}
