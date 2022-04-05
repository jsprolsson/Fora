using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fora.Server.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Banned", "Deleted", "Username" },
                values: new object[] { 1, false, false, "Jesper" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Banned", "Deleted", "Username" },
                values: new object[] { 2, false, false, "Filip" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "Games", 1 });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 2, "Books", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
