using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data_Layer_Service
{
    public class EmployeeService : IEmployeeService
    {
        private string ConnectionString => ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString;

        public DataTable GetEmployees()
        {
            DataTable table = new DataTable();
            string query = "SELECT EmployeeID, EmployeeName, DepartmentName, MailID, CONVERT(varchar(10), DOJ, 120) AS DOJ FROM dbo.Employees";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(table);
            }

            return table;
        }

        public void AddEmployee(Employee emp)
        {
            string query = "INSERT INTO dbo.Employees(EmployeeName, DepartmentName, MailID, DOJ) VALUES(@Name, @Dept, @Mail, @DOJ)";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Dept", emp.DepartmentName);
                cmd.Parameters.AddWithValue("@Mail", emp.MailID);
                cmd.Parameters.AddWithValue("@DOJ", (object)emp.DOJ ?? DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            string query = "UPDATE dbo.Employees SET EmployeeName=@Name, DepartmentName=@Dept, MailID=@Mail, DOJ=@DOJ WHERE EmployeeID=@Id";

            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Dept", emp.DepartmentName);
                cmd.Parameters.AddWithValue("@Mail", emp.MailID);
                cmd.Parameters.AddWithValue("@DOJ", (object)emp.DOJ ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            string query = "DELETE FROM dbo.Employees WHERE EmployeeID=@Id";

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