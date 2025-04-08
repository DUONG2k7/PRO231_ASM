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
    public class DAL_CBDT : DbConnect
    {
        //Sinh Viên
        public DataTable GetListStudent(string IDLOP)
        {
            string query = "SELECT CL.IDLop AS N'ID Lớp', SV.IDSV AS N'Mã Sinh Viên', SV.TenSV AS N'Tên Sinh Viên', CL.ClassName AS N'Tên Lớp', SV.Email AS N'Email', SV.SoDT AS N'Số Điện Thoại', CASE WHEN SV.Gioitinh = 1 THEN 'Nam' ELSE N'Nữ' END AS N'Giới Tính', SV.Diachi AS N'Địa Chỉ', SV.Hinh AS N'Hình' FROM STUDENTS SV JOIN CLASSES CL ON SV.IDLop = CL.IDLop WHERE CL.IDLop = @IDLOP";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLOP", IDLOP);

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
        public DataTable GetListClassFromStudent()
        {
            string query = "SELECT IDLop, ClassName FROM CLASSES";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public int checkStatusClass(string IDLop)
        {
            string query = "SELECT Trangthai FROM CLASSES WHERE IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", IDLop);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public bool KtSvDaTonTai(string maHs)
        {
            string query = "SELECT COUNT(*) FROM STUDENTS WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSV", maHs);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool KiemTraSVDaCoDiemChua(string maSV)
        {
            string query = "SELECT COUNT(*) FROM GRADE WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSV", maSV);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool InsertStudent(DTO_CBDT_SV SinhVien, out string message)
        {
            string insertQuery = "INSERT INTO STUDENTS (IDSV, TenSV, IDLop, Email, SoDT, Gioitinh, Diachi, Hinh) VALUES (@IDSV, @TenSV, @IDLop, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSV", SinhVien._MaSV);
                        cmd.Parameters.AddWithValue("@TenSV", SinhVien._TenSV);
                        cmd.Parameters.AddWithValue("@IDLop", SinhVien._MaLop);
                        cmd.Parameters.AddWithValue("@Email", SinhVien._Email);
                        cmd.Parameters.AddWithValue("@SoDT", SinhVien._SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", SinhVien._Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", SinhVien._Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", SinhVien._Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin sinh viên đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi thêm sinh viên: " + ex.Message;
                    return false;
                }
            }
        }
        public bool UpdateStudent(DTO_CBDT_SV SinhVien, out string message)
        {
            string updateQuery = "UPDATE STUDENTS SET TenSV = @TenSV, IDLop = @IDLop, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSV", SinhVien._MaSV);
                        cmd.Parameters.AddWithValue("@TenSV", SinhVien._TenSV);
                        cmd.Parameters.AddWithValue("@IDLop", SinhVien._MaLop);
                        cmd.Parameters.AddWithValue("@Email", SinhVien._Email);
                        cmd.Parameters.AddWithValue("@SoDT", SinhVien._SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", SinhVien._Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", SinhVien._Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", SinhVien._Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin sinh viên đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có sinh viên nào được cập nhật.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi cập nhật sinh viên: " + ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteStudent(string maSV)
        {
            string deleteQuery = "DELETE FROM STUDENTS WHERE IDSV = @IDSV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDSV", maSV);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string CreateNewStudentId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDSV FROM STUDENTS WHERE IDSV LIKE @prefix + '%'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["IDSV"].ToString();
                            if (id.Length > prefix.Length)
                            {
                                string numberPart = id.Substring(prefix.Length);
                                if (int.TryParse(numberPart, out int num))
                                {
                                    numbers.Add(num);
                                }
                            }
                        }
                    }
                }
            }

            numbers.Sort();
            int nextNumber = 1;
            foreach (int num in numbers)
            {
                if (num == nextNumber)
                {
                    nextNumber++;
                }
                else if (num > nextNumber)
                {
                    break;
                }
            }

            return prefix + nextNumber.ToString("D" + Math.Max(2, nextNumber.ToString().Length));
        }

        //Giáo viên
        public DataTable GetListTeacher()
        {
            string query = "SELECT T.IDGV, T.TenGV, T.IdAcc, T.Email, T.SoDT, " +
                            "CASE WHEN T.Gioitinh = 1 THEN 'Nam' ELSE N'Nữ' END AS Gioitinh, " +
                            "T.Diachi, T.Hinh, " +
                            "ISNULL(C.ClassName, N'Chưa có lớp') AS TenLop " +
                            "FROM TEACHERS T " +
                            "LEFT JOIN Class_Teacher CT ON T.IDGV = CT.IDGV " +
                            "LEFT JOIN CLASSES C ON CT.IDLop = C.IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public bool InsertTeacher(DTO_CBQL_GV GiaoVien, out string message)
        {
            try
            {
                string insertQuery = "INSERT INTO TEACHERS (IDGV, TenGV, Email, SoDT, Gioitinh, Diachi, Hinh) VALUES (@IDGV, @TenGV, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDGV", GiaoVien._MaGV);
                        cmd.Parameters.AddWithValue("@TenGV", GiaoVien._TenGV);
                        cmd.Parameters.AddWithValue("@Email", GiaoVien._Email);
                        cmd.Parameters.AddWithValue("@SoDT", GiaoVien._SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", GiaoVien._Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", GiaoVien._Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", GiaoVien._Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin giảng viên đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm giảng viên: " + ex.Message;
                return false;
            }
        }
        public bool UpdateTeacher(DTO_CBQL_GV GiaoVien, out string message)
        {
            try
            {
                string updateQuery = "UPDATE TEACHERS SET TenGV = @TenGV, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE IDGV = @IDGV";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDGV", GiaoVien._MaGV);
                        cmd.Parameters.AddWithValue("@TenGV", GiaoVien._TenGV);
                        cmd.Parameters.AddWithValue("@Email", GiaoVien._Email);
                        cmd.Parameters.AddWithValue("@SoDT", GiaoVien._SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", GiaoVien._Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", GiaoVien._Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", GiaoVien._Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin giảng viên đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có giảng viên nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật giảng viên: " + ex.Message;
                return false;
            }
        }
        public bool DeleteTeacher(string magv)
        {
            try
            {
                string deleteQuery = "DELETE FROM TEACHERS WHERE IDGV = @IDGV";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDGV", magv);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        //prefix là tiền tố cho id
        //ví dụ: A001 --> A + 001 || A là tiền tố
        public string CreateNewTeacherId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDGV FROM TEACHERS WHERE IDGV LIKE @prefix + '%'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["IDGV"].ToString();
                            if (id.Length > prefix.Length)
                            {
                                string numberPart = id.Substring(prefix.Length);
                                if (int.TryParse(numberPart, out int num))
                                {
                                    numbers.Add(num);
                                }
                            }
                        }
                    }
                }
            }

            numbers.Sort();
            int nextNumber = 1;
            foreach (int num in numbers)
            {
                if (num == nextNumber)
                {
                    nextNumber++;
                }
                else if (num > nextNumber)
                {
                    break;
                }
            }

            return prefix + nextNumber.ToString("D" + Math.Max(2, nextNumber.ToString().Length));
        }

        //Class
        public DataTable GetListClass()
        {
            string query = "SELECT c.IDLop, c.ClassName, COUNT(s.IDSV) AS SiSo, CASE WHEN c.BuoiHoc = 1 THEN N'Sáng' ELSE N'Chiều' END AS BuoiHoc, CASE WHEN c.Trangthai = 1 THEN N'Khóa' ELSE N'Đang sử dụng' END AS TrangThai FROM CLASSES c LEFT JOIN STUDENTS s ON c.IDLop = s.IDLop GROUP BY c.IDLop, c.ClassName, c.BuoiHoc, c.Trangthai";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetListTeacherFromClass()
        {
            string query = "SELECT T.IDGV, T.TenGV FROM TEACHERS T LEFT JOIN CLASSES C ON T.IDGV = C.IDGV WHERE C.IDGV IS NULL AND T.IdAcc IS NOT NULL";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow emptyRow = dataTable.NewRow();
                emptyRow["IDGV"] = DBNull.Value;
                emptyRow["TenGV"] = "Không chỉ định";
                dataTable.Rows.InsertAt(emptyRow, 0);

                return dataTable;
            }
        }
        public bool KtLopDaTonTai(string maLop)
        {
            string query = "SELECT COUNT(*) FROM CLASSES WHERE IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", maLop);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return (int)result > 0;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool KtGVDaChiDinh(string maLop)
        {
            string query = "SELECT IDGV FROM CLASSES WHERE IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", maLop);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string maGV = result.ToString().Trim();
                            return !string.IsNullOrEmpty(maGV);
                        }
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool InsertClass(DTO_CBDT_CLASS lop, out string message)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO CLASSES (IDLop, ClassName, BuoiHoc) VALUES (@IDLop, @ClassName, @BuoiHoc)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", lop._MaLop);
                        cmd.Parameters.AddWithValue("@ClassName", lop._ClassName);
                        cmd.Parameters.AddWithValue("@BuoiHoc", lop._Buoihoc ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin lớp đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi thêm lớp học: " + ex.Message;
                    return false;
                }
            }
        }

        public bool UpdateClass(DTO_CBDT_CLASS lop, out string message)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string updateQuery = "UPDATE CLASSES SET ClassName = @ClassName, BuoiHoc = @BuoiHoc WHERE IDLop = @IDLop";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", lop._MaLop);
                        cmd.Parameters.AddWithValue("@ClassName", lop._ClassName);
                        cmd.Parameters.AddWithValue("@BuoiHoc", lop._Buoihoc ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin lớp đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có lớp học nào được cập nhật.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi cập nhật lớp học: " + ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteClass(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateStudentsQuery = "UPDATE STUDENTS SET IDLop = 'L00' WHERE IDLop = @IDLop";
                    using (SqlCommand cmd1 = new SqlCommand(updateStudentsQuery, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@IDLop", maLop);
                        cmd1.ExecuteNonQuery();
                    }

                    string deleteClassQuery = "DELETE FROM CLASSES WHERE IDLop = @IDLop";
                    using (SqlCommand cmd2 = new SqlCommand(deleteClassQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@IDLop", maLop);
                        int rowsAffected = cmd2.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public bool LockOrUnlockClass(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE CLASSES SET Trangthai = CASE WHEN Trangthai = 1 THEN 0 ELSE 1 END WHERE IDLop = @IDLop";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", maLop);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public string CreateNewClassId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDLop FROM CLASSES WHERE IDLop LIKE @prefix + '%'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["IDLop"].ToString();
                            if (id.Length > prefix.Length)
                            {
                                string numberPart = id.Substring(prefix.Length);
                                if (int.TryParse(numberPart, out int num))
                                {
                                    numbers.Add(num);
                                }
                            }
                        }
                    }
                }
            }

            numbers.Sort();
            int nextNumber = 1;
            foreach (int num in numbers)
            {
                if (num == nextNumber)
                {
                    nextNumber++;
                }
                else if (num > nextNumber)
                {
                    break;
                }
            }

            return prefix + nextNumber.ToString("D" + Math.Max(2, nextNumber.ToString().Length));
        }

        //Lịch học
        public DataTable GetListLich()
        {
            string query = "SELECT L.IDLichHoc, C.IDLop, MH.IDMonHoc, T.IDGV, K.IDKyHoc, K.TenKy, C.ClassName, MH.TenMon, T.TenGV, CASE WHEN L.LoaiNgay = 1 THEN N'Ngày học' ELSE N'Ngày thi' END AS LoaiNgay, L.Ngay, L.GioBatDau, L.GioKetThuc FROM LichHoc L " +
                "JOIN CLASSES C ON L.IDLop = C.IDLop " +
                "JOIN MonHoc MH ON L.IDMonHoc = MH.IDMonHoc " +
                "JOIN TEACHERS T ON L.IDGV = T.IDGV " +
                "JOIN KyHoc K ON L.IDKyHoc = K.IDKyHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public int GetIdKyHocDangHoc()
        {
            int idKyHoc = -1;
            string query = "SELECT IDKyHoc FROM KyHoc WHERE Trangthai = 1";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        idKyHoc = Convert.ToInt32(result);
                    }
                }
            }
            return idKyHoc;
        }
        public DataTable GetListClassFormLich()
        {
            string query = "SELECT IDLop, ClassName FROM CLASSES";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public string GetBuoiHocFromLich(string IDLop)
        {
            string query = "SELECT CASE WHEN BuoiHoc = 1 THEN N'Sáng' ELSE N'Chiều' END AS BuoiHoc FROM CLASSES WHERE IDLop = @IDLop";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }
        public DataTable GetListSubjectFormLich()
        {
            string query = "SELECT MH.IDMonHoc, MH.TenMon FROM MonHoc MH JOIN MonHoc_KyHoc MK ON MH.IDMonHoc = MK.IDMonHoc JOIN KyHoc K ON MK.IDKyHoc = K.IDKyHoc WHERE K.Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListTeacherOfSubjectFormLich(int IdMonHoc, string IDLop, int IDKyHoc)
        {
            string query =  "SELECT T.IDGV, T.TenGV FROM TEACHERS T " +
                            "JOIN MonHoc_GiangVien MG ON T.IDGV = MG.IDGV " +
                            "JOIN Class_Teacher CT ON T.IDGV = CT.IDGV " +
                            "JOIN KyHoc K ON MG.IDKyHoc = K.IDKyHoc " +
                            "WHERE MG.IDMonHoc = @IDMonHoc AND CT.IDLop = @IDLop AND MG.IDKyHoc = @IDKyHoc AND K.Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDMonHoc", IdMonHoc);
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    cmd.Parameters.AddWithValue("@IDKyHoc", IDKyHoc);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public bool InsertLichHoc(DTO_CBDT_LICHHOC LICH, out string message)
        {
            try
            {
                string query = "INSERT INTO LichHoc (IDLop, IDMonHoc, IDGV, IDKyHoc, LoaiNgay, Ngay, GioBatDau, GioKetThuc) " +
               "VALUES (@IDLop, @IDMonHoc, @IDGV, @IDKyHoc, @LoaiNgay, @Ngay, @GioBatDau, @GioKetThuc)";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", LICH.IDLop);
                        cmd.Parameters.AddWithValue("@IDMonHoc", LICH.IDMonHoc);
                        cmd.Parameters.AddWithValue("@IDGV", LICH.IDGV);
                        cmd.Parameters.AddWithValue("@IDKyHoc", LICH.IDKyHoc);
                        cmd.Parameters.AddWithValue("@LoaiNgay", LICH.LoaiNgay ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Ngay", LICH.Ngay);
                        cmd.Parameters.AddWithValue("@GioBatDau", LICH.GioBatDau);
                        cmd.Parameters.AddWithValue("@GioKetThuc", LICH.GioKetThuc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin lịch đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm lịch: " + ex.Message;
                return false;
            }
        }
        public bool UpdateLichHoc(DTO_CBDT_LICHHOC LICH, out string message)
        {
            try
            {
                string query = "UPDATE LichHoc SET " +
                               "IDLop = @IDLop, IDMonHoc = @IDMonHoc, IDGV = @IDGV, IDKyHoc = @IDKyHoc, " +
                               "LoaiNgay = @LoaiNgay, Ngay = @Ngay, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc " +
                               "WHERE IDLichHoc = @IDLichHoc";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLichHoc", LICH.IDLICHHOC);
                        cmd.Parameters.AddWithValue("@IDLop", LICH.IDLop);
                        cmd.Parameters.AddWithValue("@IDMonHoc", LICH.IDMonHoc);
                        cmd.Parameters.AddWithValue("@IDGV", LICH.IDGV);
                        cmd.Parameters.AddWithValue("@IDKyHoc", LICH.IDKyHoc);
                        cmd.Parameters.AddWithValue("@LoaiNgay", LICH.LoaiNgay ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Ngay", LICH.Ngay);
                        cmd.Parameters.AddWithValue("@GioBatDau", LICH.GioBatDau);
                        cmd.Parameters.AddWithValue("@GioKetThuc", LICH.GioKetThuc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Cập nhật thông tin lịch học thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có bản ghi nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật lịch học: " + ex.Message;
                return false;
            }
        }

        //Kỳ học
        public DataTable GetListKyHoc()
        {
            string query = "SELECT IDKyHoc, TenKy, NamBatDau, NamKetThuc, CASE WHEN Trangthai = 1 THEN N'Đang học' ELSE N'Khóa' END AS Trangthai FROM KyHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListKyHocMonHoc()
        {
            string query = "SELECT K.IDKyHoc, MH.IDMonHoc, K.TenKy, MH.TenMon, CASE WHEN MK.Trangthai = 1 THEN N'Đang học' ELSE N'Khóa' END AS Trangthai FROM MonHoc_KyHoc MK JOIN KyHoc K ON MK.IDKyHoc = K.IDKyHoc JOIN MonHoc MH ON MK.IDMonHoc = MH.IDMonHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListKyHocFormChiDinhMonHoc()
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
        public DataTable GetListMHFormChiDinhMonhoc(int idKyHoc)
        {
            string query = "SELECT MH.IDMonHoc, MH.TenMon FROM MonHoc MH WHERE MH.IDMonHoc NOT IN (SELECT MK.IDMonHoc FROM MonHoc_KyHoc MK WHERE MK.IDKyHoc = @IDKyHoc)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDKyHoc", idKyHoc);

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
        public bool InsertKyHoc(DTO_CBDT_KYHOC kYHOC, out string message)
        {
            try
            {
                string query = "INSERT INTO KyHoc (TenKy, NamBatDau, NamKetThuc, Trangthai) VALUES (@TenKy, @NamBatDau, @NamKetThuc, @Trangthai)";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenKy", kYHOC.TenKy);
                        cmd.Parameters.AddWithValue("@NamBatDau", kYHOC.NamBatDau);
                        cmd.Parameters.AddWithValue("@NamKetThuc", kYHOC.NamKetThuc);
                        cmd.Parameters.AddWithValue("@Trangthai", kYHOC.Trangthai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin kỳ học đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm kỳ học: " + ex.Message;
                return false;
            }
        }
        public bool InsertChiDinhMHtoKyHoc(int IDKyHoc, int IDMonHoc, bool trangthai, out string message)
        {
            try
            {
                string query = "INSERT INTO MonHoc_KyHoc (IDMonHoc, IDKyHoc, Trangthai) VALUES (@IDMonHoc, @IDKyHoc, @Trangthai)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", IDKyHoc);
                        cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);
                        cmd.Parameters.AddWithValue("@Trangthai", trangthai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin chỉ định đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm chỉ định: " + ex.Message;
                return false;
            }
        }
        public bool UpdateKyHoc(DTO_CBDT_KYHOC kYHOC, out string message)
        {
            try
            {
                string query = "UPDATE KyHoc SET TenKy = @TenKy, NamBatDau = @NamBatDau, NamKetThuc = @NamKetThuc WHERE IDKyHoc = @IDKyHoc";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", kYHOC.IDKyHoc);
                        cmd.Parameters.AddWithValue("@TenKy", kYHOC.TenKy);
                        cmd.Parameters.AddWithValue("@NamBatDau", kYHOC.NamBatDau);
                        cmd.Parameters.AddWithValue("@NamKetThuc", kYHOC.NamKetThuc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Cập nhật thông tin kỳ học thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có bản ghi nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật kỳ học: " + ex.Message;
                return false;
            }
        }
        public bool UpdateChiDinhMHtoKyHoc(int IDKyHoc, out string message)
        {
            try
            {
                string Deletequery = "DELETE FROM MonHoc_KyHoc WHERE IDKyHoc = @IDKyHoc";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Deletequery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", IDKyHoc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin của kỳ học đã được cập nhật thành công! Vui lòng chọn lại môn học muốn chỉ định";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật chỉ định: " + ex.Message;
                return false;
            }
        }
        public bool UseKyHoc(DTO_CBDT_KYHOC kYHOC, out string message)
        {
            try
            {
                string query = "UPDATE KyHoc SET Trangthai = CASE WHEN Trangthai = 1 THEN 0 ELSE 1 END WHERE IDKyHoc = @IDKyHoc";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", kYHOC.IDKyHoc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Cập nhật thông tin kỳ học thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có bản ghi nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật kỳ học: " + ex.Message;
                return false;
            }
        }
        public bool LockOrUnlockMonHoc(int IDKyHoc, int IDMonHoc, out string message)
        {
            try
            {
                string query = "UPDATE MonHoc_KyHoc SET Trangthai = CASE WHEN Trangthai = 1 THEN 0 ELSE 1 END WHERE IDKyHoc = @IDKyHoc AND IDMonHoc = @IDMonHoc";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", IDKyHoc);
                        cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Cập nhật thông tin môn học thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có bản ghi nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật môn học: " + ex.Message;
                return false;
            }
        }

        //Môn học
        public DataTable GetListmonHoc()
        {
            string query = "SELECT IDMonHoc, TenMon, SoTiet FROM MonHoc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public bool InsertMonHoc(DTO_CBDT_MONHOC MonHOC, out string message)
        {
            try
            {
                string query = "INSERT INTO MonHoc (TenMon, SoTiet) VALUES (@TenMon, @SoTiet)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenMon", MonHOC.TenMon);
                        cmd.Parameters.AddWithValue("@SoTiet", MonHOC.SoTiet);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin môn học đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm môn học: " + ex.Message;
                return false;
            }
        }
        public bool UpdateMonHoc(DTO_CBDT_MONHOC MonHOC, out string message)
        {
            try
            {
                string query = "UPDATE MonHoc SET TenMon = @TenMon, SoTiet = @SoTiet WHERE IDMonHoc = @IDMonHoc";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMonHoc", MonHOC.IDMonHoc);
                        cmd.Parameters.AddWithValue("@TenMon", MonHOC.TenMon);
                        cmd.Parameters.AddWithValue("@SoTiet", MonHOC.SoTiet);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Cập nhật thông tin môn học thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có bản ghi nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật môn học: " + ex.Message;
                return false;
            }
        }

        //Form phân việc
        public DataTable GetListMonHocGV()
        {
            string query =  "SELECT K.IDKYHOC, MH.IDMonHoc, K.TenKY, MH.TenMon, T.TenGV, MG.NgayChotViec " +
                            "FROM MonHoc_GiangVien MG " +
                            "JOIN KyHoc K ON MG.IDKyHoc = K.IDKyHoc " +
                            "JOIN MonHoc MH ON MG.IDMonHoc = MH.IDMonHoc " +
                            "JOIN TEACHERS T ON MG.IDGV = T.IDGV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListLopHocGV()
        {
            string query = "SELECT K.IDKYHOC, C.IDLop, K.TenKY, C.ClassName, T.TenGV, CT.NgayChotLop " +
                            "FROM Class_Teacher CT " +
                            "JOIN KyHoc K ON CT.IDKyHoc = K.IDKyHoc " +
                            "JOIN CLASSES C ON CT.IDLop = C.IDLop " +
                            "JOIN TEACHERS T ON CT.IDGV = T.IDGV";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListGVFormChiDinhGV(int IDMonHoc, int KYHOC)
        {
            string query = "SELECT T.IDGV, T.TenGV FROM TEACHERS T WHERE T.IDGV NOT IN (SELECT MG.IDGV FROM MonHoc_GiangVien MG WHERE MG.IDMonHoc = @IDMonHoc AND MG.IDKyHoc = @IDKyHoc)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);
                    cmd.Parameters.AddWithValue("@IDKyHoc", KYHOC);

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
        public DataTable GetListGVFormChiDinhLop(string IDLop, int KYHOC)
        {
            string query = @"SELECT T.IDGV, T.TenGV FROM TEACHERS T 
                            WHERE T.IDGV NOT IN (SELECT CT.IDGV FROM Class_Teacher CT WHERE CT.IDLop = @IDLop AND CT.IDKyHoc = @IDKyHoc)
                            AND T.IDGV IN (SELECT MG.IDGV FROM MonHoc_GiangVien MG WHERE MG.IDKyHoc = @IDKyHoc)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDLop", IDLop);
                    cmd.Parameters.AddWithValue("@IDKyHoc", KYHOC);

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
        public DataTable GetListMonHocFormChiDinhGV()
        {
            string query = "SELECT MH.IDMonHoc, MH.TenMon FROM MonHoc MH JOIN MonHoc_KyHoc MK ON MH.IDMonHoc = MK.IDMonHoc JOIN KyHoc K ON MK.IDKyHoc = K.IDKyHoc WHERE K.Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable GetListLopHocFormChiDinhGV()
        {
            string query = "SELECT IDLop, ClassName FROM CLASSES";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DateTime? GetNamBatDauKyHoc()
        {
            string query = "SELECT NamBatDau FROM KyHoc WHERE Trangthai = 1";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                return result != null ? Convert.ToDateTime(result) : (DateTime?)null;
            }
        }
        public bool InsertChiDinhGVtoMonHoc(int IDKyhoc, int IDMonHoc, string IDGV, DateTime Ngaychot, out string message)
        {
            try
            {
                string query = "INSERT INTO MonHoc_GiangVien (IDKyHoc, IDMonHoc, IDGV, NgayChotViec) VALUES (@IDKyHoc, @IDMonHoc, @IDGV, @NgayChotViec)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", IDKyhoc);
                        cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);
                        cmd.Parameters.AddWithValue("@IDGV", IDGV);
                        cmd.Parameters.AddWithValue("@NgayChotViec", Ngaychot);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin phân công đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm phân công: " + ex.Message;
                return false;
            }
        }
        public bool InsertChiDinhGVtoLopHoc(int IDKyhoc, string IDLop, string IDGV, DateTime Ngaychot, out string message)
        {
            try
            {
                string query = "INSERT INTO Class_Teacher (IDKyHoc, IDLop, IDGV, NgayChotLop) VALUES (@IDKyHoc, @IDLop, @IDGV, @NgayChotLop)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDKyHoc", IDKyhoc);
                        cmd.Parameters.AddWithValue("@IDLop", IDLop);
                        cmd.Parameters.AddWithValue("@IDGV", IDGV);
                        cmd.Parameters.AddWithValue("@NgayChotLop", Ngaychot);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin phân công đã được lưu thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được thêm.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm phân công: " + ex.Message;
                return false;
            }
        }
        public bool UpdateChiDinhGVtoMonHoc(int IDMonHoc, out string message)
        {
            try
            {
                string Deletequery = "DELETE FROM MonHoc_GiangVien WHERE IDMonHoc = @IDMonHoc";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Deletequery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMonHoc", IDMonHoc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin của môn học đã được cập nhật thành công! Vui lòng chọn lại giảng viên muốn phân công";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật phân công: " + ex.Message;
                return false;
            }
        }
        public bool UpdateChiDinhGVtoLopHoc(string IDLop, out string message)
        {
            try
            {
                string Deletequery = "DELETE FROM Class_Teacher WHERE IDLop = @IDLop";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Deletequery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLop", IDLop);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin của lớp học đã được cập nhật thành công! Vui lòng chọn lại giảng viên muốn phân công";
                            return true;
                        }
                        else
                        {
                            message = "Không có dữ liệu nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật phân công: " + ex.Message;
                return false;
            }
        }
    }
}
