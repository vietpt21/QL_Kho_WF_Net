using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLKho
{
    public partial class frmSanPham : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private OpenFileDialog openFileDialog;
        private string imagePath;
        public frmSanPham()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn Hình Ảnh"
            };
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            hienthisanpham();
        }
        private void hienthisanpham()
        {
            List<san_pham> lstsp = db.san_phams.ToList();
            listView1.Items.Clear();
            lstsp.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.id + "");
                lvi.SubItems.Add(x.ten_san_pham);
                lvi.SubItems.Add(x.hien_thi);
                lvi.SubItems.Add(x.nhom_san_pham);
                lvi.SubItems.Add(x.hang_sx);
                lvi.SubItems.Add(x.hinh_anh);
                lvi.SubItems.Add(x.dia_chi);
                lvi.SubItems.Add(x.thong_tin);
                lvi.SubItems.Add(x.han_su_dung.ToString("MM/dd/yyyy HH:mm:ss"));
                lvi.SubItems.Add(x.quy_cach);
                listView1.Items.Add(lvi);

            });
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường nhập liệu có hợp lệ không
            if (string.IsNullOrEmpty(txtTenSp.Text) ||
                string.IsNullOrEmpty(txtHienThi.Text) ||
                string.IsNullOrEmpty(txtHinhAnh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                return;
            }

            // Lấy đường dẫn hình ảnh và tên tệp hình ảnh
            string sourceImagePath = imagePath; // Đường dẫn gốc của hình ảnh đã chọn
            string fileName = Path.GetFileName(sourceImagePath);

            // Tạo đường dẫn tới thư mục 'Images' trong thư mục cơ sở dữ liệu
            string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string destinationImagePath = Path.Combine(imagesFolder, fileName);

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            // Sao chép hình ảnh vào thư mục 'Images'
            File.Copy(sourceImagePath, destinationImagePath, true);
            // Tạo đối tượng sản phẩm mới
            var sanPham = new san_pham
                {
                    ten_san_pham = txtTenSp.Text,
                    hien_thi = txtHienThi.Text,
                    nhom_san_pham = txtNhomSp.Text,
                    hang_sx = txtHangSx.Text,
                    hinh_anh = fileName, // Lưu tên tệp hình ảnh
                    dia_chi = txtDiaChi.Text,
                    thong_tin = txtThongTin.Text,
                    han_su_dung = DateTime.Parse(txtHanSuDung.Text),
                    quy_cach = txtQuyCach.Text,
                    dvt = txtDvt.Text,
                    gia_nhap = float.Parse(txtGiaNhap.Text),
                    sl_toi_thieu = int.Parse(txtSLToiThieu.Text),
                    sl_toi_da = int.Parse(txtSLToiDa.Text),
                    sl_nhap = int.Parse(txtSLNhap.Text),
                    sl_xuat = int.Parse(txtSLXuat.Text),
                    sl_ton = int.Parse(txtSLTon.Text),
                    trang_thai = txtTrangThai.Text,
                    ghi_chu = txtGhiChu.Text,
                    ngay_tao = DateTime.Parse(txtNgayTao.Text),
                    ngay_cap_nhat = DateTime.Parse(txtNgayCapNhat.Text),
                    nguoi_tao = txtNguoiTao.Text
                };

            // Thêm sản phẩm vào cơ sở dữ liệu
            db.san_phams.InsertOnSubmit(sanPham);
            db.SubmitChanges();
            ClearTextBoxes();
            hienthisanpham();
        }
        private void ClearTextBoxes()
        {
            // Xóa nội dung của tất cả các TextBox trong form
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).Clear();
                }
            }

            // Nếu bạn có PictureBox và các điều khiển khác cần reset
            pictureBox1.Image = null;
        }
        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                txtHinhAnh.Text = Path.GetFileName(imagePath); // Hiển thị tên tệp hình ảnh
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSp.Text) ||
                string.IsNullOrEmpty(txtHienThi.Text) ||
                string.IsNullOrEmpty(txtHinhAnh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                return;
            }

            // Lấy ID của sản phẩm cần chỉnh sửa từ ListView
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để chỉnh sửa.");
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            int productId = int.Parse(selectedItem.SubItems[0].Text);

            // Lấy thông tin sản phẩm cần chỉnh sửa từ cơ sở dữ liệu
            using (var db = new DataClasses1DataContext())
            {
                var sanPham = db.san_phams.FirstOrDefault(sp => sp.id == productId);
                if (sanPham != null)
                {
                    // Cập nhật thông tin sản phẩm
                    sanPham.ten_san_pham = txtTenSp.Text;
                    sanPham.hien_thi = txtHienThi.Text;
                    sanPham.nhom_san_pham = txtNhomSp.Text;
                    sanPham.hang_sx = txtHangSx.Text;
                    sanPham.dia_chi = txtDiaChi.Text;
                    sanPham.thong_tin = txtThongTin.Text;
                    sanPham.han_su_dung = DateTime.Parse(txtHanSuDung.Text);
                    sanPham.quy_cach = txtQuyCach.Text;
                    sanPham.dvt = txtDvt.Text;
                    sanPham.gia_nhap = float.Parse(txtGiaNhap.Text);
                    sanPham.sl_toi_thieu = int.Parse(txtSLToiThieu.Text);
                    sanPham.sl_toi_da = int.Parse(txtSLToiDa.Text);
                    sanPham.sl_nhap = int.Parse(txtSLNhap.Text);
                    sanPham.sl_xuat = int.Parse(txtSLXuat.Text);
                    sanPham.sl_ton = int.Parse(txtSLTon.Text);
                    sanPham.trang_thai = txtTrangThai.Text;
                    sanPham.ghi_chu = txtGhiChu.Text;
                    sanPham.ngay_tao = DateTime.Parse(txtNgayTao.Text);
                    sanPham.ngay_cap_nhat = DateTime.Parse(txtNgayCapNhat.Text);
                    sanPham.nguoi_tao = txtNguoiTao.Text;

                    // Nếu có thay đổi hình ảnh
                    if (imagePath != null && !string.IsNullOrEmpty(txtHinhAnh.Text))
                    {
                        string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", sanPham.hinh_anh);
                        string newFileName = Path.GetFileName(imagePath);
                        string newImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", newFileName);

                        // Xóa hình ảnh cũ nếu có
                        if (File.Exists(oldImagePath))
                        {
                            File.Delete(oldImagePath);
                        }

                        // Cập nhật tên tệp hình ảnh mới
                        sanPham.hinh_anh = newFileName;

                        // Sao chép hình ảnh mới vào thư mục Images
                        File.Copy(imagePath, newImagePath, true);
                    }

                    // Cập nhật cơ sở dữ liệu
                    db.SubmitChanges();

                    // Cập nhật danh sách sản phẩm
                    hienthisanpham();

                    // Xóa dữ liệu các TextBox và PictureBox
                    ClearTextBoxes();

                    // Thông báo thành công
                    MessageBox.Show("Sản phẩm đã được chỉnh sửa thành công.");
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một san pham để chỉnh sửa.");
                return;
            }

            // Lấy mục được chọn

            ListViewItem lvi = listView1.SelectedItems[0];
            int masp = int.Parse(lvi.SubItems[0].Text);

            // Tìm đối tượng kho trong cơ sở dữ liệu
            var sanPham = db.san_phams.FirstOrDefault(x => x.id == masp);
            if (sanPham != null)
            {
                // Hiển thị thông tin sản phẩm trong các TextBox
                txtTenSp.Text = sanPham.ten_san_pham;
                txtHienThi.Text = sanPham.hien_thi;
                txtNhomSp.Text = sanPham.nhom_san_pham;
                txtHangSx.Text = sanPham.hang_sx;
                txtDiaChi.Text = sanPham.dia_chi;
                txtThongTin.Text = sanPham.thong_tin;
                txtHanSuDung.Text = sanPham.han_su_dung.ToString();
                txtQuyCach.Text = sanPham.quy_cach;
                txtDvt.Text = sanPham.dvt;
                txtGiaNhap.Text = sanPham.gia_nhap.ToString();
                txtSLToiThieu.Text = sanPham.sl_toi_thieu.ToString();
                txtSLToiDa.Text = sanPham.sl_toi_da.ToString();
                txtSLNhap.Text = sanPham.sl_nhap.ToString();
                txtSLXuat.Text = sanPham.sl_xuat.ToString();
                txtSLTon.Text = sanPham.sl_ton.ToString();
                txtTrangThai.Text = sanPham.trang_thai;
                txtGhiChu.Text = sanPham.ghi_chu;
                txtNgayTao.Text = sanPham.ngay_tao.ToString("yyyy-MM-dd");
                txtNgayCapNhat.Text = sanPham.ngay_cap_nhat.ToString("yyyy-MM-dd");
                txtNguoiTao.Text = sanPham.nguoi_tao;

                // Hiển thị hình ảnh nếu có
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", sanPham.hinh_anh);
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox1.Image = null; // Không có hình ảnh
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn sản phẩm để xóa chưa
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác Nhận Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Lấy ID của sản phẩm cần xóa
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int productId = int.Parse(selectedItem.SubItems[0].Text);

                // Xóa sản phẩm khỏi cơ sở dữ liệu
                using (var db = new DataClasses1DataContext())
                {
                    var sanPham = db.san_phams.FirstOrDefault(sp => sp.id == productId);
                    if (sanPham != null)
                    {
                        // Giải phóng hình ảnh liên quan nếu có
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", sanPham.hinh_anh);
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                // Giải phóng tài nguyên trước khi xóa
                                if (pictureBox1.Image != null && imagePath == Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", sanPham.hinh_anh))
                                {
                                    pictureBox1.Image.Dispose();
                                }
                                File.Delete(imagePath);
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show("Lỗi khi xóa hình ảnh: " + ex.Message);
                                return;
                            }
                        }

                        // Xóa sản phẩm khỏi cơ sở dữ liệu
                        db.san_phams.DeleteOnSubmit(sanPham);
                        db.SubmitChanges();

                        // Cập nhật danh sách sản phẩm
                        hienthisanpham();

                        // Xóa dữ liệu các TextBox và PictureBox
                        ClearTextBoxes();

                        // Thông báo thành công
                        MessageBox.Show("Sản phẩm đã được xóa thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại trong cơ sở dữ liệu.");
                    }
                }
            }
        }
    }
}
