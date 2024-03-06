using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRateApp.Migrations
{
    /// <inheritdoc />
    public partial class addedINTtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ation",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ation",
                table: "Movies");
        }
    }
}
