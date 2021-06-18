using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn;

        private void Form2_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QL"].ConnectionString.ToString();
            conn = new SqlConnection(conString);
            conn.Open();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            regis dk = new regis();
            dk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = textBox2.Text;
                string MatKhau = textBox3.Text;
                string login = "select*from NGUOIDUNG where tenDN='" + tenDN + "' and MatKhau='" + MatKhau + "'";
                SqlCommand cmd = new SqlCommand(login, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                    Spend ND = new Spend();
                    ND.Show();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất Bại");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
