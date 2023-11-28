namespace Core.ApiModels
{
    public class CreateAnswerModel
    {
        public List<string>? Text { get; set; }
        public int QuestionId { get; set; }
    }
}
