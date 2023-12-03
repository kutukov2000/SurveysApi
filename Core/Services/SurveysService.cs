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

        public async Task Create(SurveyModel survey)
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

        public async Task Edit(int id, SurveyModel survey)
        {
            var existingSurvey = await _context.Surveys.FindAsync(id);

            if (existingSurvey == null)
            {
                throw new Exception();//TO DO
            }

            _mapper.Map(survey, existingSurvey);

            await _context.SaveChangesAsync();
        }


        public async Task<List<Survey>>? Get()
        {
            List<Survey> surveys = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Variants)
                .AsSplitQuery()
                .ToListAsync();

            return surveys;
        }

        public async Task<Survey?> GetById(int id)
        {
            var survey = _context.Surveys
                .Where(s => s.Id == id)
                .Include(s => s.Questions)
                .ThenInclude(q => q.Variants)
                .AsSplitQuery()
                .FirstOrDefault();

            if (survey == null) throw new Exception();//TO DO

            return survey;
        }
    }
}
