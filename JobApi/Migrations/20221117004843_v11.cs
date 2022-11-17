using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobLocations",
                columns: table => new
                {
                    JobLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocations", x => x.JobLocationId);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SeekerEducationDetails",
                columns: table => new
                {
                    SeekerEducationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerEducationDetails", x => x.SeekerEducationDetailId);
                });

            migrationBuilder.CreateTable(
                name: "SeekerExperienceDetails",
                columns: table => new
                {
                    SeekerExperienceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isWorking = table.Column<bool>(type: "bit", nullable: false),
                    ExperienceYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerExperienceDetails", x => x.SeekerExperienceDetailId);
                });

            migrationBuilder.CreateTable(
                name: "SeekerSkills",
                columns: table => new
                {
                    SeekerSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeekerSkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerSkills", x => x.SeekerSkillId);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: true),
                    JobLocationId = table.Column<int>(type: "int", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_JobPosts_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId");
                    table.ForeignKey(
                        name: "FK_JobPosts_JobLocations_JobLocationId",
                        column: x => x.JobLocationId,
                        principalTable: "JobLocations",
                        principalColumn: "JobLocationId");
                    table.ForeignKey(
                        name: "FK_JobPosts_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "JobTypeId");
                });

            migrationBuilder.CreateTable(
                name: "SeekerProfiles",
                columns: table => new
                {
                    SeekerProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeekerExperienceDetailId = table.Column<int>(type: "int", nullable: true),
                    SeekerEducationDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerProfiles", x => x.SeekerProfileId);
                    table.ForeignKey(
                        name: "FK_SeekerProfiles_SeekerEducationDetails_SeekerEducationDetailId",
                        column: x => x.SeekerEducationDetailId,
                        principalTable: "SeekerEducationDetails",
                        principalColumn: "SeekerEducationDetailId");
                    table.ForeignKey(
                        name: "FK_SeekerProfiles_SeekerExperienceDetails_SeekerExperienceDetailId",
                        column: x => x.SeekerExperienceDetailId,
                        principalTable: "SeekerExperienceDetails",
                        principalColumn: "SeekerExperienceDetailId");
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeekerSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.JobSkillId);
                    table.ForeignKey(
                        name: "FK_JobSkills_SeekerSkills_SeekerSkillId",
                        column: x => x.SeekerSkillId,
                        principalTable: "SeekerSkills",
                        principalColumn: "SeekerSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeekerProfileSeekerSkill",
                columns: table => new
                {
                    SeekerSkillsSeekerSkillId = table.Column<int>(type: "int", nullable: false),
                    seekerProfilesSeekerProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerProfileSeekerSkill", x => new { x.SeekerSkillsSeekerSkillId, x.seekerProfilesSeekerProfileId });
                    table.ForeignKey(
                        name: "FK_SeekerProfileSeekerSkill_SeekerProfiles_seekerProfilesSeekerProfileId",
                        column: x => x.seekerProfilesSeekerProfileId,
                        principalTable: "SeekerProfiles",
                        principalColumn: "SeekerProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeekerProfileSeekerSkill_SeekerSkills_SeekerSkillsSeekerSkillId",
                        column: x => x.SeekerSkillsSeekerSkillId,
                        principalTable: "SeekerSkills",
                        principalColumn: "SeekerSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostJobSkill",
                columns: table => new
                {
                    JobPostsId = table.Column<int>(type: "int", nullable: false),
                    JobSkillsJobSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostJobSkill", x => new { x.JobPostsId, x.JobSkillsJobSkillId });
                    table.ForeignKey(
                        name: "FK_JobPostJobSkill_JobPosts_JobPostsId",
                        column: x => x.JobPostsId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostJobSkill_JobSkills_JobSkillsJobSkillId",
                        column: x => x.JobSkillsJobSkillId,
                        principalTable: "JobSkills",
                        principalColumn: "JobSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "JobCategoryName" },
                values: new object[] { 1, "backend developer" });

            migrationBuilder.InsertData(
                table: "JobLocations",
                columns: new[] { "JobLocationId", "City", "Country", "StreetAddress" },
                values: new object[] { 1, "Istanbul", "Turkey", "Buyukdere" });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "JobTypeName" },
                values: new object[] { 1, "remote" });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories",
                column: "JobCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostJobSkill_JobSkillsJobSkillId",
                table: "JobPostJobSkill",
                column: "JobSkillsJobSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobCategoryId",
                table: "JobPosts",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobLocationId",
                table: "JobPosts",
                column: "JobLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobTypeId",
                table: "JobPosts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SeekerSkillId",
                table: "JobSkills",
                column: "SeekerSkillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillName",
                table: "JobSkills",
                column: "SkillName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfiles_SeekerEducationDetailId",
                table: "SeekerProfiles",
                column: "SeekerEducationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfiles_SeekerExperienceDetailId",
                table: "SeekerProfiles",
                column: "SeekerExperienceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfileSeekerSkill_seekerProfilesSeekerProfileId",
                table: "SeekerProfileSeekerSkill",
                column: "seekerProfilesSeekerProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostJobSkill");

            migrationBuilder.DropTable(
                name: "SeekerProfileSeekerSkill");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "SeekerProfiles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobLocations");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "SeekerSkills");

            migrationBuilder.DropTable(
                name: "SeekerEducationDetails");

            migrationBuilder.DropTable(
                name: "SeekerExperienceDetails");
        }
    }
}
