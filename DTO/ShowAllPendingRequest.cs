using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.DTO
{
    public class ShowAllPendingRequest
    {
        public string Description { get; set; } = null!;
        public string EmpNumber { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public DateTime ReqSubmissionDate { get; set; }
        public int TotalVacDaye { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Salary { get; set; }

    }
}
