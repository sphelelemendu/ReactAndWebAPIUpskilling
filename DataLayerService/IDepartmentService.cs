using System.Data;
using WebAPI.Models;

namespace WebAPI.Data_Layer_Service
{
    public interface IDepartmentService
    {
        DataTable GetDepartments();
        void AddDepartment(Department dep);
        void UpdateDepartment(Department dep);
        void DeleteDepartment(int id);
    }
}
