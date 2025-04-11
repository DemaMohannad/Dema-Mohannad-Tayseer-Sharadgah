using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.Evaluation;

namespace Biding.Application.Evaluation
{
    public interface IEvaluationService
    {
        Task<IEnumerable<EvaluationDTO>> GetEvaluation();

        Task<EvaluationDTO> GetEvaluationByID(int evaluationId);

        Task<bool> AddEvaluatio(EvaluationDTO evaluation);

        Task<EvaluationDTO> UpdateEvaluatio(int evaluationId, EvaluationDTO evaluation);

        void DeleteEvaluatio(int evaluationId);
    }
}
