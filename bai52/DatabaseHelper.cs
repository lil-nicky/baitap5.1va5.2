using System;
using System.Data;
using System.Data.SqlClient;

namespace BaiTap42_CourseRegistration
{
    public static class DatabaseHelper
    {
        private const string ServerName = @".\SQLEXPRESS";
        private const string DatabaseName = "BaiTap42DB";

        private static string MasterConnectionString
        {
            get
            {
                return "Data Source=" + ServerName +
                       ";Initial Catalog=master;" +
                       "Integrated Security=True;" +
                       "TrustServerCertificate=True;";
            }
        }

        private static string ConnectionString
        {
            get
            {
                return "Data Source=" + ServerName +
                       ";Initial Catalog=" + DatabaseName +
                       ";Integrated Security=True;" +
                       "TrustServerCertificate=True;";
            }
        }

        public static void InitializeDatabase()
        {
            using (SqlConnection conn =
                   new SqlConnection(MasterConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText =
                    "IF DB_ID(N'" + DatabaseName +
                    "') IS NULL CREATE DATABASE [" +
                    DatabaseName + "];";

                cmd.ExecuteNonQuery();
            }

            using (SqlConnection conn =
                   new SqlConnection(ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = @"
IF OBJECT_ID('dbo.Courses', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Courses
    (
        CourseId INT IDENTITY(1,1) PRIMARY KEY,
        CourseName NVARCHAR(100) NOT NULL
    );
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Courses)
BEGIN
    INSERT INTO dbo.Courses (CourseName)
    VALUES
        (N'Lập trình C#'),
        (N'Cơ sở dữ liệu'),
        (N'Lập trình Java'),
        (N'Phát triển Web');
END;

IF OBJECT_ID('dbo.Registrations', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Registrations
    (
        RegistrationId INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(100) NOT NULL,
        Phone NVARCHAR(20) NOT NULL,
        BirthDate DATE NOT NULL,
        Gender NVARCHAR(20) NOT NULL,
        CourseId INT NOT NULL,
        WantsMaterials BIT NOT NULL,
        CreatedAt DATETIME2 NOT NULL
            DEFAULT SYSDATETIME(),

        CONSTRAINT FK_Registrations_Courses
            FOREIGN KEY (CourseId)
            REFERENCES dbo.Courses(CourseId)
    );
END;";

                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetCourses()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn =
                   new SqlConnection(ConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                @"SELECT CourseId, CourseName
                  FROM dbo.Courses
                  ORDER BY CourseName;", conn))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public static void SaveRegistration(
            string fullName,
            string phone,
            DateTime birthDate,
            string gender,
            int courseId,
            bool wantsMaterials)
        {
            string sql = @"
INSERT INTO dbo.Registrations
(
    FullName,
    Phone,
    BirthDate,
    Gender,
    CourseId,
    WantsMaterials
)
VALUES
(
    @FullName,
    @Phone,
    @BirthDate,
    @Gender,
    @CourseId,
    @WantsMaterials
);";

            using (SqlConnection conn =
                   new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(
                    "@FullName", SqlDbType.NVarChar, 100)
                    .Value = fullName;

                cmd.Parameters.Add(
                    "@Phone", SqlDbType.NVarChar, 20)
                    .Value = phone;

                cmd.Parameters.Add(
                    "@BirthDate", SqlDbType.Date)
                    .Value = birthDate.Date;

                cmd.Parameters.Add(
                    "@Gender", SqlDbType.NVarChar, 20)
                    .Value = gender;

                cmd.Parameters.Add(
                    "@CourseId", SqlDbType.Int)
                    .Value = courseId;

                cmd.Parameters.Add(
                    "@WantsMaterials", SqlDbType.Bit)
                    .Value = wantsMaterials;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}