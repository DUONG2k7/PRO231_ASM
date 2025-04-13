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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormQuanLyIT : Form
    {
        BUS_CBQL QlIT = new BUS_CBQL();
        private byte[] image;
        bool isAdding = false;
        public FormQuanLyIT()
        {
            InitializeComponent();
            LoadDsLocDuLieu();
            LoadDsPhong();
            LoadDsNhanSu();
            LockControl();

            if (dgvData.Columns.Contains("Hình"))
            {
                dgvData.Columns["Hình"].Visible = false;
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsNhanSu()
        {
            int idPhong = 0;
            
            if (cbLocDuLieu.SelectedItem is DataRowView drv)
            {
                idPhong = Convert.ToInt32(drv["IDPhong"]);
            }

            DataTable dtRole = QlIT.GetRoleFromIDPhong(idPhong);
            if (dtRole.Rows.Count == 0)
            {
                dgvData.DataSource = QlIT.GetListStaffWithNOPhongBan();
                return;
            }

            string idRole = dtRole.Rows[0]["IDRole"].ToString().Trim();
            switch (idRole)
            {
                case "R01":
                    dgvData.DataSource = QlIT.LoadDsIT(idPhong);
                    break;
                case "R02":
                    dgvData.DataSource = QlIT.LoadDsCBDT(idPhong);
                    break;
                case "R03":
                    dgvData.DataSource = QlIT.LoadDsCBQL(idPhong);
                    break;
            }

            if (dgvData.Columns.Contains("Mã Phòng"))
            {
                dgvData.Columns["Mã Phòng"].Visible = false;
            }
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvData.Columns["Hình"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void LoadDsLocDuLieu()
        {
            DataTable dtPhong = QlIT.LoadDsPhong();
            DataRow row = dtPhong.NewRow();
            row["IDPhong"] = 0;
            row["Tên Phòng"] = "Chưa có phòng ban";
            dtPhong.Rows.InsertAt(row, 0);

            cbLocDuLieu.DataSource = dtPhong;
            cbLocDuLieu.DisplayMember = "Tên Phòng";
            cbLocDuLieu.ValueMember = "IDPhong";
        }
        public void LoadDsPhong()
        {
            DataTable dtPhong = QlIT.LoadDsPhong();
            DataRow row = dtPhong.NewRow();
            row["IDPhong"] = 0;
            row["Tên Phòng"] = "Chưa có phòng ban";
            dtPhong.Rows.InsertAt(row, 0);

            cbPhongBan.DataSource = dtPhong;
            cbPhongBan.DisplayMember = "Tên Phòng";
            cbPhongBan.ValueMember = "IDPhong";
        }
        private void cbLocDuLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDsNhanSu();
        }
        private void cbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaoID();
        }
        public void TaoID()
        {
            if (cbPhongBan.SelectedValue == null)
            {
                txtID.Text = "";
                return;
            }

            int idPhong = 0;

            if (cbPhongBan.SelectedItem is DataRowView drv)
            {
                idPhong = Convert.ToInt32(drv["IDPhong"]);
            }
            else if (int.TryParse(cbPhongBan.SelectedValue.ToString(), out int parsedId))
            {
                idPhong = parsedId;
            }

            DataTable dtRole = QlIT.GetRoleFromIDPhong(idPhong);
            if (dtRole.Rows.Count == 0)
            {
                txtID.Text = "";
                txtID.PlaceholderText = "Chọn phòng ban khác";
                return;
            }

            string idRole = dtRole.Rows[0]["IDRole"].ToString().Trim();

            switch (idRole)
            {
                case "R01":
                    txtID.Text = QlIT.CreateNewItId("IT");
                    break;
                case "R02":
                    txtID.Text = QlIT.CreateNewCBDTId("DT");
                    break;
                case "R03":
                    txtID.Text = QlIT.CreateNewCBQLId("QL");
                    break;
                default:
                    txtID.Text = "";
                    break;
            }
        }
        private void LoadPictureBox()
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        if (pbPicIT.Image != null)
                        {
                            pbPicIT.Image.Dispose();
                        }

                        pbPicIT.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (pbPicIT.Image != null)
                {
                    pbPicIT.Image.Dispose();
                    pbPicIT.Image = null;
                }
            }
        }
        public void LockControl()
        {
            txtID.Enabled = false;
            txtHoten.Enabled = false;
            txtEmail.Enabled = false;
            txtSodt.Enabled = false;
            txtDiachi.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            pbPicIT.Enabled = false;
            cbPhongBan.Enabled = false;
            dgvData.Enabled = true;

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void ClearForm()
        {
            txtHoten.Clear();
            txtHoten.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtSodt.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            pbPicIT.Image = null;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
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
            cbPhongBan.Enabled = true;
            pbPicIT.Enabled = true;
            btnSave.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;

            ClearForm();

            cbPhongBan.SelectedIndexChanged += cbPhongBan_SelectedIndexChanged;
            TaoID();
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
            pbPicIT.Enabled = true;
            cbPhongBan.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            dgvData.Enabled = false;
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvData.CurrentRow != null)
            {
                btnUpdate.Enabled = true;
                cbPhongBan.SelectedIndexChanged -= cbPhongBan_SelectedIndexChanged;

                txtID.Text = dgvData.CurrentRow.Cells["Mã Cán Bộ"]?.Value?.ToString() ?? string.Empty;
                txtHoten.Text = dgvData.CurrentRow.Cells["Tên Cán Bộ"]?.Value?.ToString() ?? string.Empty;
                if (dgvData.CurrentRow.Cells["Mã Phòng"].Value != DBNull.Value && dgvData.CurrentRow.Cells["Mã Phòng"].Value != null)
                {
                    cbPhongBan.SelectedValue = dgvData.CurrentRow.Cells["Mã Phòng"].Value.ToString();
                }
                else
                {
                    cbPhongBan.SelectedIndex = 0;  // Nếu không có phòng ban, chọn không có gì trong ComboBox
                }

                txtHoten.Text = dgvData.CurrentRow.Cells["Tên Cán Bộ"]?.Value?.ToString() ?? string.Empty;
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
                        pbPicIT.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbPicIT.Image = null;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message;
            int idPhong = 0;
            if (cbPhongBan.SelectedItem is DataRowView drv)
            {
                idPhong = Convert.ToInt32(drv["IDPhong"]);
            }
            else if (int.TryParse(cbPhongBan.SelectedValue.ToString(), out int parsedId))
            {
                idPhong = parsedId;
            }
            DataTable dtRole = QlIT.GetRoleFromIDPhong(idPhong);
            string idRole = dtRole.Rows[0]["IDRole"].ToString().Trim();

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

                switch (idRole)
                {
                    case "R01":
                        DTO_CBQL_IT IT = new DTO_CBQL_IT(txtID.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                        if (QlIT.ThemIT(IT, out message))
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case "R02":
                        DTO_CBQL_CBDT CBDT = new DTO_CBQL_CBDT(txtID.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                        if (QlIT.ThemCBDT(CBDT, out message))
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case "R03":
                        DTO_CBQL_CBQL CBQL = new DTO_CBQL_CBQL(txtID.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);
                        if (QlIT.ThemCBQL(CBQL, out message))
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
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

                DTO_CBQL_IT IT = new DTO_CBQL_IT(txtID.Text, Convert.ToInt32(cbPhongBan.SelectedValue), txtHoten.Text, txtEmail.Text, txtSodt.Text, rdbNam.Checked, txtDiachi.Text, image);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật cán bộ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlIT.Update(IT, out message))
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            cbPhongBan.SelectedIndexChanged -= cbPhongBan_SelectedIndexChanged;

            ClearForm();
            LockControl();
            LoadDsLocDuLieu();
            LoadDsNhanSu();
            LoadDsPhong();
        }
    }
}
