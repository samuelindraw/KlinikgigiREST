using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class posisiGigiDAL: IposisiGigi
    {
        private AppDbContext _context;
        public posisiGigiDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PosisiGigi obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public  Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PosisiGigi>> GetAll()
        {
            var data = await (from r in _context.PosisiGigi.Include(r => r.Posisi)
                              orderby r.kuadran ascending orderby r.gigiPosisi ascending
                              select r).ToListAsync();


            return data;
        }

        public Task<PosisiGigi> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PosisiGigi obj)
        {
            throw new NotImplementedException();
        }
    }
}
