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

namespace QuanLiPhongTro
{
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
            ShowListPhongTrong();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void ShowListPhongTrong()
        {
            listView_Phongtrong.Items.Clear();

            List<QuanLiPhongTro.DTO.PhongTrong> listPT = Danhsach.ThongKe.Instance.ListPTr();
            foreach (QuanLiPhongTro.DTO.PhongTrong i in listPT)
            {
                ListViewItem lvItem = new ListViewItem(i.MAPHONG.ToString());
                lvItem.SubItems.Add(i.TENPHONG.ToString());
                lvItem.SubItems.Add(i.DIENTICH.ToString());
                //lvItem.SubItems.Add(i.DONGIA.ToString());
                lvItem.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}",i.DONGIA));
                lvItem.SubItems.Add(i.SL.ToString());
                lvItem.SubItems.Add(i.MOTA.ToString());
                

                listView_Phongtrong.Items.Add(lvItem);
            }
        }

    }
}
