using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
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
        // GET: api/<QuestionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return await _service.Get();
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody] CreateQuestionModel question)
        {
            await _service.Create(question);

            return Ok(question);
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Question question)
        {
            await _service.Edit(question);

            return NoContent();
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
    }
}
