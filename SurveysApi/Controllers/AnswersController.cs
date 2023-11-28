using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
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
        // GET: api/<QuestionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateAnswerModel>>> Get()
        {
            return await _service.Get();
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> Get(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public async Task<ActionResult<Answer>> Post([FromBody] CreateAnswerModel answer)
        {
            await _service.Create(answer);

            return Ok(answer);
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Answer answer)
        {
            await _service.Edit(answer);

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
