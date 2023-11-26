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

        public async Task Create(SurveyDto survey)
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

        public async Task Edit(SurveyDto survey)
        {
            _context.Surveys.Update(_mapper.Map<Survey>(survey));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Survey>>? Get()
        {
            //return await _context.Surveys
            //                    .Include(s => s.Questions)
            //                    .Select(s => new SurveyDto
            //                    {
            //                        Id = s.Id,
            //                        Title = s.Title,
            //                        Questions = s.Questions.Select(q => new QuestionDto
            //                        {
            //                            Id = q.Id,
            //                            Text = q.Text,
            //                            Type = q.Type,
            //                            Variants = q.Variants
            //                        }).ToList()
            //                    })
            //                    .ToListAsync();
            List<Survey> surveys = await _context.Surveys.Include(s => s.Questions).ThenInclude(q => q.Variants).ToListAsync();

            return surveys;
            //return await _context.Surveys.Include(s => s.Questions).ThenInclude(q => (q as Question).Variants).ToListAsync();
        }

        public async Task<Survey?> GetById(int id)
        {
            //var survey = await _context.Surveys.FindAsync(id);
            var survey = _context.Surveys.Where(s => s.Id == id).Include(s => s.Questions).ThenInclude(q => q.Variants).FirstOrDefault();

            if (survey == null) throw new Exception();//TO DO

            return survey;
        }

        private bool SurveyExists(int id)
        {
            return (_context.Surveys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
