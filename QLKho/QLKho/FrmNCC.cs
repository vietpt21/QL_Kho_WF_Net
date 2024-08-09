using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLKho
{
    public partial class FrmNCC : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FrmNCC()
        {
            InitializeComponent();
        }

        private void hienthiNCC()
        {
            List<ncc> lstsp = db.nccs.ToList();
            listviewNCC.Items.Clear();
            lstsp.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.id + "");
                lvi.SubItems.Add(x.ten_ncc);
                lvi.SubItems.Add(x.hien_thi);
                lvi.SubItems.Add(x.ten_day_du);
                lvi.SubItems.Add(x.loai_ncc);
                lvi.SubItems.Add(x.logo);
                lvi.SubItems.Add(x.nguoi_dai_dien);
                lvi.SubItems.Add(x.sdt);
                lvi.SubItems.Add(x.tinh_trang);
                lvi.SubItems.Add(x.nv_phu_trach);
                lvi.SubItems.Add(x.ghi_chu);
                lvi.SubItems.Add(x.ngay_tao.ToString("MM/dd/yyyy HH:mm:ss"));
                lvi.SubItems.Add(x.ngay_cap_nhat.ToString("MM/dd/yyyy HH:mm:ss"));
                listviewNCC.Items.Add(lvi);

            });
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {

                ncc nhacc = new ncc();

                nhacc.ten_ncc = txtTenNCC.Text;
                nhacc.hien_thi = txtHienThiNCC.Text;
                if (DateTime.TryParse(txtNgayTaoNCC.Text, out DateTime ngayTao))
                {
                    nhacc.ngay_tao = ngayTao;
                }
                else
                {
                    MessageBox.Show("Ngày tạo không hợp lệ.");
                    return;
                }

                if (DateTime.TryParse(txtNgayCapNhatNCC.Text, out DateTime ngayCapNhat))
                {
                    nhacc.ngay_cap_nhat = ngayCapNhat;
                }
                else
                {
                    MessageBox.Show("Ngày cập nhật không hợp lệ.");
                    return;
                }
                nhacc.ten_day_du = txtTenDayDuNCC.Text;
                nhacc.ghi_chu = txtGhiChu.Text;
                nhacc.loai_ncc = txtLoaiCC.Text;
                nhacc.logo = txtLogo.Text;
                nhacc.nguoi_dai_dien = txtNguoiDaiDienNCC.Text;
                nhacc.sdt = txtSDT.Text;
                nhacc.tinh_trang = txtTinhTrang.Text;
                nhacc.nv_phu_trach = txtNVPhuTrach.Text;
                db.nccs.InsertOnSubmit(nhacc);
                db.SubmitChanges();
                hienthiNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
