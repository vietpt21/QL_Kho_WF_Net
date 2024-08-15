using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.UI;
using Microsoft.AspNetCore.Components;
using QLKho.Model;
using QLKho.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLKho.userControl.FormItem
{
    public partial class frmAddProduc : DevExpress.XtraEditors.XtraForm
    {
        static readonly string connectionString = "Data Source=localhost;Initial Catalog=QLKho;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        static UnitService _dbUnit;
        public frmAddProduc()
        {
            InitializeComponent();
            _dbUnit = new UnitService(connectionString);
            LoadComboBoxData();
       
            lblNhapKho.BackColor = Color.Orange;
            lblNhapKhoCt.BackColor = Color.Red;
            lblHoanThanh.BackColor = Color.Red;
        }

        private void LoadComboBoxData()
        {
            var khoList = _dbUnit.KhoService.GetAllKho();
            var nccList = _dbUnit.NCCService.GetAllNCC();
            var NhapKhoList = _dbUnit.NhapKhoService.GetAllNhapKho();
            var SanPhamList = _dbUnit.SanPhamService.GetAllSanPham();

            // Clear any existing items
            cboKho.Properties.Items.Clear();
            cboNCC.Properties.Items.Clear();
            cboNhapKho.Properties.Items.Clear();
            cboSanPham.Properties.Items.Clear();
            foreach (var kho in khoList)
            {
                cboKho.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem
                {
                    Value = kho.Id,
                    Description = kho.TenKho
                });
            }
            foreach (var ncc in nccList)
            {
                cboNCC.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem
                {
                    Value = ncc.Id,
                    Description = ncc.TenNcc
                });
            }
            foreach (var nhapkho in NhapKhoList)
            {
                cboNhapKho.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem
                {
                    Value = nhapkho.Id,
                    Description = nhapkho.LoaiNhap
                });
            }
            foreach (var sp in SanPhamList)
            {
                cboSanPham.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem
                {
                    Value = sp.Id,
                    Description = sp.TenSanPham
                });
            }
        }
        private void ClearInputNhapKho()
        {
            txtLoaiNhap.Text= string.Empty;
            cboKho.EditValue = null;
            cboNCC.EditValue = null;
            txtSLNhap.Text= string.Empty;
            txtNguoiGiao.Text = string.Empty;
            txtNoiDungNhap.Text = string.Empty;
        }
        private void ClearInputNhapKhoCt()
        {
            txtSLNhapCt.Text = string.Empty;
            txtSLXuatCt.Text = string.Empty;
            txtSoLo.Text = string.Empty;
            txtNgayHetHan.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtNgayTaoCt.Text = string.Empty;
            txtNgayCapNhatCt.Text = string.Empty;
            txtNguoiTaoCt.Text = string.Empty;

            // Nếu có combobox hay control khác cần làm sạch, thêm vào đây
            cboNhapKho.EditValue = null;
            cboSanPham.EditValue = null;
        }
        private void btnNextNhapKho_Click(object sender, EventArgs e)
        {
            /* try
             {
                 // Lấy giá trị từ các ComboBoxEdit
                 int khoId = Convert.ToInt32(cboKho.EditValue);
                 int nccId = Convert.ToInt32(cboNCC.EditValue);
                 var nhapKho = new NhapKho
                 {
                     LoaiNhap = txtLoaiNhap.Text,
                     NgayNhap = DateTime.Parse(txtNgayNhap.Text),
                     NccId = nccId,
                     KhoId = khoId,
                     SlNhap = int.Parse(txtSLNhap.Text),
                     NguoiGiao = txtNguoiGiao.Text,
                     NoiDungNhap = txtNoiDungNhap.Text,
                     NgayTao = DateTime.Parse(txtNgayTao.Text),
                     NgayCapNhat = DateTime.Parse(txtNgayCapNhat.Text),
                     NguoiTao = txtNguoiTao.Text // Thay đổi theo người dùng hiện tại
                 };
                 // Thêm đối tượng vào cơ sở dữ liệu và kiểm tra kết quả
                 bool success = _dbUnit.NhapKhoService.AddNhapKho(nhapKho);

                 if (success)
                 {

                     lblNhapKho.BackColor = Color.Green;
                     lblNhapKhoCt.BackColor = Color.Orange;
                     navigationPaneNhapKho.SelectNextPage();
                 }
                 else
                 {
                     MessageBox.Show("Không thể lưu nhập kho. Vui lòng thử lại.");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
             }

             return ;*/
            navigationPaneNhapKho.SelectNextPage();
        }
        private void cboKho_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
         
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            /*  try
              {
                  if (!int.TryParse(cboNhapKho.EditValue?.ToString(), out int nhapkhoId))
                  {
                      MessageBox.Show("Mã nhập kho không hợp lệ.");

                  }

                  if (!int.TryParse(cboSanPham.EditValue?.ToString(), out int sanphamId))
                  {
                      MessageBox.Show("Mã sản phẩm không hợp lệ.");

                  }

                  // Fetch product information
                  var sanPhamList = _dbUnit.SanPhamService.GetAllSanPham();
                  var sanPham = sanPhamList.FirstOrDefault(sp => sp.Id == sanphamId);

                  if (sanPham == null)
                  {
                      MessageBox.Show("Sản phẩm không tồn tại.");

                  }

                  // Fetch all nhập kho records and find the specific one
                  var nhapKhoList = _dbUnit.NhapKhoService.GetAllNhapKho();
                  var nhapKho = nhapKhoList.FirstOrDefault(nk => nk.Id == nhapkhoId);

                  if (nhapKho == null)
                  {
                      MessageBox.Show("Nhập kho không tồn tại.");

                  }

                  // Validate quantities
                  if (!int.TryParse(txtSLNhapCt.Text, out int slNhap))
                  {
                      MessageBox.Show("Số lượng nhập không hợp lệ.");

                  }

                  if (!int.TryParse(txtSLXuatCt.Text, out int slXuat))
                  {
                      MessageBox.Show("Số lượng xuất không hợp lệ.");

                  }

                  // Calculate existing records and stock quantities
                  var nhapkhoct = _dbUnit.NhapKhoCTService.GetAllNhapKhoCT();
                  var existingRecords = nhapkhoct
                      .Where(nkct => nkct.SanPhamId == sanphamId && nkct.NhapKhoId == nhapkhoId)
                      .ToList();

                  int totalSlNhap = slNhap;
                  int totalSlXuat = slXuat;
                  int slTon;

                  if (existingRecords.Any())
                  {
                      totalSlNhap += existingRecords.Sum(record => record.SlNhap);
                      totalSlXuat += existingRecords.Sum(record => record.SlXuat);
                      slTon = totalSlNhap - totalSlXuat;

                      // Cập nhật các bản ghi hiện có
                      foreach (var record in existingRecords)
                      {
                          record.SlNhap = totalSlNhap;
                          record.SlXuat = totalSlXuat;
                          record.SlTon = slTon;
                          record.SoLo = txtSoLo.Text;
                          record.NgayCapNhat = DateTime.Now;
                          record.GhiChu = txtGhiChu.Text;

                          bool success = _dbUnit.NhapKhoCTService.UpdateNhapKhoCt(record);

                          if (!success)
                          {
                              MessageBox.Show("Không thể cập nhật bản ghi nhập kho. Vui lòng thử lại.");
                            // Thoát nếu cập nhật không thành công
                          }
                      }
                      ClearInputNhapKhoCt();
                      lblNhapKho.BackColor = Color.Green;
                      lblNhapKhoCt.BackColor = Color.Orange;
                      navigationPaneNhapKho.SelectNextPage();
                  }
                  else
                  {
                      slTon = slNhap - slXuat;

                      NhapKhoCT nhapKhoCt = new NhapKhoCT
                      {
                          NhapKhoId = nhapkhoId,
                          NgayNhap = nhapKho.NgayNhap,
                          SanPhamId = sanphamId,
                          NhomSanPham = sanPham.NhomSanPham,
                          HangSX = sanPham.HangSX,
                          HinhAnh = sanPham.HinhAnh,
                          ThongTin = sanPham.ThongTin,
                          HanSuDung = sanPham.HanSuDung,
                          QuyCach = sanPham.QuyCach,
                          Dvt = sanPham.Dvt,
                          SoLo = txtSoLo.Text,
                          GiaNhap = sanPham.GiaNhap,
                          SlNhap = slNhap,
                          SlXuat = slXuat,
                          SlTon = slTon,
                          NgayHetHan = DateTime.Parse(txtNgayHetHan.Text),
                          GhiChu = txtGhiChu.Text,
                          NgayTao = DateTime.Parse(txtNgayTaoCt.Text),
                          NgayCapNhat = DateTime.Parse(txtNgayCapNhatCt.Text),
                          NguoiTao = txtNguoiTaoCt.Text,
                      };

                      // Thêm đối tượng vào cơ sở dữ liệu
                      bool success = _dbUnit.NhapKhoCTService.AddNhapKhoCt(nhapKhoCt);

                      if (!success)
                      {
                          MessageBox.Show("Không thể lưu nhập kho. Vui lòng thử lại.");
                          // Thoát nếu không lưu thành công
                      }
                      // Chuyển trang và cập nhật giao diện
                      ClearInputNhapKhoCt();
                      lblNhapKho.BackColor = Color.Green;
                      lblNhapKhoCt.BackColor = Color.Green;
                      lblHoanThanh.BackColor = Color.Green;
                      navigationPaneNhapKho.SelectNextPage();
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                
                  // Thoát nếu có lỗi
              }   */
            navigationPaneNhapKho.SelectNextPage();
        }
        private void DeleteLastNhapKho()
        {
            try
            {
                var nhapKhoList = _dbUnit.NhapKhoService.GetAllNhapKho();

                if (nhapKhoList.Any())
                {
                    // Get the last nhập kho record (assumes sorted by ID)
                    var lastNhapKho = nhapKhoList.OrderByDescending(nk => nk.Id).FirstOrDefault();

                    if (lastNhapKho != null)
                    {
                        _dbUnit.NhapKhoService.DeleteNhapKho(lastNhapKho.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa nhập kho: {ex.Message}");
            }
        }

        private void btnTiepTucThem_Click(object sender, EventArgs e)
        {
            var pages = navigationPaneNhapKho.Pages;
            navigationPaneNhapKho.SelectedPage = (DevExpress.XtraBars.Navigation.INavigationPage)pages[0];
        }

        private void btnCance_Click(object sender, EventArgs e)
        {
            var pages = navigationPaneNhapKho.Pages;
            navigationPaneNhapKho.SelectedPage = (DevExpress.XtraBars.Navigation.INavigationPage)pages[0];
            ClearInputNhapKhoCt();
            DeleteLastNhapKho();
        }
    }
}