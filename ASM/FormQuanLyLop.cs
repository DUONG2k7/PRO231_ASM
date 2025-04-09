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
using static System.Net.Mime.MediaTypeNames;

namespace ASM
{
    public partial class FormQuanLyLop : Form
    {
        BUS_CBDT QlLop = new BUS_CBDT();
        bool isAdding = false;
        public FormQuanLyLop()
        {
            InitializeComponent();
            LoadDsLop();
            LoadsaukhidoiTrangThai();

            LockControl();

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LockControl()
        {
            txtMaLop.Enabled = false;
            txtTenlop.Enabled = false;

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnLoU.Enabled = false;
        }
        public void ClearForm()
        {
            txtMaLop.Clear();
            txtTenlop.Clear();
        }
        public void LoadsaukhidoiTrangThai()
        {
            if (dgvData.CurrentRow != null)
            {
                string trangThai = dgvData.CurrentRow.Cells["Trạng Thái"]?.Value?.ToString() ?? string.Empty;

                if (trangThai == "Khóa")
                {
                    btnNew.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnNew.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtTenlop.Text) ||
                !rdbBuoiSang.Checked && !rdbBuoiChieu.Checked)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        public void LoadDsLop()
        {
            dgvData.DataSource = QlLop.LoadDsLop();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtTenlop.Enabled = true;
            btnSave.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnLoU.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();

            string tiento = "L"; //tiền tố
            txtMaLop.Text = QlLop.CreateNewClassId(tiento);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtTenlop.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnLoU.Enabled = false;
            dgvData.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text;

            if (QlLop.KtGVDaChiDinh(maLop))
            {
                MessageBox.Show("Không thể xóa lớp vì đã có giáo viên được chỉ định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult s = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (s == DialogResult.Yes)
            {
                try
                {
                    if (QlLop.XoaLop(maLop))
                    {
                        MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadDsLop();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                    txtMaLop.Text = dgvData.CurrentRow.Cells["Mã Lớp"]?.Value?.ToString() ?? string.Empty;
                    txtTenlop.Text = dgvData.CurrentRow.Cells["Tên Lớp"]?.Value?.ToString() ?? string.Empty;

                    btnLoU.Enabled = true;

                    LoadsaukhidoiTrangThai();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLoU_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtMaLop.Text;

                if (QlLop.LockOrUnlockClass(maLop))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadDsLop();
                    LoadsaukhidoiTrangThai();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string messsage;
            if (isAdding)
            {
                if (!CheckInput())
                {
                    return;
                }

                if (QlLop.KtLopDaTonTai(txtMaLop.Text))
                {
                    MessageBox.Show("Mã lớp đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_CBDT_CLASS lop = new DTO_CBDT_CLASS(txtMaLop.Text, txtTenlop.Text, rdbBuoiSang.Checked);
                if (QlLop.ThemLop(lop, out messsage))
                {
                    MessageBox.Show(messsage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(messsage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!CheckInput())
                {
                    return;
                }

                DTO_CBDT_CLASS lop = new DTO_CBDT_CLASS(txtMaLop.Text, txtTenlop.Text, rdbBuoiSang.Checked);
                
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật lớp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlLop.CapNhatLop(lop, out messsage))
                    {
                        MessageBox.Show(messsage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(messsage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            ClearForm();
            LockControl();

            LoadDsLop();

            btnNew.Enabled = true;
            btnUpdate.Enabled = true;
            dgvData.Enabled = true;
        }

    }
}
