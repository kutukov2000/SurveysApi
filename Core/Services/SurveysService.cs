using AutoMapper;
using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class SurveysService : ISurveysService
    {
        private readonly SurveysDbContext _context;
        private readonly IMapper _mapper;

        public SurveysService(SurveysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(SurveyDTO survey)
        {
            _context.Surveys.Add(_mapper.Map<Survey>(survey));

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null) throw new Exception();//TO DO

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(SurveyDTO survey)
        {
            _context.Surveys.Update(_mapper.Map<Survey>(survey));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Survey>>? Get()
        {
            return await _context.Surveys.Include(s => s.Questions).ToListAsync();
        }

        public async Task<Survey?> GetById(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);

            if (survey == null) throw new Exception();//TO DO

            return survey;
        }

        private bool SurveyExists(int id)
        {
            return (_context.Surveys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
