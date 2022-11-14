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

            modelBuilder.Entity("JobApi.Models.JobCategory", b =>
                {
                    b.Property<int?>("JobCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("JobCategoryId"), 1L, 1);

                    b.Property<string>("JobCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobCategoryId");

                    b.ToTable("JobCategories");

                    b.HasData(
                        new
                        {
                            JobCategoryId = 1,
                            JobCategoryName = "backend developer"
                        });
                });

            modelBuilder.Entity("JobApi.Models.JobLocation", b =>
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

            modelBuilder.Entity("JobApi.Models.JobPost", b =>
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

                    b.HasIndex("JobCategoryId");

                    b.HasIndex("JobLocationId");

                    b.HasIndex("JobTypeId");

                    b.ToTable("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobType", b =>
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

            modelBuilder.Entity("JobApi.Models.JobPost", b =>
                {
                    b.HasOne("JobApi.Models.JobCategory", "JobCategory")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobCategoryId");

                    b.HasOne("JobApi.Models.JobLocation", "JobLocation")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobLocationId");

                    b.HasOne("JobApi.Models.JobType", "JobType")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobTypeId");

                    b.Navigation("JobCategory");

                    b.Navigation("JobLocation");

                    b.Navigation("JobType");
                });

            modelBuilder.Entity("JobApi.Models.JobCategory", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobLocation", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("JobApi.Models.JobType", b =>
                {
                    b.Navigation("JobPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
