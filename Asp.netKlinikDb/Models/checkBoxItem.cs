using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class checkBoxItem
    {
        public string id { get; set; }
        public int gigiPosisi { get; set; }
        public string kuadran { get; set; }
        public bool IsChecked { get; set; }
    }
}
