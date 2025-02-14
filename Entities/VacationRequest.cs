using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.Entities
{
    public class VacationRequest
    {
        public int RequestID { get; set; }
        public DateTime ReqSubmissionDate { get; set; }
        public string Description { get; set; } = null!;
        public string EmpNumber { get; set; } = null!;
        public string VacTypeCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalVacDaye { get; set; }
        public int RequestStateID { get; set; }
        public string? ApprovedbyEmpNum { get; set; } = null!;
        public string? DeclinedbyEmpNum { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public VacationType VacationType { get; set; } = null!;
        public RequestState RequestState { get; set; } = null!;
        

    }
}
