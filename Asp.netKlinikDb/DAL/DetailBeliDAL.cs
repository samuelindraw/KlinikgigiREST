using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class DetailBeliDAL : IDetailBeli
    {
        private AppDbContext _context;
        private IBarang _Barang;
        private IBeli _Beli;

        public DetailBeliDAL(AppDbContext context, IBarang barang, IBeli beli)
        {
            _context = context;
            _Barang = barang;
            _Beli = beli;
        }
        public async Task CreateAsync(DetailBeli obj)
        {
            try
            {
                if (obj.Tanggal == DateTime.Today)
                {
                    obj.TotalHarga = obj.Harga * obj.Qty;
                    var dt_brg = await _Barang.GetById(obj.IdBarang);
                    dt_brg.Stok = Convert.ToInt16(obj.Qty + dt_brg.Stok);
                    dt_brg.Harga = obj.Harga;
                    await _Barang.UpdateAsync(dt_brg);
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    //perlu looping 
                    //search idbeli then dapet value total e berapa ? 
                    Beli datapembelian = new Beli();
                    datapembelian = await _Beli.GetById(obj.IdBeli);
                    datapembelian.TotalHarga = datapembelian.TotalHarga + obj.TotalHarga;
                    await _Beli.UpdateAsync(datapembelian);
                    //mendapatkan data barang berdasarkan input ID
                    //ketika data barang ada maka stok nya di update dengan stok awal + qty yang akan dinput
                 
                    
                }
                else
                {
                    throw new Exception("Data di input di tanggal pembelian yang berbeda");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            
        }
        public async Task Deletes(string id)
        {
            var data = await getbyid(id.ToString());
            if (data != null)
            {
                try
                {
                    _context.DetailBeli.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Tenant tidak ditemukan");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DetailBeli>> GetAll()
        {
            var data = await(from r in _context.DetailBeli
                             orderby r.DetailBeliId ascending
                             select r).ToListAsync();


            return data;
        }

        public Task<DetailBeli> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DetailBeli> getbyid(string id)
        {
            var data = await(from c in _context.DetailBeli.Include(r => r.Barang).Include(r => r.beli)
                             where c.DetailBeliId == id
                             select c).SingleOrDefaultAsync();
            return data;
        }
        public async Task<IEnumerable<DetailBeli>> sortbyidbeli(int Id)
        {
            var data = await (from r in _context.DetailBeli.Include(r => r.Barang).Include(r => r.beli)
                              where r.IdBeli == Id
                              select r).ToListAsync();


            return data;
        }

        public async Task UpdateAsync(DetailBeli obj)
        {
            var data = await getbyid(obj.DetailBeliId);
            if (data != null)
            {
                try
                {
                   
                    data.Tanggal = obj.Tanggal;
                    data.IdBarang = obj.IdBarang;
                    data.Qty = obj.Qty;
                    data.Harga = obj.Harga;
                    data.TotalHarga = obj.Qty * obj.Harga;
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
    }
}
