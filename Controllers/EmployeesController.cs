using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data_Layer_Service;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public HttpResponseMessage Get()
        {
            var table = _employeeService.GetEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpPost]
        public HttpResponseMessage Post(Employee emp)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            _employeeService.AddEmployee(emp);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(Employee emp)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            _employeeService.UpdateEmployee(emp);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}