using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiPhongTro.DAO;
using QuanLiPhongTro.DTO;

namespace QuanLiPhongTro
{
    public partial class UserControlDV : UserControl
    {
        public UserControlDV()
        {
            InitializeComponent();
            LoatData();
            LoatData_ComboboxIDDichVu();
        }
        void LoatData()
        {
            LoadList_Data_DichVu();
            LoadList_Data_HoaDon();
        }
        void LoadList_Data_DichVu()
        {
            string query = "select MaDichVu as 'Mã Dịch Vụ', TenDichVu as 'Tên dịch vụ' , PARSENAME(convert(varchar,convert(money,DonGia),1),2) as 'Đơn giá', DVT as 'Đơn vị tính'  from DichVu";
            dataGridView_DichVu.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        void LoadList_Data_HoaDon()
        {
            string query = "select MaHoaDon as 'Mã Hóa Đơn', Ngaylap as 'Ngày Lập' , PARSENAME(convert(varchar,convert(money,TongTien),1),2) as 'Tổng tiền', MakhachHang as 'Mã khách hàng'  from HoaDon";
            dataGridView_HoaDon.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }


        void LoatData_ComboboxIDDichVu()
        {
            List<DichVu> list = Danhsach.ThongKe.Instance.ListDichVu();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "MADICHVU";
        }

        private void btn_ThemDV_Click(object sender, EventArgs e)
        {
            string ma = comboBox1.Text;
            string ten = txt_Tendichvu.Text;
            int dongia = 20000;
            if (txt_DongiaDV.Text.Length == 0)
            {
                try
                {
                    dongia = (int)Convert.ToDouble(txt_DongiaDV.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập đơn giá.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    dongia = (int)Convert.ToDouble(txt_DongiaDV.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập đơn giá không đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string dvt = txt_Donvitinh.Text;

            try
            {
                int madv = (int)Convert.ToDouble(ma);
                if (DAO.DichVuDAO.Instance.insertDichVu(madv, ten, dongia, dvt))
                {
                    MessageBox.Show("Thêm dịch vụ thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DichVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CapnhapDV_Click(object sender, EventArgs e)
        {
            string ma = comboBox1.Text;
            string ten = txt_Tendichvu.Text;
            int dongia = 20000;
            if (txt_DongiaDV.Text.Length == 0)
            {
                try
                {
                    dongia = (int)Convert.ToDouble(txt_DongiaDV.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập đơn giá.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    dongia = (int)Convert.ToDouble(txt_DongiaDV.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập đơn giá không đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string dvt = txt_Donvitinh.Text;

            try
            {
                int madv = (int)Convert.ToDouble(ma);
                if (DAO.DichVuDAO.Instance.updateDichVu(madv, ten, dongia, dvt))
                {
                    MessageBox.Show("Sửa dịch vụ thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DichVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_XoaDV_Click(object sender, EventArgs e)
        {
            string ma = comboBox1.Text;
            try
            {
                int madv = (int)Convert.ToDouble(ma);
                if (DAO.DichVuDAO.Instance.deleteDichVu(madv))
                {
                    MessageBox.Show("Xóa dịch vụ thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DichVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_ThemHĐ_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahoadon.ToString();
            DateTime ngay = dateTimePicker1.Value;

        }

        private void btn_CapnhapHĐ_Click(object sender, EventArgs e)
        {

        }
    }
}
