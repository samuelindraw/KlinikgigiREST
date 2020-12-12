using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class tablejual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jual_Barang_BarangIdBarang",
                table: "Jual");

            migrationBuilder.DropTable(
                name: "DetailJual");

            migrationBuilder.DropIndex(
                name: "IX_Jual_BarangIdBarang",
                table: "Jual");

            migrationBuilder.DropColumn(
                name: "BarangIdBarang",
                table: "Jual");

            migrationBuilder.DropColumn(
                name: "NamaPenjualan",
                table: "Jual");

            migrationBuilder.AddColumn<int>(
                name: "Harga",
                table: "Jual",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBarang",
                table: "Jual",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Qty",
                table: "Jual",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Jual_IdBarang",
                table: "Jual",
                column: "IdBarang");

            migrationBuilder.AddForeignKey(
                name: "FK_Jual_Barang_IdBarang",
                table: "Jual",
                column: "IdBarang",
                principalTable: "Barang",
                principalColumn: "IdBarang",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jual_Barang_IdBarang",
                table: "Jual");

            migrationBuilder.DropIndex(
                name: "IX_Jual_IdBarang",
                table: "Jual");

            migrationBuilder.DropColumn(
                name: "Harga",
                table: "Jual");

            migrationBuilder.DropColumn(
                name: "IdBarang",
                table: "Jual");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Jual");

            migrationBuilder.AddColumn<int>(
                name: "BarangIdBarang",
                table: "Jual",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPenjualan",
                table: "Jual",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailJual",
                columns: table => new
                {
                    DetailJualId = table.Column<string>(nullable: false),
                    Harga = table.Column<int>(nullable: false),
                    IdBarang = table.Column<int>(nullable: false),
                    IdJual = table.Column<int>(nullable: false),
                    Qty = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailJual", x => x.DetailJualId);
                    table.ForeignKey(
                        name: "FK_DetailJual_Barang_IdBarang",
                        column: x => x.IdBarang,
                        principalTable: "Barang",
                        principalColumn: "IdBarang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailJual_Jual_IdJual",
                        column: x => x.IdJual,
                        principalTable: "Jual",
                        principalColumn: "IdJual",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jual_BarangIdBarang",
                table: "Jual",
                column: "BarangIdBarang");

            migrationBuilder.CreateIndex(
                name: "IX_DetailJual_IdBarang",
                table: "DetailJual",
                column: "IdBarang");

            migrationBuilder.CreateIndex(
                name: "IX_DetailJual_IdJual",
                table: "DetailJual",
                column: "IdJual");

            migrationBuilder.AddForeignKey(
                name: "FK_Jual_Barang_BarangIdBarang",
                table: "Jual",
                column: "BarangIdBarang",
                principalTable: "Barang",
                principalColumn: "IdBarang",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
