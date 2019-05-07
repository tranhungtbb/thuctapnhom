using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongTro.SQL
{
    public class ThuVienSQL
    {
        public string chuoiketnoi =@"Data Source="+ Visiable.Tenmaychu+";Initial Catalog ="+ Visiable.TenCSDL + ";Integrated Security=True";
        SqlConnection connect;
        SqlCommand commad;
        public static ThuVienSQL instance;
        public static ThuVienSQL Instance
        {
            get
            {
                if (instance == null) instance = new ThuVienSQL();
                return ThuVienSQL.instance;
            }
            private set { instance = value; }
        }
        public ThuVienSQL() { }
        public bool Open()
        {
            try
            {
                if ((connect == null) || (connect.State != ConnectionState.Open))
                    connect.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("loi lket noi...");
                return false;
            }
        }
        public bool Close()
        {
            try
            {
                if ((connect == null) || (connect.State != ConnectionState.Closed))
                    connect.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("loi ket noi...");
                return false;
            }
        }
        public DataTable Execute_Query(string query, object[] para = null)
        {
            DataTable table = new DataTable();
            try
            {
                using (connect = new SqlConnection(chuoiketnoi))
                {
                    Open();
                    commad = new SqlCommand(query, connect);
                    if (para != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string iteam in listPara)
                        {
                            if (iteam.Contains('@'))
                            {
                                commad.Parameters.AddWithValue(query, para[i]);
                                i++;
                            }
                        }
                    }

                    SqlDataAdapter daA = new SqlDataAdapter(commad);

                    daA.Fill(table);
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Không có dữ liệu", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
            return table;
        }
        public int Execute_NonQuery(string query, object[] para = null)
        {
            int data = 0;
            using (connect = new SqlConnection(chuoiketnoi))
            {
                Open();
                commad = new SqlCommand(query, connect);
                if (para != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string iteam in listPara)
                    {
                        if (iteam.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(query, para[i]);
                            i++;
                        }
                    }
                }

                data = commad.ExecuteNonQuery();
                Close();
            }
            return data;

        }
    }
}
