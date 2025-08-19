using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NearEarthObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AbsoluteMagnitudeH = table.Column<double>(type: "double precision", nullable: false),
                    EstimatedDiameterMin = table.Column<double>(type: "double precision", nullable: false),
                    EstimatedDiameterMax = table.Column<double>(type: "double precision", nullable: false),
                    IsPotentiallyHazardousAsteroid = table.Column<bool>(type: "boolean", nullable: false),
                    CloseApproachDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RelativeVelocity = table.Column<double>(type: "double precision", nullable: false),
                    MissDistance = table.Column<double>(type: "double precision", nullable: false),
                    OrbitingBody = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NearEarthObjects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NearEarthObjects");
        }
    }
}
