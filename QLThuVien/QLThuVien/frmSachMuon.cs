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
	 private void data_bingding()
        {
            txttinhtrang.DataBindings.Add("Text", dgvsachmuon.DataSource, "TinhTrang");
            txtsoluongsm.DataBindings.Add("Text", dgvsachmuon.DataSource, "SLSachMuon");
        }
        private void huy_bingding()
        {
            if (cbomapm.DataBindings != null)
                cbomapm.DataBindings.Clear();
            if (cbomasach.DataBindings != null)
                cbomasach.DataBindings.Clear();
            if (dtngaytra.DataBindings != null)
                dtngaytra.DataBindings.Clear();
            if (txttinhtrang.DataBindings != null)
                txttinhtrang.DataBindings.Clear();
            if (txtsoluongsm.DataBindings != null)
                txtsoluongsm.DataBindings.Clear();
        }
	#endregion
        #region tiêu đề cột
        private void hientieudecot()
        {
            dgvsachmuon.Columns[0].HeaderText = "Mã PM";
            dgvsachmuon.Columns[1].HeaderText = "Mã Sách";
            dgvsachmuon.Columns[2].HeaderText = "Tình Trạng";
            dgvsachmuon.Columns[3].HeaderText = "SL Sách Mượn";
            dgvsachmuon.Columns[4].HeaderText = "Ngày Trả";
        }
        #endregion
        #region load sach



    }
}
