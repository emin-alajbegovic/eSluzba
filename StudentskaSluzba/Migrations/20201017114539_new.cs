using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskaSluzba.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uspjeh_StudentId",
                table: "Uspjeh");

            migrationBuilder.CreateIndex(
                name: "IX_Uspjeh_StudentId",
                table: "Uspjeh",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uspjeh_StudentId",
                table: "Uspjeh");

            migrationBuilder.CreateIndex(
                name: "IX_Uspjeh_StudentId",
                table: "Uspjeh",
                column: "StudentId",
                unique: true);
        }
    }
}
