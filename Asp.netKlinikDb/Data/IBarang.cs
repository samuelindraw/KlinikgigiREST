using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IBarang : ICrud<Barang>
    {
        Task<IEnumerable<Barang>> getbytenantid(string tenantID);
        Task<IEnumerable<Barang>> sortbystok(string tenantID);
    }
}
