using BUS_QL;
using DTO_QL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormQuanLySV : Form
    {
        BUS_CBDT QlSinhVien = new BUS_CBDT();
        private byte[] image;
        bool isAdding = false;
        public FormQuanLySV()
        {
            InitializeComponent();
            LoadDanhSachLocDulieu();
            Loaddata();
            LoadDanhSachLop();
            LockControl();

            cbLocDuLieu.SelectedValueChanged += cbLocDuLieu_SelectedIndexChanged;
            if (dgvData.Columns.Contains("Hình"))
            {
                dgvData.Columns["Hình"].Visible = false;
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LockControl()
        {
            txtMasv.Enabled = false;
            txtHoten.Enabled = false;
            txtEmail.Enabled = false;
            txtSodt.Enabled = false;
            txtDiachi.Enabled = false;
            cbLop.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            pbObama.Enabled = false;

            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void ClearForm()
        {
            txtMasv.Clear();
            txtHoten.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtSodt.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            pbObama.Image = null;
        }
        private bool CheckInput()
        {
            if (cbLop.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMasv.Text) ||
                string.IsNullOrWhiteSpace(txtHoten.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSodt.Text) ||
                string.IsNullOrWhiteSpace(txtDiachi.Text) ||
                (!rdbNam.Checked && !rdbNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtSodt.TextLength < 10 || txtSodt.TextLength >= 11 || !txtSodt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return false;
            }

            if (image == null || image.Length < 1)
            {
                MessageBox.Show("Vui lòng Chọn lại ảnh hoặc chọn ảnh mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        static bool checkEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        public void Loaddata()
        {
            dgvData.DataSource = QlSinhVien.LoadDsSinhVien(cbLocDuLieu.SelectedValue.ToString());
            dgvData.Columns[0].Visible = false;
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvData.Columns["Hình"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void LoadDanhSachLop()
        {
            cbLop.DataSource = QlSinhVien.LoadDsLopChoSinhVien();
            cbLop.DisplayMember = "ClassName";
            cbLop.ValueMember = "IDLop";
        }
        public void LoadDanhSachLocDulieu()
        {
            cbLocDuLieu.DataSource = QlSinhVien.LoadDsLopChoSinhVien();
            cbLocDuLieu.DisplayMember = "ClassName";
            cbLocDuLieu.ValueMember = "IDLop";
        }
        private void cbLocDuLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void LoadPictureBox()
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        if (pbObama.Image != null)
                        {
                            pbObama.Image.Dispose();
                        }

                        pbObama.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (pbObama.Image != null)
                {
                    pbObama.Image.Dispose();
                    pbObama.Image = null;
                }
            }
        }
        private void pbObama_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                    file.RestoreDirectory = true;
                    file.Multiselect = false;
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        image = File.ReadAllBytes(file.FileName);

                        LoadPictureBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtHoten.Enabled = true;
            txtEmail.Enabled = true;
            txtSodt.Enabled = true;
            txtDiachi.Enabled = true;
            cbLop.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            pbObama.Enabled = true;
            btnSave.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();

            string tiento = "SV"; //tiền tố
            txtMasv.Text = QlSinhVien.CreateStudentID(tiento);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtHoten.Enabled = true;
            txtEmail.Enabled = true;
            txtSodt.Enabled = true;
            txtDiachi.Enabled = true;
            cbLop.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            pbObama.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvData.CurrentRow != null)
            {
                try
                {
                    btnUpdate.Enabled = true;

                    txtMasv.Text = dgvData.CurrentRow.Cells["Mã Sinh Viên"]?.Value?.ToString() ?? string.Empty;
                    txtHoten.Text = dgvData.CurrentRow.Cells["Tên Sinh Viên"]?.Value?.ToString() ?? string.Empty;
                    cbLop.SelectedValue = dgvData.CurrentRow.Cells["ID Lớp"]?.Value?.ToString() ?? string.Empty;
                    txtEmail.Text = dgvData.CurrentRow.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                    txtSodt.Text = dgvData.CurrentRow.Cells["Số Điện Thoại"]?.Value?.ToString() ?? string.Empty;
                    txtDiachi.Text = dgvData.CurrentRow.Cells["Địa Chỉ"]?.Value?.ToString() ?? string.Empty;

                    string gioiTinh = dgvData.CurrentRow.Cells["Giới Tính"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(gioiTinh))
                    {
                        rdbNam.Checked = gioiTinh == "Nam";
                        rdbNu.Checked = gioiTinh == "Nữ";
                    }
                    else
                    {
                        rdbNam.Checked = false;
                        rdbNu.Checked = false;
                    }

                    image = dgvData.CurrentRow.Cells["Hình"]?.Value as byte[];
                    if (image != null && image.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(image))
                        {
                            pbObama.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbObama.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (QlSinhVien.KiemTraSVDaCoDiemChua(txtHoten.Text))
                {
                    MessageBox.Show("Sinh viên đã có điểm, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlSinhVien.XoaSinhVien(txtHoten.Text))
                    {
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        Loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message;
            if (isAdding)
            {
                if (!CheckInput())
                {
                    return;
                }

                if (!checkEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int trangThaiLop = QlSinhVien.KtTrangThaiCuaLop(cbLop.SelectedValue.ToString());
                if (trangThaiLop == 1)
                {
                    MessageBox.Show("Lớp này đã bị khóa. Không thể thêm sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (QlSinhVien.KtSvDaTonTai(txtHoten.Text))
                {
                    MessageBox.Show("Mã học sinh đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_CBDT_SV sinhvien = new DTO_CBDT_SV(txtMasv.Text,cbLop.SelectedValue.ToString(),txtHoten.Text,txtEmail.Text,
                                                        txtSodt.Text,rdbNam.Checked,txtDiachi.Text,image);
                if (QlSinhVien.ThemSinhVien(sinhvien, out message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!CheckInput())
                {
                    return;
                }

                int trangThaiLop = QlSinhVien.KtTrangThaiCuaLop(cbLop.SelectedValue.ToString());
                if (trangThaiLop == 1)
                {
                    MessageBox.Show("Lớp này đã bị khóa. Không thể sửa sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!checkEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_CBDT_SV sinhvien = new DTO_CBDT_SV(txtMasv.Text, cbLop.SelectedValue.ToString(), txtHoten.Text, txtEmail.Text,
                                                        txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật sinh viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlSinhVien.CapNhatSinhVien(sinhvien, out message))
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            ClearForm();
            LockControl();

            Loaddata();

            btnNew.Enabled = true;
            btnUpdate.Enabled = true;
            dgvData.Enabled = true;
        }
    }
}
