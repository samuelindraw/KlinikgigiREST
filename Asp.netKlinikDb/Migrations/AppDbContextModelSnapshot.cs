﻿// <auto-generated />
using System;
using Asp.netKlinikDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asp.netKlinikDb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp.netKlinikDb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Barang", b =>
                {
                    b.Property<int>("IdBarang")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Harga");

                    b.Property<int>("IdKatBarang");

                    b.Property<int>("KatBarangIdKategori");

                    b.Property<string>("Keterangan");

                    b.Property<int>("Minstok");

                    b.Property<string>("NamaBarang");

                    b.Property<short>("Stok");

                    b.HasKey("IdBarang");

                    b.HasIndex("KatBarangIdKategori");

                    b.ToTable("Barang");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Beli", b =>
                {
                    b.Property<int>("IdBeli")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Keterangan");

                    b.Property<string>("NamaPembelian");

                    b.Property<DateTime>("Tanggal");

                    b.Property<string>("TenantID");

                    b.Property<int>("TotalHarga");

                    b.HasKey("IdBeli");

                    b.HasIndex("TenantID");

                    b.ToTable("Beli");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailBeli", b =>
                {
                    b.Property<string>("DetailBeliId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Harga");

                    b.Property<int>("IdBarang");

                    b.Property<int>("IdBeli");

                    b.Property<short>("Qty");

                    b.Property<DateTime>("Tanggal");

                    b.Property<int>("TotalHarga");

                    b.HasKey("DetailBeliId");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdBeli");

                    b.ToTable("DetailBeli");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPasien", b =>
                {
                    b.Property<int>("DetailPasienID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdPasien");

                    b.Property<DateTime>("Registrasi");

                    b.Property<string>("RwPenyakit");

                    b.Property<string>("Username");

                    b.HasKey("DetailPasienID");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("DetailPasien");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPegawai", b =>
                {
                    b.Property<int>("DetailPegawaiID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gaji");

                    b.Property<string>("Jabatan");

                    b.Property<DateTime>("TanggalJoin");

                    b.Property<string>("Username");

                    b.HasKey("DetailPegawaiID");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("DetailPegawai");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPenggajian", b =>
                {
                    b.Property<int>("IdDetailGaji")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdGaji");

                    b.Property<int>("IdTransaksi");

                    b.HasKey("IdDetailGaji");

                    b.HasIndex("IdGaji");

                    b.HasIndex("IdTransaksi");

                    b.ToTable("DetailPenggajian");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.JenisTindakan", b =>
                {
                    b.Property<int>("IdJenisTindakan")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Biaya");

                    b.Property<int>("IdKatJenis");

                    b.Property<string>("Jenis");

                    b.Property<string>("Keterangan");

                    b.Property<string>("TenantID");

                    b.HasKey("IdJenisTindakan");

                    b.HasIndex("IdKatJenis");

                    b.HasIndex("TenantID");

                    b.ToTable("JenisTindakan");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Jual", b =>
                {
                    b.Property<int>("IdJual")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Harga");

                    b.Property<int>("IdBarang");

                    b.Property<int>("IdTransaksi");

                    b.Property<short>("Qty");

                    b.Property<string>("TenantID");

                    b.HasKey("IdJual");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdTransaksi");

                    b.HasIndex("TenantID");

                    b.ToTable("Jual");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.KatBarang", b =>
                {
                    b.Property<int>("IdKategori")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamaKategori");

                    b.Property<string>("TenantID");

                    b.HasKey("IdKategori");

                    b.HasIndex("TenantID");

                    b.ToTable("KatBarang");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.KatJenis", b =>
                {
                    b.Property<int>("IdKatJenis")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriName");

                    b.Property<string>("TenantID");

                    b.HasKey("IdKatJenis");

                    b.HasIndex("TenantID");

                    b.ToTable("KatJenis");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Penggajian", b =>
                {
                    b.Property<int>("IdGaji")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DetailPegawaiID");

                    b.Property<string>("MasaWaktu");

                    b.Property<DateTime?>("TanggalAkhir");

                    b.Property<DateTime?>("TanggalAwal");

                    b.Property<DateTime>("TanggalGaji");

                    b.Property<string>("TenantID");

                    b.Property<int>("TotalGaji");

                    b.Property<string>("Username");

                    b.HasKey("IdGaji");

                    b.HasIndex("DetailPegawaiID");

                    b.HasIndex("TenantID");

                    b.HasIndex("Username");

                    b.ToTable("Penggajian");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Pengguna", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alamat");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("IdPasien");

                    b.Property<string>("Kota");

                    b.Property<string>("Nama");

                    b.Property<string>("NoHP");

                    b.Property<string>("NoTelpon");

                    b.Property<double>("Prosentase");

                    b.Property<string>("TenantID");

                    b.Property<short>("Umur");

                    b.Property<string>("rolename");

                    b.HasKey("Username");

                    b.HasIndex("TenantID");

                    b.ToTable("Pengguna");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.PosisiGigi", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("gigiPosisi");

                    b.Property<string>("kuadran");

                    b.HasKey("id");

                    b.ToTable("PosisiGigi");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Prosentase", b =>
                {
                    b.Property<int>("IdProsentase")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DetailPegawaiID");

                    b.Property<int>("IdJenisTindakan");

                    b.Property<double>("Prosen");

                    b.Property<string>("TenantID");

                    b.Property<string>("Username");

                    b.HasKey("IdProsentase");

                    b.HasIndex("DetailPegawaiID");

                    b.HasIndex("IdJenisTindakan");

                    b.HasIndex("TenantID");

                    b.HasIndex("Username");

                    b.ToTable("Prosentase");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Tenant", b =>
                {
                    b.Property<string>("TenantID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenantName");

                    b.HasKey("TenantID");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.TenantPengguna", b =>
                {
                    b.Property<string>("TenantPenggunaID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("StatusTenant");

                    b.Property<string>("TenantID");

                    b.Property<string>("Username");

                    b.HasKey("TenantPenggunaID");

                    b.HasIndex("TenantID");

                    b.HasIndex("Username");

                    b.ToTable("TenantPengguna");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Tindakan", b =>
                {
                    b.Property<int>("IdTindakan")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Biaya");

                    b.Property<int>("BiayaDasar");

                    b.Property<string>("Diagnosis");

                    b.Property<int>("IdJenisTindakan");

                    b.Property<int>("IdTransaksi");

                    b.Property<int>("Persenan");

                    b.Property<string>("Status");

                    b.Property<string>("TenantID");

                    b.HasKey("IdTindakan");

                    b.HasIndex("IdJenisTindakan");

                    b.HasIndex("IdTransaksi");

                    b.HasIndex("TenantID");

                    b.ToTable("Tindakan");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Transaksi", b =>
                {
                    b.Property<int>("IdTransaksi")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anamnesis");

                    b.Property<int>("DetailPasienID");

                    b.Property<string>("IdPasien");

                    b.Property<string>("Resep");

                    b.Property<DateTime>("Tanggal");

                    b.Property<string>("TenantID");

                    b.Property<string>("Username");

                    b.HasKey("IdTransaksi");

                    b.HasIndex("DetailPasienID");

                    b.HasIndex("TenantID");

                    b.HasIndex("Username");

                    b.ToTable("Transaksi");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.pilihGIgi", b =>
                {
                    b.Property<int>("IdTindakan");

                    b.Property<string>("idposisiGigi");

                    b.HasKey("IdTindakan", "idposisiGigi");

                    b.HasIndex("idposisiGigi");

                    b.ToTable("pilihGIgi");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Barang", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.KatBarang", "KatBarang")
                        .WithMany("Barang")
                        .HasForeignKey("KatBarangIdKategori")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Beli", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailBeli", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Barang", "Barang")
                        .WithMany("DetailBeli")
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Beli", "beli")
                        .WithMany("detailBeli")
                        .HasForeignKey("IdBeli")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPasien", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "Pengguna")
                        .WithOne("detailPasien")
                        .HasForeignKey("Asp.netKlinikDb.Models.DetailPasien", "Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPegawai", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "Pengguna")
                        .WithOne("detailPegawai")
                        .HasForeignKey("Asp.netKlinikDb.Models.DetailPegawai", "Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.DetailPenggajian", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Penggajian", "Penggajian")
                        .WithMany("DetailPenggajian")
                        .HasForeignKey("IdGaji")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Transaksi", "Transaksi")
                        .WithMany("DetailPenggajian")
                        .HasForeignKey("IdTransaksi")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.JenisTindakan", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.KatJenis", "KatJenis")
                        .WithMany("JenisTindakan")
                        .HasForeignKey("IdKatJenis")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Jual", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Barang", "Barang")
                        .WithMany("Jual")
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Transaksi", "Transaksi")
                        .WithMany("Jual")
                        .HasForeignKey("IdTransaksi")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.KatBarang", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.KatJenis", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Penggajian", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.DetailPegawai")
                        .WithMany("Penggajian")
                        .HasForeignKey("DetailPegawaiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");

                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "Pengguna")
                        .WithMany()
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Pengguna", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Prosentase", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.DetailPegawai")
                        .WithMany("Prosentase")
                        .HasForeignKey("DetailPegawaiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.JenisTindakan", "JenisTindakan")
                        .WithMany("Prosentase")
                        .HasForeignKey("IdJenisTindakan")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");

                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "Pengguna")
                        .WithMany()
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.TenantPengguna", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");

                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "pengguna")
                        .WithMany("TenantPengguna")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Tindakan", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.JenisTindakan", "JenisTindakan")
                        .WithMany("Tindakan")
                        .HasForeignKey("IdJenisTindakan")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Transaksi", "Transaksi")
                        .WithMany("Tindakan")
                        .HasForeignKey("IdTransaksi")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.Transaksi", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.DetailPasien", "DetailPasien")
                        .WithMany("Transaksi")
                        .HasForeignKey("DetailPasienID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID");

                    b.HasOne("Asp.netKlinikDb.Models.Pengguna", "Pengguna")
                        .WithMany("Transaksi")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("Asp.netKlinikDb.Models.pilihGIgi", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.Tindakan", "Tindakan")
                        .WithMany("Posisi")
                        .HasForeignKey("IdTindakan")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.PosisiGigi", "PosisiGigi")
                        .WithMany("Posisi")
                        .HasForeignKey("idposisiGigi")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Asp.netKlinikDb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Asp.netKlinikDb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
