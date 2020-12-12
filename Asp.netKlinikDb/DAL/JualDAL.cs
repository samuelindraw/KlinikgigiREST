using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class JualDAL : IJual
    {
        private AppDbContext _context;
        private IBarang _Barang;
        private ITransaksi _transaksi;
        public JualDAL(AppDbContext context, IBarang barang, ITransaksi transaksi)
        {
            _context = context;
            _Barang = barang;
            _transaksi = transaksi;
        }

        public async Task CreateAsync(Jual obj)
        {
            try
            {
                //value barang.stok berkurang
                //harga jual 
                //tenant id di isi sesuai dengan id tenant pengguna yang login 
                var stoklist = await _Barang.GetById(obj.IdBarang);
                var data_transaksi = await _transaksi.GetById(obj.IdTransaksi);
                if (data_transaksi.Tanggal == DateTime.Today)
                {
                    if (stoklist.Stok > obj.Qty)
                    {
                        if (stoklist.KatBarang.TenantID == obj.TenantID)
                        {
                            obj.Harga = obj.Harga * obj.Qty;
                            stoklist.Stok = Convert.ToInt16(stoklist.Stok - obj.Qty);
                            _context.Add(obj);
                            await _context.SaveChangesAsync();
                            await _Barang.UpdateAsync(stoklist);
                        }
                        else
                        {
                            throw new Exception("data Tneant tidak sesuai !");
                        }
                    }
                    else
                    {
                        throw new Exception(" Stok Tidak Cukup");
                    }

                }
                else
                {
                    throw new Exception("Tanggal Transaksi berbeda dari Tanggal hari ini");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    var data_brg = await _Barang.GetById(data.IdBarang);
                    data_brg.Stok = Convert.ToInt16(data_brg.Stok + data.Qty);
                    _context.Jual.Remove(data);
                    await _Barang.UpdateAsync(data_brg);
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

        public async Task<IEnumerable<Jual>> GetAll()
        {
            var data = await(from r in _context.Jual/*.Include(r => r.Tenant).Include(r => r.Transaksi)*/
                             orderby r.IdJual ascending
                              select r).ToListAsync();
            return data;
        }


     
        public async Task<Jual> GetById(int id)
        {
            var data = await(from c in _context.Jual.Include(r => r.Tenant).Include(r => r.Transaksi).Include(r => r.Barang)
                             where c.IdJual == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(Jual obj)
        {
            var data = await GetById(obj.IdJual);
            if (data != null)
            {
                try
                {
                   
                    data.IdJual = obj.IdJual;
                    data.IdTransaksi = obj.IdTransaksi;
                    data.TenantID = obj.TenantID;
                    data.IdBarang = obj.IdBarang;
                    var dataBarang = await _Barang.GetById(data.IdBarang);
                    var Qtyjual = 0;
                    if (obj.Qty >= data.Qty)
                    {
                        
                        Qtyjual = obj.Qty;
                       
                        obj.Qty = Convert.ToInt16(obj.Qty - data.Qty);
                        data.Harga = dataBarang.Harga * Qtyjual;
                        dataBarang.Stok = Convert.ToInt16(dataBarang.Stok - obj.Qty);
                        data.Qty = Convert.ToInt16(Qtyjual);
                    }
                    else if (obj.Qty <= data.Qty)
                    {
                        Qtyjual = obj.Qty;
                        data.Qty = Convert.ToInt16(data.Qty - obj.Qty);//daata yang di kurangkan di stok
                        dataBarang.Stok = Convert.ToInt16(dataBarang.Stok + data.Qty);
                        data.Harga = dataBarang.Harga * Qtyjual;
                        data.Qty = Convert.ToInt16(Qtyjual);
                    }
                    else
                    {
                        data.Qty = obj.Qty;
                        dataBarang.Stok = data.Qty;
                    }
                 
                    await _context.SaveChangesAsync();
                    await _Barang.UpdateAsync(dataBarang);
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
