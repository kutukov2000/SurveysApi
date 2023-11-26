using Infrastructure.Data.Entities;

namespace Core.ApiModels
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Variants { get; set; }
    }
}
