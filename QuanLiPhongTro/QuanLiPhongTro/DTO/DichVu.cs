using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongTro.DTO
{
    public class DichVu
    {
        private string MaDichVu;
        private string TenDichVu;
        private int DonGia;
        private string DVT;
        public DichVu(string ma, string ten, int dongia, string dvt)
        {
            this.MaDichVu = ma;
            this.TenDichVu = ten;
            this.DonGia = dongia;
            this.DVT = dvt;
        }
        public DichVu(DataRow row)
        {
            this.MaDichVu = row["MaDichVu"].ToString();
            this.TenDichVu = row["TenDichVu"].ToString();
            this.DonGia = (int)row["DonGia"];
            this.DVT = row["DVT"].ToString();
        }
        public string MADICHVU
        {
            get
            {
                return this.MaDichVu;
            }
            set
            {
                this.MaDichVu = value;
            }
        }
        public string TENDICHVU
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
        public string DONIINH
        {
            get
            {
                return this.DVT;
            }
            set
            {
                this.DVT = value;
            }
        }
    }
}
