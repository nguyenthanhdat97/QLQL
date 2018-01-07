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
    public partial class frmNhanVien : Form
    {
	string A;
        SqlConnection cnn;
        public frmNhanVien()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
	 private void NhanVien_Load(object sender, EventArgs e)
        {
            txtManv.Enabled = false;
            loadnvlenluoi();
            A = label9.Text;
            label9.Text = "";
            timer1.Start();
            data_bingding();
            Hientieudecot();
        }
        #region xuly mã
        private string taomanv()
        {
            string manv;
            Random r = new Random();
            manv ="NV"+ r.Next(50, 999).ToString();
            return manv;
        }
        #endregion
        #region Doc du lieu len luoi
        private DataTable docdulieu()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LOADNHANVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            DataTable nhanvien = new DataTable();
            cnn.Open();
            nhanvien.Load(cmd.ExecuteReader());
            cnn.Close();
            return nhanvien;
        }
        private void loadnvlenluoi()
        {
            dgvttnv.DataSource = docdulieu();
        }
	#endregion
        #region hiện tiêu đề cột
        private void Hientieudecot()
        {
            dgvttnv.Columns[0].HeaderText = "Mã SV";
            dgvttnv.Columns[1].HeaderText = "Tên SV";
            dgvttnv.Columns[2].HeaderText = "Ngày Sinh";
            dgvttnv.Columns[3].HeaderText = "Ngày Vào Làm";
            dgvttnv.Columns[4].HeaderText = "Giới Tính";
            dgvttnv.Columns[5].HeaderText = "Chức Vụ";
            dgvttnv.Columns[6].HeaderText = "Địa Chỉ";
            dgvttnv.Columns[7].HeaderText = "ĐiệnThoại";
        }
    }
}
