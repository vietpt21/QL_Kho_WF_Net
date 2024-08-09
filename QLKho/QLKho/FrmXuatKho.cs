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
    public partial class FrmXuatKho : Form
    {
        public FrmXuatKho()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void FrmXuatKho_Load(object sender, EventArgs e)
        {
            hienThiXuatKho();
        }
        private void hienThiXuatKho()
        {
            // Xóa tất cả các mục hiện có trong ListView
            listView1.Items.Clear();

            // Tạo kết nối đến cơ sở dữ liệu
            using (var db = new DataClasses1DataContext())
            {
                // Lấy dữ liệu từ bảng xuat_kho
                var data = from xk in db.xuat_khos
                           select new
                           {
                               xk.id,
                               xk.loat_xuat,
                               xk.ngay_xuat,
                               xk.nhan_vien_id,
                               xk.ma_hoa_don,
                               xk.sl_san_pham,
                               xk.sl_xuat,
                               xk.noi_dung_xuat,
                               xk.ghi_chu,
                               xk.ngay_tao,
                               xk.ngay_cap_nhat,
                               xk.nguoi_tao,
                               
                           };

                // Thêm dữ liệu vào ListView
                foreach (var item in data)
                {
                    ListViewItem lvi = new ListViewItem(item.id.ToString());
                    lvi.SubItems.Add(item.loat_xuat);
                    lvi.SubItems.Add(item.ngay_xuat.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(item.ma_hoa_don);
                    lvi.SubItems.Add(item.sl_san_pham.ToString());
                    lvi.SubItems.Add(item.sl_xuat.ToString());
                    lvi.SubItems.Add(item.noi_dung_xuat);
                    lvi.SubItems.Add(item.ghi_chu);
                    lvi.SubItems.Add(item.ngay_tao.ToString());
                    lvi.SubItems.Add(item.ngay_cap_nhat.ToString());
                    lvi.SubItems.Add(item.nhan_vien_id+"");
                    listView1.Items.Add(lvi);
                }
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
            // Tạo kết nối đến cơ sở dữ liệu
          
            // Lấy thông tin xuất kho dựa trên ID được chọn
            var xuatKho = db.xuat_khos.FirstOrDefault(xk => xk.id == ma);
            if (xuatKho != null)
            {
                // Cập nhật các điều khiển trên form với thông tin từ cơ sở dữ liệu
                txtLoaiXuat.Text = xuatKho.loat_xuat;
                txtNgayXuat.Text = xuatKho.ngay_xuat +"";
                txtMaNv.Text = xuatKho.nhan_vien_id+"";
                txtMaHoaDon.Text = xuatKho.ma_hoa_don;
                txtSLSanPham.Text = xuatKho.sl_san_pham.ToString();
                txtSLXuat.Text = xuatKho.sl_xuat.ToString();
                txtNoiDungXuat.Text = xuatKho.noi_dung_xuat;
                txtGhiChu.Text = xuatKho.ghi_chu;
                txtNgayCapNhat.Text = xuatKho.ngay_cap_nhat+"";
                txtNgayTao.Text = xuatKho.ngay_tao + "";
                textNguoiTao.Text = xuatKho.ghi_chu;
            }
        }
        private void ClearInputFields()
        {
            // Xóa dữ liệu trong các TextBox
            txtLoaiXuat.Clear();
            txtMaHoaDon.Clear();
            txtNoiDungXuat.Clear();
            txtGhiChu.Clear();
            txtSLSanPham.Clear();
            txtSLXuat.Clear();

            txtMaNv.Clear();

            // Đặt lại giá trị của DateTimePicker
            txtNgayXuat.Value = DateTime.Now; // Hoặc giá trị mặc định khác nếu cần
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ của các trường nhập liệu
            if (string.IsNullOrEmpty(txtLoaiXuat.Text) ||
                string.IsNullOrEmpty(txtMaHoaDon.Text) ||
                string.IsNullOrEmpty(txtNoiDungXuat.Text) ||
                string.IsNullOrEmpty(txtGhiChu.Text) ||
                string.IsNullOrEmpty(txtSLSanPham.Text) ||
                string.IsNullOrEmpty(txtSLXuat.Text) ||
                string.IsNullOrEmpty(txtMaNv.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Tạo đối tượng xuất kho mới
            var xuatKho = new xuat_kho
            {
                loat_xuat = txtLoaiXuat.Text,
                ngay_xuat = txtNgayXuat.Value,
                nhan_vien_id = int.Parse(txtMaNv.Text + ""),
                ma_hoa_don = txtMaHoaDon.Text,
                sl_san_pham = int.Parse(txtSLSanPham.Text),
                sl_xuat = int.Parse(txtSLXuat.Text),
                noi_dung_xuat = txtNoiDungXuat.Text,
                ghi_chu = txtGhiChu.Text,
                ngay_tao = DateTime.Now, // Ngày tạo là thời điểm hiện tại
                ngay_cap_nhat = DateTime.Now, // Ngày cập nhật là thời điểm hiện tại
                nguoi_tao = textNguoiTao.Text // Thay đổi theo người dùng hiện tại
            };

            // Thêm đối tượng vào cơ sở dữ liệu
            db.xuat_khos.InsertOnSubmit(xuatKho);
            db.SubmitChanges();
            

            // Cập nhật lại dữ liệu trên giao diện
            MessageBox.Show("Dữ liệu đã được thêm thành công.");
            ClearInputFields();
            hienThiXuatKho();
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
            int ma = int.Parse(lvi.SubItems[0].Text);

         
           
            // Lấy bản ghi cần sửa
            var xuatKho = db.xuat_khos.FirstOrDefault(xk => xk.id == ma);
            if (xuatKho != null)
            {
                // Cập nhật thông tin bản ghi
                xuatKho.loat_xuat = txtLoaiXuat.Text;
                xuatKho.nhan_vien_id =int.Parse( txtMaNv.Text+"");
                xuatKho.ma_hoa_don = txtMaHoaDon.Text;
                xuatKho.sl_san_pham = int.Parse(txtSLSanPham.Text);
                xuatKho.sl_xuat = int.Parse(txtSLXuat.Text);
                xuatKho.noi_dung_xuat = txtNoiDungXuat.Text;
                xuatKho.ghi_chu = txtGhiChu.Text;
                xuatKho.ngay_tao = DateTime.Parse(txtNgayTao.Text);
                xuatKho.ngay_xuat = DateTime.Parse(txtNgayXuat.Text);
                xuatKho.ngay_cap_nhat = DateTime.Parse(txtNgayCapNhat.Text);
                xuatKho.nguoi_tao =textNguoiTao.Text; // Thay đổi theo người dùng hiện tại

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Cập nhật lại dữ liệu trên giao diện
                MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                ClearInputFields();
                hienThiXuatKho();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản ghi cần sửa.");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một kho để chỉnh sửa.");
                return;
            }

           
            // Xác nhận việc xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Tạo kết nối đến cơ sở dữ liệu
                using (var db = new DataClasses1DataContext())
                {
                    // Lấy bản ghi cần xóa
                    ListViewItem lvi = listView1.SelectedItems[0];
                    int maxk = int.Parse(lvi.SubItems[0].Text);

                    var xuatKho = db.xuat_khos.FirstOrDefault(xk => xk.id == maxk);
                    if (xuatKho != null)
                    {
                        // Xóa bản ghi
                        db.xuat_khos.DeleteOnSubmit(xuatKho);
                        db.SubmitChanges();

                        // Cập nhật lại dữ liệu trên giao diện
                        MessageBox.Show("Dữ liệu đã được xóa thành công.");
                        ClearInputFields();
                        hienThiXuatKho();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi cần xóa.");
                    }
                }
            }
        }
    }
}
