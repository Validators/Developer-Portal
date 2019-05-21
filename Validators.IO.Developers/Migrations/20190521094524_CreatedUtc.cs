using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Validators.IO.Developers.Migrations
{
    public partial class CreatedUtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7aef5a09-3be6-4496-b467-ec6983f49cce");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfa3ad92-193b-4f6e-95fd-724e7f7b323d", "06297872-9ac0-4f70-8d01-dee0498f2524", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cfa3ad92-193b-4f6e-95fd-724e7f7b323d");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7aef5a09-3be6-4496-b467-ec6983f49cce", "c188815f-f5a1-4c1e-aa2f-45503c4fb8e5", "Admin", "ADMIN" });
        }
    }
}
