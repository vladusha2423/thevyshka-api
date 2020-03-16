using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheVyshka.Migrations
{
    public partial class PostCollaborator_PK_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCollaborators",
                table: "PostCollaborators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("990f387f-0c73-4aee-82ef-dc044c03f479"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd47df75-e40b-4bd6-a6fa-6a1aa86e4b72"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "PostCollaborators",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCollaborators",
                table: "PostCollaborators",
                columns: new[] { "PostId", "CollaboratorId", "Role" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ad03c8e4-b8c6-49da-b550-cb00a6ec16c7"), "74576ecf-42a6-440f-9751-7ee1a5803bd5", "admin", "ADMIN" },
                    { new Guid("83326d1e-0c9f-4aba-a9a4-afb8e29a3469"), "d53ab9de-570a-458f-8891-3b86ca9fd101", "editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCollaborators",
                table: "PostCollaborators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83326d1e-0c9f-4aba-a9a4-afb8e29a3469"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad03c8e4-b8c6-49da-b550-cb00a6ec16c7"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "PostCollaborators",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCollaborators",
                table: "PostCollaborators",
                columns: new[] { "PostId", "CollaboratorId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("990f387f-0c73-4aee-82ef-dc044c03f479"), "587c8de5-07fd-45b3-a567-7930b6e385b6", "admin", "ADMIN" },
                    { new Guid("dd47df75-e40b-4bd6-a6fa-6a1aa86e4b72"), "68a48d7a-c69c-477a-971d-bd40b383e937", "editor", "EDITOR" }
                });
        }
    }
}
