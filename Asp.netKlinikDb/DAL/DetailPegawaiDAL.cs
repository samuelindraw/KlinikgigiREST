using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class DetailPegawaiDAL : IDetailPegawai
    {
        private AppDbContext _context;

        public DetailPegawaiDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(DetailPegawai obj)
        {
            var datapengguna = await _context.DetailPegawai.Where(r => r.Username == obj.Username).SingleOrDefaultAsync();
            if (datapengguna == null)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Username telah terpakai !");
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.DetailPegawai.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Detail Pegawai tidak ditemukan");
            }
        }

        public async Task DeleteByuser(string Username)
        {
            var data = await _context.DetailPegawai.Where(r => r.Username == Username).SingleOrDefaultAsync();
            if (data != null)
            {
                try
                {
                    _context.DetailPegawai.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Detail Pegawai tidak ditemukan");
            }
        }

        public async Task<IEnumerable<DetailPegawai>> GetAll()
        {
            var results = await(from t in _context.DetailPegawai
                                orderby t.DetailPegawaiID
                                select t).ToListAsync();
            return results;
        }

        public async Task<DetailPegawai> GetById(int id)
        {
            var data = await (from c in _context.DetailPegawai
                              where c.DetailPegawaiID == id
                              select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<DetailPegawai> getusername(string Username, string tenantID)
        {
            var data = await (from c in _context.DetailPegawai
                              where c.Username == Username
                              select c).SingleOrDefaultAsync();

            data.Penggajian = await _context.Penggajian.Where(r => r.Username == Username && r.TenantID == tenantID).Include(r => r.Tenant).ToListAsync();
            data.Prosentase = await _context.Prosentase.Where(r => r.Username == Username && r.TenantID == tenantID).Include(r => r.JenisTindakan).Include(r => r.Tenant).ToListAsync();

            return data;
        }

        public async Task UpdateAsync(DetailPegawai obj)
        {
            //by tenant id
            var data = await _context.DetailPegawai.Where(r => r.Username == obj.Username).SingleOrDefaultAsync();
            if (data != null)
            {
                try
                {
                    data.Gaji = obj.Gaji;
                    data.TanggalJoin = obj.TanggalJoin;
                    data.Jabatan = obj.Jabatan;
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
