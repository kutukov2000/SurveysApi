using Infrastructure.Data.Entities;

namespace Core.ApiModels
{
    public class EditQuestionModel
    {
        public required string Text { get; set; }
        public QuestionType Type { get; set; }
    }
}
