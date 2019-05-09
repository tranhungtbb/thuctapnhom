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
    public partial class UserControlDanhMuc : UserControl
    {
        public UserControlDanhMuc()
        {
            InitializeComponent();
            List_Combobox();
            LoatData();
            
        }
        #region LoatListData
        void LoadList_Data_ThietBi()
        {
            string query = "select MaThietBi as 'Mã thiết bị', TenThietBi as 'Tên thiết bị',  TinhTrang as 'Tình trạng', GhiChu as 'Ghi chú' from ThietBi";
            dataGridView_ThietBi.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        
        void LoadList_Data_LoaiPhong()
        {
            string query = "select MaLoaiPhong as 'Mã loại phòng', TenLoaiPhong as 'Tên loại phòng', DienTich as 'Diện tích',MoTa as 'Mô Tả', DonGia as 'Đơn giá', SoLuongToiDa as N'Số lượng tối đa' from LoaiPhong";
            dataGridView_LoaiPhong.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        #endregion

        private void LoatData()
        {
            LoadList_Data_ThietBi();
            LoadList_Data_LoaiPhong();
        }

        #region Create, update, delete Thiet Bi
        private void btn_ThemThietbi_Click(object sender, EventArgs e)
        {
            //int matb = (int)Convert.ToDouble(txt_Mathietbi.Text);
            string ma = txt_Mathietbi.Text;
            string tentb = txt_TenThietbi.Text;
            string tt = Comb_stt.Text;
            string ghichu = txt_GhiChu.Text;

            
            try
            {
                int matb = (int)Convert.ToDouble(ma);
                if (DAO.ThietBiDAO.Instance.insertThietBi(matb, tentb, tt, ghichu))
                {
                    MessageBox.Show("Thêm thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_ThietBi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CapnhapThietbi_Click(object sender, EventArgs e)
        {
            string ma = txt_Mathietbi.Text;
            string tentb = txt_TenThietbi.Text;
            string tt = Comb_stt.Text;
            string ghichu = txt_GhiChu.Text;
            try
            {
                int matb = (int)Convert.ToDouble(ma);
                if (DAO.ThietBiDAO.Instance.updateThietBi(matb, tentb, tt, ghichu))
                {
                    MessageBox.Show("Cập nhập thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_ThietBi();
                }
                else
                {
                    MessageBox.Show("Không có mã thiết bị là :"+matb,"Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaThietbi_Click(object sender, EventArgs e)
        {
            string ma = txt_Mathietbi.Text;
            try
            {
                int matb = (int)Convert.ToDouble(ma);
                if (DAO.ThietBiDAO.Instance.deleteThietBi(matb))
                {
                    MessageBox.Show("Xóa thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_ThietBi();
                }
                else
                {
                    MessageBox.Show("Không có mã thiết bị là :" + matb, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Create, update, delete LoaiPhong

        private void btn_ThemLoaiphong_Click(object sender, EventArgs e)
        {
            string ma = txt_Maloaiphong.Text;
            string tenlp = txt_Tenloaiphong.Text;
            string dt = txt_Dientich.Text;
            string mota = txt_Mota.Text;
            string dg = txt_Dongia.Text;
            string sl = comboBox3.Text;

            try
            {
                int malp = (int)Convert.ToDouble(ma);
                int dientich = (int)Convert.ToDouble(dt);
                int dongia = (int)Convert.ToDouble(dg);
                int soluong = (int)Convert.ToDouble(sl);
                if (DAO.LoaiPhongDAO.Instance.insertLoaiPhong(malp, tenlp, dientich, mota,dongia,soluong))
                {
                    MessageBox.Show("Thêm loại phòng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_LoaiPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CapNhapLoaiPhong_Click(object sender, EventArgs e)
        {
            string ma = txt_Maloaiphong.Text;
            string tenlp = txt_Tenloaiphong.Text;
            string dt = txt_Dientich.Text;
            string mota = txt_Mota.Text;
            string dg = txt_Dongia.Text;
            string sl = comboBox3.Text;
            try
            {
                int malp = (int)Convert.ToDouble(ma);
                int dientich = (int)Convert.ToDouble(dt);
                int dongia = (int)Convert.ToDouble(dg);
                int soluong = (int)Convert.ToDouble(sl);
                int matb = (int)Convert.ToDouble(ma);
                if (DAO.LoaiPhongDAO.Instance.updateLoaiPhong(malp, tenlp, dientich, mota, dongia, soluong))
                {
                    MessageBox.Show("Cập nhập thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_LoaiPhong();
                }
                else
                {
                    MessageBox.Show("Không có mã loại phòng là :" + malp, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaLoaiphong_Click(object sender, EventArgs e)
        {
            string ma = txt_Maloaiphong.Text;
            try
            {
                int malp = (int)Convert.ToDouble(ma);
                if (DAO.LoaiPhongDAO.Instance.deleteLoaiPhong(malp))
                {
                    MessageBox.Show("Xóa loại phòng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_LoaiPhong();
                }
                else
                {
                    MessageBox.Show("Không có mã loại phòng là :" + malp, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Create, update, delete ThietBi

        private void btn_ThemTrangBi_Click(object sender, EventArgs e)
        {
            string maphong = comb_IDPhong.Text;
            string matb = comb_IDThietbi.Text;
            string sl = comb_Sl.Text;
            try
            {
                int matbi = (int)Convert.ToDouble(matb);
                int soluong = (int)Convert.ToDouble(sl);
                if (DAO.TrangBiDAO.Instance.insertTrangBi(maphong,matbi,soluong))
                {
                    MessageBox.Show("Thêm thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_UpdateTrangBi_Click(object sender, EventArgs e)
        {
            string maphong = comb_IDPhong.Text;
            string matb = comb_IDThietbi.Text;
            string sl = comb_Sl.Text;
            try
            {
                int matbi = (int)Convert.ToDouble(matb);
                int soluong = (int)Convert.ToDouble(sl);
                if (DAO.TrangBiDAO.Instance.updateTrangBi(maphong, matbi, soluong))
                {
                    MessageBox.Show("Cập nhập thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaTrangBi_Click(object sender, EventArgs e)
        {
            string maphong = comb_IDPhong.Text;
            string matb = comb_IDThietbi.Text;
            try
            {
                int matbi = (int)Convert.ToDouble(matb);
                if (DAO.TrangBiDAO.Instance.deleteTrangBi(maphong, matbi))
                {
                    MessageBox.Show("Xóa thiết bị thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion




        void List_Combobox()
        {
            List_Combo_IDPhong();
            List_Combo_IDThietBi();

        }

        public void List_Combo_IDPhong()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhong();
            comb_IDPhong.DataSource = list;
            comb_IDPhong.DisplayMember = "MAPHONG";
        }
        public void List_Combo_IDThietBi()
        {
            List<ThietBi> list = Danhsach.ThongKe.Instance.ListThietbi();
            comb_IDThietbi.DataSource = list;
            comb_IDThietbi.DisplayMember = "MaThietBi";
        }

        public void ShowListView_TTThietBiofPhong(string maphong)
        {
            listView_ThietBi.Items.Clear();

            List<QuanLiPhongTro.DTO.ThietBi> listPT = Danhsach.ThongKe.Instance.ListThietBiofPhong(maphong);
            foreach (QuanLiPhongTro.DTO.ThietBi i in listPT)
            {
                ListViewItem lvItem = new ListViewItem(i.MATHIETBI.ToString());
                lvItem.SubItems.Add(i.TENTHIETBI.ToString());
                lvItem.SubItems.Add(i.TINHTRANG.ToString());
                lvItem.SubItems.Add(i.GHICHU.ToString());

                listView_ThietBi.Items.Add(lvItem);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string ma = comb_IDPhong.Text;
            ShowListView_TTThietBiofPhong(ma);
        }

        
    }
}
