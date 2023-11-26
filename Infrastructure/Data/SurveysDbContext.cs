using DataAccess.Data.Entities;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Data
{
    public class SurveysDbContext : DbContext
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

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SurveysDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
                    Text = "Question 1"
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
