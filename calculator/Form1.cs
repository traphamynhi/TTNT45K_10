using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            phanso a = new phanso();
            phanso b = new phanso();
            phanso c = new phanso();
            try
            {
                a.TUSO = int.Parse(txt_ts1.Text);
                a.MAUSO = int.Parse(txt_ms1.Text);
                b.TUSO = int.Parse(txt_ts2.Text);
                b.MAUSO = int.Parse(txt_ms2.Text);

            }
            catch
            {
                MessageBox.Show("nhap so nguyen");

            }
            if (radioButton1.Checked)
            {
                label1.Text = "+";
                c = c.cong(a, b);

            }
            else
                if (radioButton2.Checked)
                {
                    label1.Text = "-";
                    c = c.tru(a, b);
                }
                else
                    if (radioButton3.Checked)
                    {
                        label1.Text = "*";
                        c = c.nhan(a, b);
                    }
                    else
                        if (radioButton4.Checked)
                        {
                            label1.Text = "/";
                            c = c.chia(a, b);
                        }
            c.rutgon();
            txt_tukq.Text = c.TUSO.ToString();
            txt_maukq.Text = c.MAUSO.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("ban co muon thoat khong", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (thongbao == DialogResult.Yes)
                    Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_ts1.Text = "";
            txt_ms1.Text = "";
            txt_ts2.Text = "";
            txt_ms2.Text = "";
            txt_tukq.Text = "";
            txt_maukq.Text = "";
        }
    }
}
