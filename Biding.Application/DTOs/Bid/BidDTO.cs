using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biding.Application.DTOs.Bid
{
    public class BidDTO
    {
        public int BidID { get; set; }
        public int TenderID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string TechnicalProposalPath { get; set; } = null!;
        public string FinancialProposalPath { get; set; } = null!;
        public DateTime SubmittedAt { get; set; }
        public string document { get; set; } = null!;
    }
}
