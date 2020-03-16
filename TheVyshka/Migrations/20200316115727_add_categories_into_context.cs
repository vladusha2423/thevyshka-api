using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheVyshka.Migrations
{
    public partial class add_categories_into_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Category_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0feac0eb-5702-4193-a1c4-13ca40e97456"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("693a99ed-a4bd-4b73-98a6-5021446a475a"));

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("990f387f-0c73-4aee-82ef-dc044c03f479"), "587c8de5-07fd-45b3-a567-7930b6e385b6", "admin", "ADMIN" },
                    { new Guid("dd47df75-e40b-4bd6-a6fa-6a1aa86e4b72"), "68a48d7a-c69c-477a-971d-bd40b383e937", "editor", "EDITOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Categories_CategoryId",
                table: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("990f387f-0c73-4aee-82ef-dc044c03f479"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd47df75-e40b-4bd6-a6fa-6a1aa86e4b72"));

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("693a99ed-a4bd-4b73-98a6-5021446a475a"), "b1dc0af7-427d-4fe9-9b3f-aeaf0fe0eca2", "admin", "ADMIN" },
                    { new Guid("0feac0eb-5702-4193-a1c4-13ca40e97456"), "6cac419b-b3ee-47e2-b3b2-a246e6d85304", "editor", "EDITOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Category_CategoryId",
                table: "PostCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
