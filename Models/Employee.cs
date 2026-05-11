using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [MaxLength(100, ErrorMessage = "Employee name cannot exceed 100 characters.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [MaxLength(100, ErrorMessage = "Email address cannot exceed 100 characters.")]
        public string MailID { get; set; }

        public DateTime? DOJ { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string DepartmentName { get; set; }
    }
}