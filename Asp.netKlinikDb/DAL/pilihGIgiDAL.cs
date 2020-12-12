using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class pilihGIgiDAL : IpilihGIgi
    {
        private AppDbContext _context;
       
        public pilihGIgiDAL(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task CreateAsync(pilihGIgi obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<pilihGIgi>> GetAll()
        {
            var data = await (from r in _context.pilihGIgi
                             orderby r.idposisiGigi ascending
                             select r).ToListAsync();


            return data;
        }

        public Task<pilihGIgi> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(pilihGIgi obj)
        {
            throw new NotImplementedException();
        }
    }
}
