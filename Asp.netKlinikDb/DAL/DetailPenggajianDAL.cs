using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class DetailPenggajianDAL : IDetailPenggajian
    {
        private AppDbContext _context;
        public DetailPenggajianDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(DetailPenggajian obj)
        {
            try
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.DetailPenggajian.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }

        public async Task<IEnumerable<DetailPenggajian>> GetAll()
        {
            var data = await(from r in _context.DetailPenggajian.Include(r => r.Penggajian).Include(r => r.Transaksi)
                             orderby r.IdGaji ascending
                             select r).ToListAsync();

            return data;
        }

        public async Task<DetailPenggajian> GetById(int id)
        {
             var data = await(from c in _context.DetailPenggajian.Include(r => r.Transaksi)
                              where c.IdDetailGaji == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public Task UpdateAsync(DetailPenggajian obj)
        {
            throw new NotImplementedException();
        }
    }
}
