using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.DTO
{
    public class GetEmployeeByNumbercs
    {
        public string EmployeeNumber { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string? Reportedtoempnum { get; set; }
        public int Vacdaysleft { get; set; }
    }
}
