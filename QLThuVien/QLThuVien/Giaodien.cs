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
    public partial class Giaodien : Form
    {
        SqlDataAdapter dat;
        DataTable dt;
        string A, B, C, D,E;
        SqlConnection cnn;
        SqlCommand sqlCommand;
        public Giaodien()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
        
        private void mnudk_Click(object sender, EventArgs e)
        {
            frmdangky f = new frmdangky();
            f.ShowDialog();
        }

        private void mnudmqlsv_Click(object sender, EventArgs e)
        {
            frmthethuvien f = new frmthethuvien();
            f.ShowDialog();
        }

        private void mnudlsach_Click(object sender, EventArgs e)
        {
            frmSach f = new frmSach();
            f.ShowDialog();
        }

        private void mnudlsachmuon_Click(object sender, EventArgs e)
        {
            frmSachMuon f = new frmSachMuon();
            f.ShowDialog();
        }

        private void mnudlphieumuon_Click(object sender, EventArgs e)
        {
            frmPhieuMuon f = new frmPhieuMuon();
            f.ShowDialog();
        }

        private void mnudlphieunhactra_Click(object sender, EventArgs e)
        {
            frmPhieuNhacTra f = new frmPhieuNhacTra();
            f.ShowDialog();
        }

        private void mnudlnhanvien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmthethuvien f = new frmthethuvien();
            f.ShowDialog();
        }

        private void btnQuanSach_Click(object sender, EventArgs e)
        {
            frmSach f = new frmSach();
            f.ShowDialog();
        }
        #region dang nhap
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = cnn;
            cnn.Open();
            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            cnn.Close();
            return obj;
            //Ket qua de dau ? - de trong obj
        }
        private void dangnhap()
        {
            lblthongbao.Text="";
            label1.Text = "";
            string ten, mk;
            ten = txttaikhoan.Text;
            mk = txtmatkhau.Text;
            if (txttaikhoan.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên không được trống";
                txttaikhoan.Focus();
                return;
            }
            if (txtmatkhau.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "mk không được trống";
                txtmatkhau.Focus();
                return;
            }
            if (ten != "")
            {
                object Q = layGiaTri("select * from taikhoan where tendn='" + ten + "' and mk='" + mk + "'");
                if (Q == null)
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "sai tai khoan";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Thành Công";
                    txttaikhoan.Text = "";
                    txtmatkhau.Text = "";
                    mnudanhmuc.Enabled = true;
                    mnuxuly.Enabled = true;
                    //mnubaocao.Enabled = true;
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dangnhap();
        }
        #endregion
        #region hienpass
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txttaikhoan.PasswordChar = '\0';
                txtmatkhau.PasswordChar = '\0';
            }
            else
            {
                txttaikhoan.PasswordChar = '\0';
                txtmatkhau.PasswordChar = '*';
            }
        }
        #endregion       

        private void Giaodien_Load(object sender, EventArgs e)
        {
            txtmatkhau.PasswordChar = '*';
            A = lbl1.Text;
            B = lbl2.Text;
            C = lbl3.Text;
            D = lbl4.Text;
            E = lbl5.Text;
            lbl1.Text = "";
            lbl2.Text = "";
            lbl4.Text = "";
            lbl5.Text = "";
            lbl3.Text = "";
            timer1.Start();
            mnudanhmuc.Enabled = false;
            mnuxuly.Enabled = false;
            //mnubaocao.Enabled = false;
        }
        //#region thoi gian
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    int d = 0, x;
        //    x = A.Length;
        //    d++;
        //    string a = A.Substring(0, 1);
        //    A = A.Substring(1, A.Length - 1);
        //    lbl1.Text = lbl1.Text + a;
        //    if (d == x)
        //    {
        //        timer1.Stop();
        //        timer2.Start();
        //    }
        //}

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    int d = 0, x;
        //    x = B.Length;
        //    d++;
        //    string a = B.Substring(0, 1);
        //    B = B.Substring(1, B.Length - 1);
        //    lbl2.Text = lbl2.Text + a;
        //    if (d == x)
        //    {
        //        timer2.Stop();
        //        timer3.Start();
        //    }
        //}

        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    int d = 0, x;
        //    x = C.Length;
        //    d++;
        //    string a = C.Substring(0, 1);
        //    C = C.Substring(1, C.Length - 1);
        //    lbl3.Text = lbl3.Text + a;
        //    if (d == x)
        //    {
        //        timer3.Stop();
        //        timer4.Start();
        //    }
        //}

        //private void timer4_Tick(object sender, EventArgs e)
        //{
        //    int d = 0, x;
        //    x = D.Length;
        //    d++;
        //    string a = D.Substring(0, 1);
        //    D = D.Substring(1, D.Length - 1);
        //    lbl4.Text = lbl4.Text + a;
        //    if (d == x)
        //    {
        //        timer4.Stop();
        //        timer5.Start();
        //    }
        //}

        //private void timer5_Tick(object sender, EventArgs e)
        //{
        //    int d = 0, x;
        //    x = E.Length;
        //    d++;
        //    string a = E.Substring(0, 1);
        //    E = E.Substring(1, E.Length - 1);
        //    lbl5.Text = lbl5.Text + a;
        //    if (d == x)
        //    {
        //        timer5.Stop();
        //    }
        //}
        //#endregion               
        private void mnudx_Click(object sender, EventArgs e)
        {
            mnudanhmuc.Enabled = false;
            mnuxuly.Enabled = false;
            //mnubaocao.Enabled = false;
        }

        private void mnubaocao_Click(object sender, EventArgs e)
        {
            thongtinsach F = new thongtinsach();
            F.ShowDialog();
        }

        private void mnubaocao_Click_1(object sender, EventArgs e)
        {
            thongtinsach f = new thongtinsach();
            f.ShowDialog();
        }

        private void mnutimkiem_Click(object sender, EventArgs e)
        {
            frmtimkiemsach f = new frmtimkiemsach();
            f.ShowDialog();
        }

        private void mnuxuly_Click(object sender, EventArgs e)
        {
            muontrasach f = new muontrasach();
            f.ShowDialog();
        }

        private void mnutrogiup_Click(object sender, EventArgs e)
        {
            frmnoiquy f = new frmnoiquy();
            f.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSachMuon f = new frmSachMuon();
            f.ShowDialog();
        }    
    }
}
