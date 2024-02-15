using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCWebOverview.Migrations
{
    /// <inheritdoc />
    public partial class NewCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gemeentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KantoorLocatie_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KantoorLocatie_Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KantoorLocatie_HuisNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KantoorLocatie_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KantoorLocatie_Plaats = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemeentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Werknemers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SirName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColorHexCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActiveInOverview = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Werknemers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Initialen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZorgUren = table.Column<int>(type: "int", nullable: false),
                    HoofdWerknemerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraWerknemerIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZorgType = table.Column<int>(type: "int", nullable: false),
                    GemeenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adres_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adres_Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres_HuisNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres_Plaats = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Gemeentes_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GemeenteId",
                table: "Clients",
                column: "GemeenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Werknemers");

            migrationBuilder.DropTable(
                name: "Gemeentes");
        }
    }
}
