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
	#region masach
        private string taomasach()
        {
            string masach;
            Random r = new Random();
            masach = "MS" + r.Next(50, 999).ToString();
            return masach;
        }
        #endregion
        #region Thêm
        private void btnthemsach_Click(object sender, EventArgs e)
        {
            txtMasach.Clear();
            txtTensach.Clear();
            txtsoluong.Clear();
            txttinhtrang.Clear();
            txttheloaisach.Clear();
            txtnamxb.Clear();
            txtnxb.Clear();
            txttg.Clear();
            txtMasach.Text = taomasach();
        }
        #endregion
        #region luu sach
        private void luusach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LUUSACH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string masach, ten, theloai, tinhtrang, nxb, namxb, tg,filehinh;
            int soluong;
            if (txtTensach.Text=="")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên không được trống";
                txtTensach.Focus();
                return;
            }
            if (txtnamxb.TextLength>4)
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "sai định dạng năm";
                txtnamxb.Focus();
                return;
            }
            if (txttg.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tg không được trống";
                txttg.Focus();
                return;
            }
            if (txtnxb.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "nxb không được trống";
                txtnxb.Focus();
                return;
            }
            filehinh = openFileDialog1.FileName;
            hinh = File.ReadAllBytes(filehinh);
            masach = txtMasach.Text;
            ten = txtTensach.Text;
            theloai = txttheloaisach.Text;           
            soluong = int.Parse(txtsoluong.Text);
            tinhtrang = txttinhtrang.Text;
            nxb = txtnxb.Text;
            namxb = txtnamxb.Text;
            tg =  txttg.Text;            
            cmd.Parameters.Add("@MaSach", masach);
            cmd.Parameters.Add("@TenSach", ten);
            cmd.Parameters.Add("@TheLoai", theloai);
            cmd.Parameters.Add("@SoLuong", soluong);
            cmd.Parameters.Add("@TinhTrang", tinhtrang);
            cmd.Parameters.Add("@NXB", nxb);
            cmd.Parameters.Add("@NamXB", namxb);
            cmd.Parameters.Add("@TG", tg);
            cmd.Parameters.Add("@HINH", hinh);
            try
            {
                cmd.Parameters.Add("@kq",
                SqlDbType.Int).Direction =
                    ParameterDirection.ReturnValue;
                cnn.Open();
                cmd.ExecuteNonQuery();
                int kq = (int)cmd.Parameters["@kq"].Value;
                if (kq == 1)
                {
                    lblthongbao.ForeColor = Color.Red;
                    lblthongbao.Text = "đã tồn tại sách";
                    return;
                }
                else
                {
                    lblthongbao.ForeColor = Color.Red;
                    lblthongbao.Text = "Lưu Thành Công";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi kg them duoc vi" + ex.Message);
            }
            finally
            {
                if (cnn != null)
                    cnn.Close();
            }            
        }

        private void btnluusach_Click(object sender, EventArgs e)
        {
            huy_bingding();
            luusach();            
            loaddlsach();
            data_bingding();
        }
        #endregion
        #region Xóa sach
        private void xoasach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_XOASACH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string masach;
            masach = txtMasach.Text;            
            cmd.Parameters.Add("@MaSach", masach);
            DialogResult kq1;
            kq1 = MessageBox.Show("Bạn Thật Sự Muốn Xóa", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq1 == DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Add("@kq",
                    SqlDbType.Int).Direction =
                        ParameterDirection.ReturnValue;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    int kq = (int)cmd.Parameters["@kq"].Value;
                    if (kq == 1)
                    {
                        lblthongbao.ForeColor = Color.Red;
                        lblthongbao.Text = "Đã tồn tại sách trong PMuon";
                        return;
                    }
                    else if (kq == 2)
                    {
                        lblthongbao.ForeColor = Color.Red;
                        lblthongbao.Text = "Đã tồn tại sách trong PNhắcTrả";
                        return;
                    }
                    else if (kq == 3)
                    {
                        lblthongbao.ForeColor = Color.Red;
                        lblthongbao.Text = "Đã tồn tại sách trong Sách Mượn";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi kg them duoc vi" + ex.Message);
                }
                finally
                {
                    if (cnn != null)
                        cnn.Close();
                }
            }
            lblthongbao.ForeColor = Color.Red;
            lblthongbao.Text = "Xóa Thành Công";
        }
        private void btnxoasach_Click(object sender, EventArgs e)
        {
            huy_bingding();
            xoasach();
            loaddlsach();
            data_bingding();
        }
        #endregion        
        #region sua sach
        private void Suasach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_SUASACH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string masach, ten, theloai, tinhtrang, nxb, namxb, tg, filehinh;
            int soluong;
            if (txtTensach.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên không được trống";
                txtTensach.Focus();
                return;
            }
            if (txttg.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tg không được trống";
                txttg.Focus();
                return;
            }
            if (txtnxb.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "nxb không được trống";
                txtnxb.Focus();
                return;
            }
            masach = txtMasach.Text;
            ten = txtTensach.Text;
            theloai = txttheloaisach.Text;
            soluong = int.Parse(txtsoluong.Text);
            tinhtrang = txttinhtrang.Text;
            nxb = txtnxb.Text;
            namxb = txtnamxb.Text;
            tg = txttg.Text;
            filehinh = openFileDialog1.FileName;            
            try
            {
                hinh = File.ReadAllBytes(filehinh);
            }
            catch (Exception)
            {
                hinh = null;
            }
            cmd.Parameters.Add("@MaSach", masach);
            cmd.Parameters.Add("@TenSach", ten);
            cmd.Parameters.Add("@TheLoai", theloai);
            cmd.Parameters.Add("@SoLuong", soluong);
            cmd.Parameters.Add("@TinhTrang", tinhtrang);
            cmd.Parameters.Add("@NXB", nxb);
            cmd.Parameters.Add("@NamXB", namxb);
            cmd.Parameters.Add("@TG", tg);
            cmd.Parameters.Add("@HINH", hinh);
            try
            {
                cmd.Parameters.Add("@kq",
                SqlDbType.Int).Direction =
                    ParameterDirection.ReturnValue;
                cnn.Open();
                cmd.ExecuteNonQuery();
                int kq = (int)cmd.Parameters["@kq"].Value;
                if (kq == 1)
                {
                    lblthongbao.ForeColor = Color.Red;
                    lblthongbao.Text = "Mã không tồn tại";
                    return;
                }
                else
                {
                    lblthongbao.ForeColor = Color.Red;
                    lblthongbao.Text = "Sửa Thành Công";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi kg sửa duoc vi" + ex.Message);
            }
            finally
            {
                if (cnn != null)
                    cnn.Close();
            }
        }
        private void btnsuasach_Click(object sender, EventArgs e)
        {
            huy_bingding();
            Suasach();
            loaddlsach();
            data_bingding();
        }        
        #endregion
    }
}
