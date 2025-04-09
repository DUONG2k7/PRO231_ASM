using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL
{
    public class DAL_GUI : DbConnect
    {
        //Form login
        public string GetIdAccFormUsernameAndPassWord(string username, string passwordHash)
        {
            string query = "SELECT IdAcc FROM ACCOUNTS WHERE Username = @username AND Password = CONVERT(VARBINARY(MAX), @password, 2)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", passwordHash);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
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
        public string GetIDRole(string idAcc)
        {
            string query = "SELECT IDRole FROM ACCOUNTS WHERE IdAcc = @IdAcc";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", idAcc);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
        public void InsertLoginHistory(string idAcc)
        {
            string query = "INSERT INTO LoginHistory (IdAcc, LichSuLogin) VALUES (@IdAcc, @LichSuLogin)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAcc", idAcc);
                    cmd.Parameters.AddWithValue("@LichSuLogin", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Form ADMIN
        string role;
        public string GetRole(string ID)
        {
            string query = @"SELECT Role FROM ROLES WHERE IDROLE = @IDROLE";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDROLE", ID);

                    role = cmd.ExecuteScalar()?.ToString();
                }
            }
            return role;
        }

        //Form SV
        public DataTable GetInfoSv(string IdAcc)
        {
            string query = "SELECT IDSV AS 'Mã Sinh Viên', IDLop AS 'Mã Lớp', TenSV AS 'Tên Sinh Viên', Email, SoDT AS 'Số Điện Thoại', GioiTinh AS 'Giới Tính', Diachi AS 'Địa Chỉ' FROM STUDENTS WHERE IdAcc = @IdAcc";
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
    }
}
