using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;


namespace Biding.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService EvaluationService;
        public EvaluationController(IEvaluationService evaluationService)
        {
            EvaluationService = evaluationService;

        }

        [HttpGet]
        public async Task<ActionResult> GetEvaluation()
        {
            var Result = EvaluationService.GetEvaluation();
            return Ok(true);
        }

        [HttpGet("{evaluationId}")]
        public async Task<ActionResult<EvaluationDTO>> GetEvaluationByID(int evaluationId)
        {
            if (evaluationId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = EvaluationService.GetEvaluationByID(evaluationId);
            if (Result == null)
            {
                return NotFound($"Evaluation With ID : {evaluationId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddEvaluatio([FromBody] EvaluationDTO evaluation)
        {
            EvaluationService.AddEvaluatio(evaluation);
            return Ok(true);
        }

        [HttpPut("{evaluationId}")]
        public async Task<ActionResult<EvaluationDTO>> UpdateEvaluatio(int evaluationId, EvaluationDTO evaluation)
        {
            var result = EvaluationService.UpdateEvaluatio(evaluationId, evaluation);

            if (result == null)
                return NotFound($"Evaluation With ID : {evaluationId} Not Found");
            else
                return result;
        }

        [HttpDelete("{evaluationId}")]
        public async void DeleteEvaluatio(int evaluationId)
        {
            if (evaluationId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            EvaluationService.DeleteEvaluatio(evaluationId);
        }
    }
}
