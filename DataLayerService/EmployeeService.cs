using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPI.Data_Layer_Service
{
    public class EmployeeService:IEmployeeService
    {
        public DataTable GetEmployees()
        {
            DataTable employeeTable = new DataTable();
            string query = @"SELECT EmployeeID, EmployeeName, Department, MailID, CONVERT(varchar(10),DOJ,120) AS DOJ FROM dbo.Employees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(employeeTable);
            }

            return employeeTable;
        }
    }
}