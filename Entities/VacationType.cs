using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.Entities
{
    public class VacationType
    {      
        public string VacationTypeCode { get; set; } = null!;

        public string VacationTypeName { get; set; } = null!;
        public List<VacationRequest> VacationRequests { get; set; } = [];
    }
}
