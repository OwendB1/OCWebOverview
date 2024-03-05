using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCWebOverview.Migrations
{
    /// <inheritdoc />
    public partial class RenameInitialenToVoornaam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Initialen",
                table: "Clients",
                newName: "Voornaam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "Clients",
                newName: "Initialen");
        }
    }
}
