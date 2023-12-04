using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainerSquad.Migrations
{
    public partial class AdicionadoPersonalNoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Personal_PersonalId",
                table: "Schedule",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");
        }
    }
}
