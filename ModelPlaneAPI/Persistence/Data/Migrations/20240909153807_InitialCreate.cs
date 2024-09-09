using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelPlaneAPI.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Wings900Id = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<int>(type: "integer", nullable: false),
                    Scale = table.Column<int>(type: "integer", nullable: false),
                    Airline = table.Column<int>(type: "integer", nullable: false),
                    Aircraft = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    Registration = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ProductionYears = table.Column<string>(type: "text", nullable: false),
                    RollingGears = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Engines = table.Column<string>(type: "text", nullable: false),
                    UnitsMade = table.Column<int>(type: "integer", nullable: false),
                    IncludesStand = table.Column<bool>(type: "boolean", nullable: false),
                    Images = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
