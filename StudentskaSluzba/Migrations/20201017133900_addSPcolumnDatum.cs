using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskaSluzba.Migrations
{
    public partial class addSPcolumnDatum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPolaganja",
                table: "Uspjeh",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumPolaganja",
                table: "Uspjeh");
        }
    }
}
