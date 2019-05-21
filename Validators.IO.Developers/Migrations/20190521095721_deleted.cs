using Microsoft.EntityFrameworkCore.Migrations;

namespace Validators.IO.Developers.Migrations
{
    public partial class deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cfa3ad92-193b-4f6e-95fd-724e7f7b323d");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54945ff2-5cb0-4fa2-ada2-4bc47a444a20", "538fe9d0-35d7-45c4-9a04-33afeade98b3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "54945ff2-5cb0-4fa2-ada2-4bc47a444a20");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfa3ad92-193b-4f6e-95fd-724e7f7b323d", "06297872-9ac0-4f70-8d01-dee0498f2524", "Admin", "ADMIN" });
        }
    }
}
