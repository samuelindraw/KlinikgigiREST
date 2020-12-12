using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class Perbaikandatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Prosentase_DetailPegawai_DetailPegawaiID",
                table: "Prosentase");


            migrationBuilder.AlterColumn<int>(
                name: "DetailPegawaiID",
                table: "Prosentase",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prosentase_DetailPegawai_DetailPegawaiID",
                table: "Prosentase",
                column: "DetailPegawaiID",
                principalTable: "DetailPegawai",
                principalColumn: "DetailPegawaiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosentase_DetailPegawai_DetailPegawaiID",
                table: "Prosentase");

            migrationBuilder.AlterColumn<int>(
                name: "DetailPegawaiID",
                table: "Prosentase",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Beli_BarangIdBarang",
                table: "Beli",
                column: "BarangIdBarang");

            migrationBuilder.AddForeignKey(
                name: "FK_Beli_Barang_BarangIdBarang",
                table: "Beli",
                column: "BarangIdBarang",
                principalTable: "Barang",
                principalColumn: "IdBarang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prosentase_DetailPegawai_DetailPegawaiID",
                table: "Prosentase",
                column: "DetailPegawaiID",
                principalTable: "DetailPegawai",
                principalColumn: "DetailPegawaiID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
