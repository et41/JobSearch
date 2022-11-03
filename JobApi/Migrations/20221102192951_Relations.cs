using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_jobPosts",
                table: "jobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobLocations",
                table: "jobLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobCategories",
                table: "jobCategories");

            migrationBuilder.RenameTable(
                name: "jobPosts",
                newName: "JobPosts");

            migrationBuilder.RenameTable(
                name: "jobLocations",
                newName: "JobLocations");

            migrationBuilder.RenameTable(
                name: "jobCategories",
                newName: "JobCategories");

            migrationBuilder.AlterColumn<int>(
                name: "JobLocationId",
                table: "JobPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobLocations",
                table: "JobLocations",
                column: "JobLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategories",
                table: "JobCategories",
                column: "JobCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobCategories_JobCategoryId",
                table: "JobPosts",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobLocations_JobLocationId",
                table: "JobPosts",
                column: "JobLocationId",
                principalTable: "JobLocations",
                principalColumn: "JobLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobTypes_JobTypeId",
                table: "JobPosts",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "JobTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobCategories_JobCategoryId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobLocations_JobLocationId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobTypes_JobTypeId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobCategoryId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobLocationId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobTypeId",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobLocations",
                table: "JobLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategories",
                table: "JobCategories");

            migrationBuilder.RenameTable(
                name: "JobPosts",
                newName: "jobPosts");

            migrationBuilder.RenameTable(
                name: "JobLocations",
                newName: "jobLocations");

            migrationBuilder.RenameTable(
                name: "JobCategories",
                newName: "jobCategories");

            migrationBuilder.AlterColumn<int>(
                name: "JobLocationId",
                table: "jobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobPosts",
                table: "jobPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobLocations",
                table: "jobLocations",
                column: "JobLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobCategories",
                table: "jobCategories",
                column: "JobCategoryId");
        }
    }
}
