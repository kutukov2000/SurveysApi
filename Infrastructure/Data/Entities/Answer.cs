using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        [NotMapped]
        public List<string>? Text { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
