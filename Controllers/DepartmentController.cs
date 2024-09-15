using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        //api/department
        public HttpResponseMessage Get()
        {
            DataTable employeeTable = new DataTable();
            string query = @"SELECT DepartmentID, DepartmentName FROM Departments";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(employeeTable);
            }


            return Request.CreateResponse(HttpStatusCode.OK, employeeTable);
            //return new HttpResponseMessage(HttpStatusCode.OK); 

        }
        public string Post(Department dep)
        {
            try
            {
                DataTable departmentTable = new DataTable();
                string query = @"INSERT INTO dbo.Departments VALUES('" + dep.DepartmentName + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(departmentTable);
                }

                return "Added Successfully";
            }

            catch
            {
                return "Failed to add";
            }

        }
        public string Put(Department dep)
        {
            try
            {
                DataTable departmentTable = new DataTable();
                string query = @"
                UPDATE dbo.Departments SET
                DepartmentName= '" + dep.DepartmentName + @"'
               
                WHERE DepartmentID = " + dep.DepartmentID + @"
                ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(departmentTable);
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
                DataTable departmentTable = new DataTable();
                string query = @"
                delete from dbo.Departments where DepartmentID = " + Id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(departmentTable);
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
