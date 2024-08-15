using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            FrmNCC frm = new FrmNCC();
            frm.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            FrmKho frm = new FrmKho();
            frm.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm =new frmSanPham();
            frm.Show();

        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            FrmNhapKho frm = new FrmNhapKho();
            frm.Show();
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            FrmXuatKho frm = new FrmXuatKho();
            frm.Show();
        }

        private void btnNhapKhoCT_Click(object sender, EventArgs e)
        {
            FrmNhapKhoCT frm = new FrmNhapKhoCT();
            frm.Show();
        }

        private void btnXuatKhoCT_Click(object sender, EventArgs e)
        {
            FrmXuatKhoCT frm = new FrmXuatKhoCT();
            frm.Show();
        }
    }
}
