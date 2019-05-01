using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class Phong
    {
        private string MaPhong;
        private string TenPhong;
        private string GhiChu;
        private int MaLoaiPhong;
        public Phong(string MaPhong, string TenPhong, string GhiChu, int MaLoaiPhong)
        {
            this.MaPhong = MaPhong;
            this.TenPhong = TenPhong;
            this.GhiChu = GhiChu;
            this.MaLoaiPhong = MaLoaiPhong;
        }
        public Phong(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.TenPhong = row["TenPhong"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.MaLoaiPhong = (int)row["MaLoaiPhong"];
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
        
        public int MALOAIPHONG
        {
            get
            {
                return this.MaLoaiPhong;
            }
            set
            {
                this.MaLoaiPhong = value;
            }
        }

    }
}
