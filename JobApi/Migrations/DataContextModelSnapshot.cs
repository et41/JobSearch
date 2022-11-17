﻿// <auto-generated />
using System;
using JobApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobApi.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobCategory", b =>
                {
                    b.Property<int?>("JobCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("JobCategoryId"), 1L, 1);

                    b.Property<string>("JobCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("JobCategoryId");

                    b.HasIndex("JobCategoryName")
                        .IsUnique();

                    b.ToTable("JobCategories");

                    b.HasData(
                        new
                        {
                            JobCategoryId = 1,
                            JobCategoryName = "backend developer"
                        });
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobLocation", b =>
                {
                    b.Property<int>("JobLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobLocationId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobLocationId");

                    b.ToTable("JobLocations");

                    b.HasData(
                        new
                        {
                            JobLocationId = 1,
                            City = "Istanbul",
                            Country = "Turkey",
                            StreetAddress = "Buyukdere"
                        });
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("JobCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobLocationId")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<string>("JobTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobCategoryId");

                    b.HasIndex("JobLocationId");

                    b.HasIndex("JobTypeId");

                    b.ToTable("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobSkill", b =>
                {
                    b.Property<int?>("JobSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("JobSkillId"), 1L, 1);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("JobSkillId");

                    b.HasIndex("SkillName")
                        .IsUnique();

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobType", b =>
                {
                    b.Property<int>("JobTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobTypeId"), 1L, 1);

                    b.Property<string>("JobTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobTypeId");

                    b.ToTable("JobTypes");

                    b.HasData(
                        new
                        {
                            JobTypeId = 1,
                            JobTypeName = "remote"
                        });
                });

            modelBuilder.Entity("JobApi.Models.SeekerEducationDetail", b =>
                {
                    b.Property<int>("SeekerEducationDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeekerEducationDetailId"), 1L, 1);

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeekerEducationDetailId");

                    b.ToTable("SeekerEducationDetails");
                });

            modelBuilder.Entity("JobApi.Models.SeekerExperienceDetail", b =>
                {
                    b.Property<int>("SeekerExperienceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeekerExperienceDetailId"), 1L, 1);

                    b.Property<int>("ExperienceYear")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isWorking")
                        .HasColumnType("bit");

                    b.HasKey("SeekerExperienceDetailId");

                    b.ToTable("SeekerExperienceDetails");
                });

            modelBuilder.Entity("JobApi.Models.SeekerProfile", b =>
                {
                    b.Property<int?>("SeekerProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SeekerProfileId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeekerEducationDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("SeekerExperienceDetailId")
                        .HasColumnType("int");

                    b.HasKey("SeekerProfileId");

                    b.HasIndex("SeekerEducationDetailId");

                    b.HasIndex("SeekerExperienceDetailId");

                    b.ToTable("SeekerProfiles");
                });

            modelBuilder.Entity("JobApi.Models.SeekerSkill", b =>
                {
                    b.Property<int>("SeekerSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeekerSkillId"), 1L, 1);

                    b.Property<int?>("JobSkillId")
                        .HasColumnType("int");

                    b.Property<string>("SeekerSkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeekerSkillId");

                    b.HasIndex("JobSkillId")
                        .IsUnique()
                        .HasFilter("[JobSkillId] IS NOT NULL");

                    b.ToTable("SeekerSkills");
                });

            modelBuilder.Entity("JobPostJobSkill", b =>
                {
                    b.Property<int>("JobPostsId")
                        .HasColumnType("int");

                    b.Property<int>("JobSkillsJobSkillId")
                        .HasColumnType("int");

                    b.HasKey("JobPostsId", "JobSkillsJobSkillId");

                    b.HasIndex("JobSkillsJobSkillId");

                    b.ToTable("JobPostJobSkill");
                });

            modelBuilder.Entity("SeekerProfileSeekerSkill", b =>
                {
                    b.Property<int>("SeekerSkillsSeekerSkillId")
                        .HasColumnType("int");

                    b.Property<int>("seekerProfilesSeekerProfileId")
                        .HasColumnType("int");

                    b.HasKey("SeekerSkillsSeekerSkillId", "seekerProfilesSeekerProfileId");

                    b.HasIndex("seekerProfilesSeekerProfileId");

                    b.ToTable("SeekerProfileSeekerSkill");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobPost", b =>
                {
                    b.HasOne("JobApi.Models.Company", "Company")
                        .WithMany("JobPosts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("JobApi.Models.JobPostModels.JobCategory", "JobCategory")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobCategoryId");

                    b.HasOne("JobApi.Models.JobPostModels.JobLocation", "JobLocation")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobLocationId");

                    b.HasOne("JobApi.Models.JobPostModels.JobType", "JobType")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobTypeId");

                    b.Navigation("Company");

                    b.Navigation("JobCategory");

                    b.Navigation("JobLocation");

                    b.Navigation("JobType");
                });

            modelBuilder.Entity("JobApi.Models.SeekerProfile", b =>
                {
                    b.HasOne("JobApi.Models.SeekerEducationDetail", "SeekerEducationDetail")
                        .WithMany()
                        .HasForeignKey("SeekerEducationDetailId");

                    b.HasOne("JobApi.Models.SeekerExperienceDetail", "SeekerExperienceDetail")
                        .WithMany()
                        .HasForeignKey("SeekerExperienceDetailId");

                    b.Navigation("SeekerEducationDetail");

                    b.Navigation("SeekerExperienceDetail");
                });

            modelBuilder.Entity("JobApi.Models.SeekerSkill", b =>
                {
                    b.HasOne("JobApi.Models.JobPostModels.JobSkill", "JobSkill")
                        .WithOne("SeekerSkill")
                        .HasForeignKey("JobApi.Models.SeekerSkill", "JobSkillId");

                    b.Navigation("JobSkill");
                });

            modelBuilder.Entity("JobPostJobSkill", b =>
                {
                    b.HasOne("JobApi.Models.JobPostModels.JobPost", null)
                        .WithMany()
                        .HasForeignKey("JobPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApi.Models.JobPostModels.JobSkill", null)
                        .WithMany()
                        .HasForeignKey("JobSkillsJobSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeekerProfileSeekerSkill", b =>
                {
                    b.HasOne("JobApi.Models.SeekerSkill", null)
                        .WithMany()
                        .HasForeignKey("SeekerSkillsSeekerSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApi.Models.SeekerProfile", null)
                        .WithMany()
                        .HasForeignKey("seekerProfilesSeekerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobApi.Models.Company", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobCategory", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobLocation", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobSkill", b =>
                {
                    b.Navigation("SeekerSkill");
                });

            modelBuilder.Entity("JobApi.Models.JobPostModels.JobType", b =>
                {
                    b.Navigation("JobPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
