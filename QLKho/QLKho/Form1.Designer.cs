namespace QLKho
{
    partial class Form1
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
            this.qLKhoDataSet = new QLKho.QLKhoDataSet();
            this.qLKhoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnThemKho = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qLKhoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLKhoDataSetBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // qLKhoDataSet
            // 
            this.qLKhoDataSet.DataSetName = "QLKhoDataSet";
            this.qLKhoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLKhoDataSetBindingSource
            // 
            this.qLKhoDataSetBindingSource.DataSource = this.qLKhoDataSet;
            this.qLKhoDataSetBindingSource.Position = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSanPham);
            this.panel2.Controls.Add(this.btnKho);
            this.panel2.Controls.Add(this.btnNCC);
            this.panel2.Controls.Add(this.btnThemKho);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 62);
            this.panel2.TabIndex = 34;
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(304, 3);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(127, 48);
            this.btnSanPham.TabIndex = 6;
            this.btnSanPham.Text = "San Pham";
            this.btnSanPham.UseVisualStyleBackColor = true;
         
            // 
            // btnKho
            // 
            this.btnKho.Location = new System.Drawing.Point(152, 4);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(134, 48);
            this.btnKho.TabIndex = 5;
            this.btnKho.Text = "Them Kho";
            this.btnKho.UseVisualStyleBackColor = true;
        
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(12, 4);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(134, 48);
            this.btnNCC.TabIndex = 4;
            this.btnNCC.Text = "Them Nha Cung Cap";
            this.btnNCC.UseVisualStyleBackColor = true;
           
            // 
            // btnThemKho
            // 
            this.btnThemKho.Location = new System.Drawing.Point(-178, -8);
            this.btnThemKho.Name = "btnThemKho";
            this.btnThemKho.Size = new System.Drawing.Size(134, 48);
            this.btnThemKho.TabIndex = 3;
            this.btnThemKho.Text = "Them Kho";
            this.btnThemKho.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 1061);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
          
            ((System.ComponentModel.ISupportInitialize)(this.qLKhoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLKhoDataSetBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource qLKhoDataSetBindingSource;
        private QLKhoDataSet qLKhoDataSet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnThemKho;
        private System.Windows.Forms.Button btnSanPham;
    }
}

