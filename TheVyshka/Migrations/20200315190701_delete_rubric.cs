using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheVyshka.Migrations
{
    public partial class delete_rubric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Rubric",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("693a99ed-a4bd-4b73-98a6-5021446a475a"), "b1dc0af7-427d-4fe9-9b3f-aeaf0fe0eca2", "admin", "ADMIN" },
                    { new Guid("0feac0eb-5702-4193-a1c4-13ca40e97456"), "6cac419b-b3ee-47e2-b3b2-a246e6d85304", "editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0feac0eb-5702-4193-a1c4-13ca40e97456"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("693a99ed-a4bd-4b73-98a6-5021446a475a"));

            migrationBuilder.AddColumn<string>(
                name: "Rubric",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("485e3fff-58dc-46de-a5e0-87bb150c8454"), "75ee1bb1-3249-46fc-a746-bfef3e5612fb", "admin", "ADMIN" },
                    { new Guid("145631e9-be79-4531-8f13-e6664a5e2fae"), "0aade1ab-1531-4415-b81d-e3c57bb4c8fa", "editor", "EDITOR" }
                });
        }
    }
}
