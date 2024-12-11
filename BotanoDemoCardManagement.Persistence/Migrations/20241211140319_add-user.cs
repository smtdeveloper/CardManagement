using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotanoDemoCardManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCardAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardQuestionChoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCardAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCardAnswers_CardQuestionChoices_CardQuestionChoiceId",
                        column: x => x.CardQuestionChoiceId,
                        principalTable: "CardQuestionChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCardAnswers_CardQuestions_CardQuestionId",
                        column: x => x.CardQuestionId,
                        principalTable: "CardQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCardAnswers_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCardAnswers_Cards_CardId1",
                        column: x => x.CardId1,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCardAnswers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCardAnswers_CardId",
                table: "UserCardAnswers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardAnswers_CardId1",
                table: "UserCardAnswers",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardAnswers_CardQuestionChoiceId",
                table: "UserCardAnswers",
                column: "CardQuestionChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardAnswers_CardQuestionId",
                table: "UserCardAnswers",
                column: "CardQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCardAnswers_UserId",
                table: "UserCardAnswers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCardAnswers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
