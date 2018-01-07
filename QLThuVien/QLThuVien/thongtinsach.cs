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
    public partial class thongtinsach : Form
    {
        DataTable dssach;
        SqlConnection cnn;
        public thongtinsach()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
        private DataTable docsachhu()
        {
            string chuoikn = "select * from SACH where TinhTrang=N'Cũ' or TinhTrang=N'Hơi cũ' or TinhTrang=N'Chữ Hơi mờ' "; 
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sachhu = new DataTable();
            cnn.Open();
            sachhu.Load(cmd.ExecuteReader());
            cnn.Close();
            return sachhu;
        }        
        private DataTable docsachbanchay()
        {
            string chuoikn = "select * from SACH WHERE MaSach  IN(select MaSach from PHIEUMUON WHERE SACH.MaSach=PHIEUMUON.MaSach)";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cnn.Open();
            sach.Load(cmd.ExecuteReader());
            cnn.Close();
            return sach;
        }
        private DataTable docsachtonkho()
        {
            string chuoikn = "select * from SACH where MaSach not in(select MaSach from SACHMUON )";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cnn.Open();
            sach.Load(cmd.ExecuteReader());
            cnn.Close();
            return sach;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (chsachhu.Checked)
            {
                dgvthongtin.DataSource=docsachhu();
                txttong.ForeColor = Color.Red;
                txttong.Text = (dgvthongtin.Rows.Count).ToString();
            }
            if (chsachkbd.Checked)
            {
                dgvthongtin.DataSource = docsachtonkho();
                txttong.ForeColor = Color.Red;
                txttong.Text = (dgvthongtin.Rows.Count).ToString();
            }
            if (chsachbandc.Checked)
            {
                dgvthongtin.DataSource = docsachbanchay();
                txttong.ForeColor = Color.Red;
                txttong.Text = (dgvthongtin.Rows.Count).ToString();
            }
        }

        private void thongtinsach_Load(object sender, EventArgs e)
        {

        }
    }
}
