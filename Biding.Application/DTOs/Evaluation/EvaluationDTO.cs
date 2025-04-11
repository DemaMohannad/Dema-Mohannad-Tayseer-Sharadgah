using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biding.Application.DTOs.Evaluation
{
    public class EvaluationDTO
    {
        public int BidID { get; set; }
        public decimal score { get; set; }
        public string Comments { get; set; } = null!;
    }
}
