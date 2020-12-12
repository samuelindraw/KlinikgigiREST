using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Tindakan
    {

        [Key]
        public int IdTindakan { get; set; }
        public int IdTransaksi { get; set; }
        //posisi gigi menggunakan KUADRAN GIGI 
        public int IdJenisTindakan { get; set; }
        //biaya dokter ? dan klinik yes 
        public int Biaya { get; set; }
        //persenan ini apa ? yang akan didapat ketika ada transaksi ? 
        public int Persenan { get; set; }
        public string Diagnosis { get; set; }
        //beda dengan yang di jenis tindakan apa ? 
        public int BiayaDasar { get; set; }
        //apakah ini berdasarkan jumlah posisi x deengan biaya dasar
        public int BiayaKelipatan { get; set; }
        //status perbedaan dengan gigi palsu apa ? 
        public string Status { get; set; }
        public string TenantID { get; set; }

        public Tenant Tenant { get; set; }
        public List<pilihGIgi> Posisi { get; set; }


        //public pilihGIgi pilih { get; set; }

        public Transaksi Transaksi { get; set; }

        public JenisTindakan JenisTindakan { get; set; }
        //INI GIMANA YA PAK ?
        [NotMapped]
        public List<checkBoxItem> GigiRawat { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatK1 { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatK2 { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatK3 { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatK4 { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatKI { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatKII { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatKIII { get; set; }
        [NotMapped]
        public List<checkBoxItem> GigiRawatKIV { get; set; }
    }
}
