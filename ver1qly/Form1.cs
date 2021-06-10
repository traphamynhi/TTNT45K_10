using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ver1qly
{
    public partial class frmFrom : Form
    {
        public frmFrom()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\MAYAO;Initial Catalog=ver1.1;Integrated Security=True");

    }
}
