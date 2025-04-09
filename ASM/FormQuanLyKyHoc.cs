using BUS_QL;
using DTO_QL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormQuanLyKyHoc : Form
    {
        BUS_CBDT Qlkyhoc = new BUS_CBDT();
        bool IsAdding = false;
        public FormQuanLyKyHoc()
        {
            InitializeComponent();
            LoadDsKyHoc();
            LoadDsKyHocMonHoc();
            LoadDsKyHocFormChiDinhMonHoc();
            LoadDsMH();
            LockControl();

            cbChonKyHoc.SelectedIndexChanged += cbChonKyHoc_SelectedIndexChanged;

            if (dgvDsKyHocMonHoc.Columns.Contains("IDKyHoc"))
            {
                dgvDsKyHocMonHoc.Columns["IDKyHoc"].Visible = false;
            }
            if (dgvDsKyHocMonHoc.Columns.Contains("IDMonHoc"))
            {
                dgvDsKyHocMonHoc.Columns["IDMonHoc"].Visible = false;
            }

            dgvDsKyHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsKyHocMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiDinhMHtoKyhoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsKyHoc()
        {
            dgvDsKyHoc.DataSource = Qlkyhoc.LoadDsKyHoc();
        }
        public void LoadDsKyHocMonHoc()
        {
            dgvDsKyHocMonHoc.DataSource = Qlkyhoc.LoadDsKyHocMonHoc();
        }
        public void LoadDsKyHocFormChiDinhMonHoc()
        {
            cbChonKyHoc.DataSource = Qlkyhoc.LoadDsKyHocFormChiDinhMonHoc();
            cbChonKyHoc.DisplayMember = "TenKy";
            cbChonKyHoc.ValueMember = "IDKyHoc";
        }
        private void LoadDsMH()
        {
            dgvChiDinhMHtoKyhoc.DataSource = Qlkyhoc.LoadDsMHFormChiDinhMonHoc(Convert.ToInt32(cbChonKyHoc.SelectedValue));
        }
        private void cbChonKyHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDsMH();
        }
        public void LockControl()
        {
            txtTenKy.Enabled = false;
            dtpNamBatDau.Enabled = false;
            dtpNamKetThuc.Enabled = false;
            cbChonKyHoc.Enabled = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnUseKyHoc.Enabled = false;
            dgvDsKyHoc.Enabled = true;

            btnNew.Enabled = true;
            btnUpdateSetMHtoKyHoc.Enabled = false;
            btnSaveChiDinhMHtoKyhoc.Enabled = false;
            btnLockOrUnlockMonHoc.Enabled = false;
            dgvDsKyHocMonHoc.Enabled = true;
        }
        public void ClearForm()
        {
            txtTenKy.Clear();
            cbChonKyHoc.SelectedIndex = -1;

            dtpNamBatDau.Checked = false;
            dtpNamBatDau.ResetText();
            dtpNamKetThuc.Checked = false;
            dtpNamKetThuc.ResetText();
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsAdding = true;
            txtTenKy.Enabled = true;
            dtpNamBatDau.Enabled = true;
            dtpNamKetThuc.Enabled = true;
            dgvDsKyHoc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnUseKyHoc.Enabled = false;

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsAdding = false;
            txtTenKy.Enabled = true;
            dtpNamBatDau.Enabled = true;
            dtpNamKetThuc.Enabled = true;
            dgvDsKyHoc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnUseKyHoc.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            string message;
            if (IsAdding)
            {
                DTO_CBDT_KYHOC KyHoc = new DTO_CBDT_KYHOC(txtTenKy.Text, dtpNamBatDau.Value, dtpNamKetThuc.Value, false);
                if (Qlkyhoc.ThemKyHoc(KyHoc, out message))
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
                int idkyhoc;
                int.TryParse(dgvDsKyHoc.CurrentRow.Cells["IDKyHoc"].Value?.ToString(), out idkyhoc);

                DTO_CBDT_KYHOC KyHoc = new DTO_CBDT_KYHOC(idkyhoc, txtTenKy.Text, dtpNamBatDau.Value, dtpNamKetThuc.Value);
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật kỳ học này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (Qlkyhoc.SuaKyHoc(KyHoc, out message))
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
            LoadDsKyHoc();
            LoadDsKyHocFormChiDinhMonHoc();
        }
        private void btnUseKyHoc_Click(object sender, EventArgs e)
        {
            string message;
            int idkyhoc;
            int.TryParse(dgvDsKyHoc.CurrentRow.Cells["IDKyHoc"].Value?.ToString(), out idkyhoc);

            DTO_CBDT_KYHOC KyHoc = new DTO_CBDT_KYHOC(idkyhoc);
            if (Qlkyhoc.SudungKyHoc(KyHoc, out message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ClearForm();
            LockControl();
            LoadDsKyHoc();
        }
        private void dgvDsKyHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnUseKyHoc.Enabled = true;
            if (e.RowIndex >= 0 && dgvDsKyHoc.CurrentRow != null)
            {
                try
                {
                    txtTenKy.Text = dgvDsKyHoc.CurrentRow.Cells["Học Kỳ"]?.Value?.ToString() ?? string.Empty;
                    dtpNamBatDau.Value = Convert.ToDateTime(dgvDsKyHoc.CurrentRow.Cells["Năm Bắt Đầu"].Value);
                    dtpNamKetThuc.Value = Convert.ToDateTime(dgvDsKyHoc.CurrentRow.Cells["Năm Kết Thúc"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            IsAdding = true;
            cbChonKyHoc.Enabled = true;
            dgvChiDinhMHtoKyhoc.Enabled = true;

            btnNew.Enabled = false;
            btnUpdateSetMHtoKyHoc.Enabled = false;
            btnSaveChiDinhMHtoKyhoc.Enabled = true;
            btnLockOrUnlockMonHoc.Enabled = false;

            ClearForm();
        }

        private void btnUpdateSetMHtoKyHoc_Click(object sender, EventArgs e)
        {
            IsAdding = false;
            cbChonKyHoc.Enabled = false;
            dgvChiDinhMHtoKyhoc.Enabled = true;

            btnNew.Enabled = false;
            btnUpdateSetMHtoKyHoc.Enabled = false;
            btnSaveChiDinhMHtoKyhoc.Enabled = true;
            btnLockOrUnlockMonHoc.Enabled = false;

            if (Qlkyhoc.SuaChiDinhMHtoKyHoc(Convert.ToInt32(cbChonKyHoc.SelectedValue), out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsKyHocMonHoc();
                LoadDsMH();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveChiDinhMHtoKyhoc_Click(object sender, EventArgs e)
        {
            if (cbChonKyHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một kỳ học trước khi chỉ định môn học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKyHoc = Convert.ToInt32(cbChonKyHoc.SelectedValue);
            bool hasChecked = false;
            int successCount = 0;
            List<string> errorMessages = new List<string>();

            foreach (DataGridViewRow row in dgvChiDinhMHtoKyhoc.Rows)
            {
                if (row.Cells["CheckColumn"] is DataGridViewCheckBoxCell cell && Convert.ToBoolean(cell.Value))
                {
                    hasChecked = true;
                    int idMonHoc = Convert.ToInt32(row.Cells["Mã Môn"].Value);

                    if (Qlkyhoc.ThemChiDinhMHtoKyHoc(idKyHoc, idMonHoc, true, out string message))
                    {
                        successCount++;
                    }
                    else
                    {
                        errorMessages.Add($"Môn học ID {idMonHoc}: {message}"); // Lưu lỗi
                    }
                }
            }

            if (!hasChecked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học để chỉ định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (successCount > 0)
                {
                    MessageBox.Show($"Đã chỉ định thành công {successCount} môn học vào kỳ học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LockControl();
                    LoadDsKyHocMonHoc();
                    LoadDsMH();
                }

                if (errorMessages.Count > 0)
                {
                    MessageBox.Show("Có lỗi xảy ra với các môn học sau:\n" + string.Join("\n", errorMessages), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLockOrUnlockMonHoc_Click(object sender, EventArgs e)
        {
            string message;
            int idkyhoc;
            int.TryParse(dgvDsKyHocMonHoc.CurrentRow.Cells["IDKyHoc"].Value?.ToString(), out idkyhoc);
            int idmonhoc;
            int.TryParse(dgvDsKyHocMonHoc.CurrentRow.Cells["IDMonHoc"].Value?.ToString(), out idmonhoc);

            if (Qlkyhoc.KhoaOrMoKhoaMonHoc(idkyhoc, idmonhoc, out message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ClearForm();
            LockControl();
            LoadDsKyHocMonHoc();
            LoadDsMH();
        }

        private void dgvDsKyHocMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdateSetMHtoKyHoc.Enabled = true;
            btnLockOrUnlockMonHoc.Enabled = true;
            if (e.RowIndex >= 0 && dgvDsKyHocMonHoc.CurrentRow != null)
            {
                try
                {
                    cbChonKyHoc.SelectedValue = dgvDsKyHocMonHoc.CurrentRow.Cells["Mã Kỳ"]?.Value?.ToString() ?? string.Empty;
                    dtpNamBatDau.Value = Convert.ToDateTime(dgvDsKyHoc.CurrentRow.Cells["Năm Bắt Đầu"].Value);
                    dtpNamKetThuc.Value = Convert.ToDateTime(dgvDsKyHoc.CurrentRow.Cells["Năm Kết Thúc"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormQuanLyKyHoc_Load(object sender, EventArgs e)
        {
            tpTaoMonHoc.Controls.Clear();
            FormQuanLyMonHoc QlGV1 = new FormQuanLyMonHoc();
            QlGV1.TopLevel = false;
            QlGV1.FormBorderStyle = FormBorderStyle.None;
            QlGV1.Dock = DockStyle.Fill;
            tpTaoMonHoc.Controls.Add(QlGV1);
            QlGV1.Show();
        }
    }
}
