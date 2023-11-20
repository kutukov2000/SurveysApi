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

            modelBuilder.Entity("DataAccess.Data.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Prompt = "Question 1",
                            SurveyId = 1
                        },
                        new
                        {
                            Id = 2,
                            Prompt = "Question 2",
                            SurveyId = 1
                        },
                        new
                        {
                            Id = 3,
                            Prompt = "Question 3",
                            SurveyId = 2
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespondentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Responses");
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

            modelBuilder.Entity("DataAccess.Data.Entities.Question", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Survey", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Response", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Survey", null)
                        .WithMany("Responses")
                        .HasForeignKey("SurveyId");
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