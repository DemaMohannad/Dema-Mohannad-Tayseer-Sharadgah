using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.TenderCategory;

namespace Biding.Application.TenderCategory
{
    public interface ITenderCategoryService
    {
        Task<IEnumerable<TenderCategoryDTO>> GetCategory();

        Task<TenderCategoryDTO> GetCategoryByID(int categoryId);

        Task<bool> AddCategory(TenderCategoryDTO category);

        Task<TenderCategoryDTO> UpdateCategory(int categoryId, TenderCategoryDTO category);

        void DeleteCategory(int categoryId);
    }
}
