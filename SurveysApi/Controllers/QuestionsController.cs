using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SurveysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _service;

        public QuestionsController(IQuestionsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            return await _service.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody] CreateQuestionModel question)
        {
            await _service.Create(question);

            return Ok(await _service.GetLastQuestionId());
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditQuestionModel question)
        {
            await _service.Edit(id, question);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
    }
}
