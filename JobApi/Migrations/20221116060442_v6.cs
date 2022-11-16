using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Company_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompanyId");

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
                    ExperienceYear = table.Column<int>(type: "int", nullable: false),
                    SeekerProfieId = table.Column<int>(type: "int", nullable: true)
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
                    JobSkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerSkills", x => x.SeekerSkillId);
                    table.ForeignKey(
                        name: "FK_SeekerSkills_JobSkills_JobSkillId",
                        column: x => x.JobSkillId,
                        principalTable: "JobSkills",
                        principalColumn: "JobSkillId");
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
                    SeekerEducationDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerProfiles", x => x.SeekerProfileId);
                    table.ForeignKey(
                        name: "FK_SeekerProfiles_SeekerEducationDetails_SeekerEducationDetailId",
                        column: x => x.SeekerEducationDetailId,
                        principalTable: "SeekerEducationDetails",
                        principalColumn: "SeekerEducationDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeekerProfiles_SeekerExperienceDetails_SeekerExperienceDetailId",
                        column: x => x.SeekerExperienceDetailId,
                        principalTable: "SeekerExperienceDetails",
                        principalColumn: "SeekerExperienceDetailId");
                });

            migrationBuilder.CreateTable(
                name: "SeekerProfileSeekerSkill",
                columns: table => new
                {
                    SeekerSkilsSeekerSkillId = table.Column<int>(type: "int", nullable: false),
                    seekerProfilesSeekerProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeekerProfileSeekerSkill", x => new { x.SeekerSkilsSeekerSkillId, x.seekerProfilesSeekerProfileId });
                    table.ForeignKey(
                        name: "FK_SeekerProfileSeekerSkill_SeekerProfiles_seekerProfilesSeekerProfileId",
                        column: x => x.seekerProfilesSeekerProfileId,
                        principalTable: "SeekerProfiles",
                        principalColumn: "SeekerProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeekerProfileSeekerSkill_SeekerSkills_SeekerSkilsSeekerSkillId",
                        column: x => x.SeekerSkilsSeekerSkillId,
                        principalTable: "SeekerSkills",
                        principalColumn: "SeekerSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfiles_SeekerEducationDetailId",
                table: "SeekerProfiles",
                column: "SeekerEducationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfiles_SeekerExperienceDetailId",
                table: "SeekerProfiles",
                column: "SeekerExperienceDetailId",
                unique: true,
                filter: "[SeekerExperienceDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SeekerProfileSeekerSkill_seekerProfilesSeekerProfileId",
                table: "SeekerProfileSeekerSkill",
                column: "seekerProfilesSeekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SeekerSkills_JobSkillId",
                table: "SeekerSkills",
                column: "JobSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "SeekerProfileSeekerSkill");

            migrationBuilder.DropTable(
                name: "SeekerProfiles");

            migrationBuilder.DropTable(
                name: "SeekerSkills");

            migrationBuilder.DropTable(
                name: "SeekerEducationDetails");

            migrationBuilder.DropTable(
                name: "SeekerExperienceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Company_CompanyId",
                table: "JobPosts",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId");
        }
    }
}
