using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IPengguna : ICrud<Pengguna>
    {
        Task<Pengguna> getpenggunausername(string Username);
        Task<Pengguna> getIdPasien(string IdPasien, string tenantID);
        Task DeletebyUser(string Username);
        Task Updatetenant(Pengguna obj);
        Task<IEnumerable<Pengguna>> dataUserPerTenant(string tenantID, string rolename);
    }
}
