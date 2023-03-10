using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardOrganizer.Database.Migrations
{
    /// <inheritdoc />
    public partial class SplitOutImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                schema: "card",
                table: "BaseballCard",
                newName: "FrontImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "BackImageUrl",
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
                name: "BackImageUrl",
                schema: "card",
                table: "BaseballCard");

            migrationBuilder.RenameColumn(
                name: "FrontImageUrl",
                schema: "card",
                table: "BaseballCard",
                newName: "ImageUrl");
        }
    }
}
