using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class CTDienNuoc
    {
        private string TenDichVu;
        private int ChiSoCu;
        private int ChiSoMoi;
        private int SuDung;
        private int DonGia;
        private string DonViTinh;
        private int ThanhTien;
        public CTDienNuoc(string ten, int cu,int moi, int sd, int dongia, string dvt, int tt)
        {
            this.TenDichVu = ten;
            this.ChiSoCu = cu;
            this.ChiSoMoi = moi;
            this.SuDung = sd;
            this.DonGia = dongia;
            this.DonViTinh = dvt;
            this.ThanhTien = tt;
        }
        public CTDienNuoc(DataRow row)
        {
            this.TenDichVu = row["TenDichVu"].ToString();
            this.ChiSoCu = (int)row["ChiSoCu"];
            this.ChiSoMoi = (int)row["ChiSoMoi"];
            this.SuDung = (int)row["SuDung"];
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

        public int CHISOCU
        {
            get
            {
                return this.ChiSoCu;
            }
            set
            {
                this.ChiSoCu = value;
            }
        }
        public int CHISOMOI
        {
            get
            {
                return this.ChiSoMoi;
            }
            set
            {
                this.ChiSoMoi = value;
            }
        }
        public int SUDUNG
        {
            get
            {
                return this.SuDung;
            }
            set
            {
                this.SuDung = value;
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
