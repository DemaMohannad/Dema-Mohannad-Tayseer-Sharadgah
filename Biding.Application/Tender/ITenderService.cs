using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Tender;

namespace Biding.Application.Tender
{
    public interface ITenderService
    {
        Task<IEnumerable<TenderDTO>> GetTender();

        Task<TenderDTO> GetTenderByID(int tenderId);

        Task<bool> AddTender(TenderDTO tender);

        Task<TenderDTO> UpdateTender(int tenderId, TenderDTO tender);

        void DeleteTender(int tenderId);
    }
}
