using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.Entities
{
    public class Employee
    {
        public string EmployeeNumber { get; set; } = null!;

        public string EmployeeName { get; set; } = null!;
        public int DepID { get; set; }

        public int PosID { get; set; }

        public string Gender { get; set; } = null!;

        public string? Reportedtoempnum { get; set; }

        public int Vacdaysleft { get; set; }

        public decimal Salary { get; set; }

        public Department Department { get; set; } = null!;
        public Position Position { get; set; } = null!;
        public List<VacationRequest> VacationRequests { get; set; } = [];
        public Employee(string employeeNumber, string employeeName, int depID, int posID, string gender,string reportedtoempnum, decimal salary)
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            DepID = depID;
            PosID = posID;
            Gender = gender;
            Reportedtoempnum = reportedtoempnum;
            Vacdaysleft = 24;
            Salary = salary;
        }
    }
}
