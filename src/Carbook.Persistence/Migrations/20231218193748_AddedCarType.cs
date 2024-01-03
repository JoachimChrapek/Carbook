using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");
        }
    }
}
