using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.TenderType;

namespace Biding.Application.TenderType
{
    public class TenderTypeService : ITenderTypeService
    {
        private readonly BidingDbContext BidingDbContext;

        public TenderTypeService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        public async Task<IEnumerable<TenderTypeDTO>> GetType()
        {
            var Type = (from TenderType in BidingDbContext.Typy
                        select new TenderTypeDTO
                        {
                            Type = TenderType.Type
                        }
                            ).ToListAsync();

            return await Type;
        }

       public async Task<TenderTypeDTO> GetTypeByID(int typeId)
        {
            var Type = BidingDbContext.Typy.TryFirst(e => e.ID == typeId);
            if (Type.HasValue)
                return Type.Value;
            return null!;
        }

        public async Task<bool> AddType(TenderTypeDTO type)
        {
            var Type = new Domain.Models.TenderType(TenderType.Type);
            BidingDbContext.Category.AddAsync(Type);
            await BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        public async Task<TenderTypeDTO> UpdateType(int typeId, TenderTypeDTO type)
        {
            var Type = BidingDbContext.Typy.TryFirst(e => e.ID == typeId);
            if (Type.HasValue)
            {
                Type.Value.UpdateTenderType(TenderType.Type);
                await BidingDbContext.SaveChangesAsync();
                return Type.Value;
            }
            return null!;
        }
        public asyncvoid DeleteType(int typeId)
        {
            var Type = BidingDbContext.Typy.TryFirst(e => e.ID == typeId);

            if (Type.HasValue)
            {
                BidingDbContext.Typy.Remove(Type.Value);
                BidingDbContext.SaveChanges();
            }
        }
    }
}
