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
    public partial class Spend : Form
    {
        public Spend()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlyDataSet.KhoanChi' table. You can move, or remove it, as needed.
            this.khoanChiTableAdapter.Fill(this.quanlyDataSet.KhoanChi);
            string conString = ConfigurationManager.ConnectionStrings["QL"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "MaKC");
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dsKhoanChi.DataSource, "tenKC");
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dsKhoanChi.DataSource, "tenND");
            richTextBox1.DataBindings.Clear();
            richTextBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "NgayChi");
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dsKhoanChi.DataSource, "SoTien");
            richTextBox1.DataBindings.Clear();
            richTextBox1.DataBindings.Add("text", dsKhoanChi.DataSource, "MoTa");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        public void HienThi()
        {
            string Sqlselect = "select*from KhoanChi";
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
                    string sqlinsert = "insert into KhoanChi Values (@MaKC,@TenKC,@tenND,@NgayChi,@SoTien,@MoTa)";
                    SqlCommand cmd = new SqlCommand(sqlinsert, con);
                    cmd.Parameters.AddWithValue("MaKC", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKC", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayChi",dateTimePicker1.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn muốn Xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqldelete = "delete from KhoanChi where MaKC=@MaKC";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    cmd.Parameters.AddWithValue("MaKC", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKC", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayChi",dateTimePicker1.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn Sửa không?", "Thông báo", MessageBoxButtons.YesNo);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    string sqledit = "update KhoanChi set TenKC=@TenKC,tenND=@tenND,NgayChi=@NgayChi,SoTien=@SoTien,MoTa=@MoTa where MaKC=@MaKC";
                    SqlCommand cmd = new SqlCommand(sqledit, con);
                    cmd.Parameters.AddWithValue("MaKC", textBox1.Text);
                    cmd.Parameters.AddWithValue("TenKC", textBox2.Text);
                    cmd.Parameters.AddWithValue("tenND", textBox3.Text);
                    cmd.Parameters.AddWithValue("NgayChi", dateTimePicker1.Text);
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

        private void khoảnThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 add = new Form1();
            add.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statis tk = new statis();
            tk.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User nd = new User();
            nd.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
