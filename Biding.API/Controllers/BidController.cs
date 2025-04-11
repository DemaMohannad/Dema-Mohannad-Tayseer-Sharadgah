using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;

namespace Biding.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService BidService;
        public BidController(IBidService bidService)
        {
            BidService = bidService;
        }

        [HttpGet]
        public async Task<ActionResult>GetBid()
        {
            var Result = BidService.GetBid();
            return Ok(true);
        }

        [HttpGet("{bidId}")]
        public async Task<ActionResult<BidDTO>>GetBidByID(int bidId)
        {
            if (bidId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = BidService.GetBidByID(bidId);
            if (Result == null)
            {
                return NotFound($"Bid With ID : {bidId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddBid([FromBody] BidDTO bid)
        {
            BidService.AddBid(bid);
            return Ok(true);
        }

        [HttpPut("{bidId}")]
        public async Task<ActionResult<BidDTO>>UpdateBid(int bidId, BidDTO bid)
        {
            var result = BidService.UpdateBid(bidId, bid);

            if (result == null)
                return NotFound($"Bid With ID : {bidId} Not Found");
            else
                return result;
        }

        [HttpDelete("{bidId}")]
        public async void DeleteBid(int bidId)
        {
            if (bidId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            BidService.DeleteBid(bidId);
        }
    }
}
