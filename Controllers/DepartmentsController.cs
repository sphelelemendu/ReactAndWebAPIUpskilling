using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data_Layer_Service;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public HttpResponseMessage Get()
        {
            var table = _departmentService.GetDepartments();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpPost]
        public HttpResponseMessage Post(Department dep)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            _departmentService.AddDepartment(dep);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(Department dep)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            _departmentService.UpdateDepartment(dep);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
