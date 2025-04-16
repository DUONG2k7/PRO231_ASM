using DTO_QL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL
{
    public class DAL_CBQL : DbConnect
    {
        public DataTable GetListStaffWithNOPhongBan()
        {
            string query = @"
                                    SELECT 
                    CAST(I.IDIT AS NVARCHAR(50)) AS [Mã Cán Bộ], 
                    I.TenIT AS [Tên Cán Bộ], 
                    CAST(I.IdAcc AS NVARCHAR(50)) AS [Mã Tài Khoản], 
                    I.Email, 
                    I.SoDT AS [Số Điện Thoại], 
                    CASE WHEN I.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                    I.Diachi AS [Địa Chỉ], 
                    I.Hinh AS [Hình], 
                    N'Chưa có phòng ban' AS [Tên Phòng]
                FROM IT I 
                WHERE I.IDPhong IS NULL

                UNION ALL

                SELECT 
                    CAST(CB.IDCBDT AS NVARCHAR(50)) AS [Mã Cán Bộ], 
                    CB.TenCBDT AS [Tên Cán Bộ], 
                    CAST(CB.IdAcc AS NVARCHAR(50)) AS [Mã Tài Khoản], 
                    CB.Email, 
                    CB.SoDT AS [Số Điện Thoại], 
                    CASE WHEN CB.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                    CB.Diachi AS [Địa Chỉ], 
                    CB.Hinh AS [Hình], 
                    N'Chưa có phòng ban' AS [Tên Phòng]
                FROM CBDT CB 
                WHERE CB.IDPhong IS NULL

                UNION ALL

                SELECT 
                    CAST(QL.IDCBQL AS NVARCHAR(50)) AS [Mã Cán Bộ], 
                    QL.TenCBQL AS [Tên Cán Bộ], 
                    CAST(QL.IdAcc AS NVARCHAR(50)) AS [Mã Tài Khoản], 
                    QL.Email, 
                    QL.SoDT AS [Số Điện Thoại], 
                    CASE WHEN QL.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                    QL.Diachi AS [Địa Chỉ], 
                    QL.Hinh AS [Hình], 
                    N'Chưa có phòng ban' AS [Tên Phòng]
                FROM CBQL QL 
                WHERE QL.IDPhong IS NULL
                ";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
        }
        public bool Update(DTO_CBQL_IT cb, out string message)
        {
            try
            {
                string id = cb.IDIT;
                string getRoleQuery = "SELECT R.IDRole FROM ROLES R JOIN PhongBan PB ON R.IDRole = PB.IDRole WHERE PB.IDPhong = @IDPhong";
                string newRole = "";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Lấy Role mới
                    using (SqlCommand cmdRole = new SqlCommand(getRoleQuery, conn))
                    {
                        cmdRole.Parameters.AddWithValue("@IDPhong", cb.IDPhong);
                        object roleResult = cmdRole.ExecuteScalar();
                        if (roleResult == null)
                        {
                            message = "Không tìm thấy Role tương ứng với phòng ban.";
                            return false;
                        }
                        newRole = roleResult.ToString();
                    }

                    // Xác định bảng hiện tại (IT, CBDT, CBQL)
                    string currentTable = "";
                    string[] tables = { "IT", "CBDT", "CBQL" };
                    string[] IDs = { "IDIT", "IDCBDT", "IDCBQL" };
                    string idAcc = "";

                    for (int i = 0; i < tables.Length; i++)
                    {
                        string checkQuery = $"SELECT IDAcc FROM {tables[i]} WHERE {IDs[i]} = @ID";
                        using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@ID", id);
                            object result = cmdCheck.ExecuteScalar();
                            if (result != null)
                            {
                                idAcc = result == DBNull.Value ? "" : result.ToString();
                                currentTable = tables[i];
                                break;
                            }
                        }
                    }

                    if (currentTable == "")
                    {
                        message = "Không tìm thấy cán bộ trong hệ thống.";
                        return false;
                    }

                    string newTable = newRole == "R01" ? "IT" : newRole == "R02" ? "CBDT" : "CBQL";
                    string newIDCol = newRole == "R01" ? "IDIT" : newRole == "R02" ? "IDCBDT" : "IDCBQL";

                    if (newTable != currentTable)
                    {
                        // Generate ID mới
                        string newGeneratedID = "";
                        switch (newRole)
                        {
                            case "R01": newGeneratedID = CreateNewItId("IT"); break;
                            case "R02": newGeneratedID = CreateNewCBDTId("DT"); break;
                            case "R03": newGeneratedID = CreateNewCBQLId("QL"); break;
                        }

                        // Xóa cán bộ ở bảng cũ
                        string deleteQuery = $"DELETE FROM {currentTable} WHERE {IDs[Array.IndexOf(tables, currentTable)]} = @ID";
                        using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@ID", id);
                            cmdDelete.ExecuteNonQuery();
                        }

                        // Thêm cán bộ vào bảng mới, gán lại IDAcc
                        string insertQuery = $"INSERT INTO {newTable} ({newIDCol}, IDPhong, Ten{newTable}, Email, SoDT, Gioitinh, Diachi, Hinh, IDAcc) " +
                                             $"VALUES (@ID, @IDPhong, @Ten, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh, @IDAcc)";

                        using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@ID", newGeneratedID);
                            cmdInsert.Parameters.AddWithValue("@IDPhong", cb.IDPhong);
                            cmdInsert.Parameters.AddWithValue("@Ten", cb.TenIT);
                            cmdInsert.Parameters.AddWithValue("@Email", cb.Email);
                            cmdInsert.Parameters.AddWithValue("@SoDT", cb.SoDT);
                            cmdInsert.Parameters.AddWithValue("@Gioitinh", cb.Gioitinh ? 1 : 0);
                            cmdInsert.Parameters.AddWithValue("@Diachi", cb.Diachi);
                            cmdInsert.Parameters.AddWithValue("@Hinh", cb.Hinh);
                            cmdInsert.Parameters.AddWithValue("@IDAcc", idAcc);

                            cmdInsert.ExecuteNonQuery();
                        }

                        message = "Chuyển chức năng và cập nhật cán bộ thành công.";
                        return true;
                    }
                    else
                    {
                        // Role không đổi → chỉ UPDATE
                        string updateQuery = $"UPDATE {currentTable} SET IDPhong = @IDPhong, Ten{currentTable} = @Ten, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE {IDs[Array.IndexOf(tables, currentTable)]} = @ID";

                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@ID", id);
                            cmdUpdate.Parameters.AddWithValue("@IDPhong", cb.IDPhong);
                            cmdUpdate.Parameters.AddWithValue("@Ten", cb.TenIT);
                            cmdUpdate.Parameters.AddWithValue("@Email", cb.Email);
                            cmdUpdate.Parameters.AddWithValue("@SoDT", cb.SoDT);
                            cmdUpdate.Parameters.AddWithValue("@Gioitinh", cb.Gioitinh ? 1 : 0);
                            cmdUpdate.Parameters.AddWithValue("@Diachi", cb.Diachi);
                            cmdUpdate.Parameters.AddWithValue("@Hinh", cb.Hinh);

                            int rowsAffected = cmdUpdate.ExecuteNonQuery();
                            message = rowsAffected > 0 ? "Thông tin cán bộ được cập nhật thành công." : "Không có thông tin nào được cập nhật.";
                            return rowsAffected > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật cán bộ: " + ex.Message;
                return false;
            }
        }

        //IT
        public DataTable GetListIT(int idPhong)
        {
            string query = @"SELECT 
                                I.IDIT AS [Mã Cán Bộ], 
                                I.TenIT AS [Tên Cán Bộ], 
                                I.IdAcc AS [Mã Tài Khoản], 
                                I.Email, 
                                I.SoDT AS [Số Điện Thoại], 
                                CASE WHEN I.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                                I.Diachi AS [Địa Chỉ], 
                                I.Hinh AS [Hình], 
                                ISNULL(P.IDPhong, 0) AS [Mã Phòng], 
                                ISNULL(P.TenPhong, N'Chưa có phòng ban') AS [Tên Phòng] 
                            FROM IT I 
                            LEFT JOIN PhongBan P ON I.IDPhong = P.IDPhong 
                            WHERE I.IDPhong = @idPhong";
                    

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPhong", idPhong);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
        }
        public bool InsertIT(DTO_CBQL_IT IT, out string message)
        {
            try
            {
                string insertQuery = "INSERT INTO IT (IDIT, IDPhong, TenIT, Email, SoDT, Gioitinh, Diachi, Hinh) VALUES (@IDIT, @IDPhong, @TenIT, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDIT", IT.IDIT);
                        cmd.Parameters.AddWithValue("@IDPhong", IT.IDPhong);
                        cmd.Parameters.AddWithValue("@TenIT", IT.TenIT);
                        cmd.Parameters.AddWithValue("@Email", IT.Email);
                        cmd.Parameters.AddWithValue("@SoDT", IT.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", IT.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", IT.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", IT.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin IT đã được lưu thành công!";
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
                message = "Lỗi khi thêm IT: " + ex.Message;
                return false;
            }
        }
        public bool UpdateIT(DTO_CBQL_IT IT, out string message)
        {
            try
            {
                string updateQuery = "UPDATE IT SET IDPhong = @IDPhong, TenIT = @TenIT, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE IDIT = @IDIT";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDIT", IT.IDIT);
                        cmd.Parameters.AddWithValue("@IDPhong", IT.IDPhong);
                        cmd.Parameters.AddWithValue("@TenIT", IT.TenIT);
                        cmd.Parameters.AddWithValue("@Email", IT.Email);
                        cmd.Parameters.AddWithValue("@SoDT", IT.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", IT.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", IT.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", IT.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin IT đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có IT nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật IT: " + ex.Message;
                return false;
            }
        }
        public string CreateNewItId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDIT FROM IT WHERE IDIT LIKE @prefix + '%'";
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
                            string id = reader["IDIT"].ToString();
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

        //CBDT
        public DataTable GetListCBDT(int idPhong)
        {
            string query = @"
                    SELECT 
                        P.IDPhong AS [Mã Phòng], 
                        CB.IDCBDT AS [Mã Cán Bộ], 
                        CB.TenCBDT AS [Tên Cán Bộ], 
                        CB.IdAcc AS [Mã Tài Khoản], 
                        CB.Email, 
                        CB.SoDT AS [Số Điện Thoại], 
                        CASE WHEN CB.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                        CB.Diachi AS [Địa Chỉ], 
                        CB.Hinh AS Hình, 
                        ISNULL(P.TenPhong, N'Không có phòng ban') AS [Tên Phòng] 
                    FROM CBDT CB 
                    LEFT JOIN PhongBan P ON CB.IDPhong = P.IDPhong 
                    WHERE CB.IDPhong = @idPhong";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPhong", idPhong);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool InsertCBDT(DTO_CBQL_CBDT CBDT, out string message)
        {
            try
            {
                string insertQuery = "INSERT INTO CBDT (IDCBDT, IDPhong, TenCBDT, Email, SoDT, Gioitinh, Diachi, Hinh) VALUES (@IDCBDT, @IDPhong, @TenCBDT, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCBDT", CBDT.IDCBDT);
                        cmd.Parameters.AddWithValue("@IDPhong", CBDT.IDPhong);
                        cmd.Parameters.AddWithValue("@TenCBDT", CBDT.TenCBDT);
                        cmd.Parameters.AddWithValue("@Email", CBDT.Email);
                        cmd.Parameters.AddWithValue("@SoDT", CBDT.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", CBDT.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", CBDT.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", CBDT.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin CBDT đã được lưu thành công!";
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
                message = "Lỗi khi thêm CBDT: " + ex.Message;
                return false;
            }
        }
        public bool UpdateCBDT(DTO_CBQL_CBDT CBDT, out string message)
        {
            try
            {
                string updateQuery = "UPDATE CBDT SET IDPhong = @IDPhong, TenCBDT = @TenCBDT, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE IDCBDT = @IDCBDT";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCBDT", CBDT.IDCBDT);
                        cmd.Parameters.AddWithValue("@IDPhong", CBDT.IDPhong);
                        cmd.Parameters.AddWithValue("@TenCBDT", CBDT.TenCBDT);
                        cmd.Parameters.AddWithValue("@Email", CBDT.Email);
                        cmd.Parameters.AddWithValue("@SoDT", CBDT.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", CBDT.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", CBDT.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", CBDT.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin CBDT đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có CBDT nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật CBDT: " + ex.Message;
                return false;
            }
        }
        public string CreateNewCBDTId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDCBDT FROM CBDT WHERE IDCBDT LIKE @prefix + '%'";
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
                            string id = reader["IDCBDT"].ToString();
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

        //CBQL
        public DataTable GetListCBQL(int idPhong)
        {
            string query = @"
                    SELECT 
                        P.IDPhong AS [Mã Phòng], 
                        QL.IDCBQL AS [Mã Cán Bộ], 
                        QL.TenCBQL AS [Tên Cán Bộ], 
                        QL.IdAcc AS [Mã Tài Khoản], 
                        QL.Email, 
                        QL.SoDT AS [Số Điện Thoại], 
                        CASE WHEN QL.Gioitinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                        QL.Diachi AS [Địa Chỉ], 
                        QL.Hinh AS [Hình], 
                        ISNULL(P.TenPhong, N'Không có phòng ban') AS [Tên Phòng] 
                    FROM CBQL QL 
                    LEFT JOIN PhongBan P ON QL.IDPhong = P.IDPhong 
                    WHERE QL.IDPhong = @idPhong";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPhong", idPhong);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public bool InsertCBQL(DTO_CBQL_CBQL CBQL, out string message)
        {
            try
            {
                string insertQuery = "INSERT INTO CBQL (IDCBQL, IDPhong, TenCBQL, Email, SoDT, Gioitinh, Diachi, Hinh) VALUES (@IDCBQL, @IDPhong, @TenCBQL, @Email, @SoDT, @Gioitinh, @Diachi, @Hinh)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCBQL", CBQL.IDCBQL);
                        cmd.Parameters.AddWithValue("@IDPhong", CBQL.IDPhong);
                        cmd.Parameters.AddWithValue("@TenCBQL", CBQL.TenCBQL);
                        cmd.Parameters.AddWithValue("@Email", CBQL.Email);
                        cmd.Parameters.AddWithValue("@SoDT", CBQL.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", CBQL.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", CBQL.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", CBQL.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin CBQL đã được lưu thành công!";
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
                message = "Lỗi khi thêm CBQL: " + ex.Message;
                return false;
            }
        }
        public bool UpdateCBQL(DTO_CBQL_CBQL CBQL, out string message)
        {
            try
            {
                string updateQuery = "UPDATE CBQL SET IDPhong = @IDPhong, TenCBQL = @TenCBQL, Email = @Email, SoDT = @SoDT, Gioitinh = @Gioitinh, Diachi = @Diachi, Hinh = @Hinh WHERE IDCBQL = @IDCBQL";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCBQL", CBQL.IDCBQL);
                        cmd.Parameters.AddWithValue("@IDPhong", CBQL.IDPhong);
                        cmd.Parameters.AddWithValue("@TenCBQL", CBQL.TenCBQL);
                        cmd.Parameters.AddWithValue("@Email", CBQL.Email);
                        cmd.Parameters.AddWithValue("@SoDT", CBQL.SoDT);
                        cmd.Parameters.AddWithValue("@Gioitinh", CBQL.Gioitinh ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Diachi", CBQL.Diachi);
                        cmd.Parameters.AddWithValue("@Hinh", CBQL.Hinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin CBQL đã được cập nhật thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Không có CBQL nào được cập nhật.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật CBQL: " + ex.Message;
                return false;
            }
        }
        public string CreateNewCBQLId(string prefix)
        {
            List<int> numbers = new List<int>();

            string query = "SELECT IDCBQL FROM CBQL WHERE IDCBQL LIKE @prefix + '%'";
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
                            string id = reader["IDCBQL"].ToString();
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

        //Phòng ban
        public DataTable GetListPhongBan()
        {
            string query = @"SELECT 
                            PB.IDPhong AS [ID Phòng], 
                            PB.TenPhong AS [Tên Phòng], 
                            PB.IDRole,
                            R.Role AS [Quyền],
                            (
                                CASE 
                                    WHEN PB.IDRole = 'R01' THEN (SELECT COUNT(*) FROM IT WHERE IDPhong = PB.IDPhong)
                                    WHEN PB.IDRole = 'R02' THEN (SELECT COUNT(*) FROM CBDT WHERE IDPhong = PB.IDPhong)
                                    WHEN PB.IDRole = 'R03' THEN (SELECT COUNT(*) FROM CBQL WHERE IDPhong = PB.IDPhong)
                                    ELSE 0
                                END
                            ) AS [Sĩ Số]
                            FROM PhongBan PB
                            JOIN ROLES R ON PB.IDRole = R.IDRole";
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
        public DataTable GetListPhong()
        {
            string query = "SELECT IDPhong, TenPhong AS [Tên Phòng] FROM PhongBan";
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
        public DataTable GetListRole()
        {
            string query = "SELECT IDRole, Role FROM ROLES WHERE Role <> 'GLOBALBAN' AND Role <> 'admin' AND Role <> 'GV' AND Role <> 'SV'";
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
        public DataTable GetRoleFromIDPhong(int IDPhong)
        {
            string query = "SELECT R.IDRole, R.Role " +
                           "FROM ROLES R " +
                           "JOIN PhongBan PB ON PB.IDRole = R.IDRole " +
                           "WHERE PB.IDPhong = @IDPhong";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDPhong", IDPhong);

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
        public bool InsertPhong(string TenPhong, string IDROLE, out string message)
        {
            try
            {
                string insertQuery = "INSERT INTO PhongBan (TenPhong, IDRole) VALUES (@TenPhong, @IDRole)";
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
                        cmd.Parameters.AddWithValue("@IDRole", IDROLE);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Thông tin phòng ban đã được lưu thành công!";
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
                message = "Lỗi khi thêm phòng ban: " + ex.Message;
                return false;
            }
        }
        public bool UpdatePhong(int IDPhong, string TenPhong, string newIDRole, out string message)
        {
            try
            {
                // Lấy IDRole hiện tại của phòng ban
                string selectRoleQuery = "SELECT IDRole FROM PhongBan WHERE IDPhong = @IDPhong";
                string oldIDRole = null;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand selectCmd = new SqlCommand(selectRoleQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@IDPhong", IDPhong);
                        var result = selectCmd.ExecuteScalar();
                        if (result != null)
                        {
                            oldIDRole = result.ToString();
                        }
                        else
                        {
                            message = "Không tìm thấy phòng ban.";
                            return false;
                        }
                    }

                    // Nếu role không thay đổi, chỉ update tên phòng
                    if (oldIDRole == newIDRole)
                    {
                        string updateTenPhong = "UPDATE PhongBan SET TenPhong = @TenPhong WHERE IDPhong = @IDPhong";
                        using (SqlCommand cmd = new SqlCommand(updateTenPhong, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
                            cmd.Parameters.AddWithValue("@IDPhong", IDPhong);

                            int rows = cmd.ExecuteNonQuery();
                            message = rows > 0 ? "Tên phòng đã được cập nhật!" : "Không có thay đổi nào.";
                            return rows > 0;
                        }
                    }
                    else
                    {
                        // Nếu role thay đổi: cập nhật role + tên phòng, đồng thời set NULL cho nhân viên cũ
                        string updatePhong = "UPDATE PhongBan SET TenPhong = @TenPhong, IDRole = @IDRole WHERE IDPhong = @IDPhong";
                        using (SqlCommand cmd = new SqlCommand(updatePhong, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
                            cmd.Parameters.AddWithValue("@IDRole", newIDRole);
                            cmd.Parameters.AddWithValue("@IDPhong", IDPhong);
                            cmd.ExecuteNonQuery();
                        }

                        // Set NULL cho nhân viên cũ thuộc phòng này
                        string[] updateNVQueries = 
                        {
                            "UPDATE IT SET IDPhong = NULL WHERE IDPhong = @IDPhong",
                            "UPDATE CBDT SET IDPhong = NULL WHERE IDPhong = @IDPhong",
                            "UPDATE CBQL SET IDPhong = NULL WHERE IDPhong = @IDPhong"
                        };

                        foreach (var query in updateNVQueries)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@IDPhong", IDPhong);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        message = "Đã cập nhật chức năng phòng và tạm thời xóa phòng ban của các nhân viên.";
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật phòng ban: " + ex.Message;
                return false;
            }
        }
    }
}
