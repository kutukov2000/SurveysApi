using DataAccess.Data.Entities;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Data
{
    public class SurveysDbContext : IdentityDbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Responses { get; set; }
        public DbSet<Variant> Variants { get; set; }

        public SurveysDbContext() { }
        public SurveysDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=tcp:kutukov-artur-azure-server.database.windows.net,1433;Initial Catalog=SurveysDb;Persist Security Info=False;User ID=kutukov2000;Password=#4\"^%9c=F=.au_2\r\n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Survey>().HasData(
                new Survey
                {
                    Id = 1,
                    Title = "Survey 1",
                    Description = "Description 1",
                },
                new Survey
                {
                    Id = 2,
                    Title = "Survey 2",
                    Description = "Description 2",
                },
                new Survey
                {
                    Id = 3,
                    Title = "Survey 3",
                    Description = "Description 3",
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    SurveyId = 1,
                    Text = "Question 1",
                    Type = QuestionType.CheckBox
                },
                new Question
                {
                    Id = 2,
                    SurveyId = 1,
                    Text = "Question 2",
                    Type = QuestionType.RadioButton
                },
                new Question
                {
                    Id = 3,
                    SurveyId = 2,
                    Text = "Question 3",
                    Type = QuestionType.CheckBox
                },
                new Question
                {
                    Id = 4,
                    SurveyId = 2,
                    Text = "text question",
                    Type = QuestionType.Text
                },
                new Question
                {
                    Id = 5,
                    SurveyId = 2,
                    Text = "date question",
                    Type = QuestionType.Date
                }
            );
            modelBuilder.Entity<Variant>().HasData(
                    new Variant
                    {
                        Id = 1,
                        QuestionId = 1,
                        Text = "helllo"
                    },
                    new Variant
                    {
                        Id = 2,
                        QuestionId = 1,
                        Text = "helllo2"
                    },
                    new Variant
                    {
                        Id = 3,
                        QuestionId = 1,
                        Text = "3"
                    }
                );
        }
    }
}
