using BUS_QL;
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
    public partial class FormDanhSachHienThi : Form
    {
        BUS_GV QlDAnhSach = new BUS_GV();
        public FormDanhSachHienThi(string TK)
        {
            InitializeComponent();

            LoaddsLop(TK);
            cbDanhSach.SelectedIndex = 0;
            cbLop.SelectedIndexChanged += cbDanhSach_SelectedIndexChanged;
            cbDanhSach.SelectedIndexChanged += cbDanhSach_SelectedIndexChanged;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoaddsLop(string tk)
        {
            cbLop.DataSource = QlDAnhSach.GetMaLopFormTk(tk);
            cbLop.DisplayMember = "ClassName";
            cbLop.ValueMember = "IDLop";
        }
        private void cbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";
            switch (cbDanhSach.SelectedItem.ToString())
            {
                case "Mặc định":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên],
                    MH.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn],
                    COALESCE(CAST(GD.diem_lab AS NVARCHAR), N'Chưa nhập') AS [Lab (20%)],
                    COALESCE(CAST(GD.diem_asm AS NVARCHAR), N'Chưa nhập') AS [Assignment (30%)],
                    COALESCE(CAST(GD.diem_thi AS NVARCHAR), N'Chưa nhập') AS [Exam (50%)],
                    COALESCE(CAST(GD.diem_tb AS NVARCHAR), N'Chưa nhập') AS [Điểm Trung Bình]
                    FROM STUDENTS SV
                    LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV
                    LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc
                    WHERE SV.IDLop = @IDLop";
                    break;

                case "Top 3 sinh viên cao nhất":
                    query = @"SELECT TOP 3 
                    SV.IDSV AS [Mã Sinh Viên], 
                    SV.TenSV AS [Tên Sinh Viên],
                    ROUND(AVG(CAST(GD.diem_tb AS FLOAT)), 2) AS [Điểm Trung Bình Tất Cả Môn]
                    FROM STUDENTS SV
                    JOIN Diem GD ON SV.IDSV = GD.IDSV
                    WHERE SV.IDLop = @IDLop AND GD.diem_tb IS NOT NULL
                    GROUP BY SV.IDSV, SV.TenSV
                    ORDER BY [Điểm Trung Bình Tất Cả Môn] DESC";
                    break;

                case "Tăng dần theo mã sinh viên":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên],
                    MH.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn],
                    COALESCE(CAST(GD.diem_lab AS NVARCHAR), N'Chưa nhập') AS [Lab (20%)],
                    COALESCE(CAST(GD.diem_asm AS NVARCHAR), N'Chưa nhập') AS [Assignment (30%)],
                    COALESCE(CAST(GD.diem_thi AS NVARCHAR), N'Chưa nhập') AS [Exam (50%)],
                    COALESCE(CAST(GD.diem_tb AS NVARCHAR), N'Chưa nhập') AS [Điểm Trung Bình]
                    FROM STUDENTS SV
                    LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV
                    LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc
                    WHERE SV.IDLop = @IDLop
                    ORDER BY SV.IDSV ASC";
                    break;

                case "Tăng dần theo giới tính":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên],
                    CASE WHEN SV.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính],
                    MH.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn],
                    COALESCE(CAST(GD.diem_lab AS NVARCHAR), N'Chưa nhập') AS [Lab (20%)],
                    COALESCE(CAST(GD.diem_asm AS NVARCHAR), N'Chưa nhập') AS [Assignment (30%)],
                    COALESCE(CAST(GD.diem_thi AS NVARCHAR), N'Chưa nhập') AS [Exam (50%)],
                    COALESCE(CAST(GD.diem_tb AS NVARCHAR), N'Chưa nhập') AS [Điểm Trung Bình]
                    FROM STUDENTS SV
                    LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV
                    LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc
                    WHERE SV.IDLop = @IDLop
                    ORDER BY SV.GioiTinh ASC";
                    break;

                case "Giảm dần theo mã sinh viên":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên],
                    MH.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn],
                    COALESCE(CAST(GD.diem_lab AS NVARCHAR), N'Chưa nhập') AS [Lab (20%)],
                    COALESCE(CAST(GD.diem_asm AS NVARCHAR), N'Chưa nhập') AS [Assignment (30%)],
                    COALESCE(CAST(GD.diem_thi AS NVARCHAR), N'Chưa nhập') AS [Exam (50%)],
                    COALESCE(CAST(GD.diem_tb AS NVARCHAR), N'Chưa nhập') AS [Điểm Trung Bình]
                    FROM STUDENTS SV
                    LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV
                    LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc
                    WHERE SV.IDLop = @IDLop
                    ORDER BY SV.IDSV DESC";
                    break;

                case "Giảm dần theo giới tính":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên],
                    CASE WHEN SV.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính],
                    MH.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn],
                    COALESCE(CAST(GD.diem_lab AS NVARCHAR), N'Chưa nhập') AS [Lab (20%)],
                    COALESCE(CAST(GD.diem_asm AS NVARCHAR), N'Chưa nhập') AS [Assignment (30%)],
                    COALESCE(CAST(GD.diem_thi AS NVARCHAR), N'Chưa nhập') AS [Exam (50%)],
                    COALESCE(CAST(GD.diem_tb AS NVARCHAR), N'Chưa nhập') AS [Điểm Trung Bình]
                    FROM STUDENTS SV
                    LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV
                    LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc
                    WHERE SV.IDLop = @IDLop
                    ORDER BY SV.GioiTinh DESC";
                    break;

                default:
                    MessageBox.Show("Vui lòng chọn 1 lựa chọn hiển thị");
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                try
                {
                    DataTable dt = QlDAnhSach.GetData(query, cbLop.SelectedValue.ToString());
                    dgvDanhSach.DataSource = dt;
                }
                catch (Exception)
                {
                    MessageBox.Show("Giáo viên này chưa được phân lớp!");
                }
            }
        }
    }
}
