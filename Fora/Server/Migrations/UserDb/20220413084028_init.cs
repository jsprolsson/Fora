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
                    { "AdminId", "1", "Admin", "ADMIN" },
                    { "BannedId", "3", "Banned", "BANNED" },
                    { "DeletedId", "4", "Deleted", "DELETED" },
                    { "UserId", "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Banned", "ConcurrencyStamp", "DateTimeCreated", "DateTimeModified", "Deleted", "Email", "EmailConfirmed", "ForaUser", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, false, "90a8482c-ebfd-4b48-aff3-bfcc7e00a96a", new DateTime(2022, 4, 13, 10, 40, 27, 694, DateTimeKind.Local).AddTicks(110), new DateTime(2022, 4, 13, 10, 40, 27, 694, DateTimeKind.Local).AddTicks(192), false, "admin@gmail.com", false, 1, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFEdMfqOXX8HvbPJcyzuaIdsWC+sgN4Sd4JeUPbYlcxGMNvo1ASytdCUWN9VnizS8g==", null, false, "42029cf1-536c-4d0d-b530-fff6e231f0ee", false, "Admin" },
                    { "b74ddd14-6340-4840-95c2-db12554843e6", 0, false, "60aba6fc-c401-4a4d-b276-e8c131dc3292", new DateTime(2022, 4, 13, 10, 40, 27, 703, DateTimeKind.Local).AddTicks(6102), new DateTime(2022, 4, 13, 10, 40, 27, 703, DateTimeKind.Local).AddTicks(6113), false, "jesper@gmail.com", false, 2, false, null, "JESPER@GMAIL.COM", "JESPER", "AQAAAAEAACcQAAAAECOb6rqLw8jq7jRm2gY701kSVbxnSoaJKpbxgRQGaB8c2RC7isLjPq/rbOW41HzQPg==", null, false, "0c20b721-ae76-4a28-9ad2-c4d6cd015a4d", false, "Jesper" },
                    { "b74ddd14-6340-4840-95c2-db12554843e7", 0, true, "72f2e8a6-1cbb-47e2-b10a-8118c7307d8f", new DateTime(2022, 4, 13, 10, 40, 27, 713, DateTimeKind.Local).AddTicks(1188), new DateTime(2022, 4, 13, 10, 40, 27, 713, DateTimeKind.Local).AddTicks(1213), false, "filip@gmail.com", false, 3, false, null, "FILIP@GMAIL.COM", "FILIP", "AQAAAAEAACcQAAAAEOleoA7ymtalFUcvupZa9EVxvfVVHrYO3cdthX5Y0rMd+RCVHOKGU70er+ogZ8J7Uw==", null, false, "ec775b62-0097-4498-b555-7f80ee28be4f", false, "Filip" },
                    { "b74ddd14-6340-4840-95c2-db12554843e8", 0, false, "1033d67a-2b49-4e8e-a109-6b15fa1a2855", new DateTime(2022, 4, 13, 10, 40, 27, 722, DateTimeKind.Local).AddTicks(1454), new DateTime(2022, 4, 13, 10, 40, 27, 722, DateTimeKind.Local).AddTicks(1484), true, "marten@gmail.com", false, 4, false, null, "MARTEN@GMAIL.COM", "MÅRTEN", "AQAAAAEAACcQAAAAEOgoRGidoknR2VIZb2fstvvaGTRxgDMF37IYrJi0zKCmDWvwnF/r3dqsfrm05jDeoA==", null, false, "5697b68d-28fd-4a3d-9321-512fbe13ffb5", false, "Mårten" },
                    { "b74ddd14-6340-4840-95c2-db12554843e9", 0, false, "4405bf22-c3f3-4bb0-b07f-687c8c3092bc", new DateTime(2022, 4, 13, 10, 40, 27, 731, DateTimeKind.Local).AddTicks(1742), new DateTime(2022, 4, 13, 10, 40, 27, 731, DateTimeKind.Local).AddTicks(1762), false, "dragan@gmail.com", false, 5, false, null, "DRAGAN@GMAIL.COM", "DRAGAN", "AQAAAAEAACcQAAAAEAokPscjD5FQ+oQdfVQVR7ZrzrFlCW1m4tJVURDyKmd7Pg7Kx7j6tpAWwfPfym2uPA==", null, false, "0c91e8e8-85c8-49c6-9be8-cd01d2c0d49f", false, "Dragan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "AdminId", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "UserId", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "UserId", "b74ddd14-6340-4840-95c2-db12554843e6" },
                    { "BannedId", "b74ddd14-6340-4840-95c2-db12554843e7" },
                    { "DeletedId", "b74ddd14-6340-4840-95c2-db12554843e8" },
                    { "UserId", "b74ddd14-6340-4840-95c2-db12554843e9" }
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
