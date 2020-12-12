using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gigi");

            migrationBuilder.CreateTable(
                name: "PosisiGigi",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    gigiPosisi = table.Column<int>(nullable: false),
                    kuadran = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosisiGigi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pilihGIgi",
                columns: table => new
                {
                    IdTindakan = table.Column<int>(nullable: false),
                    idposisiGigi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pilihGIgi", x => new { x.IdTindakan, x.idposisiGigi });
                    table.ForeignKey(
                        name: "FK_pilihGIgi_Tindakan_IdTindakan",
                        column: x => x.IdTindakan,
                        principalTable: "Tindakan",
                        principalColumn: "IdTindakan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pilihGIgi_PosisiGigi_idposisiGigi",
                        column: x => x.idposisiGigi,
                        principalTable: "PosisiGigi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pilihGIgi_idposisiGigi",
                table: "pilihGIgi",
                column: "idposisiGigi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pilihGIgi");

            migrationBuilder.DropTable(
                name: "PosisiGigi");

            migrationBuilder.CreateTable(
                name: "Gigi",
                columns: table => new
                {
                    idGigi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kuadra = table.Column<string>(nullable: true),
                    TindakanIdTindakan = table.Column<int>(nullable: true),
                    nomerPosisi = table.Column<int>(nullable: false)
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
                name: "IX_Gigi_TindakanIdTindakan",
                table: "Gigi",
                column: "TindakanIdTindakan");
        }
    }
}
