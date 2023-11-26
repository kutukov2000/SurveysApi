namespace Core.ApiModels
{
    public class CreateSurveyModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
