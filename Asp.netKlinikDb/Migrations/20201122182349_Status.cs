using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penggajian_DetailPegawai_DetailPegawaiID",
                table: "Penggajian");

            migrationBuilder.DropTable(
                name: "PesananGigiPalsu");

            migrationBuilder.DropIndex(
                name: "IX_DetailPegawai_Username",
                table: "DetailPegawai");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "rolename");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "TenantName");

            migrationBuilder.RenameColumn(
                name: "Aturan",
                table: "User",
                newName: "TenantID");

            migrationBuilder.AlterColumn<int>(
                name: "DetailPegawaiID",
                table: "Penggajian",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_DetailPegawai_Username",
                table: "DetailPegawai",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Penggajian_DetailPegawai_DetailPegawaiID",
                table: "Penggajian",
                column: "DetailPegawaiID",
                principalTable: "DetailPegawai",
                principalColumn: "DetailPegawaiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penggajian_DetailPegawai_DetailPegawaiID",
                table: "Penggajian");

            migrationBuilder.DropIndex(
                name: "IX_DetailPegawai_Username",
                table: "DetailPegawai");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "rolename",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "TenantName",
                table: "User",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "TenantID",
                table: "User",
                newName: "Aturan");

            migrationBuilder.AlterColumn<int>(
                name: "DetailPegawaiID",
                table: "Penggajian",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "PesananGigiPalsu",
                columns: table => new
                {
                    IdPesanan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DetailPasienID = table.Column<int>(nullable: true),
                    HargaBeli = table.Column<int>(nullable: false),
                    HargaJual = table.Column<int>(nullable: false),
                    IdPasien = table.Column<string>(nullable: true),
                    IdTindakanPesan = table.Column<int>(nullable: true),
                    IdTransaksiPasang = table.Column<int>(nullable: false),
                    JenisGigi = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    TanggalPesan = table.Column<DateTime>(nullable: false),
                    TenantID = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesananGigiPalsu", x => x.IdPesanan);
                    table.ForeignKey(
                        name: "FK_PesananGigiPalsu_DetailPasien_DetailPasienID",
                        column: x => x.DetailPasienID,
                        principalTable: "DetailPasien",
                        principalColumn: "DetailPasienID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesananGigiPalsu_Tenant_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesananGigiPalsu_Pengguna_Username",
                        column: x => x.Username,
                        principalTable: "Pengguna",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailPegawai_Username",
                table: "DetailPegawai",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_PesananGigiPalsu_DetailPasienID",
                table: "PesananGigiPalsu",
                column: "DetailPasienID");

            migrationBuilder.CreateIndex(
                name: "IX_PesananGigiPalsu_TenantID",
                table: "PesananGigiPalsu",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_PesananGigiPalsu_Username",
                table: "PesananGigiPalsu",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Penggajian_DetailPegawai_DetailPegawaiID",
                table: "Penggajian",
                column: "DetailPegawaiID",
                principalTable: "DetailPegawai",
                principalColumn: "DetailPegawaiID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
