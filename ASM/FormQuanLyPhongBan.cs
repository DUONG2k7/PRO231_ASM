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
using static System.Net.Mime.MediaTypeNames;

namespace ASM
{
    public partial class FormQuanLyPhongBan : Form
    {
        BUS_CBQL QlPB = new BUS_CBQL();
        bool isAdding = false;
        public FormQuanLyPhongBan()
        {
            InitializeComponent();
            LoadDsPhong();
            LoadLoaiPhong();
            LockControl();

            if (dgvData.Columns.Contains("IDRole"))
            {
                dgvData.Columns["IDRole"].Visible = false;
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsPhong()
        {
            dgvData.DataSource = QlPB.LoadDsPhongBan();
        }
        public void LoadLoaiPhong()
        {
            cbLoaiPhong.DataSource = QlPB.LoadLoaiPhong();
            cbLoaiPhong.DisplayMember = "Role";
            cbLoaiPhong.ValueMember = "IDRole";
        }
        public void LockControl()
        {
            txtHoten.Enabled = false;
            cbLoaiPhong.Enabled = false;
            dgvData.Enabled = true;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnXem.Enabled = false;
        }
        public void ClearForm()
        {
            txtHoten.Clear();
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtHoten.Enabled = true;
            cbLoaiPhong.Enabled = true;

            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtHoten.Enabled = true;
            cbLoaiPhong.Enabled = true;

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
                    btnXem.Enabled = true;

                    txtHoten.Text = dgvData.CurrentRow.Cells["Tên Phòng"]?.Value?.ToString() ?? string.Empty;
                    cbLoaiPhong.SelectedValue = dgvData.CurrentRow.Cells["IDRole"]?.Value?.ToString();
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

                if (QlPB.ThemPhong(txtHoten.Text, cbLoaiPhong.SelectedValue.ToString(), out message))
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

                int IDPhong;
                int.TryParse(dgvData.CurrentRow.Cells["ID Phòng"].Value?.ToString(), out IDPhong);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật phòng ban này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlPB.CapNhatPhong(IDPhong, txtHoten.Text, cbLoaiPhong.SelectedValue.ToString(), out message))
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
            LoadDsPhong();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            int IDPhong = 0;
            int.TryParse(dgvData.CurrentRow.Cells["ID Phòng"].Value?.ToString(), out IDPhong);

            FormXemNvFormPhongBan xemNvFormPhongBan = new FormXemNvFormPhongBan(IDPhong);
            xemNvFormPhongBan.ShowDialog();
        }
    }
}
