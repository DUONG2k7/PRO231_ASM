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
    public partial class FormQuanLyGV : Form
    {
        BUS_CBDT QlGiaoVien = new BUS_CBDT();
        private byte[] image;
        bool isAdding = false;
        public FormQuanLyGV()
        {
            InitializeComponent();
            LoadDsGV();
            LockControl();

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsGV()
        {
            dgvData.DataSource = QlGiaoVien.LoadDsGiaoVien();
        }
        private void LoadPictureBox()
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        if (pbPicGV.Image != null)
                        {
                            pbPicGV.Image.Dispose();
                        }

                        pbPicGV.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (pbPicGV.Image != null)
                {
                    pbPicGV.Image.Dispose();
                    pbPicGV.Image = null;
                }
            }
        }
        public void LockControl()
        {
            txtMaGv.Enabled = false;
            txtHoten.Enabled = false;
            txtEmail.Enabled = false;
            txtSodt.Enabled = false;
            txtDiachi.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            pbPicGV.Enabled = false;
            dgvData.Enabled = true;

            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void ClearForm()
        {
            txtMaGv.Clear();
            txtHoten.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtSodt.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            pbPicGV.Image = null;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaGv.Text) ||
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
        private void pbPicGV_Click(object sender, EventArgs e)
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
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            pbPicGV.Enabled = true;
            btnSave.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();

            string tiento = "GV"; //tiền tố
            txtMaGv.Text = QlGiaoVien.CreateNewTeacherId(tiento);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtHoten.Enabled = true;
            txtEmail.Enabled = true;
            txtSodt.Enabled = true;
            txtDiachi.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            pbPicGV.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvData.CurrentRow != null)
            {
                try
                {
                    btnUpdate.Enabled = true;

                    txtMaGv.Text = dgvData.CurrentRow.Cells["Mã Giảng Viên"]?.Value?.ToString() ?? string.Empty;
                    txtHoten.Text = dgvData.CurrentRow.Cells["Tên Giảng Viên"]?.Value?.ToString() ?? string.Empty;
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
                            pbPicGV.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbPicGV.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                DTO_CBQL_GV Giaovien = new DTO_CBQL_GV(txtMaGv.Text, txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                if (QlGiaoVien.ThemGiaoVien(Giaovien, out message))
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

                if (!checkEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_CBQL_GV Giaovien = new DTO_CBQL_GV(txtMaGv.Text, txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);


                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật giảng viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlGiaoVien.CapNhatGiaoVien(Giaovien, out message))
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

            LoadDsGV();
        }
    }
}
