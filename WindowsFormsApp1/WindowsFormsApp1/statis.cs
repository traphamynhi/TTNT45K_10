using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class statis : Form
    {
        public statis()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection cn=new SqlConnection(ConfigurationManager.ConnectionStrings["QL"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using(DataTable dt=new DataTable("KhoanThu"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select n.tenND,k.MaKT, k.TenKT, k.NgayThu, k.SoTien, k.MoTa from KhoanThu k inner join NguoiDung n on k.tenND = n.tenND where k.NgayThu between @tungay and @denngay", cn))
                        {
                            cmd.Parameters.AddWithValue("@tungay", dateTimePicker1.Value);
                            cmd.Parameters.AddWithValue("@denngay", dateTimePicker2.Value);
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                            sqlDataAdapter.Fill(dt);
                            dsKhoanThu.DataSource = dt;

                            label3.Text = $"Tong thu: {dsKhoanThu.RowCount}";
                        }
                       
                    }  
                    using(DataTable dta=new DataTable("KhoanChi"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select n.tenND,k.MaKC, k.TenKC, k.NgayChi, k.SoTien, k.MoTa from KhoanChi k inner join NguoiDung n on k.tenND = n.tenND where k.NgayChi between @tungay and @denngay", cn))
                        {
                            cmd.Parameters.AddWithValue("@tungay", dateTimePicker1.Value);
                            cmd.Parameters.AddWithValue("@denngay", dateTimePicker2.Value);
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                            sqlDataAdapter.Fill(dta);
                            dsKhoanChi.DataSource = dta;

                            label4.Text = $"Tong chi: {dsKhoanThu.RowCount}";

                        }
                    }    
                         
                }    

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }
    }
}
