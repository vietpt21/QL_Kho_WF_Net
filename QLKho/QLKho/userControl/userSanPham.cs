using DevExpress.XtraEditors;
using QLKho.Services;
using QLKho.userControl.FormItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho.userControl
{
    public partial class userSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        static readonly string connectionString = "Data Source=localhost;Initial Catalog=QLKho;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        static UnitService _dbContext;
        public userSanPham()
        {
            InitializeComponent();
            _dbContext = new UnitService(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            gridDataSanPham.DataSource = _dbContext.SanPhamService.GetAllSanPham();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          /*  frmAddProduc frm = new frmAddProduc();
            frm.Show();*/
        }

        private void gridDataSanPham_Click(object sender, EventArgs e)
        {

        }
    }
}
