using Infrastructure.Data.Entities;

namespace Core.ApiModels
{
    public class CreateQuestionModel
    {
        public required string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SurveyId { get; set; }
    }
}
