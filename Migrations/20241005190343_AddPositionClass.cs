using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionId",
                table: "BPMeasurements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 1,
                columns: new[] { "MeasurementDate", "PositionId" },
                values: new object[] { new DateTime(2024, 9, 30, 15, 3, 43, 40, DateTimeKind.Local).AddTicks(2461), "2" });

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 2,
                columns: new[] { "MeasurementDate", "PositionId" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 3, 43, 40, DateTimeKind.Local).AddTicks(2589), "1" });

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 3,
                columns: new[] { "MeasurementDate", "PositionId" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 3, 43, 40, DateTimeKind.Local).AddTicks(2594), "3" });

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 4,
                columns: new[] { "MeasurementDate", "PositionId" },
                values: new object[] { new DateTime(2024, 10, 3, 15, 3, 43, 40, DateTimeKind.Local).AddTicks(2598), "2" });

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 5,
                columns: new[] { "MeasurementDate", "PositionId" },
                values: new object[] { new DateTime(2024, 10, 4, 15, 3, 43, 40, DateTimeKind.Local).AddTicks(2602), "1" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "Name" },
                values: new object[,]
                {
                    { "1", "Standing" },
                    { "2", "Sitting" },
                    { "3", "Lying down" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BPMeasurements_PositionId",
                table: "BPMeasurements",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BPMeasurements_Positions_PositionId",
                table: "BPMeasurements",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BPMeasurements_Positions_PositionId",
                table: "BPMeasurements");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_BPMeasurements_PositionId",
                table: "BPMeasurements");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "BPMeasurements");

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 1,
                column: "MeasurementDate",
                value: new DateTime(2024, 9, 30, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 2,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 1, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 3,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 2, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 4,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 3, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "BPMeasurements",
                keyColumn: "BPMeasurementId",
                keyValue: 5,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 4, 15, 1, 8, 4, DateTimeKind.Local).AddTicks(1693));
        }
    }
}
