using Infrastructure.Data.Entities;

namespace DataAccess.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public QuestionType Type { get; set; }

        public List<Variant>? Variants { get; set; }
        public List<Answer>? Answers { get; set; }

        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}
