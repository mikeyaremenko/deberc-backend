using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebercBackend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    FirstPlayerId = table.Column<int>(type: "int", nullable: true),
                    SecondPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Players_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    FirstPlayerId = table.Column<int>(type: "int", nullable: true),
                    SecondPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Players_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Players_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstTeamId = table.Column<int>(type: "int", nullable: true),
                    SecondTeamId = table.Column<int>(type: "int", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: true),
                    OpenPoints = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Teams_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Teams_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Suit = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    TrickId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Players_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayedCardId = table.Column<int>(type: "int", nullable: true),
                    DutyPlayerId = table.Column<int>(type: "int", nullable: true),
                    OrderSuit = table.Column<int>(type: "int", nullable: false),
                    OrderPlayerId = table.Column<int>(type: "int", nullable: true),
                    VotePlayerId = table.Column<int>(type: "int", nullable: true),
                    BargainRound = table.Column<int>(type: "int", nullable: false),
                    OwnerGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Cards_DisplayedCardId",
                        column: x => x.DisplayedCardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Games_OwnerGameId",
                        column: x => x.OwnerGameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Players_DutyPlayerId",
                        column: x => x.DutyPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Players_OrderPlayerId",
                        column: x => x.OrderPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rounds_Players_VotePlayerId",
                        column: x => x.VotePlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Combinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OwnerTeamId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GameRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combinations_Rounds_GameRoundId",
                        column: x => x.GameRoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Combinations_Teams_OwnerTeamId",
                        column: x => x.OwnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tricks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerTeamId = table.Column<int>(type: "int", nullable: true),
                    StarterPlayerId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    OwnerRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tricks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tricks_Players_StarterPlayerId",
                        column: x => x.StarterPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tricks_Rounds_OwnerRoundId",
                        column: x => x.OwnerRoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tricks_Teams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_OwnerId",
                table: "Cards",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TrickId",
                table: "Cards",
                column: "TrickId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_GameRoundId",
                table: "Combinations",
                column: "GameRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_OwnerTeamId",
                table: "Combinations",
                column: "OwnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DealerId",
                table: "Games",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FirstTeamId",
                table: "Games",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SecondTeamId",
                table: "Games",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_DisplayedCardId",
                table: "Rounds",
                column: "DisplayedCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_DutyPlayerId",
                table: "Rounds",
                column: "DutyPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_OrderPlayerId",
                table: "Rounds",
                column: "OrderPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_OwnerGameId",
                table: "Rounds",
                column: "OwnerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_VotePlayerId",
                table: "Rounds",
                column: "VotePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FirstPlayerId",
                table: "Teams",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SecondPlayerId",
                table: "Teams",
                column: "SecondPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tricks_OwnerRoundId",
                table: "Tricks",
                column: "OwnerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Tricks_StarterPlayerId",
                table: "Tricks",
                column: "StarterPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tricks_WinnerTeamId",
                table: "Tricks",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FirstPlayerId",
                table: "User",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SecondPlayerId",
                table: "User",
                column: "SecondPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Tricks_TrickId",
                table: "Cards",
                column: "TrickId",
                principalTable: "Tricks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Players_OwnerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_DealerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_DutyPlayerId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_OrderPlayerId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_VotePlayerId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_FirstPlayerId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_SecondPlayerId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tricks_Players_StarterPlayerId",
                table: "Tricks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Tricks_TrickId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Combinations");

            migrationBuilder.DropTable(
                name: "Contributor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tricks");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
