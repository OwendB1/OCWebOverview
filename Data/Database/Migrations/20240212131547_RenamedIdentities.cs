using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCWebOverview.Migrations
{
    /// <inheritdoc />
    public partial class RenamedIdentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KantoorLocatie_Id",
                table: "Gemeentes");

            migrationBuilder.DropColumn(
                name: "Adres_Id",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Werknemers",
                newName: "StartDatum");

            migrationBuilder.RenameColumn(
                name: "SirName",
                table: "Werknemers",
                newName: "Initialen");

            migrationBuilder.RenameColumn(
                name: "Initials",
                table: "Werknemers",
                newName: "Achternaam");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActiveInOverview",
                table: "Werknemers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KantoorLocatie_Postcode",
                table: "Gemeentes",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adres_Postcode",
                table: "Clients",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDatum",
                table: "Werknemers",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Initialen",
                table: "Werknemers",
                newName: "SirName");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "Werknemers",
                newName: "Initials");

            migrationBuilder.AlterColumn<string>(
                name: "IsActiveInOverview",
                table: "Werknemers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "KantoorLocatie_Postcode",
                table: "Gemeentes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<Guid>(
                name: "KantoorLocatie_Id",
                table: "Gemeentes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Adres_Postcode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<Guid>(
                name: "Adres_Id",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
