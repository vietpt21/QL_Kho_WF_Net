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
    public partial class FrmKho : Form
    {
        public FrmKho()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                kho kho = new kho();

                kho.ten_kho = txtTenKho.Text;
                kho.hien_thi = txtTenHienThi.Text;
                if (DateTime.TryParse(txtNgayTao.Text, out DateTime ngayTao))
                {
                    kho.ngay_tao = ngayTao;
                }
                else
                {
                    MessageBox.Show("Ngày tạo không hợp lệ.");
                    return;
                }

                if (DateTime.TryParse(txtNgayCapNhat.Text, out DateTime ngayCapNhat))
                {
                    kho.cap_nhat = ngayCapNhat;
                }
                else
                {
                    MessageBox.Show("Ngày cập nhật không hợp lệ.");
                    return;
                }
                kho.nguoi_tao = txtNguoiTao.Text;
                kho.ghi_chu = txtGhiChu.Text;
                kho.ten_kho = txtTenKho.Text;
                db.khos.InsertOnSubmit(kho);
                db.SubmitChanges();
                hienthiKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void hienthiKho()
        {
            List<kho> lstkho = db.khos.ToList();
            listView1.Items.Clear();
            lstkho.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.id + "");
                lvi.SubItems.Add(x.ten_kho);
                lvi.SubItems.Add(x.hien_thi);
                lvi.SubItems.Add(x.ghi_chu);
                lvi.SubItems.Add(x.ngay_tao.ToString("MM/dd/yyyy HH:mm:ss"));
                lvi.SubItems.Add(x.cap_nhat.ToString("MM/dd/yyyy HH:mm:ss"));
                lvi.SubItems.Add(x.nguoi_tao);
                listView1.Items.Add(lvi);

            });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một kho để chỉnh sửa.");
                return;
            }

            // Lấy mục được chọn
            ListViewItem lvi = listView1.SelectedItems[0];
            int makho = int.Parse(lvi.SubItems[0].Text);

            // Tìm đối tượng kho trong cơ sở dữ liệu
            var kho = db.khos.FirstOrDefault(x => x.id == makho);
            if (kho != null)
            {
                // Cập nhật thuộc tính của kho bằng dữ liệu từ các ô nhập liệu
                kho.ten_kho = txtTenKho.Text;
                kho.hien_thi = txtTenHienThi.Text;
                kho.ghi_chu = txtGhiChu.Text;
                kho.ngay_tao = DateTime.Parse(txtNgayTao.Text); // Chuyển đổi nếu cần
                kho.cap_nhat = DateTime.Parse(txtNgayCapNhat.Text); // Chuyển đổi nếu cần
                kho.nguoi_tao = txtNguoiTao.Text;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                hienthiKho();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một kho để chỉnh sửa.");
                return;
            }

            // Lấy mục được chọn
            ListViewItem lvi = listView1.SelectedItems[0];
            int makho = int.Parse(lvi.SubItems[0].Text);

            // Tìm đối tượng kho trong cơ sở dữ liệu
            var kho = db.khos.FirstOrDefault(x => x.id == makho);
            if (kho != null)
            {

                db.khos.DeleteOnSubmit(kho);
                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                hienthiKho();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }//cho phep chon 1 dong
            ListViewItem lvi = listView1.SelectedItems[0];
            //lay muc dau tien cua dong
            int ma = int.Parse(lvi.SubItems[0].Text);
            var kho = db.khos.FirstOrDefault(x => x.id == ma);
            if (kho != null)
            {
                txtTenKho.Text = kho.id + "";
                txtTenHienThi.Text = kho.hien_thi;
                txtGhiChu.Text = kho.ghi_chu + "";
                txtNguoiTao.Text = kho.nguoi_tao + "";
                txtNgayTao.Text = kho.ngay_tao+"";
                txtNgayCapNhat.Text = kho.cap_nhat + "";
            }
        }
    }
}
