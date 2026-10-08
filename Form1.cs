using System;
using System.Windows.Forms;

namespace NGUYEN_VU_NHAT_MINH_24810320314_BAI_TAP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện click nút Tính tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDonGia.Text, out double donGia) || donGia < 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá dịch vụ hợp lệ (số >= 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng khách hợp lệ (số nguyên > 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }

            double phanTramGiam = 0;
            if (!string.IsNullOrWhiteSpace(txtPhanTramGiam.Text))
            {
                if (!double.TryParse(txtPhanTramGiam.Text, out phanTramGiam) || phanTramGiam < 0 || phanTramGiam > 100)
                {
                    MessageBox.Show("Vui lòng nhập % giảm giá hợp lệ (0 đến 100)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhanTramGiam.Focus();
                    return;
                }
            }

            double tongTien = (donGia * soLuong) * ((100.0 - phanTramGiam) / 100.0);
            lblTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
        }

        // Sự kiện click nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtPhanTramGiam.Clear();
            lblTongTien.Text = "0 VNĐ";
            txtDonGia.Focus();
        }
    }
}