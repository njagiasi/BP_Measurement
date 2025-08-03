using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPMeasurements",
                columns: table => new
                {
                    BPMeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMeasurements", x => x.BPMeasurementId);
                });

            migrationBuilder.InsertData(
                table: "BPMeasurements",
                columns: new[] { "BPMeasurementId", "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[,]
                {
                    { 1, 80, new DateTime(2024, 9, 30, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1570), 120 },
                    { 2, 85, new DateTime(2024, 10, 1, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1680), 130 },
                    { 3, 90, new DateTime(2024, 10, 2, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1684), 140 },
                    { 4, 75, new DateTime(2024, 10, 3, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1689), 110 },
                    { 5, 80, new DateTime(2024, 10, 4, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1693), 125 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPMeasurements");
        }
    }
}
