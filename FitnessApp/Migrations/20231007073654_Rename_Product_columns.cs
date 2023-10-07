using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Product_columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "Products",
                newName: "ProteinAmount");

            migrationBuilder.RenameColumn(
                name: "Fats",
                table: "Products",
                newName: "FatsAmount");

            migrationBuilder.RenameColumn(
                name: "Carbs",
                table: "Products",
                newName: "CarbsAmount");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Products",
                newName: "CaloriesAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProteinAmount",
                table: "Products",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "FatsAmount",
                table: "Products",
                newName: "Fats");

            migrationBuilder.RenameColumn(
                name: "CarbsAmount",
                table: "Products",
                newName: "Carbs");

            migrationBuilder.RenameColumn(
                name: "CaloriesAmount",
                table: "Products",
                newName: "Calories");
        }
    }
}
