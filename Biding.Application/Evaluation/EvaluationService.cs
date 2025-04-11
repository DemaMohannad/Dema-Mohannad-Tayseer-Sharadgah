using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Evaluation;

namespace Biding.Application.Evaluation
{
    public class EvaluationService : IEvaluationService
    {
        private readonly BidingDbContext BidingDbContext;

        public EvaluationService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        async Task<IEnumerable<EvaluationDTO>> GetEvaluation()
        {
            var Evaluations = (from Evaluation in this.BidingDbContext.Evaluations
                               select new EvaluationDTO
                               {
                                   BidID = Evaluation.BidID,
                                   score = Evaluation.score,
                                   Comments = Evaluation.Comments

                               }).ToListAsync();
            return await Evaluations;
        }

        async Task<EvaluationDTO> GetEvaluationByID(int evaluationId)
        {
            var Evaluation = this.BidingDbContext.Evaluations.Find(evaluationId);
            if (Evaluation != null)
            {
                var evaluationDTO = new EvaluationDTO
                {
                    BidID = Evaluation.BidID,
                    score = Evaluation.score,
                    Comments = Evaluation.Comments
                };
                return evaluationDTO;
            }
            return null!;
        }

        async Task<bool> AddEvaluatio(EvaluationDTO evaluation)
        {
            var Evaluation = new Domain.Models.Evaluation(evaluation.BidID, evaluation.score, evaluation.Comments);
            this.BidingDbContext.Evaluations.Add(Evaluation);
            await this.BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        Task<EvaluationDTO> UpdateEvaluatio(int evaluationId, EvaluationDTO evaluation)
        {
            var Evaluation = this.BidingDbContext.Evaluations.Find(evaluationId);
            if (Evaluation != null)
            {
                Evaluation.UpdateEvaluation(evaluation.BidID, evaluation.score, evaluation.Comments);
                this.BidingDbContext.SaveChangesAsync();
            }
            return null!;
        }

        void DeleteEvaluatio(int evaluationId)
        {
            var Evaluation = this.BidingDbContext.Evaluations.Find(evaluationId);
            if (Evaluation != null)
            {
                this.BidingDbContext.Evaluations.Remove(Evaluation);
                this.BidingDbContext.SaveChangesAsync();
            }
        }
    }
}
