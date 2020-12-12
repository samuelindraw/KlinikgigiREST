using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class dbgigi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailBeli_IdBeli",
                table: "DetailBeli");

            migrationBuilder.DropColumn(
                name: "Posisi",
                table: "Tindakan");

            migrationBuilder.CreateTable(
                name: "Gigi",
                columns: table => new
                {
                    idGigi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kuadra = table.Column<string>(nullable: true),
                    nomerPosisi = table.Column<int>(nullable: false),
                    TindakanIdTindakan = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gigi", x => x.idGigi);
                    table.ForeignKey(
                        name: "FK_Gigi_Tindakan_TindakanIdTindakan",
                        column: x => x.TindakanIdTindakan,
                        principalTable: "Tindakan",
                        principalColumn: "IdTindakan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailBeli_IdBeli",
                table: "DetailBeli",
                column: "IdBeli",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gigi_TindakanIdTindakan",
                table: "Gigi",
                column: "TindakanIdTindakan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gigi");

            migrationBuilder.DropIndex(
                name: "IX_DetailBeli_IdBeli",
                table: "DetailBeli");

            migrationBuilder.AddColumn<string>(
                name: "Posisi",
                table: "Tindakan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailBeli_IdBeli",
                table: "DetailBeli",
                column: "IdBeli");
        }
    }
}
