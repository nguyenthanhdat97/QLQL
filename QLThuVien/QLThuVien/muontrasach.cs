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
	 public DataTable docthethuvien()
        {
            
            frmthethuvien f = new frmthethuvien();
            return f.docthethuvien();
        }
        #endregion        
        #region hiện thị mã thẻ
        private string taomathe()
        {
            string mapthe;
            Random r = new Random();
            mapthe = "NV" + r.Next(50, 999).ToString();
            return mapthe;
        }
        #endregion


        #region sinhvien MUON
        #region TTVdautien
        private void hiensvdautien()
        {
            txtpage.Text = vt.ToString();
            vtttv = new DataTable();
            vtttv = docthethuvien();
            DataRow r = vtttv.Rows[vt];
            txtMa.Text = r[0].ToString();
            txtTensv.Text = r[1].ToString();
            cboGioitinh.Text = r[2].ToString();
            dtngaysinh.Text = r[3].ToString();
            txtdiachisv.Text = r[4].ToString();
            txtdt.Text = r[5].ToString();
            dtngaytao.Text = r[6].ToString();
            dtngayhethan.Text = r[7].ToString();
            txtpage.Text = (1 + vt).ToString() + "/" + vtttv.Rows.Count.ToString();
        }
        #endregion
        #region bingding
        private void data_bingding()
        {
            
        }
        private void huy_bingding()
        {
            if (dtngaysinh.DataBindings != null)
                dtngaysinh.DataBindings.Clear();
            if (txtdt.DataBindings != null)
                txtdt.DataBindings.Clear();
            if (txtMa.DataBindings != null)
                txtMa.DataBindings.Clear();
            if (txtTensv.DataBindings != null)
                txtTensv.DataBindings.Clear();
            if (dtngaytao.DataBindings != null)
                dtngaytao.DataBindings.Clear();
            if (dtngayhethan.DataBindings != null)
                dtngayhethan.DataBindings.Clear();
            if (txtdiachisv.DataBindings != null)
                txtdiachisv.DataBindings.Clear();
            if (cboGioitinh.DataBindings != null)
                cboGioitinh.DataBindings.Clear();
        }
        #endregion
        #region hiện mã pm
        private string taomapm()
        {
            string mapm;
            Random r = new Random();
            mapm = "NV" + r.Next(50, 999).ToString();
            return mapm;
        }
        #endregion        
        #region lam mới dữ liệu
        private void btnthem2_Click(object sender, EventArgs e)
        {
            txtmathe1.Clear();
            txtten1.Clear();
            txtdienthoai.Clear();
            txtpage1.Clear();
            txtmathe1.Text = taomathe();
        }

        private void btnthem1_Click(object sender, EventArgs e)
        {
            txtdt.Clear();
            txtMa.Clear();
            txtTensv.Clear();
            txtdiachisv.Clear();
            txtpage.Clear();
            txtMa.Text = taomathe();
        }
        #endregion
        #region thêm vào sinh viên
        
        #endregion
        #region luu the thu vien 
        private void luuthethuvien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LUUTHETHUVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string ma, ten, diachi, dt;
            DateTime ngaytao, ngayhethan, ngaysinh;
            bool gioitinh;
            ma = txtMa.Text;
            ten = txtTensv.Text;
            diachi = txtdiachisv.Text;
            dt = txtdt.Text;
            ngayhethan = DateTime.Parse(dtngayhethan.Value.ToString());
            ngaytao = DateTime.Parse(dtngaytao.Value.ToString());
            ngaysinh = DateTime.Parse(dtngaysinh.Value.ToString());
            if (DateTime.Now.Year - ngaysinh.Year > 85 || DateTime.Now.Year - ngaysinh.Year < 18)
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "sinh viên phải đủ tuổi từ 18-85";
                dtngaysinh.Focus();
                return;
            }
            if (txtTensv.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên không được để trống";
                txtTensv.Focus();
                return;
            }
            if (txtdiachisv.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Địa chỉ không được để trống";
                txtdiachisv.Focus();
                return;
            }
            if (cboGioitinh.Text == "Nam")
            {
                gioitinh = true;
            }
            else gioitinh = false;
            cmd.Parameters.Add("@MaThe", ma);
            cmd.Parameters.Add("@TenSV", ten);
            cmd.Parameters.Add("@GioiTinh", gioitinh);
            cmd.Parameters.Add("@NgaySinh", ngaysinh);
            cmd.Parameters.Add("@DiaChiSV", diachi);
            cmd.Parameters.Add("@DienThoai", dt);
            cmd.Parameters.Add("@NgayTao", ngaytao);
            cmd.Parameters.Add("@NgayHetHan", ngayhethan);
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
                    lblthongbao.Text = "đã tồn tại TheThuViện";
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
    }
}
