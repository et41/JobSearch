using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "JobCategoryName",
                table: "JobPosts");

            migrationBuilder.AlterColumn<string>(
                name: "JobCategoryName",
                table: "JobCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories",
                column: "JobCategoryName",
                unique: true,
                filter: "[JobCategoryName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories");

            migrationBuilder.AddColumn<string>(
                name: "JobCategoryName",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "JobCategoryName",
                table: "JobCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories",
                column: "JobCategoryName",
                unique: true);
        }
    }
}
