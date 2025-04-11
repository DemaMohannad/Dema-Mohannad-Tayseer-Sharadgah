using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Tender;

namespace Biding.Application.Tender
{
    public class TenderService : ITenderService
    {
        private readonly BidingDbContext BidingDbContext;

        public TenderService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        async Task<IEnumerable<TenderDTO>> GetTender()
        {
            var Tenders = (from Tender in this.BidingDbContext.Tenders
                           select new TenderDTO
                           {
                               UserID = Tender.UserID,
                               TenderTitle = Tender.TenderTitle,
                               TenderReferenceNumber = Tender.TenderReferenceNumber,
                               IssueDate = Tender.IssueDate,
                               ClosingDate = Tender.ClosingDate,
                               TypeID = Tender.TypeID,
                               TenderType = Tender.TenderType,
                               CategoryID = Tender.CategoryID,
                               TenderCategory = Tender.TenderCategory,
                               BudgetRange = Tender.BudgetRange,
                               ContactEmail = Tender.ContactEmail,
                               Description = Tender.Description,
                               document = Tender.document

                           }).ToListAsync();
            return await Tenders;
        }

        async Task<TenderDTO> GetTenderByID(int tenderId)
        {
            var Tender = this.BidingDbContext.Tenders.Find(tenderId);
            if (Tender != null)
            {
                var tenderDTO = new TenderDTO
                {
                    UserID = Tender.UserID,
                    TenderTitle = Tender.TenderTitle,
                    TenderReferenceNumber = Tender.TenderReferenceNumber,
                    IssueDate = Tender.IssueDate,
                    ClosingDate = Tender.ClosingDate,
                    TypeID = Tender.TypeID,
                    TenderType = Tender.TenderType,
                    CategoryID = Tender.CategoryID,
                    TenderCategory = Tender.TenderCategory,
                    BudgetRange = Tender.BudgetRange,
                    ContactEmail = Tender.ContactEmail,
                    Description = Tender.Description,
                    document = Tender.document
                };
                return tenderDTO;
            }
            return null!;
        }

        async Task<bool> AddTender(TenderDTO tender)
        {
            var Tender = new Domain.Models.Tender(tender.UserID, tender.TenderTitle, tender.TenderReferenceNumber, tender.IssueDate, tender.ClosingDate, tender.TypeID, tender.TenderType, tender.CategoryID, tender.TenderCategory, tender.BudgetRange, tender.ContactEmail, tender.Description, tender.document);
            this.BidingDbContext.Tenders.Add(Tender);
            await this.BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        Task<TenderDTO> UpdateTender(int tenderId, TenderDTO tender)
        {
            var Tender = this.BidingDbContext.Tenders.Find(tenderId);
            if (Tender != null)
            {
                Tender.UpdateTender(tender.UserID, tender.TenderTitle, tender.TenderReferenceNumber, tender.IssueDate, tender.ClosingDate, tender.TypeID, tender.TenderType, tender.CategoryID, tender.TenderCategory, tender.BudgetRange, tender.ContactEmail, tender.Description, tender.document);
                this.BidingDbContext.SaveChangesAsync();
            }
            return null!;
        }

        void DeleteTender(int tenderId)
        {
            var Tender = this.BidingDbContext.Tenders.Find(tenderId);
            if (Tender != null)
            {
                this.BidingDbContext.Tenders.Remove(Tender);
                this.BidingDbContext.SaveChangesAsync();
            }
        }
    }
}
