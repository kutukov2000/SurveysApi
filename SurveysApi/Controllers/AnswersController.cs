using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SurveysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersService _service;

        public AnswersController(IAnswersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("byQuestionId")]
        public async Task<ActionResult<IEnumerable<Answer>>> GetByQuestionId(int questionIdid)
        {
            List<Answer> answers = await _service.GetByQuestionId(questionIdid);

            return answers;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Answer>> Post([FromBody] CreateAnswerModel answer)
        {
            await _service.Create(answer);

            return Ok(answer);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Answer answer)
        {
            await _service.Edit(answer);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("byQuestionId")]
        public async Task<IActionResult> DeleteByQuestionId(int questionId)
        {
            await _service.DeleteByQuestionId(questionId);

            return Ok();
        }
    }
}
