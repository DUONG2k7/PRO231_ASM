﻿using DTO_QL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL
{
    public class DAL_GV : DbConnect
    {
        //Tất cả Form đều dùng
        public string GetMaLop(string taikhoan)
        {
            string query = @"SELECT C.IDLop, C.ClassName FROM CLASSES C 
                            JOIN Class_Teacher CT ON C.IDLop = CT.IDLop 
                            JOIN TEACHERS T ON CT.IDGV = T.IDGV 
                            JOIN ACCOUNTS A ON T.IdAcc = A.IdAcc 
                            WHERE A.Username = @Username";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", taikhoan);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        //Form danh sách hiển thị
        public DataTable GetData(string query, string Malop)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", Malop);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    return dt;
                }
            }
        }

        //Form Quản Lý Điểm
        public DataTable GetListStudent(string IdGv, string IDLop, int IDMonHoc)
        {
            string query = @"SELECT 
                                SV.IDLop, 
                                SV.IDSV, 
                                SV.TenSV, 
                                KH.TenKy, 
                                MH.IDMonHoc, 
                                MH.TenMon, 
                                COALESCE(CAST(D.Diem AS NVARCHAR), N'Chưa nhập') AS Diem
                            FROM STUDENTS SV
                            JOIN CLASSES C ON SV.IDLop = C.IDLop
                            JOIN Class_Teacher CT ON SV.IDLop = CT.IDLop
                            JOIN KyHoc KH ON CT.IDKyHoc = KH.IDKyHoc
                            JOIN MonHoc_GiangVien MG ON MG.IDKyHoc = KH.IDKyHoc AND MG.IDGV = CT.IDGV
                            JOIN MonHoc MH ON MH.IDMonHoc = MG.IDMonHoc
                            LEFT JOIN Diem D ON SV.IDSV = D.IDSV AND D.IDMonHoc = MH.IDMonHoc AND D.IDKyHoc = KH.IDKyHoc
                            WHERE CT.IDGV = @IDGV AND SV.IDLop = @IDLop AND MH.IDMonHoc = @IDMonHoc;";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IdGv);
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    return dt;
                }
            }
        }
        public DataTable GetMaLopFormQuanLyDiem(string IDGV)
        {
            string query = @"SELECT C.IDLop, C.ClassName FROM CLASSES C 
                            JOIN Class_Teacher CT ON C.IDLop = CT.IDLop 
                            WHERE CT.IDGV = @IDGV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetMaMonHocFormQuanLyDiem(string IDGV)
        {
            string query = @"SELECT M.IDMonHoc, M.TenMon FROM MonHoc M
                            JOIN MonHoc_GiangVien MG ON M.IDMonHoc = MG.IDMonHoc
                            WHERE MG.IDGV = @IDGV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetStudentsByPage(string Malop, string IdGv, int offset, int pageSize)
        {
            DataTable dt = new DataTable();
            string query = "SELECT SV.IDSV, SV.TenSV, MH.TenMon, " +
                           "COALESCE(CAST(GD.Diem AS NVARCHAR), N'Chưa nhập') AS Diem " +
                           "FROM STUDENTS SV " +
                           "LEFT JOIN Diem GD ON SV.IDSV = GD.IDSV AND GD.IDMonHoc = (SELECT IDMonHoc FROM MonHoc_GiangVien WHERE IDGV = @IDGV) " +
                           "LEFT JOIN MonHoc MH ON MH.IDMonHoc = (SELECT IDMonHoc FROM MonHoc_GiangVien WHERE IDGV = @IDGV) " +
                           "WHERE SV.IDLop = @IDLop " +
                           "ORDER BY SV.IDSV ASC " +
                           "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", Malop);
                    cmd.Parameters.AddWithValue("@IDGV", IdGv);
                    cmd.Parameters.AddWithValue("@Offset", offset);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public string GetIdGvFromIdAcc(string Idacc)
        {
            string query = "SELECT IDGV FROM TEACHERS WHERE IDAcc = @IDAcc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDAcc", Idacc);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }
        public int GetIdMonhocFromIdGv_IDlop(string IdGv, string IDLop)
        {
            string query = "SELECT MG.IDMonHoc FROM MonHoc_GiangVien MG JOIN TEACHERS T ON MG.IDGV = T.IDGV JOIN Class_Teacher CT ON T.IDGV = CT.IDGV WHERE MG.IDGV = @IDGV AND CT.IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IdGv);
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public int GetTotalStudent(string maLop, string maGV)
        {
            string query = @"SELECT COUNT(*)
                            FROM STUDENTS SV
                            JOIN CLASSES C ON SV.IDLop = C.IDLop
                            JOIN Class_Teacher CT ON SV.IDLop = CT.IDLop
                            WHERE CT.IDGV = @IDGV AND SV.IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", (object)maLop ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDGV", (object)maGV ?? DBNull.Value);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public bool KtSvDaCoDiemChua(string maHs)
        {
            string query = "SELECT COUNT(*) FROM Diem WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDSV", maHs);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
        public DataTable SearchByID(string maLop, string maGV, string maSV)
        {
            DataTable dtSinhVien = new DataTable();
            string query = @"SELECT 
                                SV.IDLop, 
                                SV.IDSV, 
                                SV.TenSV, 
                                KH.TenKy, 
                                MH.IDMonHoc, 
                                MH.TenMon, 
                                COALESCE(CAST(D.Diem AS NVARCHAR), N'Chưa nhập') AS Diem
                            FROM STUDENTS SV
                            JOIN CLASSES C ON SV.IDLop = C.IDLop
                            JOIN Class_Teacher CT ON SV.IDLop = CT.IDLop
                            JOIN KyHoc KH ON CT.IDKyHoc = KH.IDKyHoc
                            JOIN MonHoc_GiangVien MG ON MG.IDKyHoc = KH.IDKyHoc AND MG.IDGV = CT.IDGV
                            JOIN MonHoc MH ON MH.IDMonHoc = MG.IDMonHoc
                            LEFT JOIN Diem D ON SV.IDSV = D.IDSV AND D.IDMonHoc = MH.IDMonHoc AND D.IDKyHoc = KH.IDKyHoc
                            WHERE CT.IDGV = @IDGV AND SV.IDLop = @IDLop AND SV.IDSV LIKE @IDSV";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", maLop);
                    cmd.Parameters.AddWithValue("@IDGV", maGV);
                    cmd.Parameters.AddWithValue("@IDSV", "%" + maSV + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtSinhVien);
                }
            }
            return dtSinhVien;
        }
        public bool InsertGrade(DTO_GV_DIEM DiemSV, out string message)
        {
            string query = "INSERT INTO Diem (IDKyHoc, IDSV, IDMonHoc, Diem) VALUES (@IDKyHoc, @IDSV, @IDMonHoc, @Diem)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", DiemSV._IDKyHoc);
                        cmd.Parameters.AddWithValue("@IDSV", DiemSV._MaSV);
                        cmd.Parameters.AddWithValue("@IDMonHoc", DiemSV._IDMonHoc);
                        cmd.Parameters.AddWithValue("@Diem", DiemSV._Diem);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin học sinh đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không thể thêm điểm!";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi: " + ex.Message;
                    return false;
                }
            }
        }
        public bool UpdateGrade(DTO_GV_DIEM DiemSV, out string message)
        {
            string query = "UPDATE Diem SET Diem = @Diem WHERE IDKyHoc = @IDKyHoc AND IDSV = @IDSV AND IDMonHoc = @IDMonHoc";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", DiemSV._IDKyHoc);
                        cmd.Parameters.AddWithValue("@IDSV", DiemSV._MaSV);
                        cmd.Parameters.AddWithValue("@IDMonHoc", DiemSV._IDMonHoc);
                        cmd.Parameters.AddWithValue("@Diem", DiemSV._Diem);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Điểm học sinh đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không thể cập nhật điểm!";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi: " + ex.Message;
                    return false;
                }
            }
        }
        public bool DeleteGrade(DTO_GV_DIEM DiemSV, out string message)
        {
            string Deletequery = "DELETE FROM Diem WHERE IDKyHoc = @IDKyHoc AND IDSV = @IDSV AND IDMonHoc = @IDMonHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Deletequery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", DiemSV._IDKyHoc);
                        cmd.Parameters.AddWithValue("@IDSV", DiemSV._MaSV);
                        cmd.Parameters.AddWithValue("@IDMonHoc", DiemSV._IDMonHoc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Điểm học sinh đã được xóa thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không thể xóa điểm!";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi: " + ex.Message;
                    return false;
                }
            }
        }

        //Form Lịch Dạy
        public DataTable GetListLichDay(string IDGV)
        {
            string query = @"SELECT L.IDLichHoc, L.IDLop, L.IDMonHoc, 
                            L.IDKyHoc, CASE WHEN L.LoaiNgay = 1 THEN N'Ngày học' ELSE N'Ngày thi' END AS LoaiNgay, 
                            L.Ngay, L.GioBatDau, L.GioKetThuc FROM LichHoc L
                            WHERE L.IDGV = @IDGV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable GetListClassOfTeacher(string IDGV)
        {
            string query = @"SELECT C.IDLop, C.ClassName 
                            FROM CLASSES C
                            JOIN Class_Teacher CT ON C.IDLop = CT.IDLop
                            JOIN KyHoc KH ON CT.IDKyHoc = KH.IDKyHoc
                            WHERE CT.IDGV = @IDGV AND KH.Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable GetListSubjectOfTeacher(string IDGV, string IDLop)
        {
            string query = @"SELECT MH.IDMonHoc, MH.TenMon
                            FROM MonHoc MH
                            JOIN MonHoc_GiangVien MG ON MH.IDMonHoc = MG.IDMonHoc
                            JOIN Class_Teacher CT ON MG.IDGV = CT.IDGV AND MG.IDKyHoc = CT.IDKyHoc
                            JOIN KyHoc KH ON CT.IDKyHoc = KH.IDKyHoc
                            WHERE MG.IDGV = @IDGV AND CT.IDLop = @IDLop AND KH.Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        //Form Điểm danh
        public DataTable GetListSinhVienDiemDanh(string IDLop, int lichhoc, DateTime ngaydiemdanh)
        {
            string query = @"SELECT SV.IDSV, SV.TenSV, DD.TrangThai, ISNULL(DD.GhiChu, '') AS GhiChu FROM STUDENTS SV
                            LEFT JOIN DIEMDANH DD ON SV.IDSV = DD.IDSV AND DD.IDLichHoc = @IDLichHoc AND DD.ThoiGianDiemDanh = @ThoiGianDiemDanh
                            WHERE SV.IDLop = @IDLop ORDER BY SV.IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLichHoc", lichhoc);
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    cmd.Parameters.AddWithValue("@ThoiGianDiemDanh", ngaydiemdanh);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public int GetIDLichHoc(string IDLop, int IDmonhoc, string IDGV, int idkyhoc)
        {
            string query = @"SELECT IDLichHoc FROM LichHoc WHERE IDLop = @IDLop AND IDMonHoc = @IDMonHoc AND IDGV = @IDGV AND IDKyHoc = @IDKyHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    cmd.Parameters.AddWithValue("@IDMonHoc", IDmonhoc);
                    cmd.Parameters.AddWithValue("@IDGV", IDGV);
                    cmd.Parameters.AddWithValue("@IDKyHoc", idkyhoc);

                    object result = cmd.ExecuteScalar();

                    return (result != null) ? Convert.ToInt32(result) : -1;
                }
            }
        }
        public DateTime? GetNgayDiemdanh(int IDLichHoc)
        {
            string query = @"SELECT TOP 1 Ngay
                            FROM LichHoc
                            WHERE IDLichHoc = @IDLichHoc";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IDLichHoc", IDLichHoc);

                conn.Open();
                object result = cmd.ExecuteScalar();

                return (result != null && result != DBNull.Value) ? Convert.ToDateTime(result) : (DateTime?)null;
            }
        }
        public string GetTenLop(int IDLop)
        {
            string query = @"SELECT ClassName FROM CLASSES WHERE IDLop = @IDLop";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IDLop", IDLop);

                conn.Open();
                object result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
        }
        public string GetTenMon(int IDMonHoc)
        {
            string query = @"SELECT TenMon FROM MonHoc WHERE IDMonHoc = @IDMonHoc";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);

                conn.Open();
                object result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
        }
        public bool XoaDiemDanhCu(DTO_GV_DIEMDANH d, out string Message)
        {
            Message = string.Empty;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = @"DELETE FROM DIEMDANH WHERE IDLichHoc = @IDLichHoc AND ThoiGianDiemDanh >= @NgayDiemDanh";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@IDLichHoc", d.IDLichHoc);
                            deleteCmd.Parameters.AddWithValue("@NgayDiemDanh", d.ThoiGianDiemDanh);
                            deleteCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Message = "Lỗi khi xóa điểm danh cũ: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        public bool ThemDiemDanh(DTO_GV_DIEMDANH d, out string Message)
        {
            Message = string.Empty;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = @"INSERT INTO DIEMDANH (IDLichHoc, IDGV, IDSV, ThoiGianDiemDanh, TrangThai, GhiChu)
                                          VALUES (@IDLichHoc, @IDGV, @IDSV, @ThoiGianDiemDanh, @TrangThai, @GhiChu)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@IDLichHoc", d.IDLichHoc);
                            insertCmd.Parameters.AddWithValue("@IDGV", d.IDGV);
                            insertCmd.Parameters.AddWithValue("@IDSV", d.IDSV);
                            insertCmd.Parameters.AddWithValue("@ThoiGianDiemDanh", d.ThoiGianDiemDanh);
                            insertCmd.Parameters.AddWithValue("@TrangThai", d.TrangThai);
                            insertCmd.Parameters.AddWithValue("@GhiChu", d.GhiChu ?? "");

                            insertCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Message = "Lỗi khi thêm điểm danh: " + ex.Message;
                        return false;
                    }
                }
            }
        }
        public DataTable GetListBaoCaoDiemDanh(int idLichHoc, DateTime Ngay)
        {
            string query = @"SELECT s.IDSV, s.TenSV, 
                                           CASE WHEN dd.TrangThai = 1 THEN N'Có Mặt' ELSE N'Vắng' END AS TrangThai,
                                           dd.GhiChu, dd.ThoiGianDiemDanh
                                    FROM DIEMDANH dd
                                    INNER JOIN STUDENTS s ON dd.IDSV = s.IDSV
                                    WHERE dd.IDLichHoc = @IDLichHoc
                                      AND dd.ThoiGianDiemDanh = @ThoiGianDiemDanh
                                    ORDER BY s.IDSV, dd.ThoiGianDiemDanh";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLichHoc", idLichHoc);
                    cmd.Parameters.AddWithValue("@ThoiGianDiemDanh", Ngay);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        //Form Tra cứu SV
        public DataTable GetInfoSv(string IDSV)
        {
            string query = "SELECT IDLop, TenSV, Email, SoDT, GioiTinh, Diachi, Hinh FROM STUDENTS WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDSV", IDSV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetListDiem(string IDSV)
        {
            string query = @"SELECT 
                                K.IDKyHoc, 
                                K.TenKy, 
                                MH.IDMonHoc, 
                                MH.TenMon, 
                                D.Diem 
                            FROM Diem D
                            JOIN MonHoc MH ON D.IDMonHoc = MH.IDMonHoc
                            JOIN KyHoc K ON D.IDKyHoc = K.IDKyHoc
                            JOIN STUDENTS S ON D.IDSV = S.IDSV
                            WHERE S.IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDSV", IDSV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
