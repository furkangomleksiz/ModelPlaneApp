using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelPlaneAPI.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrateEnumToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aircraft",
                table: "Planes");

            migrationBuilder.AlterColumn<string>(
                name: "Scale",
                table: "Planes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Planes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Airline",
                table: "Planes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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
                name: "Model",
                table: "Planes");

            migrationBuilder.AlterColumn<int>(
                name: "Scale",
                table: "Planes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Manufacturer",
                table: "Planes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Airline",
                table: "Planes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Aircraft",
                table: "Planes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
