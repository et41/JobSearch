using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApi.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories");

            migrationBuilder.AlterColumn<string>(
                name: "JobCategoryName",
                table: "JobCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobCategoryName",
                table: "JobCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_JobCategoryName",
                table: "JobCategories",
                column: "JobCategoryName",
                unique: true,
                filter: "[JobCategoryName] IS NOT NULL");
        }
    }
}
