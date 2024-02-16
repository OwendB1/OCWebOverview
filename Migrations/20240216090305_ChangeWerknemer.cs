using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCWebOverview.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWerknemer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "Werknemers");

            migrationBuilder.RenameColumn(
                name: "Initialen",
                table: "Werknemers",
                newName: "Naam");

            migrationBuilder.AddColumn<int>(
                name: "UrenPerWeek",
                table: "Werknemers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrenPerWeek",
                table: "Werknemers");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Werknemers",
                newName: "Initialen");

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "Werknemers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
