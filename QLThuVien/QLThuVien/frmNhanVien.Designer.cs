namespace QLThuVien
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblthongbaonv = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnthoatnv = new System.Windows.Forms.Button();
            this.btnsuanv = new System.Windows.Forms.Button();
            this.btnluunv = new System.Windows.Forms.Button();
            this.btnthemnv = new System.Windows.Forms.Button();
            this.btnxoanv = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvttnv = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboGioitinhnv = new System.Windows.Forms.ComboBox();
            this.dtngayvaolam = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaysinhnv = new System.Windows.Forms.DateTimePicker();
            this.txtDienthoainv = new System.Windows.Forms.TextBox();
            this.txtDiachinv = new System.Windows.Forms.TextBox();
            this.txtchucvunv = new System.Windows.Forms.TextBox();
            this.txtTennv = new System.Windows.Forms.TextBox();
            this.txtManv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btncuoi = new System.Windows.Forms.Button();
            this.btntoi = new System.Windows.Forms.Button();
            this.btnlui = new System.Windows.Forms.Button();
            this.btndau = new System.Windows.Forms.Button();
            this.txtpage = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvttnv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Colonna MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(293, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(405, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "DANH MỤC DANH SÁCH NHÂN VIÊN";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblthongbaonv);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnthoatnv);
            this.groupBox3.Controls.Add(this.btnsuanv);
            this.groupBox3.Controls.Add(this.btnluunv);
            this.groupBox3.Controls.Add(this.btnthemnv);
            this.groupBox3.Controls.Add(this.btnxoanv);
            this.groupBox3.Location = new System.Drawing.Point(3, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1020, 83);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Xử Lý";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lblthongbaonv
            // 
            this.lblthongbaonv.AutoSize = true;
            this.lblthongbaonv.Location = new System.Drawing.Point(631, 22);
            this.lblthongbaonv.Name = "lblthongbaonv";
            this.lblthongbaonv.Size = new System.Drawing.Size(0, 13);
            this.lblthongbaonv.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(923, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnthoatnv
            // 
            this.btnthoatnv.Location = new System.Drawing.Point(490, 33);
            this.btnthoatnv.Name = "btnthoatnv";
            this.btnthoatnv.Size = new System.Drawing.Size(91, 28);
            this.btnthoatnv.TabIndex = 0;
            this.btnthoatnv.Text = "Thoát";
            this.btnthoatnv.UseVisualStyleBackColor = true;
            this.btnthoatnv.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsuanv
            // 
            this.btnsuanv.Location = new System.Drawing.Point(362, 33);
            this.btnsuanv.Name = "btnsuanv";
            this.btnsuanv.Size = new System.Drawing.Size(91, 28);
            this.btnsuanv.TabIndex = 0;
            this.btnsuanv.Text = "Sửa";
            this.btnsuanv.UseVisualStyleBackColor = true;
            this.btnsuanv.Click += new System.EventHandler(this.btnsuanv_Click);
            // 
            // btnluunv
            // 
            this.btnluunv.Location = new System.Drawing.Point(122, 31);
            this.btnluunv.Name = "btnluunv";
            this.btnluunv.Size = new System.Drawing.Size(91, 28);
            this.btnluunv.TabIndex = 0;
            this.btnluunv.Text = "Lưu";
            this.btnluunv.UseVisualStyleBackColor = true;
            this.btnluunv.Click += new System.EventHandler(this.btnluunv_Click);
            // 
            // btnthemnv
            // 
            this.btnthemnv.Location = new System.Drawing.Point(4, 31);
            this.btnthemnv.Name = "btnthemnv";
            this.btnthemnv.Size = new System.Drawing.Size(91, 28);
            this.btnthemnv.TabIndex = 0;
            this.btnthemnv.Text = "Thêm";
            this.btnthemnv.UseVisualStyleBackColor = true;
            this.btnthemnv.Click += new System.EventHandler(this.btnthemnv_Click);
            // 
            // btnxoanv
            // 
            this.btnxoanv.Location = new System.Drawing.Point(241, 31);
            this.btnxoanv.Name = "btnxoanv";
            this.btnxoanv.Size = new System.Drawing.Size(91, 28);
            this.btnxoanv.TabIndex = 0;
            this.btnxoanv.Text = "Xóa";
            this.btnxoanv.UseVisualStyleBackColor = true;
            this.btnxoanv.Click += new System.EventHandler(this.btnxoanv_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.dgvttnv);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(379, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 390);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng Thông Tin Nhân Viên";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 27;
            // 
            // dgvttnv
            // 
            this.dgvttnv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvttnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvttnv.Location = new System.Drawing.Point(6, 44);
            this.dgvttnv.Name = "dgvttnv";
            this.dgvttnv.Size = new System.Drawing.Size(632, 340);
            this.dgvttnv.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Hiện có:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboGioitinhnv);
            this.groupBox1.Controls.Add(this.dtngayvaolam);
            this.groupBox1.Controls.Add(this.dtpNgaysinhnv);
            this.groupBox1.Controls.Add(this.txtDienthoainv);
            this.groupBox1.Controls.Add(this.txtDiachinv);
            this.groupBox1.Controls.Add(this.txtchucvunv);
            this.groupBox1.Controls.Add(this.txtTennv);
            this.groupBox1.Controls.Add(this.txtManv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 459);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Nhân Viên";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cboGioitinhnv
            // 
            this.cboGioitinhnv.FormattingEnabled = true;
            this.cboGioitinhnv.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioitinhnv.Location = new System.Drawing.Point(127, 330);
            this.cboGioitinhnv.Name = "cboGioitinhnv";
            this.cboGioitinhnv.Size = new System.Drawing.Size(75, 21);
            this.cboGioitinhnv.TabIndex = 3;
            // 
            // dtngayvaolam
            // 
            this.dtngayvaolam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtngayvaolam.Location = new System.Drawing.Point(127, 280);
            this.dtngayvaolam.Name = "dtngayvaolam";
            this.dtngayvaolam.Size = new System.Drawing.Size(135, 20);
            this.dtngayvaolam.TabIndex = 2;
            // 
            // dtpNgaysinhnv
            // 
            this.dtpNgaysinhnv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaysinhnv.Location = new System.Drawing.Point(127, 229);
            this.dtpNgaysinhnv.Name = "dtpNgaysinhnv";
            this.dtpNgaysinhnv.Size = new System.Drawing.Size(135, 20);
            this.dtpNgaysinhnv.TabIndex = 2;
            // 
            // txtDienthoainv
            // 
            this.txtDienthoainv.Location = new System.Drawing.Point(127, 180);
            this.txtDienthoainv.Name = "txtDienthoainv";
            this.txtDienthoainv.Size = new System.Drawing.Size(227, 20);
            this.txtDienthoainv.TabIndex = 1;
            // 
            // txtDiachinv
            // 
            this.txtDiachinv.Location = new System.Drawing.Point(127, 383);
            this.txtDiachinv.Multiline = true;
            this.txtDiachinv.Name = "txtDiachinv";
            this.txtDiachinv.Size = new System.Drawing.Size(227, 70);
            this.txtDiachinv.TabIndex = 1;
            // 
            // txtchucvunv
            // 
            this.txtchucvunv.Location = new System.Drawing.Point(127, 128);
            this.txtchucvunv.Name = "txtchucvunv";
            this.txtchucvunv.Size = new System.Drawing.Size(227, 20);
            this.txtchucvunv.TabIndex = 1;
            // 
            // txtTennv
            // 
            this.txtTennv.Location = new System.Drawing.Point(127, 71);
            this.txtTennv.Name = "txtTennv";
            this.txtTennv.Size = new System.Drawing.Size(227, 20);
            this.txtTennv.TabIndex = 1;
            // 
            // txtManv
            // 
            this.txtManv.Location = new System.Drawing.Point(127, 22);
            this.txtManv.Name = "txtManv";
            this.txtManv.Size = new System.Drawing.Size(88, 20);
            this.txtManv.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(20, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gioi Tính";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(20, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ngày Vào Làm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(20, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Điện Thoại  NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(20, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày Sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(20, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Địa Chỉ  NV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(20, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chức Vụ Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(20, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên NV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NV";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btncuoi);
            this.groupBox4.Controls.Add(this.btntoi);
            this.groupBox4.Controls.Add(this.btnlui);
            this.groupBox4.Controls.Add(this.btndau);
            this.groupBox4.Controls.Add(this.txtpage);
            this.groupBox4.Location = new System.Drawing.Point(379, 523);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(644, 63);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Điều Khiền";
            // 
            // btncuoi
            // 
            this.btncuoi.BackgroundImage = global::QLThuVien.Properties.Resources.Actions_green_arrow_right_end_icon;
            this.btncuoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btncuoi.Location = new System.Drawing.Point(510, 19);
            this.btncuoi.Name = "btncuoi";
            this.btncuoi.Size = new System.Drawing.Size(87, 29);
            this.btncuoi.TabIndex = 0;
            this.btncuoi.UseVisualStyleBackColor = true;
            // 
            // btntoi
            // 
            this.btntoi.BackgroundImage = global::QLThuVien.Properties.Resources.next_icon;
            this.btntoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btntoi.Location = new System.Drawing.Point(405, 19);
            this.btntoi.Name = "btntoi";
            this.btntoi.Size = new System.Drawing.Size(87, 29);
            this.btntoi.TabIndex = 0;
            this.btntoi.UseVisualStyleBackColor = true;
            // 
            // btnlui
            // 
            this.btnlui.BackgroundImage = global::QLThuVien.Properties.Resources.back_icon;
            this.btnlui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnlui.Location = new System.Drawing.Point(113, 19);
            this.btnlui.Name = "btnlui";
            this.btnlui.Size = new System.Drawing.Size(87, 29);
            this.btnlui.TabIndex = 0;
            this.btnlui.UseVisualStyleBackColor = true;
            // 
            // btndau
            // 
            this.btndau.BackgroundImage = global::QLThuVien.Properties.Resources.Actions_green_arrow_left_end_icon;
            this.btndau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btndau.Location = new System.Drawing.Point(14, 19);
            this.btndau.Name = "btndau";
            this.btndau.Size = new System.Drawing.Size(87, 29);
            this.btndau.TabIndex = 0;
            this.btndau.UseVisualStyleBackColor = true;
            // 
            // txtpage
            // 
            this.txtpage.Location = new System.Drawing.Point(209, 24);
            this.txtpage.Name = "txtpage";
            this.txtpage.Size = new System.Drawing.Size(192, 20);
            this.txtpage.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 589);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNhanVien";
            this.Text = "FrmNhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvttnv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnxoanv;
        private System.Windows.Forms.Button btnsuanv;
        private System.Windows.Forms.Button btnluunv;
        private System.Windows.Forms.Button btnthemnv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvttnv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboGioitinhnv;
        private System.Windows.Forms.DateTimePicker dtpNgaysinhnv;
        private System.Windows.Forms.TextBox txtDienthoainv;
        private System.Windows.Forms.TextBox txtDiachinv;
        private System.Windows.Forms.TextBox txtchucvunv;
        private System.Windows.Forms.TextBox txtTennv;
        private System.Windows.Forms.TextBox txtManv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnthoatnv;
        private System.Windows.Forms.Label lblthongbaonv;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btncuoi;
        private System.Windows.Forms.Button btntoi;
        private System.Windows.Forms.Button btnlui;
        private System.Windows.Forms.Button btndau;
        private System.Windows.Forms.TextBox txtpage;
        private System.Windows.Forms.DateTimePicker dtngayvaolam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
    }
}