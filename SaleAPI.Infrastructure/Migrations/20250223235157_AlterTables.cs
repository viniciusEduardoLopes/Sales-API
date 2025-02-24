using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "SalesProducts",
                newName: "Quantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SalesProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SalesProducts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SalesProducts",
                newName: "Quantidade");
        }
    }
}
