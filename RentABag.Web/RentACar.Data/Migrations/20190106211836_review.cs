using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentABag.Data.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedOn",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewedOn",
                table: "Reviews");
        }
    }
}
