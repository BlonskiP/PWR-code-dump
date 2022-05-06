using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeAndCloud.Core.Migrations
{
    public partial class noisactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContactModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactModel",
                table: "ContactModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactModel",
                table: "ContactModel");

            migrationBuilder.RenameTable(
                name: "ContactModel",
                newName: "Contacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }
    }
}
