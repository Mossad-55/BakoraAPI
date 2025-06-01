using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BakoraAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditedRoleConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9b36d7e3-df7a-4c2f-a7df-1b7db92900c9"), null, "Requester", "REQUESTER" },
                    { new Guid("d0a1fbd9-1d3f-4e38-bf9e-aac1e60e5a77"), null, "Admin", "ADMIN" },
                    { new Guid("f1a0f0e5-8423-44d7-b1b2-ccda2a876a23"), null, "Provider", "PROVIDER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b36d7e3-df7a-4c2f-a7df-1b7db92900c9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0a1fbd9-1d3f-4e38-bf9e-aac1e60e5a77"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1a0f0e5-8423-44d7-b1b2-ccda2a876a23"));

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ced1fc6-461a-4782-ac20-bc81720fae00", null, "REQUESTER", "REQUESTER" },
                    { "a82ba050-bdc3-40ec-aa71-2e1444451505", null, "Admin", "ADMIN" },
                    { "ebedaacf-1c65-45be-ab6a-bf4203d318fb", null, "Provider", "PROVIDER" }
                });
        }
    }
}
