using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;

namespace Biding.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {

        private readonly ITenderTypeService Typetenderservice;
        public TypeController(ITenderTypeService typetenderservice)
        {
            Typetenderservice = typetenderservice;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetType()
        {
            var Result = Typetenderservice.GetType();
            return Ok(true);
        }

        [HttpGet("{typeId}")]
        public async Task<ActionResult<TenderTypeDTO>> GetTypeByID(int typeId)
        {
            if(typeId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = Typetenderservice.GetTypeByID(typeId);
            if (Result == null)
            {
                return NotFound($"Tender Type With ID : {typeId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddType([FromBody] TenderTypeDTO type)
        {
            Typetenderservice.AddType(type);
            return Ok(true);
        }

        [HttpPut("{typeId}")]
        public async Task<ActionResult<TenderTypeDTO>> UpdateType(int typeId, TenderTypeDTO type)
        {
            var result = Typetenderservice.UpdateType(typeId, type);

            if (result == null)
                return NotFound($"Tender Type With ID : {typeId} Not Found");
            else
                return result;
        }

        [HttpDelete("{typeId}")]
        public async void DeleteType(int typeId)
        {
            if (typeId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            Typetenderservice.DeleteType(typeId);
        }


}

       
}
