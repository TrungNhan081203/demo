namespace QUANLYQUANAO
{
    partial class frmTimKiemHD
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTKHoaDon = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnBoQua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 84);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QUANLYQUANAO.Properties.Resources.timkiem;
            this.pictureBox2.Location = new System.Drawing.Point(217, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ForeColor = System.Drawing.Color.Blue;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(217, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(128, 38);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::QUANLYQUANAO.Properties.Resources.tru;
            this.pictureBox6.Location = new System.Drawing.Point(527, 30);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 35);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::QUANLYQUANAO.Properties.Resources.icon_bo_qua;
            this.pictureBox5.Location = new System.Drawing.Point(374, 30);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.ForeColor = System.Drawing.Color.Blue;
            this.btnDong.Location = new System.Drawing.Point(524, 26);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(86, 42);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.ForeColor = System.Drawing.Color.Blue;
            this.btnBoQua.Location = new System.Drawing.Point(371, 26);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 42);
            this.btnBoQua.TabIndex = 7;
            this.btnBoQua.Text = "Tìm Lại";
            this.btnBoQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 27);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nháy đúp vào hóa đơn để hiện thị thông tin chi tiết";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNam);
            this.panel3.Controls.Add(this.txtThang);
            this.panel3.Controls.Add(this.txtMaNhanVien);
            this.panel3.Controls.Add(this.txtTongTien);
            this.panel3.Controls.Add(this.txtMaKhachHang);
            this.panel3.Controls.Add(this.txtMaHoaDon);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(931, 166);
            this.panel3.TabIndex = 3;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(301, 75);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(76, 22);
            this.txtNam.TabIndex = 11;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(148, 75);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(92, 22);
            this.txtThang.TabIndex = 10;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(148, 124);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(229, 22);
            this.txtMaNhanVien.TabIndex = 9;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(628, 73);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(229, 22);
            this.txtTongTien.TabIndex = 8;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            this.txtTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTien_KeyPress);
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(628, 28);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(229, 22);
            this.txtMaKhachHang.TabIndex = 7;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(148, 28);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(229, 22);
            this.txtMaHoaDon.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(481, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tổng Tiền";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(28, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tháng ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(28, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã Nhân Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(251, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(481, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Khách Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Hóa Đơn";
            // 
            // dgvTKHoaDon
            // 
            this.dgvTKHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTKHoaDon.Location = new System.Drawing.Point(0, 166);
            this.dgvTKHoaDon.Name = "dgvTKHoaDon";
            this.dgvTKHoaDon.RowHeadersWidth = 51;
            this.dgvTKHoaDon.RowTemplate.Height = 24;
            this.dgvTKHoaDon.Size = new System.Drawing.Size(931, 286);
            this.dgvTKHoaDon.TabIndex = 4;
            this.dgvTKHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTKHoaDon_CellContentClick);
            // 
            // frmTimKiemHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 563);
            this.Controls.Add(this.dgvTKHoaDon);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTimKiemHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Hóa Đơn";
            this.Load += new System.EventHandler(this.frmTimKiemHD_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTKHoaDon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtMaHoaDon;
    }
}