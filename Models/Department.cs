using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Department
    {
        public long DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string DepartmentName { get; set; }
    }
}