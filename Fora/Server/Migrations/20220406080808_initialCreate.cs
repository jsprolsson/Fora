using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fora.Server.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banned = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threads_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestModel", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterestModel_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterestModel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Banned", "Deleted", "Username" },
                values: new object[,]
                {
                    { 1, false, false, "Jesper" },
                    { 2, false, false, "Filip" },
                    { 3, true, false, "Mårten" },
                    { 4, false, false, "Dragan" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeModified", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(492), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Games", 1 },
                    { 2, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(530), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books", 2 },
                    { 3, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(533), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music", 2 },
                    { 4, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hiking", 1 }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeModified", "InterestId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elden Ring", 1 },
                    { 2, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Blazors guide to the universe", 2 },
                    { 3, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(566), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Hiking in dr martens??", 3 },
                    { 4, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "About twilight...", 4 }
                });

            migrationBuilder.InsertData(
                table: "UserInterestModel",
                columns: new[] { "InterestId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 1, 4 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeModified", "Message", "ThreadId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I love the new elden ring game", 1, 1 },
                    { 2, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(582), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I think it's the worst in the series", 1, 4 },
                    { 3, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(584), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It's not a part of any series", 1, 1 },
                    { 4, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(586), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes it is", 1, 4 },
                    { 5, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I've heard they are releasing another book in the twilight franschise", 4, 4 },
                    { 6, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(589), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOBODY CARES", 4, 1 },
                    { 7, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(591), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I care", 4, 4 },
                    { 8, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keep a civil tone in here please and only post regarding the topic.", 4, 2 },
                    { 9, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I'm sorry. I'm actually prtty excited 4 the new release", 4, 1 },
                    { 10, new DateTime(2022, 4, 6, 10, 8, 7, 832, DateTimeKind.Local).AddTicks(595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Has anybody tried hiking in dr martens?? And if so, do you have any recommendations for me? I'm going up to Sälen next week and would like a pair of martens, but I've heard they're not that good for hiking in..", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ThreadId",
                table: "Messages",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_InterestId",
                table: "Threads",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_UserId",
                table: "Threads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestModel_InterestId",
                table: "UserInterestModel",
                column: "InterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserInterestModel");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
