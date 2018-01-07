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

namespace QLThuVien
{
    public partial class frmthethuvien : Form
    {
        SqlConnection cnn;
        DataTable vtttv;
        int vt;
        public frmthethuvien()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        } 
    }
}
