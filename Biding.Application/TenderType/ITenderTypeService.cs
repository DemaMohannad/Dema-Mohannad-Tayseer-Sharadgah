using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.TenderType;

namespace Biding.Application.TenderType
{
    public interface ITenderTypeService
    {
        Task<IEnumerable<TenderTypeDTO>> GetType();

        Task<TenderTypeDTO> GetTypeByID(int typeId);

        Task<bool> AddType(TenderTypeDTO type);

        Task<TenderTypeDTO> UpdateType(int typeId, TenderTypeDTO type);

        void DeleteType(int typeId);
    }
}
