using DevExpress.XtraEditors;
using QLKho.Model;
using QLKho.Services;
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

namespace QLKho.userControl
{
    public partial class userWorkhouse : DevExpress.XtraEditors.XtraUserControl
    {
     
        static UnitService _dbUnit;
        private OpenFileDialog openFileDialog;
        private string imagePath;
        public userWorkhouse(string connectionString)
        {
            InitializeComponent();
          
            _dbUnit = new UnitService(connectionString);
            openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn Hình Ảnh"
            };
            /*  LoadData();*/
        }
        private void LoadDataKho()
        {
            gridDataKho.DataSource = _dbUnit.KhoService.GetAllKho();
        }
        private void LoadDataNCC()
        {
            gridNCC.DataSource = _dbUnit.NCCService.GetAllNCC();
        }
        private void LoadDataNhapKho()
        {
            gridDataNhapKho.DataSource = _dbUnit.NhapKhoService.GetAllNhapKho();
            LoadComboBoxData();
        }
        private void LoadDataSanPham()
        {
            gridDataSanPham.DataSource = _dbUnit.SanPhamService.GetAllSanPham();
        }
        private void LoadDataNhapKhoCT()
        {
            gridControlNhapKhoCT.DataSource = _dbUnit.NhapKhoCTService.GetAllNhapKhoCT();
        }
        private void LoadDataXuatKho()
        {
            gridControlDataXuatKho.DataSource = _dbUnit.XuatKhoService.GetAllXuatKho();
        }
        private void LoadDataXuatKhoCT()
        {
            gridControlDataXuatKhoCT.DataSource = _dbUnit.XuatKhoCTService.GetAllXuatKhoCT();
        }

        private void btnThenKho_Click(object sender, EventArgs e)
        {

            Kho kho = new Kho()
            {
                TenKho = txtTenKho.Text,
                HienThi = txtHienThi.Text,
                GhiChu = txtGhiChu.Text,
                NguoiTao = txtNguoiTao.Text,
                NgayTao = DateTime.Parse(txtNgayTao.Text),
                CapNhat = DateTime.Parse(txtNgayCapNhat.Text),
            };

            _dbUnit.KhoService.AddKho(kho);
            ResetKho();
            LoadDataKho();
        }
        private void ResetKho()
        {
            txtTenKho.Text = string.Empty;
            txtHienThi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtNguoiTao.Text = string.Empty;
            txtNgayTao.Value = DateTime.Now;
            txtNgayCapNhat.Value = DateTime.Now;
        }

