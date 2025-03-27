using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurisCodeTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddClientToReserve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Reserve",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Reserve");
        }
    }
}
