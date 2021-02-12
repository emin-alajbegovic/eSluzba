using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskaSluzba.Migrations
{
    public partial class uspjeh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentiPredmeti_Predmet_PredmetId",
                table: "StudentiPredmeti");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentiPredmeti_Student_StudentId",
                table: "StudentiPredmeti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentiPredmeti",
                table: "StudentiPredmeti");

            migrationBuilder.RenameTable(
                name: "StudentiPredmeti",
                newName: "Uspjeh");

            migrationBuilder.RenameIndex(
                name: "IX_StudentiPredmeti_StudentId",
                table: "Uspjeh",
                newName: "IX_Uspjeh_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentiPredmeti_PredmetId",
                table: "Uspjeh",
                newName: "IX_Uspjeh_PredmetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uspjeh",
                table: "Uspjeh",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uspjeh_Predmet_PredmetId",
                table: "Uspjeh",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uspjeh_Student_StudentId",
                table: "Uspjeh",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uspjeh_Predmet_PredmetId",
                table: "Uspjeh");

            migrationBuilder.DropForeignKey(
                name: "FK_Uspjeh_Student_StudentId",
                table: "Uspjeh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uspjeh",
                table: "Uspjeh");

            migrationBuilder.RenameTable(
                name: "Uspjeh",
                newName: "StudentiPredmeti");

            migrationBuilder.RenameIndex(
                name: "IX_Uspjeh_StudentId",
                table: "StudentiPredmeti",
                newName: "IX_StudentiPredmeti_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Uspjeh_PredmetId",
                table: "StudentiPredmeti",
                newName: "IX_StudentiPredmeti_PredmetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentiPredmeti",
                table: "StudentiPredmeti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentiPredmeti_Predmet_PredmetId",
                table: "StudentiPredmeti",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentiPredmeti_Student_StudentId",
                table: "StudentiPredmeti",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
