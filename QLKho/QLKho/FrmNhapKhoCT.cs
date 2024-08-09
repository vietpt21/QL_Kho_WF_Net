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
    public partial class FrmNhapKhoCT : Form
    {
        public FrmNhapKhoCT()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void FrmNhapKhoCT_Load(object sender, EventArgs e)
        {
            hienThiNhapKhoCt();
            LoadComboBoxData();


        }
        private void LoadComboBoxData()
        {
           
            // Tải danh sách kho vào ComboBox
            cboNhapKho.DataSource = db.nhap_khos.ToList();
            cboNhapKho.DisplayMember = "loai_nhap"; // Thay đổi theo thuộc tính hiển thị
            cboNhapKho.ValueMember = "id"; // Thay đổi theo thuộc tính ID

            // Tải danh sách NCC vào ComboBox
            cboSanPham.DataSource = db.san_phams.ToList();
            cboSanPham.DisplayMember = "ten_san_pham"; // Thay đổi theo thuộc tính hiển thị
            cboSanPham.ValueMember = "id"; // Thay đổi theo thuộc tính ID
          
        }
        private void hienThiNhapKhoCt()
        {
            // Xóa tất cả các mục hiện có trong ListView
            listView1.Items.Clear();

            // Tạo kết nối đến cơ sở dữ liệu
       
                // Lấy dữ liệu từ bảng nhap_kho_ct và các bảng liên kết
            var data = from nkct in db.nhap_kho_cts
                        join nk in db.nhap_khos on nkct.nhap_kho_id equals nk.id
                        join sp in db.san_phams on nkct.san_pham_id equals sp.id
                        select new
                        {
                            nkct.id,
                            nkct.ngay_nhap,
                            nkct.nhom_san_pham,
                            nkct.hang_sx,
                            nkct.hinh_anh,
                            nkct.thong_tin,
                            nkct.han_su_dung,
                            nkct.quy_cach,
                            nkct.dvt,
                            nkct.so_lo,
                            nkct.gia_nhap,
                            nkct.sl_nhap,
                            nkct.sl_xuat,
                            nkct.sl_ton,
                            nkct.ngay_het_han,
                            nkct.ghi_chu,
                            nk.ngay_tao,
                            nk.ngay_cap_nhat,
                            nk.nguoi_tao,
                            sp.ten_san_pham
                        };

            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem lvi = new ListViewItem(item.id.ToString());
                lvi.SubItems.Add(item.ngay_nhap.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.ten_san_pham);
                lvi.SubItems.Add(item.nhom_san_pham);
                lvi.SubItems.Add(item.hinh_anh);
                lvi.SubItems.Add(item.hang_sx);
                lvi.SubItems.Add(item.thong_tin);
                lvi.SubItems.Add(item.han_su_dung.ToString());
                lvi.SubItems.Add(item.quy_cach);
                lvi.SubItems.Add(item.dvt);
                lvi.SubItems.Add(item.so_lo);
                lvi.SubItems.Add(item.gia_nhap.ToString());
                lvi.SubItems.Add(item.sl_nhap.ToString());
                lvi.SubItems.Add(item.sl_xuat.ToString());
                lvi.SubItems.Add(item.sl_ton.ToString());
                lvi.SubItems.Add(item.ngay_het_han.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.ghi_chu);
                lvi.SubItems.Add(item.ngay_tao.ToString());
                lvi.SubItems.Add(item.ngay_cap_nhat.ToString());
                lvi.SubItems.Add(item.nguoi_tao);
                listView1.Items.Add(lvi);
            }
            
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
                LoadComboBoxData();
                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
           
              
            }
        }

        private void cboNhapKho_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khoá tìm kiếm
            string searchText = cboNhapKho.Text;

          
            // Lọc danh sách NCC theo từ khoá tìm kiếm
            var filtereNhapkhos = db.nhap_khos
                .Where(n => n.loai_nhap.Contains(searchText))
                .ToList();

            // Cập nhật dữ liệu cho ComboBox
            cboNhapKho.DataSource = filtereNhapkhos;
            cboNhapKho.DisplayMember = "loai_nhap";
            cboNhapKho.ValueMember = "id";

            btnKho.Visible = !filtereNhapkhos.Any();
            
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ của các trường nhập liệu
            if (cboSanPham.SelectedItem == null || cboNhapKho.SelectedItem == null ||
                string.IsNullOrEmpty(txtSoLo.Text) ||
                string.IsNullOrEmpty(txtNgayHetHan.Text) ||
                string.IsNullOrEmpty(txtNgayTao.Text) ||
                string.IsNullOrEmpty(cboSanPham.Text) ||
                string.IsNullOrEmpty(cboNhapKho.Text) ||
                string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            int sanPhamId = (int)cboSanPham.SelectedValue;
            int nhapKhoId = (int)cboNhapKho.SelectedValue;

            // Lấy thông tin sản phẩm từ bảng san_pham
            var sanPham = db.san_phams.FirstOrDefault(sp => sp.id == sanPhamId);
            if (sanPham == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại.");
                return;
            }

            // Lấy thông tin nhập kho từ bảng nhap_kho
            var nhapKho = db.nhap_khos.FirstOrDefault(nk => nk.id == nhapKhoId);
            if (nhapKho == null)
            {
                MessageBox.Show("Nhập kho không tồn tại.");
                return;
            }
            // Lấy số lượng nhập và xuất hiện tại của sản phẩm
            var existingRecords = db.nhap_kho_cts
                .Where(nkct => nkct.san_pham_id == sanPhamId)
                .ToList();

            int slNhap = int.Parse(txtSLNhap.Text);
            int slXuat = int.Parse(txtSLXuat.Text);

            // Tính toán số lượng tồn mới
            int totalSlNhap = slNhap;
            int totalSlXuat = slXuat;
            int slTon = 0;

            if (existingRecords.Any())
            {
                // Cộng dồn số lượng nhập và xuất trước đó
                totalSlNhap += existingRecords.Sum(record => record.sl_nhap);
                totalSlXuat += existingRecords.Sum(record => record.sl_xuat);

                // Tính toán số lượng tồn dựa trên số lượng nhập và xuất hiện tại
                slTon = totalSlNhap - totalSlXuat;
            }
            else
            {
                // Nếu không có dữ liệu trước đó, số lượng tồn mới chỉ dựa trên số lượng nhập và xuất
                slTon = slNhap - slXuat;
            }

            // Tạo đối tượng nhập kho chi tiết mới
            var nhapKhoCt = new nhap_kho_ct
            {

                nhap_kho_id = nhapKhoId,
                ngay_nhap = nhapKho.ngay_nhap,
                san_pham_id = sanPhamId,
                nhom_san_pham = sanPham.nhom_san_pham,
                hang_sx = sanPham.hang_sx,
                hinh_anh = sanPham.hinh_anh,
                thong_tin = sanPham.thong_tin,
                han_su_dung= sanPham.han_su_dung,
                quy_cach = sanPham.quy_cach,
                dvt = sanPham.dvt,
                so_lo = txtSoLo.Text,
                gia_nhap = sanPham.gia_nhap,
                sl_nhap = slNhap,
                sl_xuat =slXuat,
                sl_ton = slTon,
                ngay_het_han = txtNgayHetHan.Value,
                ghi_chu = txtGhiChu.Text,
                ngay_tao = txtNgayTao.Value,
                ngay_cap_nhat = txtNgayCapNhat.Value,
                nguoi_tao = txtNguoiTao.Text, // Thay đổi theo người dùng hiện tại
            };

            // Thêm đối tượng vào cơ sở dữ liệu
            db.nhap_kho_cts.InsertOnSubmit(nhapKhoCt);
            db.SubmitChanges();

            // Cập nhật lại dữ liệu trên giao diện
            MessageBox.Show("Dữ liệu đã được thêm thành công.");
            ClearInputFields();
            hienThiNhapKhoCt();
            
        }
        private void ClearInputFields()
        {
            // Ví dụ về các trường nhập liệu
           
            txtSLNhap.Text = string.Empty;
            txtSLXuat.Text = string.Empty;
            txtSLTon.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtNguoiTao.Text = string.Empty;
            txtSoLo.Text = string.Empty;
        

            // Đặt lại ComboBox về giá trị mặc định
            cboSanPham.SelectedIndex = -1;
            cboNhapKho.SelectedIndex = -1;

            // Đặt lại các DateTimePicker
            txtNgayTao.Value = DateTime.Now;
            txtNgayHetHan.Value = DateTime.Now;
            txtNgayCapNhat.Value = DateTime.Now;

            // Ẩn nút "Thêm" nếu cần
            btnSp.Visible = false;
            btnKho.Visible = false;
        }

        /* private void listView1_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (listView1.SelectedItems.Count == 0)
             {
                 return;
             }

             // Lấy mục được chọn
             ListViewItem selectedItem = listView1.SelectedItems[0];

             // Lấy ID của mục được chọn
             int ma = int.Parse(selectedItem.SubItems[0].Text);

             // Tạo kết nối đến cơ sở dữ liệu
             using (var db = new DataClasses1DataContext())
             {
                 // Lấy thông tin nhập kho chi tiết dựa trên ID được chọn
                 var nhapKhoCt = db.nhap_kho_cts.FirstOrDefault(nkct => nkct.id == ma);
                 if (nhapKhoCt != null)
                 {
                     // Cập nhật các điều khiển trên form với thông tin từ cơ sở dữ liệu
                     cboNhapKho.SelectedValue = nhapKhoCt.nhap_kho_id;
                     dtpNgayNhap.Value = nhapKhoCt.ngay_nhap;
                     cboSanPham.SelectedValue = nhapKhoCt.san_pham_id;
                     txtNhomSanPham.Text = nhapKhoCt.nhom_san_pham;
                     txtHangSx.Text = nhapKhoCt.hang_sx;
                     txtHinhAnh.Text = nhapKhoCt.hinh_anh;
                     txtThongTin.Text = nhapKhoCt.thong_tin;
                     txtHanSuDung.Text = nhapKhoCt.han_su_dung.ToString();
                     txtQuyCach.Text = nhapKhoCt.quy_cach;
                     txtDvt.Text = nhapKhoCt.dvt;
                     txtSoLo.Text = nhapKhoCt.so_lo;
                     txtGiaNhap.Text = nhapKhoCt.gia_nhap.ToString();
                     txtSlNhap.Text = nhapKhoCt.sl_nhap.ToString();
                     txtSlXuat.Text = nhapKhoCt.sl_xuat.ToString();
                     txtSlTon.Text = nhapKhoCt.sl_ton.ToString();
                     dtpNgayHetHan.Value = nhapKhoCt.ngay_het_han;
                     txtGhiChu.Text = nhapKhoCt.ghi_chu;
                 }
             }
         }*/
    }
}
