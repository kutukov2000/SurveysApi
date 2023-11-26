﻿using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Interfaces
{
    public interface IQuestionsService
    {
        Task<List<Question>>? Get();
        Task<Question?> GetById(int id);
        Task Create(CreateQuestionModel question);
        Task Edit(Question question);
        Task Delete(int id);
    }
}
