using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class BarangDAL : IBarang
    {
        private AppDbContext _context;
        private IKatBarang _katbarang;
        public BarangDAL(AppDbContext context, IKatBarang katbarang)
        {
            _context = context;
            _katbarang = katbarang;
        }
        public async Task CreateAsync(Barang obj)
        {
            var datatenant = await _katbarang.GetById(obj.IdKatBarang);
            var data = await getbytenantid(datatenant.TenantID);
            var result = data.Where(e => e.NamaBarang == obj.NamaBarang).ToList();
            if (result.Count == 0)
            {
                try
                {
                    obj.KatBarangIdKategori = obj.IdKatBarang;
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Nama Barang tidak boleh Sama");
            }
           
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.Barang.Remove(data);
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

        public async Task<IEnumerable<Barang>> GetAll()
        {
            var data = await (from r in _context.Barang.Include(r => r.KatBarang).Include(r=>r.KatBarang.Tenant)
                              .Include(r => r.DetailBeli)
                              orderby r.KatBarang ascending
                             select r).ToListAsync();


            return data;
        }

        public async Task<Barang> GetById(int id)
        {
            var data = await(from c in _context.Barang.Include(r => r.KatBarang).Include(r => r.KatBarang.Tenant)
                             where c.IdBarang == id
                             select c).SingleOrDefaultAsync();
            return data;
        }
        public async Task<IEnumerable<Barang>> getbytenantid(string tenantID) 
        {
            var data = await (from c in _context.Barang.Include(r => r.KatBarang).Include(r => r.KatBarang.Tenant)
                              where c.KatBarang.TenantID == tenantID 
                              select c).ToListAsync();
            return data;
        }
        public async Task UpdateAsync(Barang obj)
        {
            //must make sure that the idkatbarang is not null 
            var data = await GetById(obj.IdBarang);
            if (data != null)
            {
                try
                {
                    data.NamaBarang = obj.NamaBarang;
                    data.Harga = obj.Harga;
                    data.Stok = obj.Stok;
                    data.Keterangan = obj.Keterangan;
                    data.IdKatBarang = obj.IdKatBarang;
                    data.Minstok = obj.Minstok;
                    data.KatBarangIdKategori = obj.IdKatBarang;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }

        public async Task<IEnumerable<Barang>> sortbystok(string tenantID)
        {

            var data = await (from c in _context.Barang
                              where c.KatBarang.TenantID == tenantID && c.Stok <= c.Minstok
                              select c).ToListAsync();

            if(data == null)
            {
                throw new Exception("Data tidak ditemukan");
            }
            return data;
        }
    }
}
