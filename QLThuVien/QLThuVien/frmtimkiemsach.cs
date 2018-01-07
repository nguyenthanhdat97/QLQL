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
    public partial class frmtimkiemsach : Form
    {
        OpenFileDialog file;
        SqlConnection cnn;
        public frmtimkiemsach()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
        private void frmtimkiemsach_Load(object sender, EventArgs e)
        {
            loaddlsach();
        }
        private DataTable docsachtheoTinhTrang(string tinhtrang)
        {
            string chuoikn = "select * from SACH where TinhTrang=@TinhTrang";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TinhTrang", tinhtrang);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachtheoma(string ma)
        {
            string chuoikn = "select * from SACH where MaSach LIKE @MaSach";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSach", ma);
            try
            {
                 cnn.Open();
            sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {
                
            }
            finally
                {
                    if (cnn!=null)
                    {
                        cnn.Close();
                    }
                }
            
            return sach;
        }
        private DataTable docsachtheoten(string TEN)
        {
            string chuoikn = "select * from SACH where TenSach=@TenSach";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenSach", TEN);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachsoluong(string SoLuong)
        {
            string chuoikn = "select * from SACH where SoLuong=@SoLuong";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachtheonam(string NamXB)
        {
            string chuoikn = "select * from SACH where NamXB=@NamXB";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NamXB", NamXB);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachNXB(string NXB)
        {
            string chuoikn = "select * from SACH where NXB=@NXB";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NXB", NXB);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachTheLoai(string TheLoai)
        {
            string chuoikn = "select * from SACH where TheLoai=@TheLoai";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TheLoai", TheLoai);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private DataTable docsachTG(string TG)
        {
            string chuoikn = "select * from SACH where TG=@TG";
            SqlCommand cmd = new SqlCommand(chuoikn, cnn);
            DataTable sach = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TG", TG);
            try
            {
                cnn.Open();
                sach.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return sach;
        }
        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            if (txtMasach.Text!=null)
            {
                dgvthongtin.DataSource = docsachtheoma(txtMasach.Text);
            }
            if (txtTensach.Text != null)
            {
                dgvthongtin.DataSource = docsachtheoten(txtTensach.Text);
            }
            if (txtnamxb.Text != null)
            {
                dgvthongtin.DataSource = docsachtheonam(txtnamxb.Text);
            }
            if (txtsoluong.Text != null)
            {
                dgvthongtin.DataSource = docsachsoluong(txtsoluong.Text);
            }
            if (txtnxb.Text != null)
            {
                dgvthongtin.DataSource = docsachNXB(txtnxb.Text);
            }
            if (txttheloaisach.Text != null)
            {
                dgvthongtin.DataSource = docsachTheLoai(txttheloaisach.Text);
            }
            if (txttg.Text != null)
            {
                dgvthongtin.DataSource = docsachTG(txttg.Text);
            }
        }
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
            dgvthongtin.DataSource = docsach();
            lbltong.ForeColor = Color.Red;
            lbltong.Text = (dgvthongtin.Rows.Count).ToString()+ " quyển";
        }
        #endregion
        #region xử lý bingding
        private void data_bingding()
        {
            txtMasach.DataBindings.Add("Text", dgvthongtin.DataSource, "MaSach");
            txtTensach.DataBindings.Add("Text", dgvthongtin.DataSource, "TenSach");
            txttheloaisach.DataBindings.Add("Text", dgvthongtin.DataSource, "TheLoai");
            txttinhtrang.DataBindings.Add("Text", dgvthongtin.DataSource, "TinhTrang");
            txtsoluong.DataBindings.Add("Text", dgvthongtin.DataSource, "SoLuong");
            txtnxb.DataBindings.Add("Text", dgvthongtin.DataSource, "NXB");
            txtnamxb.DataBindings.Add("Text", dgvthongtin.DataSource, "NamXB");
            txttg.DataBindings.Add("Text", dgvthongtin.DataSource, "TG");
            PICHINH.DataBindings.Add("Image", dgvthongtin.DataSource, "Hinh", true);
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
            if (PICHINH.DataBindings != null)
                PICHINH.DataBindings.Clear();
        }
        private void tieudecotsach()
        {
            dgvthongtin.Columns[0].HeaderText = "Mã Sách";
            dgvthongtin.Columns[1].HeaderText = "Tên Sách";
            dgvthongtin.Columns[2].HeaderText = "Thể Loại";
            dgvthongtin.Columns[3].HeaderText = "Tình Trạng";
            dgvthongtin.Columns[4].HeaderText = "Số Lượng";
            dgvthongtin.Columns[5].HeaderText = "Mã NXB";
            dgvthongtin.Columns[6].HeaderText = "Năm NXB";
            dgvthongtin.Columns[7].HeaderText = "Mã TG";
            dgvthongtin.Columns[8].HeaderText = "Hình";
        }
        #endregion
        #region Lấy hình
        private void BTNHINH_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Image file(*.jpg)|*.jpg";
            string tenanh = openFileDialog1.FileName;
            Bitmap anh = new Bitmap(tenanh);
            PICHINH.SizeMode = PictureBoxSizeMode.Zoom;
            PICHINH.Image = (Image)anh;
            PICHINH.Text = "Đường dẫn file ảnh : " + tenanh;
            PICHINH.Text = tenanh;            
        }
        #endregion
    }
}
