using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string MailID { get; set; }

        public DateTime? DOJ {  get; set; }
        public string DepartmentName { get; set; }
    }
}