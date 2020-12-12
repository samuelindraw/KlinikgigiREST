using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Barang> Barang { get; set; }
        public DbSet<Beli> Beli { get; set; }
        public DbSet<DetailPenggajian> DetailPenggajian { get; set; }
        public DbSet<DetailPasien> DetailPasien { get; set; }
        public DbSet<DetailBeli> DetailBeli { get; set; }
        public DbSet<DetailPegawai> DetailPegawai { get; set; }
        public DbSet<JenisTindakan> JenisTindakan { get; set; }
        public DbSet<Jual> Jual { get; set; }
        public DbSet<KatBarang> KatBarang { get; set; }
        public DbSet<KatJenis> KatJenis { get; set; }
        public DbSet<Penggajian> Penggajian { get; set; }
        public DbSet<Pengguna> Pengguna { get; set; }
        public DbSet<Prosentase> Prosentase { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TenantPengguna> TenantPengguna { get; set; }
        public DbSet<Tindakan> Tindakan { get; set; }
        public DbSet<pilihGIgi> pilihGIgi { get; set; }
        public DbSet<PosisiGigi> PosisiGigi { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<pilihGIgi>().HasKey(c => new { c.IdTindakan, c.idposisiGigi });

            builder.Entity<pilihGIgi>()
                .HasOne(r => r.Tindakan)
                .WithMany(c => c.Posisi)
                .HasForeignKey(sc => sc.IdTindakan);

            builder.Entity<pilihGIgi>()
                .HasOne(r => r.PosisiGigi)
                .WithMany(c => c.Posisi)
                .HasForeignKey(sc => sc.idposisiGigi);


        }
        public DbSet<Transaksi>Transaksi { get;
            set; }

     

        public DbSet<ApplicationUser> ApplicationUser { get; set; }





    }
}
