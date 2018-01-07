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
    public partial class frmSachMuon : Form
    {
        string A;
        SqlConnection cnn;
        public frmSachMuon()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");

        }
	 private void SachMuon_Load(object sender, EventArgs e)
        {
            loaddllenfile();
            hiendlphieumuon();
            hiendlsach();
            A = label9.Text;
            label9.Text = "";
            timer1.Start();
            hientieudecot();
            data_bingding();
        }
        #region bingding





    }
}
