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
    public partial class UserControlThueMoi : UserControl
    {
        public UserControlThueMoi()
        {
            InitializeComponent();
            LoatList();
            ComboData();
            

        }
        void LoatList()
        {
            LoadList_Data_KhachHang();
            LoadList_Data_HopDong();
        }
        void LoadList_Data_KhachHang()
        {
            string query = "select MaKhachHang as 'Mã khách hàng', HoTen as 'Tên khách hàng' , NgaySinh as 'Ngày sinh', GioiTinh as 'Giới tính' , QueQuan as 'Quê Quán', SDT as 'SĐT', CMND as 'CMND/Căn cước', Status as 'Status', MaPhong as 'Mã phòng' from KhachHang";
            dataGridViewKH.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }
        void LoadList_Data_HopDong()
        {
            string query = "select MaHopDong as 'Mã hợp đồng', NgayBatDau as 'Ngày bắt đầu',  ThoiGianThue as 'Thời gian', PARSENAME(convert(varchar,convert(money,TienCoc),1),2) as 'Tiền cọc' , GhiChu as 'Ghi chú', MaPhong as 'Mã phòng', MaKhachHang as 'Mã KH' from HopDong";
            dataGridViewHĐ.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }

        private void btn_Themkhachhang_Click(object sender, EventArgs e)
        {
            string ma = txt_IDKhachhang.Text;
            string ten = txt_Tenkhachhang.Text;
            DateTime ns = Ngaysinh.Value;
            string gt = Comb_Gioitinh.Text;
            string qq = txt_Quequan.Text;

            int sdt = 0;
            if (txt_CMND.Text.Length == 0)
            {
                try
                {
                    sdt = (int)Convert.ToDouble(txt_SDT.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập sdt.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    sdt = (int)Convert.ToDouble(txt_CMND.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập sdt đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int cm=0;
            if (txt_CMND.Text.Length == 0)
            {
                try
                {
                    cm = (int)Convert.ToDouble(txt_CMND.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập cm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    cm = (int)Convert.ToDouble(txt_CMND.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập chứng minh chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int stt = 0;
            if(checkBox1.Checked == true)
            {
                stt = 1;
            }
            

            string maphong = Comb_MaPhong.Text;

            try
            {
                int makh = (int)Convert.ToDouble(ma);
                if (DAO.KhachHangDAO.Instance.insertKhachHang(makh, ten, ns, gt, qq,sdt,cm,stt,maphong))
                {
                    MessageBox.Show("Thêm khách hàng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_KhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Capnhapkhachhang_Click(object sender, EventArgs e)
        {
            string ma = txt_IDKhachhang.Text;
            string ten = txt_Tenkhachhang.Text;
            DateTime ns = Ngaysinh.Value;
            string gt = Comb_Gioitinh.Text;
            string qq = txt_Quequan.Text;

            int sdt = 0;
            if (txt_SDT.Text.Length == 0)
            {
                try
                {
                    sdt = (int)Convert.ToDouble(txt_SDT.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập sdt.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    sdt = (int)Convert.ToDouble(txt_SDT.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập sdt chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int cm = 0;
            if (txt_CMND.Text.Length == 0)
            {
                try
                {
                    cm = (int)Convert.ToDouble(txt_CMND.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập cm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    cm = (int)Convert.ToDouble(txt_CMND.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập chứng minh chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int stt = 0;
            if (checkBox1.Checked == true)
            {
                stt = 1;
            }

            string maphong = Comb_MaPhong.Text;

            try
            {
                int makh = (int)Convert.ToDouble(ma);

                if (DAO.KhachHangDAO.Instance.updateKhachHang(makh, ten, ns, gt, qq, sdt, cm, stt, maphong))
                {
                    MessageBox.Show("Cập nhập khách hàng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_KhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoakhachhang_Click(object sender, EventArgs e)
        {
            string ma = txt_IDKhachhang.Text;
            
            try
            {
                int makh = (int)Convert.ToDouble(ma);

                if (DAO.KhachHangDAO.Instance.deleteKhachHang(makh))
                {
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_KhachHang();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công.Không có mã KH là :" +makh, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThemHopdong_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahopdong.Text;

            DateTime nbd = Ngaybatdau.Value;

            int tg = 6;
            
            if (txt_Thoigianthue.Text.Length == 0)
            {
                try
                {
                    tg = (int)Convert.ToDouble(txt_Thoigianthue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập thời gian thuê.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    tg = (int)Convert.ToDouble(txt_Thoigianthue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập thời gian thuê chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int tiencoc = 0;
            if (txt_Tiencoc.Text.Length == 0)
            {
                try
                {
                    tiencoc = (int)Convert.ToDouble(txt_Tiencoc.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập Tiền cọc.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    tiencoc = (int)Convert.ToDouble(txt_Tiencoc.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập Tiền cọc đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string ghichu = txt_Ghichu.Text;
            string maphong = Comb_IDMaPhong_HD.Text;
            int idKH = 0;
            try
            {
                idKH = (int)Convert.ToDouble(Comb_IDkhachhang_HD.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhập Mã khách hàng chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                if (DAO.HopDongDAO.Instance.insertHopDong(mahd, nbd , tg, tiencoc, ghichu, maphong, idKH))
                {
                    MessageBox.Show("Thêm Hợp đồng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HopDong();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Capnhaphopdong_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahopdong.Text;

            DateTime nbd = Ngaybatdau.Value;

            int tg = 6;

            if (txt_Thoigianthue.Text.Length == 0)
            {
                try
                {
                    tg = (int)Convert.ToDouble(txt_Thoigianthue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập thời gian thuê.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    tg = (int)Convert.ToDouble(txt_Thoigianthue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập thời gian thuê chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            int tiencoc = 0;
            if (txt_Tiencoc.Text.Length == 0)
            {
                try
                {
                    tiencoc = (int)Convert.ToDouble(txt_Tiencoc.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chưa nhập Tiền cọc.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    tiencoc = (int)Convert.ToDouble(txt_Tiencoc.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nhập Tiền cọc đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string ghichu = txt_Ghichu.Text;
            string maphong = Comb_IDMaPhong_HD.Text;
            int idKH = 0;
            try
            {
                idKH = (int)Convert.ToDouble(Comb_IDkhachhang_HD.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nhập Mã khách hàng chưa đúng định dạng.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                if (DAO.HopDongDAO.Instance.updateHopDong(mahd, nbd, tg, tiencoc, ghichu, maphong, idKH))
                {
                    MessageBox.Show("Cập nhập Hợp đồng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HopDong();
                }
                else
                {
                    MessageBox.Show("Không có hợp đồng nào có mã là :" + mahd + ".", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cập nhập không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoahopdong_Click(object sender, EventArgs e)
        {
            string ma = txt_Mahopdong.Text;
            
            try
            {
                int mahd = (int)Convert.ToDouble(ma);
                if (DAO.HopDongDAO.Instance.deleteHopDong(mahd))
                {
                    MessageBox.Show("Xóa Hợp đồng thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList_Data_HopDong();
                }
                else
                {
                    MessageBox.Show("Không có hợp đồng nào có mã là :"+mahd+".", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa không thành công.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            string ten = txt_searchKH.Text;
            DataTable table = DAO.KhachHangDAO.Instance.searchKhachHang(ten);
            dataGridViewKH.DataSource = table;
            foreach (DataGridViewRow d in dataGridViewKH.Rows)
            {
                d.Cells[1].Style.ForeColor = Color.Red;
            }
        }// aaaaaaaaaa

        void ComboData()
        {
            List_Combobox_IDPhong_TT();
            List_Combobox_IDPhong_HĐ();

        }

        public void List_Combobox_IDPhong_TT()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhong();
            Comb_IDphong_TB.DataSource = list;
            Comb_IDphong_TB.DisplayMember = "MAPHONG";
        }
        public void List_Combobox_IDPhong_HĐ()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhongChuaLamHopDong();
            Comb_IDMaPhong_HD.DataSource = list;
            Comb_IDMaPhong_HD.DisplayMember = "MAPHONG";
        }
        
        public void List_Combobox_IDKH_HĐ(string ma)
        {
            List<KhachHang> list = Danhsach.ThongKe.Instance.ListKhachHangChuaLamHopDong(ma);
            Comb_IDkhachhang_HD.DataSource = list;
            Comb_IDkhachhang_HD.DisplayMember = "MaKhachHang";
        }
        public void List_Combobox_IDPhongTrong()
        {
            List<PhongTrong> list = Danhsach.ThongKe.Instance.ListPTr();
            Comb_MaPhong.DataSource = list;
            Comb_MaPhong.DisplayMember = "MaPhong";
        }
        public void List_Combobox_IDPhongThemKH()
        {
            List<Phong> list = Danhsach.ThongKe.Instance.ListPhongChuaĐuNguoi();
            Comb_MaPhong.DataSource = list;
            Comb_MaPhong.DisplayMember = "MaPhong";
        }

        public void ShowListView_TTThietBiofPhong(string maphong)
        {
            listView1.Items.Clear();

            List<ThietBi> listPT = Danhsach.ThongKe.Instance.ListThietBiofPhong(maphong);
            foreach (ThietBi i in listPT)
            {
                ListViewItem lvItem = new ListViewItem(i.MATHIETBI.ToString());
                lvItem.SubItems.Add(i.TENTHIETBI.ToString());
                lvItem.SubItems.Add(i.TINHTRANG.ToString());
                lvItem.SubItems.Add(i.GHICHU.ToString());

                listView1.Items.Add(lvItem);
            }
        }
        private void btn_XemTB_Click(object sender, EventArgs e)
        {
            string ma = Comb_IDphong_TB.Text;
            ShowListView_TTThietBiofPhong(ma);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                List_Combobox_IDPhongTrong();
            }
            else
            {
                List_Combobox_IDPhongThemKH();
            }
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            string query = "ListHopDongSapHetHan";
            dataGridViewHĐ.ClearSelection();
            dataGridViewHĐ.DataSource = SQL.ThuVienSQL.Instance.Execute_Query(query);
        }

        private void Comb_IDMaPhong_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = Comb_IDMaPhong_HD.Text;
            List_Combobox_IDKH_HĐ(ma);
        }
    }
}
