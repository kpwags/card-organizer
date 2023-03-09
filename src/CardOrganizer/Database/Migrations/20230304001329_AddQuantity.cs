using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardOrganizer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballCards",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "application");

            migrationBuilder.DropTable(
                name: "UserAccount",
                schema: "application");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "card",
                table: "BaseballCard",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "card",
                table: "BaseballCard");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "application",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                schema: "application",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserAccountId);
                });

            migrationBuilder.CreateTable(
                name: "BaseballCards",
                schema: "application",
                columns: table => new
                {
                    BaseballCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    Flags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballCards", x => x.BaseballCardId);
                    table.ForeignKey(
                        name: "FK_BaseballCards_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "application",
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballCards_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "application",
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseballCards_BrandId",
                schema: "application",
                table: "BaseballCards",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballCards_UserAccountId",
                schema: "application",
                table: "BaseballCards",
                column: "UserAccountId");
        }
    }
}
