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
    public partial class muontrasach : Form
    {
        SqlConnection cnn;
        DataTable vtttv;
        DataRow r1;
        int vt;
        public muontrasach()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
            vtttv = new DataTable();
            vtttv = docthethuvien();
        }
       private void muontrasach_Load(object sender, EventArgs e)
        {
            docthethuvien();
            Hienbangpm(txtMa.Text);
            Hienbangphieunhactra(txtmathe1.Text);
            hiensvdautien2();
            hiensvdautien();
            loaddlsach();
            txtmapnt.Enabled = false;
            txtMa.Enabled = false;
            txtMapm.Enabled = false;
            txtmathe1.Enabled = false;
        }
        #region hiện thị mã pnt
	private string taomapnt()
        {
            string mapnt;
            Random r = new Random();
            mapnt = "NV" + r.Next(50, 999).ToString();
            return mapnt;
        }
        #endregion
        #region docthethuvien
    }
}
