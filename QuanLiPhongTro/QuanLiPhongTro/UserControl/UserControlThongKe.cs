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

namespace QuanLiPhongTro
{
    public partial class UserControlThongKe : UserControl
    {
        public UserControlThongKe()
        {
            InitializeComponent();
            List_Combobox_IDPhong1();
            List_Combobox_IDPhong2();
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
        public void ShowListView_ChiTietHoaDon(string maphong)
        {
            listView2.Items.Clear();

            List<ThietBi> listPT = Danhsach.ThongKe.Instance.ListThietBiofPhong(maphong);
            foreach (ThietBi i in listPT)
            {
                ListViewItem lvItem = new ListViewItem(i.MATHIETBI.ToString());
                lvItem.SubItems.Add(i.TENTHIETBI.ToString());
                lvItem.SubItems.Add(i.TINHTRANG.ToString());
                lvItem.SubItems.Add(i.GHICHU.ToString());

                listView2.Items.Add(lvItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = comboBox3.Text;
            ShowListView_KhachHang(ma);
            DataTable a = Danhsach.ThongKe.Instance.SoLuongNguoiToiDaOfPhong(ma);
            sl.Text = a.Rows[0][0].ToString();
        }
    }
}
