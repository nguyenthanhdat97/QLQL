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
	private void btnluu1_Click(object sender, EventArgs e)
        {
            huy_bingding();
            docthethuvien();
            luuthethuvien();
            data_bingding();
        }
        #endregion                        
        #region  sua thethuvien
        private void suathethuvien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_SUATHETHUVIEN";
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
        private void btnsua1_Click(object sender, EventArgs e)
        {
            huy_bingding();
            suathethuvien();
            data_bingding();
        }
	#endregion
        #region xoanhanvien
        private void XoaNhanVien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_XOANHANVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string manv;
            manv = txtMa.Text;
            cmd.Parameters.Add("@MaNV", manv);
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
                    int kq2 = (int)cmd.Parameters["@kq"].Value;
                    if (kq2 == 1)
                    {
                        lblthongbao.ForeColor = Color.Red;
                        lblthongbao.Text = "đã tồn tại TheThuViện trong phieu muon";
                        return;
                    } if (kq2 == 2)
                    {
                        lblthongbao.ForeColor = Color.Red;
                        lblthongbao.Text = "đã tồn tại TheThuViện trong phieu nhac tra";
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
                    lblthongbao.Text = "Mã đã tồn tại trong Phiếu nhắc trả";
                    return;
                }
                else
                {
                    lblthongbao.ForeColor = Color.Red;
                    lblthongbao.Text = "Xóa Thành Công";
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
        private void btnxoa1_Click(object sender, EventArgs e)
        {
            huy_bingding();
            XoaNhanVien();
            data_bingding();
        }
        #endregion        
        #region lui
        private void btnlui1_Click(object sender, EventArgs e)
        {
            if (vt > 0)
            {
                vt--;
                DataRow r = vtttv.Rows[vt];
                txtMa.Text = r[0].ToString();
                txtTensv.Text = r[1].ToString();
                cboGioitinh.Text = r[2].ToString();
                dtngaysinh.Text = r[3].ToString();
                txtdiachisv.Text = r[4].ToString();
                txtdt.Text = r[5].ToString();
                dtngaytao.Text = r[6].ToString();
                dtngayhethan.Text = r[7].ToString();
                txtpage.Text = vt.ToString();
                txtpage.Text = (1 + vt).ToString() + "/" + vtttv.Rows.Count.ToString();
                btntoi1.Enabled = true;
                Hienbangpm(txtMa.Text);
            }
            else btnlui1.Enabled = false;
        }
        #endregion
        #region toi
        private void btntoi1_Click(object sender, EventArgs e)
        {
            if (vt < vtttv.Rows.Count - 1)
            {
                vt++;
                DataRow r = vtttv.Rows[vt];
                txtMa.Text = r[0].ToString();
                txtTensv.Text = r[1].ToString();
                cboGioitinh.Text = r[2].ToString();
                dtngaysinh.Text = r[3].ToString();
                txtdiachisv.Text = r[4].ToString();
                txtdt.Text = r[5].ToString();
                dtngaytao.Text = r[6].ToString();
                dtngayhethan.Text = r[7].ToString();
                txtpage.Text = vt.ToString();
                txtpage.Text = (1 + vt).ToString() + "/" + vtttv.Rows.Count.ToString();
                btnlui1.Enabled = true;
                Hienbangpm(txtMa.Text);
            }
            else btntoi1.Enabled = false;
        }
        #endregion
        #region cuoi
        private void btncuoi1_Click(object sender, EventArgs e)
        {
            if (vt < vtttv.Rows.Count - 1)
            {
                vt = vtttv.Rows.Count - 1;
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
                btndau1.Enabled = true;
                Hienbangpm(txtMa.Text);
            }
            else btncuoi1.Enabled = false;
        }
        #endregion
        #region dau
        private void btndau1_Click(object sender, EventArgs e)
        {
            if (vt >0)
            {
                vt = 0;
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
                btncuoi1.Enabled = true;
                Hienbangpm(txtMa.Text);
            }
            else btndau1.Enabled = false;
        }
	 #endregion                
	#endregion
	#region load SACH
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
            cbomasach.DataSource = docsach();
            cbomasach.ValueMember = "MaSach";
            cbomasach.DisplayMember = "TenSach";
        }
        #endregion


        #region XU LY PHIEU MUON
        #region thempm
        private void btnthempm_Click(object sender, EventArgs e)
        {
            txtMapm.Clear();
            txtMapm.Text = taomapm();
        }
        #endregion
        #region luuphieumuon
        private void luuphieumuon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Luuphieumuonsinhvien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string mapm, mathe, masach;
            DateTime ngaymuon;
            mapm = txtMapm.Text;
            masach = cbomasach.SelectedValue.ToString();
            mathe = txtMa.Text;
            ngaymuon = DateTime.Parse(dtpNgaymuon.Value.ToString());
            cmd.Parameters.AddWithValue("@MaPM", mapm);
            cmd.Parameters.AddWithValue("@MaSach", masach);
            cmd.Parameters.AddWithValue("@MaThe", mathe);
            cmd.Parameters.AddWithValue("@NgayMuon", ngaymuon);
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
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Đã tồn tại phiếu mượn";
                    return;
                }
                else if (kq == 2)
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Không tồn tại sách ";
                    return;
                }
                else if (kq == 3)
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Không tồn tại Sinh Viên";
                    return;
                }
                else if (kq == 4)
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Sinh viên mượn không quá 3 Quyển";
                    return;
                }
                else
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Luu Thành Công";
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
        private void btnluupm_Click(object sender, EventArgs e)
        {            
            luuphieumuon();
            Hienbangpm(txtMa.Text);
            docthethuvien();
        }
        #endregion
        #region docpm
        private DataTable docphieumuon(string mathe)
        {
            DataTable pmsv = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Docphieumuonsinhvien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            //masv = txtmasv.Text;
            cmd.Parameters.AddWithValue("@mathe", mathe);
            try
            {
                cnn.Open();
                pmsv.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                MessageBox.Show("Loi khong doc duoc phieu muon",e.Message);
            }
            finally
            {
                if (cnn != null)
                    cnn.Close();
            }
            return pmsv;
        }
        private void Hienbangpm(string mathe)
        {
            huybingdingketqua();
            dgvds1.DataSource = docphieumuon(mathe);
            bingdingketqua();
        }
        #endregion
        #region bingdingkq
        private void bingdingketqua()
        {
            cbomasach.DataBindings.Add("SelectedValue", dgvds1.DataSource, "MaSach");
            txtMapm.DataBindings.Add("Text", dgvds1.DataSource, "MaPM");
        }
        private void huybingdingketqua()
        {
            if (cbomasach.DataBindings != null)
                cbomasach.DataBindings.Clear();
            if (txtMapm.DataBindings != null)
                txtMapm.DataBindings.Clear();
        }
        #endregion
        #region  sua phieu muon
        private void suaphieumuon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_SUAPHIEUMUON";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string mapm, mathe, masach;
            DateTime ngaymuon;
            mapm = txtMapm.Text;
            masach = cbomasach.SelectedValue.ToString();
            mathe = txtMa.Text;
            ngaymuon = DateTime.Parse(dtpNgaymuon.Value.ToString());
            cmd.Parameters.Add("@MaPM", mapm);
            cmd.Parameters.Add("@MaSach", masach);
            cmd.Parameters.Add("@MaThe", mathe);
            cmd.Parameters.Add("@NgayMuon", ngaymuon);
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
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "không tồn tại phiếu mượn";
                    return;
                }
                else if (kq == 1)
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Không tồn tại sách ";
                    return;
                }
                else if (kq == 1)
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Không tồn tại Sinh Viên";
                    return;
                }
                else
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Sửa Thành Công";
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
	  private void btnsuapm_Click(object sender, EventArgs e)
        {
            huy_bingding();
            suaphieumuon();
            Hienbangpm(txtMa.Text);
            docthethuvien();
            data_bingding();
        }
        #endregion
        #region xoa phieumuon
        private void xoaphieumuon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Xoaphieumuonsinhvien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string mapm;
            mapm = txtMapm.Text;
            cmd.Parameters.Add("@MaPM", mapm);
            DialogResult kq1;
            kq1 = MessageBox.Show("Bạn Thật Sự Muốn Xóa", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Đã tồn tại PM trong sách mượn";
                    return;
                }
                else
                {
                    lbltbpm.ForeColor = Color.Red;
                    lbltbpm.Text = "Xóa Thành Công";
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
        private void btnxoapm_Click(object sender, EventArgs e)
        {
            huybingdingketqua();
            xoaphieumuon();
            Hienbangpm(txtMa.Text);
        }
        #endregion
        #endregion

        #region SINH VIEN CẦN NHẮC TRẢ
        #region bingding
        private void data_bingding2()
        {

        }
        private void huy_bingding2()
        {
            if (dtngaysinh1.DataBindings != null)
                dtngaysinh1.DataBindings.Clear();
            if (txtdienthoai.DataBindings != null)
                txtdienthoai.DataBindings.Clear();
            if (txtmathe1.DataBindings != null)
                txtmathe1.DataBindings.Clear();
            if (txtten1.DataBindings != null)
                txtten1.DataBindings.Clear();
            if (dttao1.DataBindings != null)
                dttao1.DataBindings.Clear();
            if (dthethan1.DataBindings != null)
                dthethan1.DataBindings.Clear();
            if (txtdc1.DataBindings != null)
                txtdc1.DataBindings.Clear();
            if (cbogt.DataBindings != null)
                cbogt.DataBindings.Clear();
        }
        #endregion
        #region luu the thu vien 2
        private void luusinhvien2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LUUTHETHUVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string ma, ten, diachi, dt;
            DateTime ngaytao, ngayhethan, ngaysinh;
            bool gioitinh;
            ma = txtmathe1.Text;
            ten = txtten1.Text;
            diachi = txtdc1.Text;
            dt = txtdienthoai.Text;
            ngayhethan = DateTime.Parse(dthethan1.Value.ToString());
            ngaytao = DateTime.Parse(dttao1.Value.ToString());
            ngaysinh = DateTime.Parse(dtngaysinh1.Value.ToString());
            if (DateTime.Now.Year - ngaysinh.Year > 85 || DateTime.Now.Year - ngaysinh.Year < 18)
            {
                lblthongbao1.ForeColor = Color.Red;
                lblthongbao1.Text = "sinh viên phải đủ tuổi từ 18-85";
                dtngaysinh1.Focus();
                return;
            }
            if (txtten1.Text == "")
            {
                lblthongbao1.ForeColor = Color.Red;
                lblthongbao1.Text = "Tên không được để trống";
                txtten1.Focus();
                return;
            }
            if (txtdc1.Text == "")
            {
                lblthongbao1.ForeColor = Color.Red;
                lblthongbao1.Text = "Địa chỉ không được để trống";
                txtdc1.Focus();
                return;
            }
            if (cbogt.Text == "Nam")
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
                    lblthongbao1.ForeColor = Color.Red;
                    lblthongbao1.Text = "đã tồn tại TheThuViện";
                    return;
                }
                else
                {
                    lblthongbao1.ForeColor = Color.Red;
                    lblthongbao1.Text = "Lưu Thành Công";
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
        private void btnluu2_Click(object sender, EventArgs e)
        {
            huy_bingding2();
            luusinhvien2();
            docthethuvien();
            data_bingding2();
        }
        #endregion
        #region  sua thethuvien trong NHẮC TRẢ
        private void suathethuvien2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_SUATHETHUVIEN";
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
                    lblthongbao1.ForeColor = Color.Red;
                    lblthongbao1.Text = "đã tồn tại TheThuViện";
                    return;
                }
                else
                {
                    lblthongbao1.ForeColor = Color.Red;
                    lblthongbao1.Text = "Sửa Thành Công";
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
