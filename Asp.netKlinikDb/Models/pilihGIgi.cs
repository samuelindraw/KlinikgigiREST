using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class pilihGIgi
    {
        public int IdTindakan { get; set; }
        public Tindakan Tindakan { get; set; }
        public string idposisiGigi { get; set; }
        public PosisiGigi PosisiGigi { get; set; }

        
    }
}
