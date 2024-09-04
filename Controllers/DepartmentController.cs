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
        public HttpResponseMessage Get() {
            DataTable employeeTable = new DataTable();
            string query = @"SELECT DepartmentID, DepartmentName FROM Departments";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(employeeTable);
            }


                return Request.CreateResponse(HttpStatusCode.OK,employeeTable);
                //return new HttpResponseMessage(HttpStatusCode.OK); 
        
        }
        
    }
}
