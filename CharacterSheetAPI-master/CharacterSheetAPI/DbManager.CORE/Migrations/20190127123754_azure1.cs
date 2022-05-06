using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbManager.CORE.Migrations
{
    public partial class azure1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVENTS_TABLE",
                columns: table => new
                {
                    Event_id = table.Column<int>(nullable: false),
                    event_Title = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    event_date = table.Column<DateTime>(type: "date", nullable: true),
                    place = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    event_Description = table.Column<string>(unicode: false, maxLength: 2047, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTS_TABLE", x => x.Event_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    Player_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    surname = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Asp_User_id_FK = table.Column<string>(maxLength: 450, nullable: false),
                    AspUserIdFkNavigationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYERS", x => x.Player_id);
                    table.ForeignKey(
                        name: "FK_PLAYERS_AspNetUsers_AspUserIdFkNavigationId",
                        column: x => x.AspUserIdFkNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "API_KEYS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    APIKEY = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Event_id = table.Column<int>(nullable: false),
                    Asp_User_id_FK = table.Column<string>(maxLength: 450, nullable: false),
                    AspUserIdFkNavigationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_KEYS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_API_KEYS_AspNetUsers_AspUserIdFkNavigationId",
                        column: x => x.AspUserIdFkNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "API_KEY_EVENT_FK",
                        column: x => x.Event_id,
                        principalTable: "EVENTS_TABLE",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASP_USER_EVENT",
                columns: table => new
                {
                    ASP_USER_EVENT_Id = table.Column<int>(nullable: false),
                    Asp_User_id_FK = table.Column<string>(maxLength: 450, nullable: false),
                    Event_id_FK = table.Column<int>(nullable: false),
                    AspUserIdFkNavigationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASP_USER_EVENT", x => x.ASP_USER_EVENT_Id);
                    table.ForeignKey(
                        name: "FK_ASP_USER_EVENT_AspNetUsers_AspUserIdFkNavigationId",
                        column: x => x.AspUserIdFkNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EVENT_FK",
                        column: x => x.Event_id_FK,
                        principalTable: "EVENTS_TABLE",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHARACTERS_SHEETS",
                columns: table => new
                {
                    Sheet_id = table.Column<int>(nullable: false),
                    Player_id_FK = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    money = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    description = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
                    approved = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    Event_id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHARACTERS_SHEETS", x => x.Sheet_id);
                    table.ForeignKey(
                        name: "EVENT_CHARACTER_SHEET_FK",
                        column: x => x.Event_id_FK,
                        principalTable: "EVENTS_TABLE",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Event_Player_FK",
                        column: x => x.Player_id_FK,
                        principalTable: "PLAYERS",
                        principalColumn: "Player_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "APIKEY_UC",
                table: "API_KEYS",
                column: "APIKEY",
                unique: true,
                filter: "[APIKEY] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_API_KEYS_AspUserIdFkNavigationId",
                table: "API_KEYS",
                column: "AspUserIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_API_KEYS_Event_id",
                table: "API_KEYS",
                column: "Event_id");

            migrationBuilder.CreateIndex(
                name: "IX_ASP_USER_EVENT_AspUserIdFkNavigationId",
                table: "ASP_USER_EVENT",
                column: "AspUserIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ASP_USER_EVENT_Event_id_FK",
                table: "ASP_USER_EVENT",
                column: "Event_id_FK");

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

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_SHEETS_Event_id_FK",
                table: "CHARACTERS_SHEETS",
                column: "Event_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_SHEETS_Player_id_FK",
                table: "CHARACTERS_SHEETS",
                column: "Player_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYERS_AspUserIdFkNavigationId",
                table: "PLAYERS",
                column: "AspUserIdFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "EMAIL_UC",
                table: "PLAYERS",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API_KEYS");

            migrationBuilder.DropTable(
                name: "ASP_USER_EVENT");

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
                name: "CHARACTERS_SHEETS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EVENTS_TABLE");

            migrationBuilder.DropTable(
                name: "PLAYERS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
