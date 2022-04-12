using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fora.Server.Migrations.UserDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ForaUser = table.Column<int>(type: "int", nullable: false),
                    Banned = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "ADMIN" },
                    { "fab4fac1-c546-41de-aebc-a14da6895712", "2", "User", "USER" },
                    { "fab4fac1-c546-41de-aebc-a14da6895713", "3", "Banned", "BANNED" },
                    { "fab4fac1-c546-41de-aebc-a14da6895714", "4", "Deleted", "DELETED" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Banned", "ConcurrencyStamp", "DateTimeCreated", "DateTimeModified", "Deleted", "Email", "EmailConfirmed", "ForaUser", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, false, "79296980-e146-4e76-9f4d-e76b23a3bc8f", new DateTime(2022, 4, 12, 11, 35, 49, 644, DateTimeKind.Local).AddTicks(907), new DateTime(2022, 4, 12, 11, 35, 49, 644, DateTimeKind.Local).AddTicks(974), false, "admin@gmail.com", false, 1, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBykl4j4H70AbmM3GZvIRS9lbzkwbUySfNg0nfINSI1M+dKk50RRYZPCQaOqczwSUA==", null, false, "074734e9-24a2-4810-ac9f-c628422035d5", false, "Admin" },
                    { "b74ddd14-6340-4840-95c2-db12554843e6", 0, false, "534e4fdf-2765-4453-9875-3c5158df6e4d", new DateTime(2022, 4, 12, 11, 35, 49, 649, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 4, 12, 11, 35, 49, 649, DateTimeKind.Local).AddTicks(9299), false, "jesper@gmail.com", false, 2, false, null, null, "JESPER", "AQAAAAEAACcQAAAAEDxURXRnZ1j1Xg5VyarO2/4AsVwxSUmc5OFSnkKWIwxjYOWHr05UgdpO9IH+IdWZag==", null, false, "73a018a6-5cf3-499c-b152-abb0063ce9cd", false, "Jesper" },
                    { "b74ddd14-6340-4840-95c2-db12554843e7", 0, true, "e38af087-f962-4fb4-bdfe-477e161168ca", new DateTime(2022, 4, 12, 11, 35, 49, 656, DateTimeKind.Local).AddTicks(778), new DateTime(2022, 4, 12, 11, 35, 49, 656, DateTimeKind.Local).AddTicks(796), false, "filip@gmail.com", false, 3, false, null, null, "FILIP", "AQAAAAEAACcQAAAAEIRNM4HSzlew8TDx5fES3kUMP+0A6QBFejWZfJnIyUNRItCKCr2TIFoaHQCxVd7Ltg==", null, false, "c5a656dc-5896-4591-8600-9267865906f2", false, "Filip" },
                    { "b74ddd14-6340-4840-95c2-db12554843e8", 0, false, "f5e55278-e6ce-4e70-9e0d-542613cf6577", new DateTime(2022, 4, 12, 11, 35, 49, 661, DateTimeKind.Local).AddTicks(7418), new DateTime(2022, 4, 12, 11, 35, 49, 661, DateTimeKind.Local).AddTicks(7431), true, "mårten@gmail.com", false, 4, false, null, null, "MÅRTEN", "AQAAAAEAACcQAAAAEJ3rslhPIvlevhfonC9StPE31t067cHxFznByTuK09HApdCyaH+6JzL1LCnqafbLOQ==", null, false, "b867f914-a041-45ca-ab27-1404413a3fbc", false, "Mårten" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "fab4fac1-c546-41de-aebc-a14da6895712", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "fab4fac1-c546-41de-aebc-a14da6895712", "b74ddd14-6340-4840-95c2-db12554843e6" },
                    { "fab4fac1-c546-41de-aebc-a14da6895713", "b74ddd14-6340-4840-95c2-db12554843e7" },
                    { "fab4fac1-c546-41de-aebc-a14da6895714", "b74ddd14-6340-4840-95c2-db12554843e8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
