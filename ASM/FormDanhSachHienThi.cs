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
        string Malop;
        public FormDanhSachHienThi(string TK)
        {
            InitializeComponent();

            Malop = QlDAnhSach.GetMaLop(TK);
            cbDanhSach.SelectedIndex = 0;
            cbDanhSach.SelectedIndexChanged += cbDanhSach_SelectedIndexChanged;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";
            switch (cbDanhSach.SelectedItem.ToString())
            {
                case "Mặc định":
                    query = @"SELECT GD.IDDiem AS [Mã Điểm], SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên], MH.TenMon AS [Tên Môn],
                            COALESCE(CAST(GD.Diem AS NVARCHAR), N'Chưa nhập') AS [Điểm] 
                            FROM STUDENTS SV 
                            LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV 
                            LEFT JOIN MonHoc MH ON GD.IDMonHoc = MH.IDMonHoc 
                            WHERE SV.IDLop = @IDLop";
                    break;

                case "Top 3 sinh viên cao nhất":
                    query = @"SELECT TOP 3 SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên], 
                            ROUND(SUM(GD.Diem) / COUNT(GD.IDDiem), 2) AS [Điểm Trung Bình]
                            FROM STUDENTS SV
                            JOIN Diem GD ON SV.IDSV = GD.IDSV
                            WHERE SV.IDLop = @IDLop AND GD.Diem IS NOT NULL
                            GROUP BY SV.IDSV, SV.TenSV
                            ORDER BY DiemTB DESC";
                    break;

                case "Tăng dần theo mã sinh viên":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên], 
                            COALESCE(CAST(GD.Diem AS NVARCHAR), N'Chưa nhập') AS [Điểm], 
                            ROUND(AVG(CAST(GD.Diem AS FLOAT)), 2) AS [Điểm Trung Bình] 
                            FROM STUDENTS SV 
                            LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV 
                            WHERE SV.IDLop = @IDLop 
                            GROUP BY SV.IDSV, SV.TenSV, GD.Diem 
                            ORDER BY SV.IDSV ASC";
                    break;

                case "Tăng dần theo giới tính":
                    query = @"SELECT SV.IDSV, SV.TenSV, 
                            CASE WHEN SV.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                            ROUND(AVG(CAST(GD.Diem AS FLOAT)), 2) AS [Điểm Trung Bình] 
                            FROM STUDENTS SV 
                            LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV 
                            WHERE SV.IDLop = @IDLop 
                            GROUP BY SV.IDSV, SV.TenSV, SV.GioiTinh 
                            ORDER BY SV.GioiTinh ASC";
                    break;

                case "Giảm dần theo mã sinh viên":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên], 
                            COALESCE(CAST(GD.Diem AS NVARCHAR), N'Chưa nhập') AS [Điểm], 
                            ROUND(AVG(CAST(GD.Diem AS FLOAT)), 2) AS [Điểm Trung Bình] 
                            FROM STUDENTS SV 
                            LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV 
                            WHERE SV.IDLop = @IDLop 
                            GROUP BY SV.IDSV, SV.TenSV, GD.Diem 
                            ORDER BY SV.IDSV DESC";
                    break;

                case "Giảm dần theo giới tính":
                    query = @"SELECT SV.IDSV AS [Mã Sinh Viên], SV.TenSV AS [Tên Sinh Viên], 
                            CASE WHEN SV.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                            ROUND(AVG(CAST(GD.Diem AS FLOAT)), 2) AS [Điểm Trung Bình] 
                            FROM STUDENTS SV 
                            LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV 
                            WHERE SV.IDLop = @IDLop 
                            GROUP BY SV.IDSV, SV.TenSV, SV.GioiTinh 
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
                    DataTable dt = QlDAnhSach.GetData(query, Malop);
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
