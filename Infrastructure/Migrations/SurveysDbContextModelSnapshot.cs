﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SurveysDbContext))]
    partial class SurveysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Data.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SurveyId = 1,
                            Text = "Question 1",
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            SurveyId = 1,
                            Text = "Question 2",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            SurveyId = 2,
                            Text = "Question 3",
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            SurveyId = 2,
                            Text = "text question",
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            SurveyId = 2,
                            Text = "date question",
                            Type = 3
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            Title = "Survey 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            Title = "Survey 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description 3",
                            Title = "Survey 3"
                        });
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Variants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionId = 1,
                            Text = "helllo"
                        },
                        new
                        {
                            Id = 2,
                            QuestionId = 1,
                            Text = "helllo2"
                        },
                        new
                        {
                            Id = 3,
                            QuestionId = 1,
                            Text = "3"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Answer", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.Survey", null)
                        .WithMany("Responses")
                        .HasForeignKey("SurveyId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Question", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Variant", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Question", "Question")
                        .WithMany("Variants")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Survey", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
