using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheVyshka.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f4c5892-02f9-435d-9b47-87ea03653887"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aaca63fd-1f60-4d80-8993-0b71b9e43108"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bdc9f634-6757-4c54-bd46-65a814886525"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9807ff42-18c8-4a38-aee2-82a1c716c1f1"), "f0cad1f1-1cb8-4728-9884-900441fa28f8", "admin", "ADMIN" },
                    { new Guid("7474b021-5c6b-47a0-a5f4-85015df0da8b"), "8c72d388-5a1c-4da1-9a22-258f96fce472", "editor", "EDITOR" },
                    { new Guid("d99025de-b6db-4f7e-ae1a-b513019785b9"), "73bf60fc-ddbd-4f88-b7b6-9f21cdcba0f8", "user", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7474b021-5c6b-47a0-a5f4-85015df0da8b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9807ff42-18c8-4a38-aee2-82a1c716c1f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d99025de-b6db-4f7e-ae1a-b513019785b9"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5f4c5892-02f9-435d-9b47-87ea03653887"), "1b7740c2-4906-4a14-b5ba-968c5357747d", "admin", "ADMIN" },
                    { new Guid("bdc9f634-6757-4c54-bd46-65a814886525"), "e04d21ab-da9e-41e3-ac27-28ed98934324", "editor", "EDITOR" },
                    { new Guid("aaca63fd-1f60-4d80-8993-0b71b9e43108"), "ba281c33-0a32-4a53-9bab-5d0b5340955f", "user", "USER" }
                });
        }
    }
}
