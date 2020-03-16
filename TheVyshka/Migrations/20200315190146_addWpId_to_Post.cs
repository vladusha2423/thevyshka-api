using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheVyshka.Migrations
{
    public partial class addWpId_to_Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("35197f08-f35f-4a8f-bb17-3be2d8b621ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d80de3ec-c389-480d-999b-4451e68bfa18"));

            migrationBuilder.AddColumn<int>(
                name: "WpId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("485e3fff-58dc-46de-a5e0-87bb150c8454"), "75ee1bb1-3249-46fc-a746-bfef3e5612fb", "admin", "ADMIN" },
                    { new Guid("145631e9-be79-4531-8f13-e6664a5e2fae"), "0aade1ab-1531-4415-b81d-e3c57bb4c8fa", "editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("145631e9-be79-4531-8f13-e6664a5e2fae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("485e3fff-58dc-46de-a5e0-87bb150c8454"));

            migrationBuilder.DropColumn(
                name: "WpId",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("35197f08-f35f-4a8f-bb17-3be2d8b621ba"), "8caeb6c9-dbdb-4f22-9db2-a727daecf79b", "admin", "ADMIN" },
                    { new Guid("d80de3ec-c389-480d-999b-4451e68bfa18"), "fa1a8eaa-051d-4f7b-ac4f-2974c8589133", "editor", "EDITOR" }
                });
        }
    }
}
