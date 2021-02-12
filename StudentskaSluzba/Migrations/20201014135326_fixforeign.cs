using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskaSluzba.Migrations
{
    public partial class fixforeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_GodinaStudja_GodinastudijaId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GodinaStudijaId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "GodinastudijaId",
                table: "Student",
                newName: "GodinaStudijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GodinastudijaId",
                table: "Student",
                newName: "IX_Student_GodinaStudijaId");

            migrationBuilder.AlterColumn<int>(
                name: "GodinaStudijaId",
                table: "Student",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_GodinaStudja_GodinaStudijaId",
                table: "Student",
                column: "GodinaStudijaId",
                principalTable: "GodinaStudja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_GodinaStudja_GodinaStudijaId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "GodinaStudijaId",
                table: "Student",
                newName: "GodinastudijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GodinaStudijaId",
                table: "Student",
                newName: "IX_Student_GodinastudijaId");

            migrationBuilder.AlterColumn<int>(
                name: "GodinastudijaId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GodinaStudijaId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_GodinaStudja_GodinastudijaId",
                table: "Student",
                column: "GodinastudijaId",
                principalTable: "GodinaStudja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
