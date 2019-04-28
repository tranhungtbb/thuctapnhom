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
            userControlHome2.BringToFront();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControlHome2.BringToFront();
            label_tital.Text = "Home";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            userControlDanhMuc1.BringToFront();
            label_tital.Text = "Danh mục";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userControlThueMoi1.BringToFront();
            label_tital.Text = "Thuê mới";
        }
    }
}
