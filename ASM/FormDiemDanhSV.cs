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
    public partial class FormDiemDanhSV : Form
    {
        BUS_GV QLDiemDanh = new BUS_GV();
        int IDKYHOC;
        string IDGV;
        string IDLOP;
        int IDMONHOC;
        int IDLICHHOC;
        DateTime NGAYDIEMDANH;
        public FormDiemDanhSV(string IDlop, int IDMon, DateTime NgayDiemDanh, string IdGv, int IDKyhoc, int idlich)
        {
            InitializeComponent();
            cboLopHoc.Enabled = false;
            cboMonHoc.Enabled = false;
            dtpNgayDiemDanh.Enabled = false;

            IDKYHOC = IDKyhoc;
            IDGV = IdGv;
            IDLOP = IDlop;
            IDMONHOC = IDMon;
            NGAYDIEMDANH = NgayDiemDanh;
            IDLICHHOC = idlich;

            LoadDsLopGvDangDay();
            LoadDsMonHocGvDangDay();

            cboLopHoc.SelectedValue = IDLOP;
            cboMonHoc.SelectedValue = IDMONHOC;
            dtpNgayDiemDanh.Value = NGAYDIEMDANH;
            LoadDsSvDiemDanh();

            //dgvDanhSachSinhVien.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDanhSachSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDsSvDiemDanh()
        {
            dgvDanhSachSinhVien.DataSource = QLDiemDanh.LoadDsSinhVienDiemDanh(IDLOP, IDLICHHOC, NGAYDIEMDANH);
        }
        public void LoadDsLopGvDangDay()
        {
            cboLopHoc.DataSource = QLDiemDanh.LoadDsLopGvDangDay(IDGV);
            cboLopHoc.DisplayMember = "ClassName";
            cboLopHoc.ValueMember = "IDLop";
        }
        public void LoadDsMonHocGvDangDay()
        {
            cboMonHoc.DataSource = QLDiemDanh.LoadDsMonHocGvDangDay(IDGV, IDLOP);
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "IDMonHoc";
        }

        private void btnDiemDanhAll_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào để điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvDanhSachSinhVien.Rows)
            {
                row.Cells["TrangThai"].Value = 1;
            }
        }

        private void btnHuyDiemDanhAll_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào để điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvDanhSachSinhVien.Rows)
            {
                row.Cells["TrangThai"].Value = 0; // Đặt giá trị là 0 (Vắng mặt)
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            FormBaoCaoDiemDanh baoCaoDiemDanh = new FormBaoCaoDiemDanh(IDLICHHOC, NGAYDIEMDANH);
            baoCaoDiemDanh.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào để điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_GV_DIEMDANH XoaDiemDanh = new DTO_GV_DIEMDANH(IDKYHOC, NGAYDIEMDANH);
            if (!QLDiemDanh.XoaDiemDanhCu(XoaDiemDanh, out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in dgvDanhSachSinhVien.Rows)
            {
                if (row.Cells["IDSV"].Value == null) continue;

                string idSV = row.Cells["IDSV"].Value.ToString();
                object trangThaiValueObj = row.Cells["TrangThai"].Value;
                if (trangThaiValueObj == null || trangThaiValueObj == DBNull.Value) continue;

                bool trangThai = Convert.ToInt32(trangThaiValueObj) == 1;

                string ghiChu = row.Cells["GhiChu"].Value?.ToString() ?? "";
                if (ghiChu.Length > 255) ghiChu = ghiChu.Substring(0, 255);

                DTO_GV_DIEMDANH ThemDiemDanh = new DTO_GV_DIEMDANH(IDLICHHOC, IDGV, idSV, NGAYDIEMDANH, trangThai, ghiChu);
                if (!QLDiemDanh.ThemDiemDanh(ThemDiemDanh, out string messsage))
                {
                    MessageBox.Show(messsage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
