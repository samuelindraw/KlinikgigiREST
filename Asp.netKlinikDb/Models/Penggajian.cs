using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Penggajian
    {
        public Penggajian()
        {
            this.DetailPenggajian = new List<DetailPenggajian>();
        }
        [Key]
        public int IdGaji { get; set; }
        //cek role dulu admin atau bukan
        public string Username { get; set; }
        //ini tanggal gaji maksutnya apa // ngechecknya dari transaksi 
        public DateTime TanggalGaji { get; set; }
        //tanggal gaji perbulan 1 x 
        //tanggal awal dan akhir apaan ? 
        public DateTime? TanggalAwal { get; set; } // ngechecknya dari transaksi 
        public DateTime? TanggalAkhir { get; set; } 
        public int TotalGaji { get; set; }
        //count dari tanggal awal - akhir ? 
        public string MasaWaktu { get; set; }
        public string TenantID { get; set; }
        public int DetailPegawaiID { get; set; }

        public Tenant Tenant { get; set; }
        public Pengguna Pengguna { get; set; }
        public IEnumerable<DetailPenggajian> DetailPenggajian { get; set; }

        [NotMapped]
        public string Totaji { get; set; }

        [NotMapped]
        public DateTime? Tanggalbulandepan { get; set; }

    }
}
