using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakoraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedJoiningDatetoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "AspNetUsers");
        }
    }
}
