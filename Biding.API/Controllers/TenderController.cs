using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;


namespace Biding.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenderController : ControllerBase
    {

        private readonly ITenderService TenderService;
        public TenderController(ITenderService tenderService)
        {
            TenderService = tenderService;
        }

        [HttpGet]
        public async Task<ActionResult>GetTender()
        {
            var Result = TenderService.GetTender();
            return Ok(true);
        }

        [HttpGet("{tenderId}")]
        public async Task<ActionResult<TenderDTO>>GetTenderByID(int tenderId)
        {
            if (tenderId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = TenderService.GetTenderByID(tenderId);
            if (Result == null)
            {
                return NotFound($"Tender With ID : {tenderId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>>AddTender([FromBody] TenderDTO tender)
        {
            TenderService.AddTender(tender);
            return Ok(true);
        }

        [HttpPut("{tenderId}")]
        public async Task<ActionResult<TenderDTO>>UpdateTender(int tenderId, TenderDTO tender)
        {
            var result = TenderService.UpdateTender(tenderId, tender);

            if (result == null)
                return NotFound($"Tender With ID : {tenderId} Not Found");
            else
                return result;
        }

        [HttpDelete("{tenderId}")]
        public async void DeleteTender(int tenderId)
        {
            if (tenderId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            TenderService.DeleteTender(tenderId);
        }
    }
}
