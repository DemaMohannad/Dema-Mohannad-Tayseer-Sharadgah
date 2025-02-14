using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; } = null!;

        public List<Employee> Employees { get; set; } = [];
        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
