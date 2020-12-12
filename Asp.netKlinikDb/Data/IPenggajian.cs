using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IPenggajian : ICrud<Penggajian>
    {
        Task CreateGajiPerawat(Penggajian penggajian);
        Task<Penggajian> JadwalGajiPerawat(string Username);

        Task<IEnumerable<Penggajian>> DataGajiRoleTenannt(string tenantID, string rolename);
    }
}
