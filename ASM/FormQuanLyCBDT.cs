﻿using BUS_QL;
using DTO_QL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormQuanLyCBDT : Form
    {
        BUS_CBQL QlCBDT = new BUS_CBQL();
        private byte[] image;
        bool isAdding = false;
        public FormQuanLyCBDT()
        {
            InitializeComponent();
            LoadDsCBDT();
            LoadDsPhong();
            LockControl();

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsCBDT()
        {
            dgvData.DataSource = QlCBDT.LoadDsCBDT();
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvData.Columns["Hinh"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void LoadDsPhong()
        {
            cbPhongBan.DataSource = QlCBDT.LoadDsPhong();
            cbPhongBan.DisplayMember = "TenPhong";
            cbPhongBan.ValueMember = "IDPhong";
        }
        private void LoadPictureBox()
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        if (pbPicCBDT.Image != null)
                        {
                            pbPicCBDT.Image.Dispose();
                        }

                        pbPicCBDT.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (pbPicCBDT.Image != null)
                {
                    pbPicCBDT.Image.Dispose();
                    pbPicCBDT.Image = null;
                }
            }
        }
        public void LockControl()
        {
            txtMaCBDT.Enabled = false;
            txtHoten.Enabled = false;
            txtEmail.Enabled = false;
            txtSodt.Enabled = false;
            txtDiachi.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            pbPicCBDT.Enabled = false;
            dgvData.Enabled = true;

            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void ClearForm()
        {
            txtMaCBDT.Clear();
            txtHoten.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtSodt.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            pbPicCBDT.Image = null;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaCBDT.Text) ||
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
        private void pbPicCBDT_Click(object sender, EventArgs e)
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
            pbPicCBDT.Enabled = true;
            btnSave.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();

            string tiento = "DT"; //tiền tố
            txtMaCBDT.Text = QlCBDT.CreateNewCBDTId(tiento);
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
            pbPicCBDT.Enabled = true;
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

                    txtMaCBDT.Text = dgvData.CurrentRow.Cells["IDCBDT"]?.Value?.ToString() ?? string.Empty;
                    cbPhongBan.SelectedValue = dgvData.CurrentRow.Cells["IDPhong"]?.Value?.ToString() ?? string.Empty;
                    txtHoten.Text = dgvData.CurrentRow.Cells["TenCBDT"]?.Value?.ToString() ?? string.Empty;
                    txtEmail.Text = dgvData.CurrentRow.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                    txtSodt.Text = dgvData.CurrentRow.Cells["SoDT"]?.Value?.ToString() ?? string.Empty;
                    txtDiachi.Text = dgvData.CurrentRow.Cells["Diachi"]?.Value?.ToString() ?? string.Empty;

                    string gioiTinh = dgvData.CurrentRow.Cells["Gioitinh"]?.Value?.ToString();
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

                    image = dgvData.CurrentRow.Cells["Hinh"]?.Value as byte[];
                    if (image != null && image.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(image))
                        {
                            pbPicCBDT.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbPicCBDT.Image = null;
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

                DTO_CBQL_CBDT CBDT = new DTO_CBQL_CBDT(txtMaCBDT.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                if (QlCBDT.ThemCBDT(CBDT, out message))
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

                DTO_CBQL_CBDT CBDT = new DTO_CBQL_CBDT(txtMaCBDT.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);


                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật cán bộ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlCBDT.CapNhatCBDT(CBDT, out message))
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
            LoadDsCBDT();
            LoadDsPhong();
        }
    }
}
