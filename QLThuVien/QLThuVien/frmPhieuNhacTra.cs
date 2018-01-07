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
	#endregion
        #region bingding
        private void data_bingding()
        {
            txtmapnt.DataBindings.Add("Text", dgvttpnt.DataSource, "MaPNT");
            cbomanv.DataBindings.Add("Selectedvalue", dgvttpnt.DataSource, "MaNV");
            cbomasach.DataBindings.Add("Selectedvalue", dgvttpnt.DataSource, "MaSach");
            cbomathe.DataBindings.Add("Selectedvalue", dgvttpnt.DataSource, "MaThe");
            txtdgp.DataBindings.Add("Text", dgvttpnt.DataSource, "DonGiaPhat");
            txtghichu.DataBindings.Add("Text", dgvttpnt.DataSource, "GhiChu");
        }
        private void huy_bingding()
        {
            if (txtmapnt.DataBindings != null)
                txtmapnt.DataBindings.Clear();
            if (txtghichu.DataBindings != null)
                txtghichu.DataBindings.Clear();
            if (dtngaplap.DataBindings != null)
                dtngaplap.DataBindings.Clear();
            if (txtdgp.DataBindings != null)
                txtdgp.DataBindings.Clear();
            if (cbomasach.DataBindings != null)
                cbomasach.DataBindings.Clear();
            if (cbomanv.DataBindings != null)
                cbomanv.DataBindings.Clear();
            if (cbomathe.DataBindings != null)
                cbomathe.DataBindings.Clear();
        }
        #endregion
        #region tiêu đề cột
        private void hientieudecot()
        {
            dgvttpnt.Columns[0].HeaderText="Mã PNT";
            dgvttpnt.Columns[1].HeaderText = "Mã The";
            dgvttpnt.Columns[2].HeaderText = "Ngày Lập";
            dgvttpnt.Columns[3].HeaderText = "Đơn Giám Phạt";
            dgvttpnt.Columns[4].HeaderText = "Mã NV";
            dgvttpnt.Columns[5].HeaderText = "Mã Sách";
        }
        #endregion
        #region load sach
           private DataTable loadsach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_LOADSACH";
            cmd.Connection = cnn;
            DataTable sach = new DataTable();
            cnn.Open();
            sach.Load(cmd.ExecuteReader());
            cnn.Close();
            return sach;
        }
         private void hiendlsach()
        {
            cbomasach.DataSource = loadsach();
            cbomasach.ValueMember = "MaSach";
            cbomasach.DisplayMember = "TenSach";
        }
        #endregion
        #region load nhanvien
	 private DataTable loadnv()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_LOADNHANVIEN";
            cmd.Connection = cnn;
            DataTable nv = new DataTable();
            cnn.Open();
            nv.Load(cmd.ExecuteReader());
            cnn.Close();
            return nv;
        }
	private void hiendlnv()
        {
            cbomanv.DataSource = loadnv();
            cbomanv.ValueMember = "MaNV";
            cbomanv.DisplayMember = "TenNV";
        }
        #endregion
        #region load thẻ thư viện
	
        private DataTable loadTheThuVien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_LOADTHETHUVIEN";
            cmd.Connection = cnn;
            DataTable ttv = new DataTable();
            cnn.Open();
            ttv.Load(cmd.ExecuteReader());
            cnn.Close();
            return ttv;
        }
        private void hiendlthethuvien()
        {
            cbomathe.DataSource = loadTheThuVien();
            cbomathe.ValueMember = "MaThe";
            cbomathe.DisplayMember = "TenSV";
        }
	 #endregion
        #region doc len file
        private DataTable docphieunhactra()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LOADPHIEUNHACTRA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            DataTable phieumuon = new DataTable();
            cnn.Open();
            phieumuon.Load(cmd.ExecuteReader());
            cnn.Close();
            return phieumuon;
        }
    }
}
