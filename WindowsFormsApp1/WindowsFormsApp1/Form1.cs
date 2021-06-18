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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlyDataSet.KhoanThu' table. You can move, or remove it, as needed.
            this.khoanThuTableAdapter.Fill(this.quanlyDataSet.KhoanThu);
            string conString = ConfigurationManager.ConnectionStrings["QL"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "MaKT");
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dsKhoanChi.DataSource, "tenKT");
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dsKhoanChi.DataSource, "tenND");
            richTextBox1.DataBindings.Clear();
            richTextBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "NgayThu");
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dsKhoanChi.DataSource, "SoTien");
            richTextBox1.DataBindings.Clear();
            richTextBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "MoTa");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        public void HienThi()
        {
            string Sqlselect = "select*from KhoanThu";
            SqlCommand cmd = new SqlCommand(Sqlselect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsKhoanChi.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn Thêm không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqlinsert = "insert into KhoanThu Values (@MaKT,@TenKT,@tenND,@NgayThu,@SoTien,@MoTa)";
                    SqlCommand cmd = new SqlCommand(sqlinsert, con);
                    cmd.Parameters.AddWithValue("MaKT", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKT", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayThu", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("SoTien", textBox4.Text);
                    cmd.Parameters.AddWithValue("MoTa", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Thêm dữ liệu thành công!");
                }
                catch
                {
                    MessageBox.Show("Thêm dữ liệu thất bại!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn Sửa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqlupdate = "update KhoanThu set TenKT=@TenKT,tenND=@tenND,NgayThu=@NgayThu,SoTien=@SoTien,MoTa=@MoTa where MaKT=@MaKT";
                    SqlCommand cmd = new SqlCommand(sqlupdate, con);
                    cmd.Parameters.AddWithValue("MaKT", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKT", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayThu", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("SoTien", textBox4.Text);
                    cmd.Parameters.AddWithValue("MoTa", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Sửa dữ liệu thành công!");
                }
                catch
                {
                    MessageBox.Show("Sửa dữ liệu thất bại!");
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
                    string sqldelete = "delete from KhoanChi where MaKT=@MaKT";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    cmd.Parameters.AddWithValue("MaKT", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKT", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayThu", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("SoTien", textBox4.Text);
                    cmd.Parameters.AddWithValue("MoTa", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Xóa dữ liệu thành công");

                }
                catch
                {
                    MessageBox.Show("Xóa dữ liệu thất bại!!");
                }

            }
        }
    }
}
