using DataAccess.Data.Entities;
namespace Infrastructure.Data.Entities
{
    public class Variant
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
