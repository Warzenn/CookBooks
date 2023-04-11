using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBooks.Migrations
{
    /// <inheritdoc />
    public partial class RecipeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Recipes",
                newName: "RecipeCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeCategory",
                table: "Recipes",
                newName: "Category");
        }
    }
}
