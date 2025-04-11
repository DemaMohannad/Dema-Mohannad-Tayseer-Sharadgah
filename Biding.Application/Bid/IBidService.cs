using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Bid;

namespace Biding.Application.Bid
{
    public interface IBidService
    {
        Task<IEnumerable<BidDTO>> GetBid();

        Task<BidDTO> GetBidByID(int bidId);

        Task<bool> AddBid(BidDTO bid);

        Task<BidDTO> UpdateBid(int bidId, BidDTO bid);

        void DeleteBid(int bidId);
    }
}
