using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardOrganizer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseballCardImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "application",
                table: "BaseballCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "card",
                table: "BaseballCard",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "application",
                table: "BaseballCards");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "card",
                table: "BaseballCard");
        }
    }
}
