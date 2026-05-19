using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data_Layer_Service
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(long id);
    }
}
