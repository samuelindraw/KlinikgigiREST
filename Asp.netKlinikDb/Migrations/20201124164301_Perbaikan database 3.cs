using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class Perbaikandatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TenantID = table.Column<string>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    rolename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Username);
                });
        }
    }
}
