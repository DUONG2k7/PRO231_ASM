using BUS_QL;
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
    public partial class FormQuanLyCongViec : Form
    {
        BUS_CBDT QlViec = new BUS_CBDT();
        DateTime? Nambatdau;
        public FormQuanLyCongViec(int IDKYHOC)
        {
            InitializeComponent();
            LoadDsMonHocGV();
            LoadDsLopHocGV();
            LoadDsMonHocFormChiDinhGV();
            LoadDsLopHocFormChiDinhGV();
            LoadGiangVienList();
            LoadGiangVienFormChiDinhLop();
            LockControl();

            cbChonMonHoc.SelectedIndexChanged += cbChonMonHoc_SelectedIndexChanged;
            cbLop.SelectedIndexChanged += cbLop_SelectedIndexChanged;

            txtKyhoc.Text = IDKYHOC.ToString();
            txtKyhocFormGVCLass.Text = IDKYHOC.ToString();

            Nambatdau = QlViec.LayNamBatDauKyHoc() ?? DateTime.Now;
            dtpNgayChotViecKM.Value = Nambatdau.Value.AddDays(-28);
            dtpNgayLopGV.Value = Nambatdau.Value.AddDays(-28);

            if (dgvDsMonHocGV.Columns.Contains("IDKyHoc"))
            {
                dgvDsMonHocGV.Columns["IDKyHoc"].Visible = false;
            }
            if (dgvDsMonHocGV.Columns.Contains("IDMonHoc"))
            {
                dgvDsMonHocGV.Columns["IDMonHoc"].Visible = false;
            }
            if (dgvDsGvClass.Columns.Contains("IDKyHoc"))
            {
                dgvDsGvClass.Columns["IDKyHoc"].Visible = false;
            }
            if (dgvDsGvClass.Columns.Contains("IDLop"))
            {
                dgvDsGvClass.Columns["IDLop"].Visible = false;
            }

            dgvDsMonHocGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiDinhGVtoMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsGvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsGvFormGvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsMonHocGV()
        {
            dgvDsMonHocGV.DataSource = QlViec.LoadDsMonHocGV();
        }
        public void LoadDsLopHocGV()
        {
            dgvDsGvClass.DataSource = QlViec.LoadDsLopHocGV();
        }
        public void LoadDsMonHocFormChiDinhGV()
        {
            cbChonMonHoc.DataSource = QlViec.LoadDsMonHocFormChiDinhGV();
            cbChonMonHoc.DisplayMember = "TenMon";
            cbChonMonHoc.ValueMember = "IDMonHoc";
        }
        public void LoadDsLopHocFormChiDinhGV()
        {
            cbLop.DataSource = QlViec.LoadDsLopHocFormChiDinhGV();
            cbLop.DisplayMember = "ClassName";
            cbLop.ValueMember = "IDLop";
        }
        private void LoadGiangVienList()
        {
            if (cbChonMonHoc.SelectedValue != null && int.TryParse(cbChonMonHoc.SelectedValue.ToString(), out int idMonHoc) && int.TryParse(txtKyhoc.Text, out int idKYHOC))
            {
                dgvChiDinhGVtoMH.DataSource = QlViec.LoadDsGVFormChiDinhGV(idMonHoc, idKYHOC);
            }
        }
        private void LoadGiangVienFormChiDinhLop()
        {
            if (cbLop.SelectedValue != null && int.TryParse(txtKyhoc.Text, out int idKYHOC))
            {
                string idlop = cbLop.SelectedValue.ToString();
                dgvDsGvFormGvClass.DataSource = QlViec.LoadDsGVFormChiDinhLop(idlop, idKYHOC);
            }
        }
        private void cbChonMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGiangVienList();
        }
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGiangVienFormChiDinhLop();
        }
        public void LockControl()
        {
            cbChonMonHoc.Enabled = false;
            cbLop.Enabled = false;

            btnNew.Enabled = true;
            btnUpdateSetGVtoMH.Enabled = false;
            btnSaveChiDinhGVtoMH.Enabled = false;
            dtpNgayChotViecKM.Enabled = false;
            dgvDsMonHocGV.Enabled = true;
            dgvChiDinhGVtoMH.Enabled = true;

            btnNewGvToClass.Enabled = true;
            btnUpdateGvtoClass.Enabled = false;
            btnSaveGvtoClass.Enabled = false;
            dtpNgayLopGV.Enabled = false;
            dgvDsGvClass.Enabled = true;
            dgvDsGvFormGvClass.Enabled = true;
        }
        public void ClearForm()
        {
            cbChonMonHoc.SelectedIndex = -1;
            cbLop.SelectedIndex = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbChonMonHoc.Enabled = true;
            dgvDsMonHocGV.Enabled = false;
            dtpNgayChotViecKM.Enabled = true;
            dgvChiDinhGVtoMH.Enabled = true;

            btnNew.Enabled = false;
            btnUpdateSetGVtoMH.Enabled = false;
            btnSaveChiDinhGVtoMH.Enabled = true;

            ClearForm();
        }
        private void btnNewGvToClass_Click(object sender, EventArgs e)
        {
            cbLop.Enabled = true;
            dgvDsGvClass.Enabled = false;
            dtpNgayLopGV.Enabled = true;
            dgvDsGvFormGvClass.Enabled = true;

            btnNewGvToClass.Enabled = false;
            btnUpdateGvtoClass.Enabled = false;
            btnSaveGvtoClass.Enabled = true;

            ClearForm();
        }
        private void btnUpdateSetGVtoMH_Click(object sender, EventArgs e)
        {
            cbChonMonHoc.Enabled = false;
            dtpNgayChotViecKM.Enabled = true;
            dgvDsMonHocGV.Enabled = false;
            dgvChiDinhGVtoMH.Enabled = true;

            btnNew.Enabled = false;
            btnUpdateSetGVtoMH.Enabled = false;
            btnSaveChiDinhGVtoMH.Enabled = true;

            if (QlViec.SuaChiDinhGVtoMonHoc(Convert.ToInt32(cbChonMonHoc.SelectedValue), out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsMonHocGV();
                LoadGiangVienList();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnUpdateGvtoClass_Click(object sender, EventArgs e)
        {
            cbLop.Enabled = false;
            dtpNgayLopGV.Enabled = true;
            dgvDsGvClass.Enabled = false;
            dgvDsGvFormGvClass.Enabled = true;

            btnNewGvToClass.Enabled = false;
            btnUpdateGvtoClass.Enabled = false;
            btnSaveGvtoClass.Enabled = true;

            string idlop = cbLop.SelectedValue.ToString();
            if (QlViec.SuaChiDinhGVtoLopHoc(idlop, out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsLopHocGV();
                LoadGiangVienFormChiDinhLop();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSaveChiDinhGVtoMH_Click(object sender, EventArgs e)
        {
            if (cbChonMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một môn học trước khi chỉ định giáo viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKyhoc = Convert.ToInt32(txtKyhoc.Text);
            int idMonHoc = Convert.ToInt32(cbChonMonHoc.SelectedValue);
            bool hasChecked = false;
            int successCount = 0;
            List<string> errorMessages = new List<string>();

            foreach (DataGridViewRow row in dgvChiDinhGVtoMH.Rows)
            {
                if (row.Cells["CheckColumn"] is DataGridViewCheckBoxCell cell && Convert.ToBoolean(cell.Value))
                {
                    hasChecked = true;
                    string idGV = row.Cells["IDGV"].Value.ToString();

                    if (QlViec.ThemChiDinhGVtoMonHoc(idKyhoc, idMonHoc, idGV, dtpNgayChotViecKM.Value, out string message))
                    {
                        successCount++;
                    }
                    else
                    {
                        errorMessages.Add($"GV ID {idGV}: {message}"); // Lưu lỗi
                    }
                }
            }

            if (!hasChecked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một giáo viên để chỉ định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (successCount > 0)
                {
                    MessageBox.Show($"Đã chỉ định thành công {successCount} giáo viên vào môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LockControl();
                    LoadGiangVienList();
                    LoadDsMonHocGV();
                }

                if (errorMessages.Count > 0)
                {
                    MessageBox.Show("Có lỗi xảy ra với các giáo viên sau:\n" + string.Join("\n", errorMessages), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSaveGvtoClass_Click(object sender, EventArgs e)
        {
            if (cbLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một môn học trước khi chỉ định giáo viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKyhoc = Convert.ToInt32(txtKyhoc.Text);
            string idlop = cbLop.SelectedValue.ToString();
            bool hasChecked = false;
            int successCount = 0;
            List<string> errorMessages = new List<string>();

            foreach (DataGridViewRow row in dgvDsGvFormGvClass.Rows)
            {
                if (row.Cells["CCo"] is DataGridViewCheckBoxCell cell && Convert.ToBoolean(cell.Value))
                {
                    hasChecked = true;
                    string idGV = row.Cells["IDGV"].Value.ToString();

                    if (QlViec.ThemChiDinhGVtoLopHoc(idKyhoc, idlop, idGV, dtpNgayLopGV.Value, out string message))
                    {
                        successCount++;
                    }
                    else
                    {
                        errorMessages.Add($"GV ID {idGV}: {message}"); // Lưu lỗi
                    }
                }
            }

            if (!hasChecked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một giáo viên để chỉ định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (successCount > 0)
                {
                    MessageBox.Show($"Đã chỉ định thành công {successCount} giáo viên vào môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LockControl();
                    LoadDsLopHocGV();
                    LoadGiangVienFormChiDinhLop();
                }

                if (errorMessages.Count > 0)
                {
                    MessageBox.Show("Có lỗi xảy ra với các giáo viên sau:\n" + string.Join("\n", errorMessages), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvDsMonHocGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdateSetGVtoMH.Enabled = true;
            if (e.RowIndex >= 0 && dgvDsMonHocGV.CurrentRow != null)
            {
                try
                {
                    cbChonMonHoc.SelectedValue = dgvDsMonHocGV.CurrentRow.Cells["Mã Môn"]?.Value?.ToString() ?? string.Empty;
                    dtpNgayChotViecKM.Value = Convert.ToDateTime(dgvDsMonHocGV.CurrentRow.Cells["Ngày Chốt Việc"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDsGvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdateGvtoClass.Enabled = true;
            if (e.RowIndex >= 0 && dgvDsGvClass.CurrentRow != null)
            {
                try
                {
                    cbLop.SelectedValue = dgvDsGvClass.CurrentRow.Cells["Mã Lớp"]?.Value?.ToString() ?? string.Empty;
                    dtpNgayLopGV.Value = Convert.ToDateTime(dgvDsGvClass.CurrentRow.Cells["Ngày Chốt Lớp"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
