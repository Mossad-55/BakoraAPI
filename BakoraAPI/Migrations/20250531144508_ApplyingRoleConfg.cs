using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BakoraAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplyingRoleConfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "430baff0-6f31-428f-88fe-89135e3dd58b");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "51357b69-cbe8-4186-aa01-08dedef52b48");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9358957b-ac9e-48f8-97fc-dcc447edad48");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2ced1fc6-461a-4782-ac20-bc81720fae00");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a82ba050-bdc3-40ec-aa71-2e1444451505");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ebedaacf-1c65-45be-ab6a-bf4203d318fb");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "430baff0-6f31-428f-88fe-89135e3dd58b", null, "REQUESTER", "REQUESTER" },
                    { "51357b69-cbe8-4186-aa01-08dedef52b48", null, "Admin", "ADMIN" },
                    { "9358957b-ac9e-48f8-97fc-dcc447edad48", null, "Provider", "PROVIDER" }
                });
        }
    }
}
