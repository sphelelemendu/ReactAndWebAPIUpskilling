using System.Data;
using WebAPI.Models;

namespace WebAPI.Data_Layer_Service
{
    public interface IEmployeeService
    {
        DataTable GetEmployees();
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
    }
}
