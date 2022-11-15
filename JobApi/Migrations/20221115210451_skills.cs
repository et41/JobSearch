using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobSkillId",
                table: "JobPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.JobSkillId);
                });

            migrationBuilder.CreateTable(
                name: "JobPostJobSkill",
                columns: table => new
                {
                    JobPostsId = table.Column<int>(type: "int", nullable: false),
                    JobSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostJobSkill", x => new { x.JobPostsId, x.JobSkillId });
                    table.ForeignKey(
                        name: "FK_JobPostJobSkill_JobPosts_JobPostsId",
                        column: x => x.JobPostsId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostJobSkill_JobSkill_JobSkillId",
                        column: x => x.JobSkillId,
                        principalTable: "JobSkill",
                        principalColumn: "JobSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostJobSkill_JobSkillId",
                table: "JobPostJobSkill",
                column: "JobSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostJobSkill");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropColumn(
                name: "JobSkillId",
                table: "JobPosts");
        }
    }
}
