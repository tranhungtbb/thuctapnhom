using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using QuanLiPhongTro.DTO;

namespace QuanLiPhongTro
{
    public partial class UserControlDoanhThu : UserControl
    {
        int tongtien = 0;
        public UserControlDoanhThu()
        {
            InitializeComponent();
        }
        public void ShowListView_DoanhThu(int thang)
        {
            listView_DT.Items.Clear();

            List<DoanhThu> listPT = Danhsach.ThongKe.Instance.ListDoanhThu(thang);
            int j = 0;
            foreach (DoanhThu i in listPT)
            {
                j++;
                ListViewItem lvItem = new ListViewItem(j.ToString());
                lvItem.SubItems.Add(i.MA.ToString());
                lvItem.SubItems.Add(i.TENP.ToString());
                lvItem.SubItems.Add(i.KH.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.DONGIA));
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.DIENNUOC));
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.DVKHAC));
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", i.TT));
                tongtien += i.TT;
                listView_DT.Items.Add(lvItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = comboBox1.Text;
            int thang = (int)Convert.ToDouble(t);
            ShowListView_DoanhThu(thang);
            label5.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongtien);
        }
    }
}
