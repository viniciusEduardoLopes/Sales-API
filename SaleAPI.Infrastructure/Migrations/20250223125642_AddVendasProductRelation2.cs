using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVendasProductRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
