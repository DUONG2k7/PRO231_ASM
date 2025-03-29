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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ASM
{
    public partial class FormQuanLyLich : Form
    {
        BUS_CBDT QlLich = new BUS_CBDT();
        bool IsAdding = false;
        int idkyhoc;
        public FormQuanLyLich(int IDKYHOC)
        {
            InitializeComponent();

            idkyhoc = IDKYHOC;

            LoadDsLich();
            LoadDsLop();
            LoadBuoiHoc(cbLop.SelectedValue.ToString());
            LoadDsMonHoc();
            LoadDsGvBoMon(cbMonhoc.SelectedValue.ToString());
            LoadCaHoc();
            LockControl();

            cbLop.SelectedIndexChanged += cbLop_SelectedIndexChanged;
            cbMonhoc.SelectedIndexChanged += cbMonhoc_SelectedIndexChanged;
            txtBuoihoc.TextChanged += txtBuoihoc_TextChanged;
            cbCahoc.SelectedIndexChanged += cbCahoc_SelectedIndexChanged;

            if (dgvLichHoc.Columns.Contains("IDLop"))
            {
                dgvLichHoc.Columns["IDLop"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("IDMonHoc"))
            {
                dgvLichHoc.Columns["IDMonHoc"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("IDGV"))
            {
                dgvLichHoc.Columns["IDGV"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("IDKyHoc"))
            {
                dgvLichHoc.Columns["IDKyHoc"].Visible = false;
            }

            dgvLichHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsLich()
        {
            dgvLichHoc.DataSource = QlLich.LoadDsLich();
        }
        public void LoadDsLop()
        {
            cbLop.DataSource = QlLich.LoadDsLopFormLich();
            cbLop.DisplayMember = "ClassName";
            cbLop.ValueMember = "IDLop";
        }
        public void LoadBuoiHoc(string IDLop)
        {
            txtBuoihoc.Text = QlLich.LoadBuoiHoc(IDLop);
        }
        public void LoadDsMonHoc()
        {
            cbMonhoc.DataSource = QlLich.LoadDsMonHoc();
            cbMonhoc.DisplayMember = "TenMon";
            cbMonhoc.ValueMember = "IDMonHoc";
        }
        public void LoadDsGvBoMon(string IdMonHoc)
        {
            cbGvMonhoc.DataSource = QlLich.LoadDsGvBoMon(IdMonHoc);
            cbGvMonhoc.DisplayMember = "TenGV";
            cbGvMonhoc.ValueMember = "IDGV";
        }
        private void LoadCaHoc()
        {
            cbCahoc.Items.Clear();

            if (txtBuoihoc.Text == "Sáng")
            {
                cbCahoc.Items.Add(1);
                cbCahoc.Items.Add(2);
            }
            else if (txtBuoihoc.Text == "Chiều")
            {
                cbCahoc.Items.Add(3);
                cbCahoc.Items.Add(4);
            }
        }
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBuoiHoc(cbLop.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu buổi học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDsGvBoMon(cbMonhoc.SelectedValue.ToString());
        }

        private void txtBuoihoc_TextChanged(object sender, EventArgs e)
        {
            LoadCaHoc();
        }

        private void cbCahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCahoc.SelectedItem != null && int.TryParse(cbCahoc.SelectedItem.ToString(), out int caHoc))
            {
                switch (caHoc)
                {
                    case 1:
                        dtpGioBatDau.Value = DateTime.Today.AddHours(7).AddMinutes(30); // 07:30
                        dtpGioKetThuc.Value = dtpGioBatDau.Value.AddMinutes(120); // 09:30
                        break;
                    case 2:
                        dtpGioBatDau.Value = DateTime.Today.AddHours(9).AddMinutes(10);
                        dtpGioKetThuc.Value = dtpGioBatDau.Value.AddMinutes(120);
                        break;
                    case 3:
                        dtpGioBatDau.Value = DateTime.Today.AddHours(13);
                        dtpGioKetThuc.Value = dtpGioBatDau.Value.AddMinutes(120);
                        break;
                    case 4:
                        dtpGioBatDau.Value = DateTime.Today.AddHours(15).AddMinutes(10);
                        dtpGioKetThuc.Value = dtpGioBatDau.Value.AddMinutes(120);
                        break;
                    default:
                        dtpGioBatDau.Value = DateTime.Today; // Đặt giờ mặc định
                        dtpGioKetThuc.Value = DateTime.Today;
                        break;
                }
            }
        }
        public void LockControl()
        {
            cbLop.Enabled = false;
            cbCahoc.Enabled = false;
            cbMonhoc.Enabled = false;
            cbGvMonhoc.Enabled = false;
            dtpNgay.Enabled = false;
            rdbNgayhoc.Enabled = false;
            rdbNgaythi.Enabled = false;

            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            dgvLichHoc.Enabled = true;
        }
        public void ClearForm()
        {
            cbLop.SelectedIndex = 0;
            cbCahoc.SelectedIndex = 0;
            cbMonhoc.SelectedIndex = 0;
            cbGvMonhoc.SelectedIndex = 0;
            rdbNgayhoc.Checked = false;
            rdbNgaythi.Checked = false;

            dtpGioBatDau.Checked = false;
            dtpGioBatDau.ResetText();
            dtpGioKetThuc.Checked = false;
            dtpGioKetThuc.ResetText();
        }
        private bool CheckInput()
        {
            if (cbLop.SelectedItem == null || cbMonhoc.SelectedItem == null ||
                cbCahoc.SelectedItem == null || cbGvMonhoc.SelectedItem == null ||
                !rdbNgayhoc.Checked && !rdbNgaythi.Checked)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            IsAdding = true;
            cbLop.Enabled = true;
            cbCahoc.Enabled = true;
            cbMonhoc.Enabled = true;
            cbGvMonhoc.Enabled = true;
            dtpNgay.Enabled = true;
            rdbNgayhoc.Enabled = true;
            rdbNgaythi.Enabled = true;
            dgvLichHoc.Enabled = false;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsAdding = false;
            cbLop.Enabled = true;
            cbCahoc.Enabled = true;
            cbMonhoc.Enabled = true;
            cbGvMonhoc.Enabled = true;
            dtpNgay.Enabled = true;
            rdbNgayhoc.Enabled = true;
            rdbNgaythi.Enabled = true;
            dgvLichHoc.Enabled = false;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message;
            if (IsAdding)
            {
                if (!CheckInput())
                {
                    return;
                }

                DTO_CBDT_LICHHOC Lich = new DTO_CBDT_LICHHOC(cbLop.SelectedValue.ToString(), Convert.ToInt32(cbMonhoc.SelectedValue), cbGvMonhoc.SelectedValue.ToString(), idkyhoc, rdbNgayhoc.Checked, dtpNgay.Value, dtpGioBatDau.Value.TimeOfDay, dtpGioKetThuc.Value.TimeOfDay);
                if (QlLich.ThemLichHoc(Lich, out message))
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

                int idlichhoc;
                int.TryParse(dgvLichHoc.CurrentRow.Cells["IDLichHoc"].Value?.ToString(), out idlichhoc);

                DTO_CBDT_LICHHOC Lich = new DTO_CBDT_LICHHOC(idlichhoc, cbLop.SelectedValue.ToString(), Convert.ToInt32(cbMonhoc.SelectedValue), cbGvMonhoc.SelectedValue.ToString(), idkyhoc, rdbNgayhoc.Checked, dtpNgay.Value, dtpGioBatDau.Value.TimeOfDay, dtpGioKetThuc.Value.TimeOfDay);
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật lịch học này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (QlLich.SuaLichHoc(Lich, out message))
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
            LoadDsLich();
        }

        private void dgvLichHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            if (e.RowIndex >= 0 && dgvLichHoc.CurrentRow != null)
            {
                try
                {
                    cbLop.SelectedValue = dgvLichHoc.CurrentRow.Cells["IDLop"].Value;
                    cbMonhoc.SelectedValue = dgvLichHoc.CurrentRow.Cells["IDMonHoc"].Value;
                    cbGvMonhoc.SelectedValue = dgvLichHoc.CurrentRow.Cells["IDGV"].Value;

                    TimeSpan gioBatDau = (TimeSpan)dgvLichHoc.CurrentRow.Cells["GioBatDau"].Value;
                    if (gioBatDau == new TimeSpan(7, 30, 0)) cbCahoc.SelectedItem = 1;
                    else if (gioBatDau == new TimeSpan(9, 10, 0)) cbCahoc.SelectedItem = 2;
                    else if (gioBatDau == new TimeSpan(13, 0, 0)) cbCahoc.SelectedItem = 3;
                    else if (gioBatDau == new TimeSpan(15, 10, 0)) cbCahoc.SelectedItem = 4;
                    else cbCahoc.SelectedIndex = -1;

                    dtpNgay.Value = Convert.ToDateTime(dgvLichHoc.CurrentRow.Cells["Ngay"].Value);
                    dtpGioBatDau.Value = DateTime.Today.Add(TimeSpan.Parse(dgvLichHoc.CurrentRow.Cells["GioBatDau"].Value.ToString()));
                    dtpGioKetThuc.Value = DateTime.Today.Add(TimeSpan.Parse(dgvLichHoc.CurrentRow.Cells["GioKetThuc"].Value.ToString()));

                    string LoaiNgay = dgvLichHoc.CurrentRow.Cells["LoaiNgay"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(LoaiNgay))
                    {
                        rdbNgayhoc.Checked = LoaiNgay == "Ngày học";
                        rdbNgaythi.Checked = LoaiNgay == "Ngày thi";
                    }
                    else
                    {
                        rdbNgayhoc.Checked = false;
                        rdbNgaythi.Checked = false;
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
