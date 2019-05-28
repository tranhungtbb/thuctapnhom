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
            LoatData_ComboboxDichVuKhac();
            LoatData_ComboboxDichVuDienNuoc();
        }
        void LoatData()
        {
            LoadList_Data_DichVu();
            LoadList_Data_HoaDon();
            LoadList_Data_DVKhac();
            LoadList_Data_DVDien();
        }
        void LoadList_Data_DichVu()
        {
            string query = "select MaDichVu as 'Mã Dịch Vụ', TenDichVu as 'Tên dịch vụ' , PARSENAME(convert(varchar,convert(money,DonGia),1),2) as 'Đơn giá', DVT as 'Đơn vị tính'  from DichVu";
            dataGridView_DichVu.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        void LoadList_Data_HoaDon()
        {
            string query = "select MaHoaDon as 'Mã Hóa Đơn', Ngaylap as 'Ngày Lập' , MakhachHang as 'Mã khách hàng'  from HoaDon";
            dataGridView_HoaDon.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        void LoadList_Data_DVDien()
        {
            string query = "select MaHoaDon as 'Mã Hóa Đơn', MaDichVu as 'Mã dịch vụ' , ChiSoCu as 'Chỉ số cũ' , ChiSoMoi as 'Chỉ số mới' from ChiTietDienNuoc";
            dataGridView3.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        void LoadList_Data_DVKhac()
        {
            string query = "select MaHoaDon as 'Mã Hóa Đơn', MaDichVu as 'Mã dịch vụ' , SoLuong as 'Số lượng'  from ChiTietHoaDon";
            dataGridView4.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }



        void LoatData_ComboboxIDDichVu()
        {
            List<DichVu> list = Danhsach.ThongKe.Instance.ListDichVu();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "MADICHVU";
        }
        void LoatData_ComboboxDichVuDienNuoc()
        {
            List<DichVu> list = Danhsach.ThongKe.Instance.ListDVDienNuoc();
            comb_MaDVDienNuoc.DataSource = list;
            comb_MaDVDienNuoc.DisplayMember = "TenDichVu";
            comb_MaDVDienNuoc.ValueMember = "MaDichVu";
        }
        void LoatData_ComboboxDichVuKhac()
        {
            List<DichVu> list = Danhsach.ThongKe.Instance.ListDVKhac();
            comb_MaDV_Khac.DataSource = list;
            comb_MaDV_Khac.DisplayMember = "TenDichVu";
            comb_MaDV_Khac.ValueMember = "MaDichVu";
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
            
            DateTime ngay = dateTimePicker1.Value;
            string makhach = comb_MaKH_HĐ.Text;
            try
            {
                int mamakhachH = (int)Convert.ToInt16(makhach);
                if (DAO.HoaDonDAO.Instance.insertHoaDon(ngay, mamakhachH))
                {
                    MessageBox.Show("Thêm hóa đơn thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_CapnhapHĐ_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahoadon.Text;
            DateTime ngay = dateTimePicker1.Value;
            string makhach = comb_MaKH_HĐ.Text;
            try
            {
                int mamakhachH = (int)Convert.ToInt16(makhach);
                int mahd = (int)Convert.ToInt16(ma);
                if (DAO.HoaDonDAO.Instance.updateHoaDon(mahd,ngay, mamakhachH))
                {
                    MessageBox.Show("Cập hóa đơn thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaHĐ_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahoadon.Text;
            
            try
            {
                
                int mahd = (int)Convert.ToInt16(ma);
                if (DAO.HoaDonDAO.Instance.deleteHoaDon(mahd))
                {
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThemDV_ĐN_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHDĐN.Text;
            string madv = comb_MaDVDienNuoc.SelectedValue.ToString();
            string cu = txt_Chisocu.Text;
            string moi = txt_Chisomoi.Text;
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                int cscu = (int)Convert.ToDouble(cu);
                int csmoi = (int)Convert.ToInt16(moi);
                if (DAO.HoaDonDAO.Instance.insertChiTietDienNuoc(mahd, madvdn,cscu,csmoi))
                {
                    MessageBox.Show("Thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVDien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CapnhapDV_ĐN_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHDĐN.Text;
            string madv = comb_MaDVDienNuoc.SelectedValue.ToString();
            string cu = txt_Chisocu.Text;
            string moi = txt_Chisomoi.Text;
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                int cscu = (int)Convert.ToDouble(cu);
                int csmoi = (int)Convert.ToInt16(moi);
                if (DAO.HoaDonDAO.Instance.updateChiTietDienNuoc(mahd, madvdn, cscu, csmoi))
                {
                    MessageBox.Show("Cập nhập thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVDien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaDV_ĐN_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHDĐN.Text;
            string madv = comb_MaDVDienNuoc.SelectedValue.ToString();
           
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                
                if (DAO.HoaDonDAO.Instance.deleteChiTietDienNuoc(mahd, madvdn))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVDien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btn_ThemDV_HĐ_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHD_CT.Text;
            string madv = comb_MaDV_Khac.SelectedValue.ToString();
            string soluong = comboBox2.Text;
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                int sl = (int)Convert.ToDouble(soluong);
                if (DAO.HoaDonDAO.Instance.insertChiTietHoaDon(mahd, madvdn, sl))
                {
                    MessageBox.Show("Thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVKhac();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHD_CT.Text;
            string madv = comb_MaDV_Khac.SelectedValue.ToString();
            string soluong = comboBox2.Text;
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                int sl = (int)Convert.ToDouble(soluong);
                if (DAO.HoaDonDAO.Instance.updateChiTietHoaDon(mahd, madvdn, sl))
                {
                    MessageBox.Show("Cập nhập thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVKhac();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaDV_HĐ_Click(object sender, EventArgs e)
        {
            string ma = comb_MaHD_CT.Text;
            string madv = comb_MaDV_Khac.SelectedValue.ToString();
            
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                int madvdn = (int)Convert.ToInt16(madv);
                if (DAO.HoaDonDAO.Instance.deleteChiTietHoaDon(mahd, madvdn))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_DVKhac();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
