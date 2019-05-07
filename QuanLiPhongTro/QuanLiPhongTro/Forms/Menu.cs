using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongTro.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            UserControlHome home = new UserControlHome();
            panelControl.Controls.Add(home);
            home.Dock = DockStyle.Fill;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát hay không?", " Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                DangNhap d = new DangNhap();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label_tital.Text = "Home";
            UserControlHome home = new UserControlHome();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(home);
            home.Dock = DockStyle.Fill;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //userControlDanhMuc1.BringToFront();
            label_tital.Text = "Danh mục";
            UserControlDanhMuc danhmuc = new UserControlDanhMuc();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(danhmuc);
            danhmuc.Dock = DockStyle.Fill;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //userControlThueMoi1.BringToFront();
            label_tital.Text = "Thuê mới";
            UserControlThueMoi thuemoi = new UserControlThueMoi();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(thuemoi);
            thuemoi.Dock = DockStyle.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //userControlDV1.BringToFront();
            label_tital.Text = "Dịch vụ";
            UserControlDV dichvu = new UserControlDV();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(dichvu);
            dichvu.Dock = DockStyle.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label_tital.Text = "Thống kê";
            UserControlThongKe thongke = new UserControlThongKe();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(thongke);
            thongke.Dock = DockStyle.Fill;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_tital.Text = "Doanh thu";
            UserControlDoanhThu doanhthu = new UserControlDoanhThu();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(doanhthu);
            doanhthu.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label_tital.Text = "Trợ giúp";
            UserControlTroGiup trogiup = new UserControlTroGiup();
            panelControl.Controls.Clear();
            panelControl.Controls.Add(trogiup);
            trogiup.Dock = DockStyle.Fill;
        }

        
    }
}
