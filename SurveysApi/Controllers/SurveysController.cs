using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            Survey survey = await _service.GetById(id);

            return survey;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, [FromBody] SurveyModel survey)
        {
            await _service.Edit(id, survey);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Survey>> PostSurvey(SurveyModel survey)
        {
            await _service.Create(survey);

            return Ok(survey);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
    }
}
