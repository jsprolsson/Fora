using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fora.Server.Migrations
{
    public partial class addedMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "InterestId", "Name", "UserId" },
                values: new object[] { 1, 1, "Elden Ring", 1 });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "InterestId", "Name", "UserId" },
                values: new object[] { 2, 2, "Blazors guide to the universe", 2 });

            migrationBuilder.InsertData(
                table: "UserInterestModel",
                columns: new[] { "InterestId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserInterestModel",
                columns: new[] { "InterestId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Message", "ThreadId", "UserId" },
                values: new object[] { 1, "I love the new elden ring game", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInterestModel",
                keyColumns: new[] { "InterestId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserInterestModel",
                keyColumns: new[] { "InterestId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
