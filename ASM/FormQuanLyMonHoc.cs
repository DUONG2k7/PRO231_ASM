using BUS_QL;
using DTO_QL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormQuanLyMonHoc : Form
    {
        BUS_CBDT QlMonhoc = new BUS_CBDT();
        bool IsAdding = false;
        public FormQuanLyMonHoc()
        {
            InitializeComponent();
            LoadDsMonHoc();
            LockControl();

            dgvDsMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsMonHoc()
        {
            dgvDsMonHoc.DataSource = QlMonhoc.LoadDsMonHocFormMonHoc();
        }
        public void LockControl()
        {
            txtTenMon.Enabled = false;
            txtSotiet.Enabled = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            dgvDsMonHoc.Enabled = true;
        }
        public void ClearForm()
        {
            txtTenMon.Clear();
            txtSotiet.Clear();
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtSotiet.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsAdding = true;
            txtTenMon.Enabled = true;
            txtSotiet.Enabled = true;
            dgvDsMonHoc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsAdding = false;
            txtTenMon.Enabled = true;
            txtSotiet.Enabled = true;
            dgvDsMonHoc.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
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
                DTO_CBDT_MONHOC MonHoc = new DTO_CBDT_MONHOC(txtTenMon.Text, Convert.ToInt32(txtSotiet.Text));
                if (QlMonhoc.ThemMonHoc(MonHoc, out message))
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
                int idmonhoc;
                int.TryParse(dgvDsMonHoc.CurrentRow.Cells["IDMonHoc"].Value?.ToString(), out idmonhoc);

                DTO_CBDT_MONHOC MonHoc = new DTO_CBDT_MONHOC(idmonhoc, txtTenMon.Text, Convert.ToInt32(txtSotiet.Text));
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật kỳ học này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlMonhoc.SuaMonHoc(MonHoc, out message))
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
            LoadDsMonHoc();
        }
        private void dgvDsMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            if (e.RowIndex >= 0 && dgvDsMonHoc.CurrentRow != null)
            {
                try
                {
                    txtTenMon.Text = dgvDsMonHoc.CurrentRow.Cells["Tên Môn Học"]?.Value?.ToString() ?? string.Empty;
                    txtSotiet.Text = dgvDsMonHoc.CurrentRow.Cells["Số Tiết"]?.Value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
