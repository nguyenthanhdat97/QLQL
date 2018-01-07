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
    public partial class frmPhieuNhacTra : Form
    {
      string A;
        SqlConnection cnn;
        public frmPhieuNhacTra()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
  	private void PhieuNhacTra_Load(object sender, EventArgs e)
        {
            loaddllenfile();
            txtmapnt.Enabled = false;
            hiendlnv();
            hiendlsach();
            hiendlthethuvien();
            A = label9.Text;
            label9.Text = "";
            timer1.Start();
            hientieudecot();
            data_bingding();
        }
        #region hiện thị mã pnt
        private string taomapnt()
        {
            string mapnt;
            Random r = new Random();
            mapnt = "NV" + r.Next(50, 999).ToString();
            return mapnt;
        }
        
        
    }
}
