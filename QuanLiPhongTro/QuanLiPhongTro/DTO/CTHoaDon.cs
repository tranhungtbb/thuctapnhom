using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class CTHoaDon
    {
        private string TenDichVu;
        private int SL;
        private int DonGia;
        private string DonViTinh;
        private int ThanhTien;
        public CTHoaDon(string ten, int sl, int dongia,string dvt, int tt)
        {
            this.TenDichVu = ten;
            this.SL = sl;
            this.DonGia = dongia;
            this.DonViTinh = dvt;
            this.ThanhTien = tt;
        }
        public CTHoaDon(DataRow row)
        {
            this.TenDichVu = row["TenDichVu"].ToString();
            this.SL = (int)row["SoLuong"];
            this.DonGia = (int)row["DonGia"];
            this.DonViTinh = row["DVT"].ToString();
            this.ThanhTien = (int)row["ThanhTien"];
        }
        public string TEN
        {
            get
            {
                return this.TenDichVu;
            }
            set
            {
                this.TenDichVu = value;
            }
        }
        public int SLUONG
        {
            get
            {
                return this.SL;
            }
            set
            {
                this.SL = value;
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
        public string DVT
        {
            get
            {
                return this.DonViTinh;
            }
            set
            {
                this.DonViTinh = value;
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
