using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class Change_Meals_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarbsAmount",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FatsAmount",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ProteinAmount",
                table: "Meals");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Meals",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Meals");

            migrationBuilder.AddColumn<double>(
                name: "CarbsAmount",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FatsAmount",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProteinAmount",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
