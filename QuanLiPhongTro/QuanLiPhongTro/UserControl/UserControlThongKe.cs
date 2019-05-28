using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiPhongTro.DTO;
using System.Globalization;

namespace QuanLiPhongTro
{
    public partial class UserControlThongKe : UserControl
    {
        int tongtien=0;
        public UserControlThongKe()
        {
            InitializeComponent();
            List_Combobox_IDPhong1();
            List_Combobox_IDPhong2();
            label9.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongtien);

        }
        public void List_Combobox_IDPhong1()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhong();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "MaPhong";
        }
        public void List_Combobox_IDPhong2()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhong();
            comboBox3.DataSource = list;
            comboBox3.DisplayMember = "MaPhong";
        }
        public void ShowListView_KhachHang(string maphong)
        {
            listView1.Items.Clear();

            List<KhachHang> listPT = Danhsach.ThongKe.Instance.ListKhachHangofPhong(maphong);
            foreach (KhachHang i in listPT)
            {
                ListViewItem lvItem = new ListViewItem(i.MAKHACHHANG.ToString());
                lvItem.SubItems.Add(i.TENKHACHHANG.ToString());
                lvItem.SubItems.Add(i.NGAYSINH.ToString());
                lvItem.SubItems.Add(i.GIOITINH.ToString());
                lvItem.SubItems.Add(i.QUEQUAN.ToString());
                lvItem.SubItems.Add(i.SDTHOAI.ToString());
                lvItem.SubItems.Add(i.SOCM.ToString());
                lvItem.SubItems.Add(i.MAPHONG.ToString());
                
                listView1.Items.Add(lvItem);
            }
        }
        public void ShowListView_ChiTietHoaDon(string maphong, int thang)
        {
            listView_CTDVK.Items.Clear();

            List<CTHoaDon> listPT = Danhsach.ThongKe.Instance.ListCTHoaDon(maphong, thang);
            int j = 0;
            foreach (CTHoaDon i in listPT)
            {
                j++;
                ListViewItem lvItem = new ListViewItem(j.ToString());
                lvItem.SubItems.Add(i.TEN.ToString());
                lvItem.SubItems.Add(i.SLUONG.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.DONGIA));
                lvItem.SubItems.Add(i.DVT.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.TT));
                tongtien += i.TT;
                listView_CTDVK.Items.Add(lvItem);
            }
        }
        public void ShowListView_ChiTietDienNuoc(string maphong, int thang)
        {
            listView_CTĐN.Items.Clear();

            List<CTDienNuoc> listPT = Danhsach.ThongKe.Instance.ListCTDienNuoc(maphong, thang);
            int j = 0;
            foreach (CTDienNuoc i in listPT)
            {
                j++;
                ListViewItem lvItem = new ListViewItem(j.ToString());
                lvItem.SubItems.Add(i.TEN.ToString());
                lvItem.SubItems.Add(i.CHISOCU.ToString());
                lvItem.SubItems.Add(i.CHISOMOI.ToString());
                lvItem.SubItems.Add(i.SUDUNG.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.DONGIA));
                lvItem.SubItems.Add(i.DVT.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.TT));
                tongtien += i.TT;
                listView_CTĐN.Items.Add(lvItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = comboBox3.Text;
            ShowListView_KhachHang(ma);
            DataTable a = Danhsach.ThongKe.Instance.SoLuongNguoiToiDaOfPhong(ma);
            sl.Text = a.Rows[0][0].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ma =comboBox1.Text;
            string t = comboBox2.Text;
            int thang = (int)Convert.ToDouble(t);
            ShowListView_ChiTietHoaDon(ma,thang);
            ShowListView_ChiTietDienNuoc(ma,thang);
            label9.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongtien);
        }
    }
}
