using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlyDataSet.NguoiDung' table. You can move, or remove it, as needed.
            this.nguoiDungTableAdapter.Fill(this.quanlyDataSet.NguoiDung);
            string conString = ConfigurationManager.ConnectionStrings["QL"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dsNguoiDung.DataSource, "tenND");
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dsNguoiDung.DataSource, "tenDN");
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dsNguoiDung.DataSource, "MatKhau");
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("text", dsNguoiDung.DataSource, "GioiTinh");
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("text", dsNguoiDung.DataSource, "DiaChi");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        public void HienThi()
        {
            string Sqlselect = "select*from NGUOIDUNG";
            SqlCommand cmd = new SqlCommand(Sqlselect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsNguoiDung.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn Sửa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqledit = "update NGUOIDUNG set tenND=@tenND,tenDN=@tenDN,MatKhau=@MatKhau,GioiTinh=@GioiTinh,DiaChi=@DiaChi where tenND=@tenND";
                    SqlCommand cmd = new SqlCommand(sqledit, con);
                    cmd.Parameters.AddWithValue("tenND", textBox1.Text);
                    cmd.Parameters.AddWithValue("tenDN", textBox2.Text);
                    cmd.Parameters.AddWithValue("MatKhau", textBox3.Text);
                    cmd.Parameters.AddWithValue("GioiTinh", comboBox1.Text);
                    cmd.Parameters.AddWithValue("DiaChi", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();

                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên người dùng");
                        textBox1.Focus();
                    }
                    else if (textBox2.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập Tên đăng nhập");
                        textBox2.Focus();
                    }
                    else if (textBox3.Text.Length < 3)
                    {
                        MessageBox.Show("Mật khẩu phải nhiều hơn 3 kí tự");
                        textBox3.Focus();
                    }
                    else if (textBox5.Text == "")
                    {
                        MessageBox.Show("Địa chỉ không được để trống");
                        textBox5.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu thành công!");
                    }
                }
                catch
                {
                    MessageBox.Show("Sửa dữ liệu Người Dùng thất bại!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn muốn Xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqldelete = "delete from NGUOIDUNG where tenND=@tenND";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    cmd.Parameters.AddWithValue("tenND", textBox1.Text);
                    cmd.Parameters.AddWithValue("tenDN", textBox2.Text);
                    cmd.Parameters.AddWithValue("MatKhau", textBox3.Text);
                    cmd.Parameters.AddWithValue("GioiTinh", comboBox1.Text);
                    cmd.Parameters.AddWithValue("DiaChi", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Xóa người dùng thành công");

                }
                catch
                {
                    MessageBox.Show("Xóa người dùng thất bại!!");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn muốn Thêm không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh==DialogResult.Yes)
            {
                try
                {
                    string sqlinsert = "insert into NguoiDung values (@tenND,@tenDN,@MatKhau,@GioiTinh,@DiaChi)";
                    SqlCommand cmd = new SqlCommand(sqlinsert, con);
                    cmd.Parameters.AddWithValue("tenND", textBox1.Text);
                    cmd.Parameters.AddWithValue("tenDN", textBox2.Text);
                    cmd.Parameters.AddWithValue("MatKhau", textBox3.Text);
                    cmd.Parameters.AddWithValue("GioiTinh", comboBox1.Text);
                    cmd.Parameters.AddWithValue("DiaChi", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    if (textBox3.Text.Length < 3)
                    {
                        MessageBox.Show("Mật khẩu phải nhiều hơn 3 kí tự");
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng thành công");
                    }    
                    
                }
                catch
                {
                    MessageBox.Show("Thêm người dùng thất bại!");
                }

            }
        }

        private void dsNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
