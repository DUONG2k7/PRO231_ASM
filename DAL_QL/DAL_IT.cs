using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DTO_QL;

namespace DAL_QL
{
    public class DAL_IT : DbConnect
    {
        public static string GetSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public bool KtSlRoleAdmin(string idAcc)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string checkQuery = @"SELECT COUNT(*) FROM ACCOUNTS WHERE IDRole = 'R01' AND Trangthai = 0";

                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    int countAdmin = (int)cmd.ExecuteScalar();

                    if (countAdmin == 1)
                    {
                        string checkCurrentQuery = "SELECT IDRole FROM ACCOUNTS WHERE IdAcc = @IdAcc";
                        using (SqlCommand cmdCheck = new SqlCommand(checkCurrentQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@IdAcc", idAcc);
                            object result = cmdCheck.ExecuteScalar();
                            if (result != null && result.ToString() == "R01")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool KtTkDaTonTai(string maTk)
        {
            string query = "SELECT COUNT(*) FROM ACCOUNTS WHERE IdAcc = @IdAcc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdAcc", maTk);
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
        public DataTable GetListAccount(string IDRole)
        {
            string query = "SELECT R.IDRole AS [Mã Quyền], A.IdAcc AS [Mã Tài Khoản], A.Username AS [Tên Tài Khoản], R.Role AS [Quyền], CASE WHEN A.Trangthai = 1 THEN N'Khóa' ELSE N'Đang sử dụng' END AS [Trạng Thái] FROM ACCOUNTS A JOIN ROLES R ON A.IDRole = R.IDRole WHERE R.IDRole = @IDRole";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDRole", IDRole);

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
        public DataTable GetListRoleLocDuLieu()
        {
            string query = "SELECT IDRole, Role FROM ROLES";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable GetListRole()
        {
            string query = "SELECT IDRole, Role FROM ROLES WHERE Role <> 'GLOBALBAN' AND Role <> 'admin'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable GetListChuaCoTaiKhoan(string Role)
        {
            string query = @"SELECT 
                                Users.ID, 
                                CASE 
                                    WHEN Users.Role = 'IT' THEN Users.Name
                                    WHEN Users.Role = 'CBDT' THEN Users.Name
                                    WHEN Users.Role = 'CBQL' THEN Users.Name
                                    WHEN Users.Role = 'GV' THEN Users.Name
                                    WHEN Users.Role = 'SV' THEN Users.Name
                                END AS RoleName
                            FROM (
                                SELECT IDIT AS ID, TenIT AS Name, 'IT' AS Role, IDAcc FROM IT
                                UNION ALL
                                SELECT IDCBDT AS ID, TenCBDT AS Name, 'CBDT' AS Role, IDAcc FROM CBDT
                                UNION ALL
                                SELECT IDCBQL AS ID, TenCBQL AS Name, 'CBQL' AS Role, IDAcc FROM CBQL
                                UNION ALL
                                SELECT IDGV AS ID, TenGV AS Name, 'GV' AS Role, IDAcc FROM TEACHERS
                                UNION ALL
                                SELECT IDSV AS ID, TenSV AS Name, 'SV' AS Role, IDAcc FROM STUDENTS
                            ) AS Users 
                            LEFT JOIN ACCOUNTS A ON Users.IdAcc = A.IdAcc
                            WHERE Users.IdAcc IS NULL AND Users.Role = @Role";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Role", Role);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public DataTable GetListHistory(string idAcc)
        {
            string query = "SELECT A.IdAcc, A.Username, R.Role, L.LichSuLogin FROM LoginHistory L JOIN ACCOUNTS A ON L.IdAcc = A.IdAcc JOIN ROLES R ON A.IDRole = R.IDRole WHERE A.IdAcc = @IdAcc";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.Add("@IdAcc", SqlDbType.NVarChar).Value = idAcc;
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public bool InsertAccount(DTO_IT_IT taikhoan, out string message)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string hashedPassword = GetSha256Hash(taikhoan._Password);

                    string insertQuery = "INSERT INTO ACCOUNTS (IDAcc, Username, Password, IDRole, Trangthai) " +
                                         "VALUES (@IDAcc, @Username, CONVERT(varbinary(max), @Password, 2), @IDRole, @Trangthai)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IDAcc", taikhoan._IdAcc);
                        cmd.Parameters.AddWithValue("@Username", taikhoan._Username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@IDRole", taikhoan._IdRole);
                        cmd.Parameters.AddWithValue("@Trangthai", taikhoan._TrangThai ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }

                    string UpdateQuery = "";
                    string idValue = "";

                    switch (taikhoan._IdRole)
                    {
                        case "R01":
                            UpdateQuery = "UPDATE IT SET IdAcc = @IdAcc WHERE IDIT = @ID";
                            idValue = taikhoan._IDIT;
                            break;
                        case "R02":
                            UpdateQuery = "UPDATE CBDT SET IdAcc = @IdAcc WHERE IDCBDT = @ID";
                            idValue = taikhoan._CBDT;
                            break;
                        case "R03":
                            UpdateQuery = "UPDATE CBQL SET IdAcc = @IdAcc WHERE IDCBQL = @ID";
                            idValue = taikhoan._CBQL;
                            break;
                        case "R04":
                            UpdateQuery = "UPDATE TEACHERS SET IdAcc = @IdAcc WHERE IDGV = @ID";
                            idValue = taikhoan._MaGV;
                            break;
                        case "R05":
                            UpdateQuery = "UPDATE STUDENTS SET IdAcc = @IdAcc WHERE IDSV = @ID";
                            idValue = taikhoan._IDSV;
                            break;
                    }

                    if (!string.IsNullOrEmpty(UpdateQuery) && !string.IsNullOrEmpty(idValue))
                    {
                        using (SqlCommand cmd = new SqlCommand(UpdateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdAcc", taikhoan._IdAcc);
                            cmd.Parameters.AddWithValue("@ID", idValue);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    message = "Thông tin tài khoản đã được lưu thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    message = "Lỗi: " + ex.Message;
                    return false;
                }
            }
        }
        public string GetRole(string Idacc)
        {
            string Role = "";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string getRoleQuery = "SELECT IDRole FROM ACCOUNTS WHERE IdAcc = @IdAcc";
                using (SqlCommand cmd = new SqlCommand(getRoleQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", Idacc);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        Role = result.ToString();
                    }
                }
            }
            return Role;
        }
        public bool UpdateAccount(DTO_IT_IT taikhoan, out string message)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string oldrole = GetRole(taikhoan._IdAcc);
                    if (oldrole != taikhoan._IdRole)
                    {
                        message = "Không được thay đổi role của tài khoản.";
                        return false;
                    }

                    string newHash;
                    if (string.IsNullOrWhiteSpace(taikhoan._Password))
                    {
                        byte[] MkCuDaMaHoa = null;
                        string GetPassQuery = "SELECT Password FROM ACCOUNTS WHERE IdAcc = @IdAcc";
                        using (SqlCommand cmd = new SqlCommand(GetPassQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdAcc", taikhoan._IdAcc);
                            var result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                MkCuDaMaHoa = (byte[])result;
                            }
                        }
                        newHash = MkCuDaMaHoa != null ? BitConverter.ToString(MkCuDaMaHoa).Replace("-", "").ToLower() : "";
                    }
                    else
                    {
                        newHash = GetSha256Hash(taikhoan._Password);
                    }

                    if (string.IsNullOrWhiteSpace(newHash))
                    {
                        message = "Lỗi: Hash mật khẩu không hợp lệ!";
                        return false;
                    }

                    string UpdateQuery = "UPDATE ACCOUNTS SET Password = CONVERT(VARBINARY(MAX), @Password, 2) WHERE IdAcc = @IdAcc";
                    using (SqlCommand cmd = new SqlCommand(UpdateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IdAcc", taikhoan._IdAcc);
                        cmd.Parameters.AddWithValue("@Password", newHash);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    message = "Thông tin tài khoản đã được cập nhật thành công!";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    message = "Lỗi: " + ex.Message;
                    return false;
                }
            }
        }
        public bool LockOrUnlockAccount(string idAcc)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string updateQuery = @"
                UPDATE ACCOUNTS SET Trangthai = CASE WHEN Trangthai = 1 THEN 0 ELSE 1 END,
                                    RoleBanDau = CASE WHEN Trangthai = 0 THEN IDRole ELSE RoleBanDau END,
                                    IDRole = CASE WHEN Trangthai = 0 THEN 'R06' ELSE RoleBanDau END WHERE IdAcc = @IdAcc;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", idAcc);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //prefix là tiền tố cho id
        //ví dụ: A001 --> A + 001 || A là tiền tố
        public string CreateNewId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IdAcc FROM ACCOUNTS WHERE IdAcc LIKE @prefix + '%'";
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
                            string id = reader["IdAcc"].ToString();
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

        //Form Quản lý tin tức
        public DataTable GetListNews()
        {
            string query = "SELECT N.IDTin AS [Mã Tin], N.Title AS [Tiêu Đề], N.Content AS [Nội Dung], N.NgayDang AS [Ngày Đăng], N.Hinh AS [Hình], CASE WHEN N.Trangthai = 1 THEN N'Đang sử dụng' ELSE N'Khóa' END AS [Trạng Thái] FROM NEWS N";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }
        public bool InsertNews(DTO_IT_TINTUC New, out string message)
        {
            string insertQuery = "INSERT INTO NEWS (Title, Content, NgayDang, Hinh, Trangthai) VALUES (@Title, @Content, @NgayDang, @Hinh, @Trangthai)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", New.Title);
                        cmd.Parameters.AddWithValue("@Content", New.Content);
                        cmd.Parameters.AddWithValue("@NgayDang", New.NgayDang);
                        cmd.Parameters.AddWithValue("@Hinh", New.Hinh);
                        cmd.Parameters.AddWithValue("@Trangthai", New.Trangthai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Tin tức đã được duyệt thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có tin tức nào được thêm.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi thêm tin tức: " + ex.Message;
                    return false;
                }
            }
        }
        public bool UpdateNews(DTO_IT_TINTUC New, out string message)
        {
            string updateQuery = "UPDATE NEWS SET Title = @Title, Content = @Content, NgayDang = @NgayDang, Hinh = @Hinh WHERE IDTin = @IDTin";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDTin", New.IDTin);
                        cmd.Parameters.AddWithValue("@Title", New.Title);
                        cmd.Parameters.AddWithValue("@Content", New.Content);
                        cmd.Parameters.AddWithValue("@NgayDang", New.NgayDang);
                        cmd.Parameters.AddWithValue("@Hinh", New.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin tin tức đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có tin tức nào được cập nhật.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Lỗi khi cập nhật tin tức: " + ex.Message;
                    return false;
                }
            }
        }
        public bool LockOrUnlockNews(int IDTin)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE NEWS SET Trangthai = CASE WHEN Trangthai = 1 THEN 0 ELSE 1 END WHERE IDTin = @IDTin";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IDTin", IDTin);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public string CreateNewIdTinTuc(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDTin FROM NEWS WHERE IDTin LIKE @prefix + '%'";
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
                            string id = reader["IDTin"].ToString();
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

        //Form hiện tin tức
        public int GetTotalNews()
        {
            string query = @"SELECT COUNT(*) FROM NEWS";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public DataTable GetAllNews(int IDtin)
        {
            string query = "SELECT N.IDTin, N.Title, N.Content, N.NgayDang, N.Hinh, " +
                           "CASE WHEN N.Trangthai = 1 THEN N'Đang sử dụng' ELSE N'Khóa' END AS Trangthai " +
                           "FROM NEWS N WHERE N.IDTin = @tin AND N.Trangthai = 1";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@tin", IDtin);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}