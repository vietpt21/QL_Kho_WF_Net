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
    public partial class FrmXuatKhoCT: Form
    {
        public FrmXuatKhoCT()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void FrmXuatKhoCT_Load(object sender, EventArgs e)
        {
            hienThiXuatKhoCt();
            LoadComboBoxData();
        }
        private void hienThiXuatKhoCt()
        {
            // Xóa tất cả các mục hiện có trong ListView
            listView1.Items.Clear();

            // Tạo kết nối đến cơ sở dữ liệu
           
                // Lấy dữ liệu từ bảng xuat_kho_ct
            var data = from xkct in db.xuat_kho_cts
                        join xk in db.xuat_khos on xkct.xuat_kho_id equals xk.id
                        join sp in db.san_phams on xkct.san_pham_id equals sp.id
                        select new
                        {
                            xkct.id,
                            xkct.LoaiXuat,
                            xkct.xuat_kho_id,
                            xkct.san_pham_id,
                            xkct.ngay_xuat,
                            xkct.ten_san_pham,
                            xkct.nhom_san_pham,
                            xkct.hang_sx,
                            xkct.hinh_anh,
                            xkct.thong_tin,
                            xkct.quy_cach,
                            xkct.dvt,
                            xkct.so_lo,
                            xkct.ngay_het_han,
                            xkct.sl_xuat,
                            xkct.sl_xuat_tong,
                            xkct.ngay_tao,
                            xkct.ngay_cap_nhat,
                            xkct.nguoi_tao
                        };

            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem lvi = new ListViewItem(item.id.ToString());
                lvi.SubItems.Add(item.LoaiXuat);
                lvi.SubItems.Add(item.xuat_kho_id+"");
                lvi.SubItems.Add(item.ngay_xuat.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.san_pham_id+"");
                lvi.SubItems.Add(item.ten_san_pham);
                lvi.SubItems.Add(item.nhom_san_pham);
                lvi.SubItems.Add(item.hang_sx);
                lvi.SubItems.Add(item.hinh_anh);
                lvi.SubItems.Add(item.thong_tin);
                lvi.SubItems.Add(item.quy_cach);
                lvi.SubItems.Add(item.dvt);
                lvi.SubItems.Add(item.so_lo);
                lvi.SubItems.Add(item.ngay_het_han.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.sl_xuat.ToString());
                lvi.SubItems.Add(item.sl_xuat_tong.ToString());
                lvi.SubItems.Add(item.ngay_tao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.ngay_cap_nhat.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.nguoi_tao);

                listView1.Items.Add(lvi);

            }
            
        }
        private void LoadComboBoxData()
        {

            // Tải danh sách kho vào ComboBox
            cboXuatKho.DataSource = db.xuat_khos.ToList();
            cboXuatKho.DisplayMember = "loat_xuat"; // Thay đổi theo thuộc tính hiển thị
            cboXuatKho.ValueMember = "id"; // Thay đổi theo thuộc tính ID

            // Tải danh sách NCC vào ComboBox
            cboSanPham.DataSource = db.san_phams.ToList();
            cboSanPham.DisplayMember = "ten_san_pham"; // Thay đổi theo thuộc tính hiển thị
            cboSanPham.ValueMember = "id"; // Thay đổi theo thuộc tính ID

        }
        private void btnKho_Click(object sender, EventArgs e)
        {
            // Mở form nhập NCC
            using (var form = new FrmXuatKho())
            {
                form.ShowDialog();

                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
                LoadComboBoxData();
            }
        }

        private void btnSp_Click(object sender, EventArgs e)
        {
            // Mở form nhập NCC
            using (var form = new frmSanPham())
            {
                form.ShowDialog();

                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
                LoadComboBoxData();
            }
        }

        private void cboXuatKho_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khoá tìm kiếm
            string searchText = cboXuatKho.Text;

            using (var db = new DataClasses1DataContext())
            {
                // Lọc danh sách NCC theo từ khoá tìm kiếm
                var filtereSps = db.xuat_khos
                    .Where(n => n.loat_xuat.Contains(searchText))
                    .ToList();

                // Cập nhật dữ liệu cho ComboBox
                cboXuatKho.DataSource = filtereSps;
                cboXuatKho.DisplayMember = "loat_xuat";
                cboXuatKho.ValueMember = "id";
                btnKho.Visible = !filtereSps.Any();

            }
        }

        private void cboSanPham_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khoá tìm kiếm
            string searchText = cboSanPham.Text;

            using (var db = new DataClasses1DataContext())
            {
                // Lọc danh sách NCC theo từ khoá tìm kiếm
                var filtereSps = db.san_phams
                    .Where(n => n.ten_san_pham.Contains(searchText))
                    .ToList();

                // Cập nhật dữ liệu cho ComboBox
                cboSanPham.DataSource = filtereSps;
                cboSanPham.DisplayMember = "ten_san_pham";
                cboSanPham.ValueMember = "id";
                btnSp.Visible = !filtereSps.Any();
            }
        }
        private void ClearInputFields()
        {
            // Xóa các trường nhập liệu trong các TextBox
            txtSoLo.Clear();
            txtNgayHetHan.Value = DateTime.Now;
            txtNgayTao.Value = DateTime.Now;
            txtNgayCapNhat.Value = DateTime.Now;
            txtSLXuat.Clear();
            txtNguoiTao.Clear();

            // Đặt lại các ComboBox về trạng thái không chọn
            cboSanPham.SelectedIndex = -1;
            cboXuatKho.SelectedIndex = -1;

            // Đặt lại giá trị cho các trường nhập liệu khác nếu cần
            // Ví dụ: nếu bạn có các trường ngày hoặc số lượng khác, hãy đặt lại giá trị của chúng
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ của các trường nhập liệu
         /*   if (cboSanPham.SelectedItem == null || cboXuatKho.SelectedItem == null ||
                string.IsNullOrEmpty(txtSoLo.Text) ||
                string.IsNullOrEmpty(txtNgayHetHan.Text) ||
                string.IsNullOrEmpty(txtNgayTao.Text) ||
                string.IsNullOrEmpty(cboSanPham.Text) ||
                string.IsNullOrEmpty(cboXuatKho.Text) ||
                string.IsNullOrEmpty(txtSLXuatTong.Text) ||
                string.IsNullOrEmpty(txtSLXuat.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }*/

            int sanPhamId = (int)cboSanPham.SelectedValue;
            int xuatKhoId = (int)cboXuatKho.SelectedValue;

            // Tạo kết nối đến cơ sở dữ liệu
            using (var db = new DataClasses1DataContext())
            {
                // Lấy thông tin sản phẩm từ bảng san_pham
                var sanPham = db.san_phams.FirstOrDefault(sp => sp.id == sanPhamId);
                if (sanPham == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại.");
                    return;
                }

                // Lấy thông tin xuất kho từ bảng xuat_kho
                var xuatKho = db.xuat_khos.FirstOrDefault(xk => xk.id == xuatKhoId);
                if (xuatKho == null)
                {
                    MessageBox.Show("Xuất kho không tồn tại.");
                    return;
                }

                // Lấy số lượng xuất hiện tại của sản phẩm
                var existingRecords = db.xuat_kho_cts
                    .Where(xkct => xkct.san_pham_id == sanPhamId && xkct.xuat_kho_id== xuatKhoId)
                    .ToList();

                int slXuat = int.Parse(txtSLXuat.Text);

                // Tính toán số lượng xuất tổng mới
                int totalSlXuat = slXuat;
                if (existingRecords.Any())
                {
                    totalSlXuat += existingRecords.Sum(record => record.sl_xuat);
                }

                // Tạo đối tượng xuất kho chi tiết mới
                var xuatKhoCt = new xuat_kho_ct
                {
                    LoaiXuat=xuatKho.loat_xuat,
                    xuat_kho_id = xuatKhoId,
                    ngay_xuat = xuatKho.ngay_xuat,
                    san_pham_id = sanPhamId,
                    ten_san_pham = sanPham.ten_san_pham,
                    nhom_san_pham = sanPham.nhom_san_pham,
                    hang_sx = sanPham.hang_sx,
                    hinh_anh = sanPham.hinh_anh,
                    thong_tin = sanPham.thong_tin,
                    quy_cach = sanPham.quy_cach,
                    dvt = sanPham.dvt,
                    so_lo = txtSoLo.Text,
                    ngay_het_han = txtNgayHetHan.Value,
                    sl_xuat = slXuat,
                    sl_xuat_tong = totalSlXuat,
                    ngay_tao = txtNgayTao.Value,
                    ngay_cap_nhat = txtNgayCapNhat.Value,
                    nguoi_tao = txtNguoiTao.Text, // Thay đổi theo người dùng hiện tại
                   
                };

                // Thêm đối tượng vào cơ sở dữ liệu
                db.xuat_kho_cts.InsertOnSubmit(xuatKhoCt);
                db.SubmitChanges();

                // Cập nhật lại dữ liệu trên giao diện
                MessageBox.Show("Dữ liệu đã được thêm thành công.");
                ClearInputFields();
                hienThiXuatKhoCt(); // Hiển thị dữ liệu đã thêm
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
