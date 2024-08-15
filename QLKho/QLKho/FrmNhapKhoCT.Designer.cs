namespace QLKho
{
    partial class FrmNhapKhoCT
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSLXuat = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSLNhap = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNguoiTao = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnSp = new System.Windows.Forms.Button();
            this.cboNhapKho = new System.Windows.Forms.ComboBox();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.txtNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.txtNgayTao = new System.Windows.Forms.DateTimePicker();
            this.NgayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "San pham id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Nhap kho id";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(93, 361);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(126, 37);
            this.btnThem.TabIndex = 49;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 404);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(703, 146);
            this.listView1.TabIndex = 61;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ma ";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Loai nhap";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngay nhap";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ten san pham ";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nhom sp";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "hang san xuat";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hinh anh";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Thong tin";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Han su dung";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Quy cach ";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Dvt";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "So so";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Gia nhap";
            this.columnHeader13.Width = 100;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(250, 361);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(126, 37);
            this.btnSua.TabIndex = 50;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(399, 361);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(126, 37);
            this.btnXoa.TabIndex = 51;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "So lo";
            // 
            // txtSoLo
            // 
            this.txtSoLo.Location = new System.Drawing.Point(61, 158);
            this.txtSoLo.Name = "txtSoLo";
            this.txtSoLo.Size = new System.Drawing.Size(207, 20);
            this.txtSoLo.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 295);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 84;
            this.label13.Text = "Ngay het han";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(58, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "SL xuat";
            // 
            // txtSLXuat
            // 
            this.txtSLXuat.Location = new System.Drawing.Point(58, 265);
            this.txtSLXuat.Name = "txtSLXuat";
            this.txtSLXuat.Size = new System.Drawing.Size(207, 20);
            this.txtSLXuat.TabIndex = 81;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(58, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 79;
            this.label16.Text = "SL nhap";
            // 
            // txtSLNhap
            // 
            this.txtSLNhap.Location = new System.Drawing.Point(58, 210);
            this.txtSLNhap.Name = "txtSLNhap";
            this.txtSLNhap.Size = new System.Drawing.Size(207, 20);
            this.txtSLNhap.TabIndex = 77;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(375, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 92;
            this.label19.Text = "Nguoi tao";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(370, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 91;
            this.label20.Text = "Ngay cap nhat";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(367, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 90;
            this.label21.Text = "Ngay tao";
            // 
            // txtNguoiTao
            // 
            this.txtNguoiTao.Location = new System.Drawing.Point(375, 165);
            this.txtNguoiTao.Name = "txtNguoiTao";
            this.txtNguoiTao.Size = new System.Drawing.Size(207, 20);
            this.txtNguoiTao.TabIndex = 89;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(373, 203);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 86;
            this.label22.Text = "Ghi chu";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(373, 229);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(207, 20);
            this.textBox16.TabIndex = 85;
            // 
            // btnKho
            // 
            this.btnKho.Location = new System.Drawing.Point(267, 51);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(75, 23);
            this.btnKho.TabIndex = 95;
            this.btnKho.Text = "Them kho";
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Visible = false;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnSp
            // 
            this.btnSp.Location = new System.Drawing.Point(267, 95);
            this.btnSp.Name = "btnSp";
            this.btnSp.Size = new System.Drawing.Size(75, 23);
            this.btnSp.TabIndex = 96;
            this.btnSp.Text = "Them Sp";
            this.btnSp.UseVisualStyleBackColor = true;
            this.btnSp.Visible = false;
            this.btnSp.Click += new System.EventHandler(this.btnSp_Click);
            // 
            // cboNhapKho
            // 
            this.cboNhapKho.FormattingEnabled = true;
            this.cboNhapKho.Location = new System.Drawing.Point(54, 54);
            this.cboNhapKho.Name = "cboNhapKho";
            this.cboNhapKho.Size = new System.Drawing.Size(200, 21);
            this.cboNhapKho.TabIndex = 97;
            this.cboNhapKho.TextChanged += new System.EventHandler(this.cboNhapKho_TextChanged);
            // 
            // cboSanPham
            // 
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(57, 95);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(197, 21);
            this.cboSanPham.TabIndex = 98;
            this.cboSanPham.TextChanged += new System.EventHandler(this.cboSanPham_TextChanged);
            // 
            // txtNgayHetHan
            // 
            this.txtNgayHetHan.Location = new System.Drawing.Point(58, 320);
            this.txtNgayHetHan.Name = "txtNgayHetHan";
            this.txtNgayHetHan.Size = new System.Drawing.Size(188, 20);
            this.txtNgayHetHan.TabIndex = 99;
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.Location = new System.Drawing.Point(370, 55);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.Size = new System.Drawing.Size(188, 20);
            this.txtNgayTao.TabIndex = 100;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.Location = new System.Drawing.Point(370, 107);
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Size = new System.Drawing.Size(188, 20);
            this.NgayCapNhat.TabIndex = 101;
            // 
            // FrmNhapKhoCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 566);
            this.Controls.Add(this.NgayCapNhat);
            this.Controls.Add(this.txtNgayTao);
            this.Controls.Add(this.txtNgayHetHan);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.cboNhapKho);
            this.Controls.Add(this.btnSp);
            this.Controls.Add(this.btnKho);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtNguoiTao);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSLXuat);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtSLNhap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoLo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Name = "FrmNhapKhoCT";
            this.Text = "FrmNhapKhoCT";
            this.Load += new System.EventHandler(this.FrmNhapKhoCT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSLXuat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSLNhap;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNguoiTao;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnSp;
        private System.Windows.Forms.ComboBox cboNhapKho;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.DateTimePicker txtNgayHetHan;
        private System.Windows.Forms.DateTimePicker txtNgayTao;
        private System.Windows.Forms.DateTimePicker NgayCapNhat;
    }
}