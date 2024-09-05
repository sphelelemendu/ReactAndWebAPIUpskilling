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
    }
}
