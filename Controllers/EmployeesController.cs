using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using WebAPI.Data_Layer_Service;


namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        // Inject the service via the constructor
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public HttpResponseMessage Get()
        {
            var employeeTable = _employeeService.GetEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, employeeTable);
        }
    }
}