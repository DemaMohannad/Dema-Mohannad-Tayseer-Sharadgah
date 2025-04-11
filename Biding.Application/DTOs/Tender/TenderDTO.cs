using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biding.Application.DTOs.Tender
{
    public class TenderDTO
    {
        public string TenderTitle { get; set; } = null!;
        public string TenderReferenceNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int TypeID { get; set; } 
        public string TenderType { get; set; } = null!;
        public int CategoryID { get; set; } 
        public string TenderCategory { get; set; } = null!;
        public decimal? BudgetRange { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string document { get; set; } = null!;
    }
}
