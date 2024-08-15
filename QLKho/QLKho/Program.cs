using QLKho.userControl.FormItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKho
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static readonly string connectionString = "Data Source=localhost;Initial Catalog=QLKho;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAddProduc());
        }
    }
}
