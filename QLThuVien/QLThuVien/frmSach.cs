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
using System.IO;

namespace QLThuVien
{
    public partial class frmSach : Form
    {
        string A;
        DataTable vtsach;
        OpenFileDialog file;
        byte[] hinh;
        int vt;
        SqlConnection cnn;
        public frmSach()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
            vtsach = new DataTable();
            vtsach = docsach();
        }
        private void Sach_Load(object sender, EventArgs e)
        {
            txtMasach.Enabled = false;
            loaddlsach();
            hiensachdautien();
            tieudecotsach();
            A = lbltieude.Text;
            lbltieude.Text = "";
            timer1.Start();
            data_bingding();
        }
        #region chạy chữ
        private void timer1_Tick(object sender, EventArgs e)
        {
            int d = 0, x;
            x = A.Length;
            d++;
            string a = A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            lbltieude.Text = lbltieude.Text + a;
            if (d == x)
            {
                timer1.Stop();
            }
        }
        #endregion
        #region load len luoi
        private DataTable docsach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LOADSACH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            DataTable sach = new DataTable();
            cnn.Open();
            sach.Load(cmd.ExecuteReader());
            cnn.Close();
            return sach;
        }
        private void loaddlsach()
        {
            dgvttsach.DataSource = docsach();
            lbltong.ForeColor = Color.Red;
            lbltong.Text = (dgvttsach.Rows.Count).ToString();
        }
        #endregion
        #region xử lý bingding
        private void data_bingding()
        {
            txtMasach.DataBindings.Add("Text",dgvttsach.DataSource,"MaSach");
            txtTensach.DataBindings.Add("Text",dgvttsach.DataSource,"TenSach");
            txttheloaisach.DataBindings.Add("Text",dgvttsach.DataSource,"TheLoai");
            txttinhtrang.DataBindings.Add("Text",dgvttsach.DataSource,"TinhTrang");
            txtsoluong.DataBindings.Add("Text",dgvttsach.DataSource,"SoLuong");
            txtnxb.DataBindings.Add("Text", dgvttsach.DataSource, "NXB");
            txtnamxb.DataBindings.Add("Text",dgvttsach.DataSource,"NamXB");
            txttg.DataBindings.Add("Text", dgvttsach.DataSource, "TG");
            PICHINH.DataBindings.Add("Image", dgvttsach.DataSource, "HINH", true);
        }
        private void huy_bingding()
        {
            if (txtMasach.DataBindings != null)
                txtMasach.DataBindings.Clear();
            if (txtTensach.DataBindings != null)
                txtTensach.DataBindings.Clear();
            if (txttheloaisach.DataBindings != null)
                txttheloaisach.DataBindings.Clear();
            if (txttinhtrang.DataBindings != null)
                txttinhtrang.DataBindings.Clear();
            if (txtsoluong.DataBindings != null)
                txtsoluong.DataBindings.Clear();
            if (txtnxb.DataBindings != null)
                txtnxb.DataBindings.Clear();
            if (txtnamxb.DataBindings != null)
                txtnamxb.DataBindings.Clear();
            if (txttg.DataBindings != null)
                txttg.DataBindings.Clear();
            if (PICHINH.DataBindings!=null)
                PICHINH.DataBindings.Clear();
        }
        private void tieudecotsach()
        {
            dgvttsach.Columns[0].HeaderText = "Mã Sách";
            dgvttsach.Columns[1].HeaderText = "Tên Sách";
            dgvttsach.Columns[2].HeaderText = "Thể Loại";
            dgvttsach.Columns[3].HeaderText = "Tình Trạng";
            dgvttsach.Columns[4].HeaderText = "Số Lượng";
            dgvttsach.Columns[5].HeaderText = "Mã NXB";
            dgvttsach.Columns[6].HeaderText = "Năm NXB";
            dgvttsach.Columns[7].HeaderText = "Mã TG";
            dgvttsach.Columns[8].HeaderText = "Hình";
        }
        #endregion
    }
}
