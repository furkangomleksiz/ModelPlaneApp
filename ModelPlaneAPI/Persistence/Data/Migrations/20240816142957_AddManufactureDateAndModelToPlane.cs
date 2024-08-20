using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelPlaneAPI.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManufactureDateAndModelToPlane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ManufactureDate",
                table: "Planes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Planes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufactureDate",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Planes");
        }
    }
}
