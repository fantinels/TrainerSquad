using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainerSquad.Migrations
{
    public partial class physicalAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PhysicalDate",
                table: "PhysicalAssessment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_PersonalId",
                table: "Schedule",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_PersonalId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PhysicalDate",
                table: "PhysicalAssessment");
        }
    }
}
