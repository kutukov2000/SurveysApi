using AutoMapper;
using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly SurveysDbContext _context;
        private readonly IMapper _mapper;

        public QuestionsService(SurveysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreateQuestionModel question)
        {
            _context.Questions.Add(_mapper.Map<Question>(question));

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) throw new Exception();//TO DO

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Question question)
        {
            _context.Questions.Update(question);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Question>>? Get()
        {
            return await _context.Questions.Include(q => q.Variants).ToListAsync();
        }

        public async Task<Question?> GetById(int id)
        {
            var question = _context.Questions.Where(q => q.Id == id).Include(q => q.Variants).FirstOrDefault();

            if (question == null) throw new Exception();//TO DO

            return question;
        }
    }
}
