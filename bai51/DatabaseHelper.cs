
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace BaiTap41_LoginForm
{
    public static class DatabaseHelper
    {
        private const string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=BaiTap41DB;Integrated Security=True;TrustServerCertificate=True";

        public static void InitializeDatabase()
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "IF DB_ID('BaiTap41DB') IS NULL CREATE DATABASE BaiTap41DB",
                    connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(64) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
BEGIN
    INSERT INTO dbo.Users (Username, PasswordHash)
    VALUES ('admin', '" + HashPassword("123456") + @"');
END";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool ValidateLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"
SELECT COUNT(*)
FROM dbo.Users
WHERE Username = @username
AND PasswordHash = @passwordHash";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@passwordHash", HashPassword(password));

                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
