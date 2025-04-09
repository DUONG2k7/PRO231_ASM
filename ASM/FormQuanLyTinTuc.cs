using BUS_QL;
using DTO_QL;
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

namespace ASM
{
    public partial class FormQuanLyTinTuc : Form
    {
        BUS_IT QlTinTuc = new BUS_IT();
        private byte[] image;
        bool isAdding = false;
        public FormQuanLyTinTuc()
        {
            InitializeComponent();
            LoadDsTinTuc();
            LockControl();

            dgvDataTinTuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsTinTuc()
        {
            dgvDataTinTuc.DataSource = QlTinTuc.LoadDsTinTuc();
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvDataTinTuc.Columns["Hình"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void LoadPictureBox()
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        if (pbPic.Image != null)
                        {
                            pbPic.Image.Dispose();
                        }

                        pbPic.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (pbPic.Image != null)
                {
                    pbPic.Image.Dispose();
                    pbPic.Image = null;
                }
            }
        }
        public void LockControl()
        {
            txtTieuDe.Enabled = false;
            txtNoiDung.Enabled = false;
            dtpNgayDang.Enabled = false;
            pbPic.Enabled = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDuyet.Enabled = false;
            btnLoU.Enabled = false;
            dgvDataTinTuc.Enabled = true;
        }
        public void ClearForm()
        {
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            dtpNgayDang.ResetText();
            pbPic.Image = null;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (image == null || image.Length < 1)
            {
                MessageBox.Show("Vui lòng Chọn lại ảnh hoặc chọn ảnh mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void pbPic_Click(object sender, EventArgs e)
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtTieuDe.Enabled = true;
            txtNoiDung.Enabled = true;
            dtpNgayDang.Enabled = true;
            pbPic.Enabled = true;
            dgvDataTinTuc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDuyet.Enabled = true;
            btnLoU.Enabled = false;

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtTieuDe.Enabled = true;
            txtNoiDung.Enabled = true;
            dtpNgayDang.Enabled = true;
            pbPic.Enabled = true;
            dgvDataTinTuc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDuyet.Enabled = true;
            btnLoU.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            string message;
            if (isAdding)
            {
                DTO_IT_TINTUC Tintuc = new DTO_IT_TINTUC(txtTieuDe.Text, txtNoiDung.Text, dtpNgayDang.Value, image, true);
                if (QlTinTuc.ThemTinTuc(Tintuc, out message))
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
                int.TryParse(dgvDataTinTuc.CurrentRow.Cells["IDTin"].Value?.ToString(), out int IDTin);

                DTO_IT_TINTUC Tintuc = new DTO_IT_TINTUC(IDTin, txtTieuDe.Text, txtNoiDung.Text, dtpNgayDang.Value, image);
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật tin tức này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlTinTuc.CapNhatTinTuc(Tintuc, out message))
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
            LoadDsTinTuc();
        }

        private void btnLoU_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(dgvDataTinTuc.CurrentRow.Cells["Mã Tin"].Value?.ToString(), out int IDTin);
                if (QlTinTuc.LockOrUnlockNews(IDTin))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LockControl();
                    LoadDsTinTuc();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tin tức để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDataTinTuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDataTinTuc.CurrentRow != null)
            {
                try
                {
                    btnUpdate.Enabled = true;
                    btnLoU.Enabled = true;

                    txtTieuDe.Text = dgvDataTinTuc.CurrentRow.Cells["Tiêu Đề"]?.Value?.ToString() ?? string.Empty;
                    txtNoiDung.Text = dgvDataTinTuc.CurrentRow.Cells["Nội Dung"]?.Value?.ToString() ?? string.Empty;

                    dtpNgayDang.Value = Convert.ToDateTime(dgvDataTinTuc.CurrentRow.Cells["Ngày Đăng"].Value);

                    image = dgvDataTinTuc.CurrentRow.Cells["Hình"]?.Value as byte[];
                    if (image != null && image.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(image))
                        {
                            pbPic.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbPic.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
