using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_SeekerSkills_SeekerSkillId",
                table: "JobSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobSkills_SeekerSkillId",
                table: "JobSkills");

            migrationBuilder.DropColumn(
                name: "SeekerSkillId",
                table: "JobSkills");

            migrationBuilder.AddColumn<int>(
                name: "JobSkillId",
                table: "SeekerSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeekerSkills_JobSkillId",
                table: "SeekerSkills",
                column: "JobSkillId",
                unique: true,
                filter: "[JobSkillId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SeekerSkills_JobSkills_JobSkillId",
                table: "SeekerSkills",
                column: "JobSkillId",
                principalTable: "JobSkills",
                principalColumn: "JobSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeekerSkills_JobSkills_JobSkillId",
                table: "SeekerSkills");

            migrationBuilder.DropIndex(
                name: "IX_SeekerSkills_JobSkillId",
                table: "SeekerSkills");

            migrationBuilder.DropColumn(
                name: "JobSkillId",
                table: "SeekerSkills");

            migrationBuilder.AddColumn<int>(
                name: "SeekerSkillId",
                table: "JobSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SeekerSkillId",
                table: "JobSkills",
                column: "SeekerSkillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_SeekerSkills_SeekerSkillId",
                table: "JobSkills",
                column: "SeekerSkillId",
                principalTable: "SeekerSkills",
                principalColumn: "SeekerSkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
