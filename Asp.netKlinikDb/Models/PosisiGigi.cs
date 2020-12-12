using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{   
    public class PosisiGigi
    {
        
        public string id { get; set; }
        public int gigiPosisi { get; set; }
        public string kuadran { get; set; }

        public List<pilihGIgi> Posisi { get; set; }

    }
}
