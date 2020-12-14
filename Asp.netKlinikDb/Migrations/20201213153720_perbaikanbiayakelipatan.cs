using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class perbaikanbiayakelipatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiayaKelipatan",
                table: "Tindakan");

            migrationBuilder.DropColumn(
                name: "BiayaKelipatan",
                table: "JenisTindakan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BiayaKelipatan",
                table: "Tindakan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BiayaKelipatan",
                table: "JenisTindakan",
                nullable: true);
        }
    }
}
