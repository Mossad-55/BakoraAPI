using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakoraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedProviderTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstitutionNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionTypeEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionTypeAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Providers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
