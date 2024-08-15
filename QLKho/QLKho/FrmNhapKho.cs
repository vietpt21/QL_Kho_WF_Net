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
    public partial class FrmNhapKho : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FrmNhapKho()
        {
            InitializeComponent();
        }

        private void FrmNhapKho_Load(object sender, EventArgs e)
        {
            hienthinhapkho();
            LoadComboBoxData();
        }
        private void LoadComboBoxData()
        {
            using (var db = new DataClasses1DataContext())
            {
                // Tải danh sách kho vào ComboBox
                cbTenKho.DataSource = db.khos.ToList();
                cbTenKho.DisplayMember = "ten_kho"; // Thay đổi theo thuộc tính hiển thị
                cbTenKho.ValueMember = "id"; // Thay đổi theo thuộc tính ID

                // Tải danh sách NCC vào ComboBox
                cbTenNCC.DataSource = db.nccs.ToList();
                cbTenNCC.DisplayMember = "ten_ncc"; // Thay đổi theo thuộc tính hiển thị
                cbTenNCC.ValueMember = "id"; // Thay đổi theo thuộc tính ID
            }
        }
        private void hienthinhapkho()
        {
            // Xóa tất cả các mục hiện có trong ListView
            listView1.Items.Clear();

            // Tạo kết nối đến cơ sở dữ liệu
            using (var db = new DataClasses1DataContext())
            {
                // Lấy dữ liệu từ bảng nhap_kho và các bảng liên kết
                var data = from nh in db.nhap_khos
                           join k in db.khos on nh.kho_id equals k.id
                           join n in db.nccs on nh.ncc_id equals n.id
                           select new
                           {
                               nh.id,
                               nh.loai_nhap,
                               nh.ngay_nhap,
                               KhoName = k.ten_kho,
                               NCCName = n.ten_ncc,
                               nh.sl_nhap,
                               nh.nguoi_giao,
                               nh.noi_dung_nhap,
                               nh.ngay_tao,
                               nh.ngay_cap_nhat,
                               nh.nguoi_tao
                           };

                // Thêm dữ liệu vào ListView
                foreach (var item in data)
                {
                    ListViewItem lvi = new ListViewItem(item.id.ToString());
                    lvi.SubItems.Add(item.loai_nhap);
                    lvi.SubItems.Add(item.ngay_nhap.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(item.KhoName);
                    lvi.SubItems.Add(item.NCCName);
                   
                    lvi.SubItems.Add(item.sl_nhap+"");
                    lvi.SubItems.Add(item.nguoi_giao);
                    lvi.SubItems.Add(item.noi_dung_nhap);
                    lvi.SubItems.Add(item.ngay_tao+"");
                    lvi.SubItems.Add(item.ngay_cap_nhat+"");
                    lvi.SubItems.Add(item.nguoi_giao);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void cbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTenNCC_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khoá tìm kiếm
            string searchText = cbTenNCC.Text;

            using (var db = new DataClasses1DataContext())
            {
                // Lọc danh sách NCC theo từ khoá tìm kiếm
                var filteredNCCs = db.nccs
                    .Where(n => n.ten_ncc.Contains(searchText))
                    .ToList();

                // Cập nhật dữ liệu cho ComboBox
                cbTenNCC.DataSource = filteredNCCs;
                cbTenNCC.DisplayMember = "ten_ncc";
                cbTenNCC.ValueMember = "id";

                btnThemNCC.Visible = !filteredNCCs.Any();
            }
        }

        private void cbTenKho_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khoá tìm kiếm
            string searchText = cbTenKho.Text;

            using (var db = new DataClasses1DataContext())
            {
                // Lọc danh sách kho theo từ khoá tìm kiếm
                var filteredKhos = db.khos
                    .Where(k => k.ten_kho.Contains(searchText))
                    .ToList();

                // Cập nhật dữ liệu cho ComboBox
                cbTenKho.DataSource = filteredKhos;
                cbTenKho.DisplayMember = "ten_kho";
                cbTenKho.ValueMember = "id";

                btnThemKho.Visible = !filteredKhos.Any();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            // Mở form nhập NCC
            using (var form = new FrmNCC())
            {
                form.ShowDialog();

                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
                LoadComboBoxData();
            }
        }

        private void ClearInputFields()
        {
            txtLoaiNhap.Clear();
            cbTenKho.SelectedIndex = -1;
            cbTenNCC.SelectedIndex = -1;
            txtSLNhap.Clear();
            txtNguoiGiao.Clear();
            txtNDNhap.Clear();
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoaiNhap.Text) ||
            cbTenNCC.SelectedItem == null ||
            cbTenKho.SelectedItem == null ||
            string.IsNullOrEmpty(txtSLNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (var db = new DataClasses1DataContext())
            {
                var nhapKho = new nhap_kho
                {
                    loai_nhap = txtLoaiNhap.Text,
                  
                    ngay_nhap = DateTime.Parse(txtNgayNhap.Text),
                    ncc_id = (int)cbTenNCC.SelectedValue,
                    kho_id = (int)cbTenKho.SelectedValue,
                    sl_nhap = int.Parse(txtSLNhap.Text),
                    nguoi_giao = txtNguoiGiao.Text,
                    noi_dung_nhap = txtNDNhap.Text,
                    ngay_tao = DateTime.Parse(txtNgayTao.Text),
                    ngay_cap_nhat = DateTime.Parse(txtNgayCapNhat.Text),
                    nguoi_tao = "UserName" // Thay đổi theo người dùng hiện tại
                };

                db.nhap_khos.InsertOnSubmit(nhapKho);
                db.SubmitChanges();

                MessageBox.Show("Dữ liệu đã được lưu thành công.");
                ClearInputFields();
                hienthinhapkho();
            }
        }

   //Xử lý sự kiện nút "Sửa"
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
            var nhapKho = db.nhap_khos.FirstOrDefault(nk => nk.id == ma);
            if (nhapKho != null)
            {
                nhapKho.loai_nhap = txtLoaiNhap.Text;
                nhapKho.ngay_nhap = txtNgayNhap.Value;
                nhapKho.ncc_id = (int)cbTenNCC.SelectedValue;
                nhapKho.kho_id = (int)cbTenKho.SelectedValue;
                nhapKho.sl_nhap = int.Parse(txtSLNhap.Text);
                nhapKho.nguoi_giao = txtNguoiGiao.Text;
                nhapKho.noi_dung_nhap = txtNDNhap.Text;
                nhapKho.ngay_cap_nhat = DateTime.Now;
                nhapKho.ngay_tao = DateTime.Now;
                nhapKho.nguoi_tao = txtNguoiTao.Text; ; // Thay đổi theo người dùng hiện tại

                db.SubmitChanges();

                MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                ClearInputFields();
                hienthinhapkho();
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            // Lấy mục được chọn
            ListViewItem selectedItem = listView1.SelectedItems[0];

            // Lấy ID của mục được chọn
            int selectedId = int.Parse(selectedItem.Text);

            // Tạo kết nối đến cơ sở dữ liệu
            using (var db = new DataClasses1DataContext())
            {
                // Lấy thông tin nhập kho dựa trên ID được chọn
                var nhapKho = db.nhap_khos.FirstOrDefault(nk => nk.id == selectedId);
                if (nhapKho != null)
                {
                    // Cập nhật các điều khiển trên form với thông tin từ cơ sở dữ liệu
                    txtLoaiNhap.Text = nhapKho.loai_nhap;
                    txtNgayNhap.Value = nhapKho.ngay_nhap;
                    cbTenNCC.SelectedValue = nhapKho.ncc_id;
                    cbTenKho.SelectedValue = nhapKho.kho_id;
                    txtSLNhap.Text = nhapKho.sl_nhap.ToString();
                    txtNguoiGiao.Text = nhapKho.nguoi_giao;
                    txtNDNhap.Text = nhapKho.noi_dung_nhap;
                    txtNgayTao.Text = nhapKho.ngay_tao+"";
                    txtNgayCapNhat.Text = nhapKho.ngay_nhap+"";
                    txtNguoiTao.Text = nhapKho.nguoi_tao;
                }
            }
        }
        // Xử lý sự kiện nút "Xóa"
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = listView1.SelectedItems[0];
            int ma = int.Parse(lvi.SubItems[0].Text);
           
            var nhapKho = db.nhap_khos.FirstOrDefault(nk => nk.id == ma);
            if (nhapKho != null)
            {
                db.nhap_khos.DeleteOnSubmit(nhapKho);
                db.SubmitChanges();

                MessageBox.Show("Dữ liệu đã được xóa thành công.");
                ClearInputFields();
                hienthinhapkho();
            }
            
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {

        }
    }
}
