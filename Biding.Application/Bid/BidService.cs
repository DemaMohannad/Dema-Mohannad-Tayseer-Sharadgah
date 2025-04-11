using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Bid;

namespace Biding.Application.Bid
{
    public class BidService : IBidService
    {
        private readonly BidingDbContext BidingDbContext;

        public BidService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        async Task<IEnumerable<BidDTO>> GetBid()
        {
            var Bids = (from Bid in this.BidingDbContext.Bids
                        select new BidDTO
                        {
                            TenderID = Bid.TenderID,
                            CompanyName = Bid.CompanyName,
                            TechnicalProposalPath = Bid.TechnicalProposalPath,
                            FinancialProposalPath = Bid.FinancialProposalPath,
                            SubmittedAt = Bid.SubmittedAt,
                            document = Bid.document

                        }).ToListAsync();
            return await Bids;
        }

        async Task<BidDTO> GetBidByID(int bidId)
        {
            var Bid = this.BidingDbContext.Bids.Find(bidId);
            if (Bid != null)
            {
                var bidDTO = new BidDTO
                {
                    TenderID = Bid.TenderID,
                    CompanyName = Bid.CompanyName,
                    TechnicalProposalPath = Bid.TechnicalProposalPath,
                    FinancialProposalPath = Bid.FinancialProposalPath,
                    SubmittedAt = Bid.SubmittedAt,
                    document = Bid.document
                };
                return bidDTO;
            }
            return null!;
        }

        async Task<bool> AddBid(BidDTO bid)
        {
            var Bid = new Domain.Models.Bid(bid.TenderID, bid.CompanyName, bid.TechnicalProposalPath, bid.FinancialProposalPath, bid.SubmittedAt, bid.document);
            this.BidingDbContext.Bids.Add(Bid);
            await this.BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        Task<BidDTO> UpdateBid(int bidId, BidDTO bid)
        {
            var Bid = this.BidingDbContext.Bids.Find(bidId);
            if (Bid != null)
            {
                Bid.UpdateBid(bid.TenderID, bid.CompanyName, bid.TechnicalProposalPath, bid.FinancialProposalPath, bid.SubmittedAt, bid.document);
                this.BidingDbContext.SaveChangesAsync();
            }
            return null!;
        }

        void DeleteBid(int bidId)
        {
            var Bid = this.BidingDbContext.Bids.Find(bidId);
            if (Bid != null)
            {
                this.BidingDbContext.Bids.Remove(Bid);
                this.BidingDbContext.SaveChangesAsync();
            }
        }
    }
}
