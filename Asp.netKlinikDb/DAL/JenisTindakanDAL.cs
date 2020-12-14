using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class JenisTindakanDAL : IJenisTindakan
    {
        private AppDbContext _context;
        private IPengguna _pengguna;
        private UserManager<ApplicationUser> _userManager;
        //private IUserRole _UserRole;
        private IProsentase _Prosentase;
        private ITenantPengguna _tenantPengguna;
        public JenisTindakanDAL(AppDbContext context ,IPengguna pengguna, UserManager<ApplicationUser> userManager,ITenantPengguna tenantPengguna,IProsentase prosentase)
        {
            _context = context;
           _pengguna = pengguna;
            //_UserRole = userRole;
            _userManager = userManager;
            _Prosentase =  prosentase;
            _tenantPengguna = tenantPengguna;

        }
        public async Task CreateAsync(JenisTindakan obj)
        {
            //result dengan mencari dari hasil search tenant
            var data = await getbytenantid(obj.TenantID);
            //var result = data.Where(e => e.Jenis == obj.Jenis).ToList();
            var result = _context.JenisTindakan.Where(e => e.Jenis == obj.Jenis && e.IdKatJenis == obj.IdKatJenis).SingleOrDefault();
            //mencari data tenant ccc
            if (result == null)
            {
               
                var dt_dokter = await _pengguna.dataUserPerTenant(obj.TenantID,"Dokter");
                var result2 = dt_dokter.Where(e => e.TenantID == obj.TenantID).ToList();
                if (result2.Count == 0)
                {
                    throw new Exception("Data pengguna di tenant ini tidak ada");
                }
                _context.Add(obj);
                IdentityOptions _option = new IdentityOptions();
                foreach (var dokter in dt_dokter)
                {
                   
                    if (dokter.rolename == "Dokter" )
                    {
                       
                        Prosentase dt_pros = new Prosentase();
                        dt_pros.Username = dokter.Username;
                        dt_pros.IdJenisTindakan = obj.IdJenisTindakan;
                        dt_pros.TenantID = obj.TenantID;
                        dt_pros.Prosen = dokter.Prosentase;
                        dt_pros.DetailPegawaiID = dokter.detailPegawai.DetailPegawaiID;
                        await _Prosentase.CreateAsync(dt_pros);
                        
                    }
                    else
                    {
                        throw new Exception("Bukan data dokter");
                    }
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nama Jenis Tindakan tidak boleh sama");
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.JenisTindakan.Remove(data);
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

        public async Task<IEnumerable<JenisTindakan>> GetAll()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(150);
            var data = await(from r in _context.JenisTindakan.Include(r => r.Tenant)
                             select r).AsNoTracking().ToListAsync();


            return data;
        }

        public async Task<JenisTindakan> GetById(int id)
        {
            var data = await(from c in _context.JenisTindakan.Include(r => r.Tenant).Include(r => r.KatJenis).Include(r => r.Prosentase).
                             Include(r => r.Tindakan)
                             where c.IdJenisTindakan == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<JenisTindakan>> getbytenantid(string tenantID)
        {
            var data = await(from c in _context.JenisTindakan.Include(r => r.Tenant).Include(r => r.KatJenis)
                             where c.TenantID == tenantID
                             select c).ToListAsync();
            return data;
        }
        public async Task<IEnumerable<JenisTindakan>> getidkatjenis(int Id)
        {
            var data = await (from c in _context.JenisTindakan.Include(r => r.Tenant)
                              where c.IdKatJenis == Id
                              select c).ToListAsync();
            return data;
        }

        public async Task UpdateAsync(JenisTindakan obj)
        {
            var data = await GetById(obj.IdJenisTindakan);
            if (data != null)
            {
                try
                {
                    data.IdKatJenis = obj.IdKatJenis;
                    data.Jenis = obj.Jenis;
                    data.Biaya = obj.Biaya;
                    data.Keterangan = obj.Keterangan;
                    data.TenantID = obj.TenantID;
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
