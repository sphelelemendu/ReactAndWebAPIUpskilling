using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data_Layer_Service
{
    public class DepartmentService : IDepartmentService
    {
        private string ConnectionString => ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString;

        public DataTable GetDepartments()
        {
            DataTable table = new DataTable();
            string query = "SELECT DepartmentID, DepartmentName FROM dbo.Departments";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(table);
            }

            return table;
        }

        public void AddDepartment(Department dep)
        {
            string query = "INSERT INTO dbo.Departments(DepartmentName) VALUES(@Name)";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", dep.DepartmentName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(Department dep)
        {
            string query = "UPDATE dbo.Departments SET DepartmentName=@Name WHERE DepartmentID=@Id";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", dep.DepartmentName);
                cmd.Parameters.AddWithValue("@Id", dep.DepartmentID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int id)
        {
            string query = "DELETE FROM dbo.Departments WHERE DepartmentID=@Id";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