        private void WorkHouse_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string selectedTabName = e.Page.Name;
            if (selectedTabName == "tabKho")
            {
                LoadDataKho();
            }
            else if (selectedTabName == "tabNCC")
            {
                LoadDataNCC();

            }
            else if (selectedTabName == "tabSanPham")
            {
                LoadDataSanPham();

            }
            else if (selectedTabName == "tabNhapKho")
            {
                LoadDataNhapKho();
            }
            else if (selectedTabName == "tabNhapKhoCT")
            {
                LoadDataNhapKhoCT();
            }
            else if (selectedTabName == "tabXuatKho")
            {
                LoadDataXuatKho();
            }
            else if (selectedTabName == "tabXuatKhoCT")
            {
                LoadDataXuatKhoCT();
            }
        }


        private void gridViewDataKho_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            // Lấy đối tượng dữ liệu từ hàng hiện tại
            var row = e.Row as Kho;

            if (row != null)
            {
                // Thực hiện cập nhật dữ liệu trong cơ sở dữ liệu
                _dbUnit.KhoService.EditKho(row);

                // Cập nhật lại dữ liệu hoặc giao diện nếu cần
                ResetKho();
                LoadDataKho();
            }
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            var selectedRow = gridViewDataKho.GetFocusedRow() as Kho;

            if (selectedRow != null)
            {
               int ma = selectedRow.Id; // Giả sử thuộc tính ID của đối tượng là Id
                                        // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa kho có mã la : " + ma + " này?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _dbUnit.KhoService.DeleteKho(ma);
                    selectedRow = null;
                    LoadDataKho();
                }
            }
          
        }

        private void ResetNCC()
        {
            txtTenNCC.Text = string.Empty;
            txtTenDayDuNCC.Text = string.Empty;
            txtHienThiNCC.Text = string.Empty;
            txtLoaiCungCap.Text = string.Empty;
            txtLogo.Text = string.Empty;
            txtNGuoiDaiDienNCC.Text = string.Empty;
            txtSdtNCC.Text = string.Empty;
            txtTinhTrangNCC.Text = string.Empty;
            txtNVPhuTrachNCC.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtNgayTaoNCC.Value = DateTime.Now;
            txtNgayCapNhatNCC.Value = DateTime.Now;
        }
        private void btnThenNCC_Click(object sender, EventArgs e)
        {
            NCC ncc = new NCC()
            {
                TenNcc = txtTenNCC.Text,
                TenDayDu = txtTenDayDuNCC.Text,
                HienThi = txtHienThiNCC.Text,
                LoaiNcc = txtLoaiCungCap.Text,
                Logo = txtLogo.Text,
                NguoiDaiDien =txtNGuoiDaiDienNCC.Text,
                Sdt = txtSdtNCC.Text,
                TinhTrang = txtTinhTrangNCC.Text,
                NvPhuTrach = txtNVPhuTrachNCC.Text,
                GhiChu = txtGhiChu.Text,
                NgayTao = DateTime.Parse(txtNgayTao.Text),
                NgayCapNhat = DateTime.Parse(txtNgayTao.Text),
            };

            _dbUnit.NCCService.AddNCC(ncc);
            ResetKho();
            LoadDataNCC();
        }

        private void gridViewNCC_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            // Lấy đối tượng dữ liệu từ hàng hiện tại
            var row = e.Row as NCC;

            if (row != null)
            {
                // Thực hiện cập nhật dữ liệu trong cơ sở dữ liệu
                _dbUnit.NCCService.EditNCC(row);

                // Cập nhật lại dữ liệu hoặc giao diện nếu cần
                ResetNCC();
                LoadDataNCC();
            }
        }

     
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            var selectedRow = gridViewNCC.GetFocusedRow() as NCC;

            if (selectedRow != null)
            {
                int ma = selectedRow.Id; // Giả sử thuộc tính ID của đối tượng là Id
                                         // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ncc có mã la : " + ma + " này?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _dbUnit.NCCService.DeleteNCC(ma);
                    selectedRow = null;
                    LoadDataKho();
                }
            }
        }

        private void ResetSanPham()
        {
            txtTenSp.Text = string.Empty;
            txtNhomSp.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtHienThiSP.Text = string.Empty;
            txtHangSx.Text = string.Empty;
            txtThongTin.Text = string.Empty;
            txtGhiChuSP.Text = string.Empty;
            txtNgayTaoSp.Text = string.Empty;
            txtTrangThai.Text = string.Empty;
            txtNgayTaoSp.Value = DateTime.Now;
            txtNgayCapNhatSp.Value = DateTime.Now;
            txtHanSuDung.Value = DateTime.Now;
            txtDvt.Text = string.Empty;
            txtSLTon.Text = string.Empty;
            txtQuyCach.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            txtSLNhap.Text = string.Empty;
            txtSLToiDa.Text = string.Empty;
            txtSLToiDa.Text = string.Empty;
            txtSLXuat.Text = string.Empty;
            pictureBox1.Image = null;
            txtHinhAnh.Text = string.Empty;
        }
        private void btnThemSp_Click(object sender, EventArgs e)
        {
 
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

            // Kiểm tra nếu hình ảnh đã tồn tại trong thư mục đích
            if (File.Exists(destinationImagePath))
            {
                MessageBox.Show("Hình ảnh đã tồn tại trong thư mục. Không sao chép hình ảnh nữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Sao chép hình ảnh vào thư mục 'Images'
                File.Copy(sourceImagePath, destinationImagePath, true);
            }
            // Tạo đối tượng sản phẩm mới
            SanPham sanPham = new SanPham
            {
                TenSanPham = txtTenSp.Text,
                HienThi = txtHienThiSP.Text,
                NhomSanPham = txtNhomSp.Text,
                HangSX = txtHangSx.Text,
                HinhAnh = fileName, // Lưu tên tệp hình ảnh
                DiaChi = txtDiaChi.Text,
                ThongTin = txtThongTin.Text,
                HanSuDung = DateTime.Parse(txtHanSuDung.Text),
                QuyCach = txtQuyCach.Text,
                Dvt = txtDvt.Text,
                GiaNhap = float.Parse(txtGiaNhap.Text),
                SlToiThieu = int.Parse(txtSLToiThieu.Text),
                SlToiDa = int.Parse(txtSLToiDa.Text),
                SlNhap = int.Parse(txtSLNhap.Text),
                SlXuat = int.Parse(txtSLXuat.Text),
                SlTon = int.Parse(txtSLTon.Text),
                TrangThai = txtTrangThai.Text,
                GhiChu = txtGhiChuSP.Text,
                NgayTao = DateTime.Parse(txtNgayTaoSp.Text),
                NgayCapNhat = DateTime.Parse(txtNgayCapNhatSp.Text),
                NguoiTao = txtNgayTaoSp.Text
            };

            // Thêm sản phẩm vào cơ sở dữ liệu
            _dbUnit.SanPhamService.AddSanPham(sanPham);
            ResetSanPham();
            LoadDataSanPham();

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

        private void btnXoaSp_Click(object sender, EventArgs e)
        {
            var selectedRow = gridViewSanPham.GetFocusedRow() as SanPham; // Giả sử đối tượng là SanPham

            if (selectedRow != null)
            {
                int ma = selectedRow.Id; // Lấy ID của sản phẩm đã chọn

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm có mã: " + ma + " không?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa hình ảnh liên quan (nếu có)
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", selectedRow.HinhAnh);
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath); // Xóa tệp hình ảnh
                        }

                        // Xóa sản phẩm từ cơ sở dữ liệu
                        _dbUnit.SanPhamService.DeleteSanPham(ma);
                         MessageBox.Show("Sản phẩm đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật giao diện
                         LoadDataSanPham();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadComboBoxData()
        {
            using (var db = new DataClasses1DataContext())
            {
                // Tải danh sách kho vào ComboBox
                cbTenKho.DataSource =_dbUnit.KhoService.GetAllKho();
                cbTenKho.DisplayMember = "TenKho"; // Thay đổi theo thuộc tính hiển thị
                cbTenKho.ValueMember = "Id"; // Thay đổi theo thuộc tính ID

                // Tải danh sách NCC vào ComboBox
                cbTenNCC.DataSource = _dbUnit.NCCService.GetAllNCC();
                cbTenNCC.DisplayMember = "TenNcc"; // Thay đổi theo thuộc tính hiển thị
                cbTenNCC.ValueMember = "Id"; // Thay đổi theo thuộc tính ID
            }
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            using (var form = new FrmNhapKho())
            {
                form.ShowDialog();
                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
                LoadComboBoxData();
            }
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            using (var form = new FrmNhapKho())
            {
                form.ShowDialog();

                // Tải lại dữ liệu vào ComboBox sau khi thêm mới
                LoadComboBoxData();
            }
        }

        private void ResetNhapKho()
        {
            txtLoaiNhap.Text = string.Empty;
            txrNguoiTaoNk.Text = string.Empty;
            txtSLNhapNk.Text = string.Empty;
            txtNDNhap.Text = string.Empty;
            txtNguoiGiao.Text = string.Empty;
            txtNgayNhap.Value = DateTime.Now;
            txtNgayTaoNk.Value = DateTime.Now;
            txtNgayCapNhatNk.Value = DateTime.Now;
        }
        private void btnThemNhapKho_Click(object sender, EventArgs e)
        {
            NhapKho nhapKho = new NhapKho
            {
                LoaiNhap = txtLoaiNhap.Text,
                NgayNhap = DateTime.Parse(txtNgayNhap.Text),
                NccId = (int)cbTenNCC.SelectedValue,
                KhoId = (int)cbTenKho.SelectedValue,
                SlNhap = int.Parse(txtSLNhapNk.Text),
                NguoiGiao = txtNguoiGiao.Text,
                NoiDungNhap = txtNDNhap.Text,
                NgayTao = DateTime.Parse(txtNgayTaoNk.Text),
                NgayCapNhat = DateTime.Parse(txtNgayCapNhatNk.Text),
                NguoiTao = txtNgayTaoNk.Text, // Thay đổi theo người dùng hiện tại
                
            };
            _dbUnit.NhapKhoService.AddNhapKho(nhapKho);
            ResetNhapKho();
            LoadDataNhapKho();
        }

        private void btnXoaNhapKho_Click(object sender, EventArgs e)
        {
            var selectedRow = gridViewNhapKho.GetFocusedRow() as NhapKho;

            if (selectedRow != null)
            {
                int ma = selectedRow.Id; // Giả sử thuộc tính ID của đối tượng là Id
                                         // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhap kho có mã la : " + ma + " này?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _dbUnit.NhapKhoService.DeleteNhapKho(ma);
                    selectedRow = null;
                    LoadDataNhapKho();
                }
            }
        }

        private void WorkHouse_Click(object sender, EventArgs e)
        {

        }

        private void gridDataNhapKho_Click(object sender, EventArgs e)
        {

        }
    }
}
