using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;

namespace Biding.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ITenderCategoryService TenderCategoryService;
        public CategoryController(ITenderCategoryService tendercategoryService)
        {
            TenderCategoryService = tendercategoryService;

        }

        [HttpGet]
        public async Task<ActionResult> GetCategory()
        {
            var Result = TenderCategoryService.GetCategory();
            return Ok(true);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<TenderCategoryDTO>> GetCategoryByID(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = TenderCategoryService.GetCategoryByID(categoryId);
            if (Result == null)
            {
                return NotFound($" Tender Category With ID : {categoryId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddCategory([FromBody] TenderCategoryDTO category)
        {
            TenderCategoryService.AddCategory(category);
            return Ok(true);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult<TenderCategoryDTO>> UpdateCategory(int categoryId, TenderCategoryDTO category)
        {
            var result = TenderCategoryService.UpdateCategory(categoryId, category);

            if (result == null)
                return NotFound($"Tender Category With ID : {categoryId} Not Found");
            else
                return result;
        }

        [HttpDelete("{categoryId}")]
        public async void DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            TenderCategoryService.DeleteCategory(categoryId);
        }
    }
}
