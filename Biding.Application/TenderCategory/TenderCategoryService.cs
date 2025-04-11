using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.TenderCategory;

namespace Biding.Application.TenderCategory
{
    public class TenderCategoryService : ITenderCategoryService
    {
        private readonly BidingDbContext BidingDbContext;

        public TenderCategoryService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        public async Task<IEnumerable<TenderCategoryDTO>> GetCategory()
        {
            var Categorys = (from TenderCategory in BidingDbContext.Category
                             select new TenderCategoryDTO
                             {
                                 CategoryName = TenderCategory.CategoryName
                             }
                            ).ToListAsync();

            return await Categorys;
        }

       public async Task<TenderCategoryDTO> GetCategoryByID(int categoryId)
        {
            var Category = BidingDbContext.Category.TryFirst(e => e.ID == categoryId);
            if (Category.HasValue)
                return Category.Value;
            return null!;
        }

        public async Task<bool> AddCategory(TenderCategoryDTO category)
        {
            var Category = new Domain.Models.TenderCategory(TenderCategory.CategoryName);
            BidingDbContext.Category.AddAsync(Category);
            await BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        public async Task<TenderCategoryDTO> UpdateCategory(int categoryId, TenderCategoryDTO category)
        {
            var Category = BidingDbContext.Category.TryFirst(e => e.ID == categoryId);
            if (Category.HasValue)
            {
                Category.Value.UpdateTenderCategory(TenderCategory.CategoryName);
                await BidingDbContext.SaveChangesAsync();
                return Category.Value;
            }
            return null!;
        }
        public async void DeleteCategory(int categoryId)
        {
            var Category = BidingDbContext.Category.TryFirst(e => e.ID == categoryId);

            if (Category.HasValue)
            {
                BidingDbContext.Category.Remove(Category.Value);
                BidingDbContext.SaveChanges();
            }
        }
    }
}
