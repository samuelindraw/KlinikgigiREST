using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class PerbaikantabeStatusTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusTenant",
                table: "TenantPengguna",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusTenant",
                table: "TenantPengguna");
        }
    }
}
