using DevExpress.XtraBars;
using QLKho.userControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=QLKho;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            userWorkhouse house = new userWorkhouse(connectionString);
            house.Dock = DockStyle.Fill;
            panelMain.Controls.Add(house);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            userSanPham userSanPham = new userSanPham();
            userSanPham.Dock = DockStyle.Fill;
            panelMain.Controls.Add(userSanPham);
        }
    }
}