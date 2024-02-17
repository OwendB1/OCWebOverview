using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCWebOverview.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClientInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraWerknemerIds",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ZorgUren",
                table: "Clients",
                newName: "ZorgUrenHoofd");

            migrationBuilder.AddColumn<Guid>(
                name: "ExtraWerknemerId",
                table: "Clients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZorgUrenExtra",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraWerknemerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ZorgUrenExtra",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ZorgUrenHoofd",
                table: "Clients",
                newName: "ZorgUren");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ExtraWerknemerIds",
                table: "Clients",
                type: "uuid[]",
                nullable: false);
        }
    }
}
