﻿using Core.ApiModels;
using Core.Interfaces;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SurveysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantsController : ControllerBase
    {
        private readonly IVariantsService _service;

        public VariantsController(IVariantsService service)
        {
            _service = service;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variant>>> Get()
        {
            return await _service.Get();
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variant>> Get(int id)
        {
            Variant variant = await _service.GetById(id);

            return variant;
        }

        // GET: api/Surveys/5
        [HttpGet("byQuestionId")]
        public async Task<ActionResult<IEnumerable<Variant>>> GetByQuestionId(int questionIdid)
        {
            List<Variant> variants = await _service.GetByQuestionId(questionIdid);

            return variants;
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Variant variant)
        {
            await _service.Edit(variant);

            return NoContent();
        }

        // POST: api/Surveys
        [HttpPost]
        public async Task<ActionResult<Variant>> Post(CreateVariantModel variant)
        {
            await _service.Create(variant);

            return Ok(variant);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }

        [HttpDelete("byQuestionId")]
        public async Task<IActionResult> DeleteByQuestionId(int questionId)
        {
            await _service.DeleteByQuestionId(questionId);

            return Ok();
        }
    }
}