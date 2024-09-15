using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable employeeTable = new DataTable();
            string query = @"SELECT EmployeeID, EmployeeName,MailID, CONVERT(varchar(10),DOJ,120) AS DOJ FROM dbo.Employees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString) ) 
            using ( var cmd = new SqlCommand(query, con) )
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(employeeTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employeeTable);
        }
        [HttpPost]
        public string Post(Employee emp)
        {
            try
            {
                DataTable employeeTable = new DataTable();
                string query = @"INSERT INTO dbo.Employees(EmployeeName,Department,MailID,DOJ) VALUES(
                '" + emp.EmployeeName + @"',
                '" + emp.DepartmentName + @"',
                '" + emp.MailID + @"',
                '" + emp.DOJ + @"'
                )";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(employeeTable);
                }
                return "Added Successfully";
            }
            
            catch
            {
                return "Failed to add";
            }

        }
        public string Put(Employee emp)
        {
            try
            {
                DataTable employeeTable = new DataTable();
                string query = @"
                UPDATE dbo.Employees SET
                EmployeeName= '" + emp.EmployeeName + @"',
                Department ='" + emp.DepartmentName + @"',
                MailID = '" + emp.MailID + @"',
                DOJ = '" + emp.DOJ + @"'
                WHERE EmployeeID = "+emp.EmployeeId+@"
                ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(employeeTable);
                }
                return "Updated Successfully";
            }

            catch
            {
                return "Failed to update";
            }

        }
        public string Delete(int Id)
        {
            try
            {
                DataTable employeeTable = new DataTable();
                string query = @"
                Delete from dbo.Employees where EmployeeID= "+ Id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(employeeTable);
                }
                return "Deleted Successfully";
            }

            catch
            {
                return "Failed to delete";
            }

        }
    }
}
