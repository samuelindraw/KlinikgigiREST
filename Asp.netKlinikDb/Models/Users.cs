using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class Users
    {
        public string Id { get; set; }
        [Key]
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string TenantID { get; set; }
        public string TenantName { get; set; }
        public string rolename { get; set; }
        //current role nampung role lama sebelum di update
        public string currentrole { get; set; }
        public bool IsEnabled { get; set; }
        public bool Status { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string NoHp { get; set; }
        public string NoTelpon { get; set; }
        public float Prosentase { get; set; }
        public short umur{ get; set; }
        public int Gaji { get; set; }
        public DateTime TanggalJoin { get; set; }
        public string RwPenyakit { get; set; }
        [NotMapped]
        public DateTime Registrasi { get; set; }
        public ICollection<Pengguna> Pengguna { get; set; }
    }
}
