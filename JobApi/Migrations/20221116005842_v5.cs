using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "JobSkills",
                columns: table => new
                {
                    JobSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.JobSkillId);
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
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: true),
                    JobLocationId = table.Column<int>(type: "int", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
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
                name: "IX_JobSkills_SkillName",
                table: "JobSkills",
                column: "SkillName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostJobSkill");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobLocations");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
