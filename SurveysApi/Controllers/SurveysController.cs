using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveysService _service;

        public SurveysController(ISurveysService service)
        {
            _service = service;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            return await _service.Get();
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            Survey survey = await _service.GetById(id);

            return survey;
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, [FromBody] SurveyModel survey)
        {
            // Опрацювання id
            await _service.Edit(id, survey);

            return Ok();
        }


        // POST: api/Surveys
        [HttpPost]
        public async Task<ActionResult<Survey>> PostSurvey(SurveyModel survey)
        {
            await _service.Create(survey);

            return Ok(survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
    }
}
