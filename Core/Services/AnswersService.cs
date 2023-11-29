using AutoMapper;
using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class AnswersService : IAnswersService
    {
        private readonly SurveysDbContext _context;
        private readonly IMapper _mapper;

        public AnswersService(SurveysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreateAnswerModel answer)
        {
            _context.Responses.Add(_mapper.Map<Answer>(answer));

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var answer = await _context.Responses.FindAsync(id);
            if (answer == null) throw new Exception();//TO DO

            _context.Responses.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Answer answer)
        {
            _context.Responses.Update(answer);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Answer>>? Get()
        {
            //List<CreateAnswerModel> answer = new List<CreateAnswerModel>();
            //foreach (var item in _context.Responses)
            //{
            //    answer.Add(_mapper.Map<CreateAnswerModel>(item));
            //}
            return await _context.Responses.ToListAsync();
        }

        public async Task<Answer?> GetById(int id)
        {
            var answer = await _context.Responses.FindAsync();

            if (answer == null) throw new Exception();//TO DO

            return answer;
        }
    }
}
