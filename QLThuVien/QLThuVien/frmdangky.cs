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
    public partial class frmdangky : Form
    {
        SqlConnection cnn;
        public frmdangky()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }
        private void dangky()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_luutk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            string ten, mk,nlmk;
            ten = txttentk.Text;
            mk = txtmk.Text;
            nlmk = txtnlmk.Text;
            if (txttentk.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên không được trống";
                txttentk.Focus();
                return;
            }
            if (txtmk.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "mk không được trống";
                txtmk.Focus();
                return;
            }
            if (txtnlmk.Text == "")
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "nlmk không được trống";
                txtnlmk.Focus();
                return;
            }
            if (txttentk.Text.Length-1 <5)
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Tên quá ngắn";
                txttentk.Focus();
                return;
            }
            if (txtmk.Text.Length - 1 < 5)
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Mật khẩu không an toàn";
                txtmk.Focus();
                return;
            }
            if (txtmk.Text!=txtnlmk.Text)
            {
                lblthongbao.ForeColor = Color.Red;
                lblthongbao.Text = "Mật khẩu không trùng";
                txtmk.Focus();
                return;                
            }
            cmd.Parameters.AddWithValue("@tendn", ten);
            cmd.Parameters.AddWithValue("@mk", mk);
            cmd.Parameters.AddWithValue("@nhmk", nlmk);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            this.Close();
        }
        private void btndangky_Click(object sender, EventArgs e)
        {
            dangky();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txttentk.PasswordChar = '\0';
                txtmk.PasswordChar = '\0';
                txtnlmk.PasswordChar = '\0';
            }
            else
            {
                txttentk.PasswordChar = '\0';
                txtmk.PasswordChar = '*';
                txtnlmk.PasswordChar = '*';
            }
        }

        private void frmdangky_Load(object sender, EventArgs e)
        {
            txtmk.PasswordChar = '*';
            txtnlmk.PasswordChar = '*';
        }
        private void frmdangky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn thật sự muốn thoát không?", "Chú Ý!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
