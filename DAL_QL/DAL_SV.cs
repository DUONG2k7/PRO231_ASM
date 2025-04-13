using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL
{
    public class DAL_SV : DbConnect
    {
        public DataTable GetListLichHocSv(string IdAcc)
        {
            string query = @"SELECT L.IDLichHoc AS [Mã Lịch], 
                           L.LoaiNgay AS [Loại Ngày], 
                           L.IDKyHoc AS [Mã Kỳ], 
                           L.IDLop AS [Mã Lớp], 
                           L.IDGV AS [Mã Giảng Viên], 
                           K.TenKy AS [Học Kỳ], 
                           L.Ngay AS [Ngày], 
                           L.IDMonHoc AS [Mã Môn], 
                           MH.TenMon AS [Tên Môn], 
                           C.ClassName AS [Tên Lớp], 
                           T.TenGV AS [Tên Giảng Viên], 
                           L.GioBatDau AS [Giờ Bắt Đầu], 
                           L.GioKetThuc AS [Giờ Kết Thúc] 
                    FROM LichHoc L
                    JOIN CLASSES C ON L.IDLop = C.IDLop 
                    JOIN MonHoc MH ON L.IDMonHoc = MH.IDMonHoc
                    JOIN TEACHERS T ON L.IDGV = T.IDGV
                    JOIN KyHoc K ON L.IDKyHoc = K.IDKyHoc
                    JOIN STUDENTS S ON C.IDLop = S.IDLop 
                    WHERE S.IdAcc = @IdAcc AND L.LoaiNgay = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", IdAcc);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetListLichThiSv(string IdAcc)
        {
            string query = @"SELECT L.IDLichHoc AS [Mã Lịch], L.LoaiNgay AS [Loại Ngày], L.IDKyHoc AS [Mã Kỳ], L.IDLop AS [Mã Lớp], L.IDGV AS [Mã Giảng Viên], K.TenKy AS [Học Kỳ], L.Ngay AS [Ngày], L.IDMonHoc AS [Mã Môn], MH.TenMon AS [Tên Môn], C.ClassName AS [Tên Lớp], T.TenGV AS [Tên Giảng Viên], L.GioBatDau AS [Giờ Bắt Đầu], L.GioKetThuc AS [Giờ Kết Thúc] FROM LichHoc L
                            JOIN CLASSES C ON L.IDLop = C.IDLop 
                            JOIN MonHoc MH ON L.IDMonHoc = MH.IDMonHoc
                            JOIN TEACHERS T ON L.IDGV = T.IDGV
                            JOIN KyHoc K ON L.IDKyHoc = K.IDKyHoc
                            JOIN STUDENTS S ON C.IDLop = S.IDLop 
                            WHERE S.IdAcc = @IdAcc AND L.LoaiNgay = 0";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", IdAcc);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetListKyHoc()
        {
            string query = "SELECT IDKyHoc, TenKy FROM KyHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListDiem(string IDACC, int IDKYHOC)
        {
            string query = @"
        SELECT 
            MH.IDMonHoc AS [Mã Môn], 
            MH.TenMon AS [Tên Môn], 
            D.diem_lab AS [Điểm Lab],
            D.diem_asm AS [Điểm ASM],
            D.diem_thi AS [Điểm Thi],
            D.diem_tb AS [Điểm TB]
        FROM 
            MonHoc MH 
        JOIN 
            Diem D ON MH.IDMonHoc = D.IDMonHoc 
        JOIN 
            KyHoc K ON D.IDKyHoc = K.IDKyHoc 
        JOIN 
            STUDENTS S ON D.IDSV = S.IDSV 
        WHERE 
            S.IdAcc = @IdAcc AND K.IDKyHoc = @IDKyHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", IDACC);
                    cmd.Parameters.AddWithValue("@IDKyHoc", IDKYHOC);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
