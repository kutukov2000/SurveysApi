﻿using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Interfaces
{
    public interface IAnswersService
    {
        Task<List<Answer>>? Get();
        Task<Answer?> GetById(int id);
        Task<List<Answer>>? GetByQuestionId(int questionId);
        Task Create(CreateAnswerModel answer);
        Task Edit(Answer answer);
        Task Delete(int id);
        Task DeleteByQuestionId(int questionId);
    }
}
