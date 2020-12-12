using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailJual_Beli_beliIdBeli",
                table: "DetailJual");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi");

            migrationBuilder.DropIndex(
                name: "IX_DetailJual_beliIdBeli",
                table: "DetailJual");

            migrationBuilder.DropColumn(
                name: "beliIdBeli",
                table: "DetailJual");

            migrationBuilder.AlterColumn<int>(
                name: "DetailPasienID",
                table: "Transaksi",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailJual_IdJual",
                table: "DetailJual",
                column: "IdJual");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailJual_Jual_IdJual",
                table: "DetailJual",
                column: "IdJual",
                principalTable: "Jual",
                principalColumn: "IdJual",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi",
                column: "DetailPasienID",
                principalTable: "DetailPasien",
                principalColumn: "DetailPasienID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailJual_Jual_IdJual",
                table: "DetailJual");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi");

            migrationBuilder.DropIndex(
                name: "IX_DetailJual_IdJual",
                table: "DetailJual");

            migrationBuilder.AlterColumn<int>(
                name: "DetailPasienID",
                table: "Transaksi",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "beliIdBeli",
                table: "DetailJual",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailJual_beliIdBeli",
                table: "DetailJual",
                column: "beliIdBeli");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailJual_Beli_beliIdBeli",
                table: "DetailJual",
                column: "beliIdBeli",
                principalTable: "Beli",
                principalColumn: "IdBeli",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi",
                column: "DetailPasienID",
                principalTable: "DetailPasien",
                principalColumn: "DetailPasienID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
