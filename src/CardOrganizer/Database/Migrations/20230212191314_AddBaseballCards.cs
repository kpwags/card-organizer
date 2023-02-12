using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardOrganizer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseballCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "card");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "application",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "card",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                schema: "application",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserAccountId);
                });

            migrationBuilder.CreateTable(
                name: "BaseballCard",
                schema: "card",
                columns: table => new
                {
                    BaseballCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Flags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_BaseballCard", x => x.BaseballCardId);
                    table.ForeignKey(
                        name: "FK_BaseballCard_AspNetUsers_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "application",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseballCard_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "card",
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
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
                    Year = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flags = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_BaseballCard_BrandId",
                schema: "card",
                table: "BaseballCard",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballCard_UserAccountId",
                schema: "card",
                table: "BaseballCard",
                column: "UserAccountId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballCard",
                schema: "card");

            migrationBuilder.DropTable(
                name: "BaseballCards",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "card");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "application");

            migrationBuilder.DropTable(
                name: "UserAccount",
                schema: "application");
        }
    }
}
