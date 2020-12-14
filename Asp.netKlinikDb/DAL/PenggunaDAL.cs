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
    public class PenggunaDAL : IPengguna
    {
        private UserManager<ApplicationUser> _userManager;
        private AppDbContext _context;
        private IUserRole _UserRole;
        private IUser _userService;
        private IDetailPasien _detailPasien;
        private IDetailPegawai _detailPegawai;
        private ITenantPengguna _tenantPengguna;
        private IProsentase _prosentase;

        public PenggunaDAL(AppDbContext context, UserManager<ApplicationUser> userManager, IUserRole UserRole, IUser userservice, IDetailPasien detailPasien
            ,IDetailPegawai detailPegawai, ITenantPengguna tenantpengguna, IProsentase prosentase)
        {
            _context = context;
            _userManager = userManager;
            _UserRole = UserRole;
            _userService = userservice;
            _detailPasien = detailPasien;
            _detailPegawai = detailPegawai;
            _tenantPengguna = tenantpengguna;
            _prosentase = prosentase;
           
           
        }
        public async Task CreateAsync(Pengguna obj)
        {
            //username per tenant tak boleh sama beda tenant boleh sama
            var datapengguna = await getpenggunausername(obj.Username);
            if (datapengguna == null)
            {
               
                if(datapengguna.rolename != "Dokter")
                {
                    obj.Prosentase = 0;
                }
                _context.Add(obj);
               
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Username telah terpakai !");
            }
        }
        //UNTUK GET LIST PASIEN PER TENANT
        public async Task<IEnumerable<Pengguna>> dataUserPerTenant(string tenantID, string rolename)
        {
            var data = await(from c in _context.Pengguna.Include(r => r.Tenant).Include( r=> r.detailPegawai).Include(r=>r.TenantPengguna)
                             where c.rolename == rolename
                             select c).ToListAsync();

            foreach(var item in data)
            {
                var identityuser = await _userManager.FindByNameAsync(item.Username);
                var finduserrole = await _userManager.GetRolesAsync(identityuser);
             
                IdentityOptions _option = new IdentityOptions();
                var userrole = (_option.ClaimsIdentity.RoleClaimType, finduserrole.SingleOrDefault()).Item2;
                var lookedEnabled = await _userService.GetbyUsername(item.Username);
                
                item.rolename = userrole;
                item.IsEnabled = lookedEnabled.IsEnabled;
                item.Status = lookedEnabled.Status;
                var tenantpengguna = await _context.TenantPengguna.Where(r => r.TenantID == tenantID && r.Username == item.Username).SingleOrDefaultAsync();
                if (tenantpengguna == null)
                {
                    item.TenantID = item.TenantID;
                }
                else
                {
                    item.TenantID = tenantpengguna.TenantID;
                }
               
            }

            var datauser = data.Where(x => x.TenantID == tenantID).ToList();
   
           
            return datauser;
        }
        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.Pengguna.Remove(data);
                    
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Pengguna tidak ditemukan");
            }
        }

        public async Task DeletebyUser(string Username)
        {
            
            var data = await getpenggunausername(Username);
            if (data != null)
            {
                try
                {
                   
                    _context.Pengguna.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data pengguna tidak ditemukan");
            }
        }
        //untuk system admin
        public async Task<IEnumerable<Pengguna>> GetAll()
        {
            var data = await(from t in _context.Pengguna
                                orderby t.Username
                                select t).ToListAsync();
            foreach (var item in data)
            {
                var identityuser = await _userManager.FindByNameAsync(item.Username);
                var finduserrole = await _userManager.GetRolesAsync(identityuser);

                IdentityOptions _option = new IdentityOptions();
                var userrole = (_option.ClaimsIdentity.RoleClaimType, finduserrole.SingleOrDefault()).Item2;
                item.rolename = userrole;
            }

            return data;
        }

        public async Task<Pengguna> GetById(int id)
        {
            var data = await(from c in _context.Pengguna
                             where c.Username == id.ToString()
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<Pengguna> getIdPasien(string IdPasien, string tenantID)
        {
            var data = await (from c in _context.Pengguna.Include(r => r.detailPasien).Include(r => r.Tenant).Include(r => r.TenantPengguna).ThenInclude(r => r.Tenant)
                              where c.IdPasien == IdPasien 
                              select c).SingleOrDefaultAsync();

            var identityuser = await _userManager.FindByNameAsync(data.Username);
            var finduserrole = await _userManager.GetRolesAsync(identityuser);
            data.Transaksi = await _context.Transaksi.Where(r => r.IdPasien == IdPasien && r.TenantID == tenantID).ToListAsync();
            IdentityOptions _option = new IdentityOptions();
            var userrole = (_option.ClaimsIdentity.RoleClaimType, finduserrole.SingleOrDefault()).Item2;
            data.rolename = userrole;
            return data;
        }

        //pada saat admin edit user lain 
        public async Task<Pengguna> getpenggunausername(string Username)
        {
            var data = await(from c in _context.Pengguna.Include(r=>r.detailPegawai)
                             where c.Username == Username
                             select c).SingleOrDefaultAsync();

            var identityuser = await _userManager.FindByNameAsync(Username);
            var finduserrole = await _userManager.GetRolesAsync(identityuser);
            IdentityOptions _option = new IdentityOptions();
            var userrole = (_option.ClaimsIdentity.RoleClaimType, finduserrole.SingleOrDefault()).Item2;
            data.rolename = userrole;
            
            return data;
        }
        public async Task UpdateAsync(Pengguna obj)
        {
            try
            {
                //harus dapetin role dari user
                var getdatapengguna = await getpenggunausername(obj.Username);
                if (getdatapengguna.rolename == null)
                {
                    await _UserRole.AddUserToRoleAsync(obj.Username, obj.rolename);
                }
                else
                {
                    await _UserRole.RemoveuserRole(getdatapengguna.Username, getdatapengguna.rolename);
                    await _UserRole.AddUserToRoleAsync(obj.Username, obj.rolename);
                }
                if (getdatapengguna.rolename == null)
                {
                    await _UserRole.AddUserToRoleAsync(obj.Username, obj.rolename);
                }
                if (obj.rolename != "Pasien")
                {
                    if (getdatapengguna.IdPasien != null)
                    {
                        obj.IdPasien = null;
                    }
                    var detailpasien = await _detailPasien.getusername(obj.Username);
                    if(detailpasien != null)
                    {
                        await _detailPasien.DeleteByuser(obj.Username);
                    }
                   
                    DetailPegawai pegawai = new DetailPegawai();

                    var pegawaii = await _detailPegawai.getusername(obj.Username,obj.TenantID);
                    if(pegawaii == null)
                    
                    {
                        pegawai.Username = obj.Username;
                        pegawai.Jabatan = obj.rolename;
                        pegawai.TanggalJoin = DateTime.Today;
                        await _detailPegawai.CreateAsync(pegawai);
                    }
                    // create data pegawai 

                }
                else if (obj.rolename == "Pasien")
                {
                    //kasi contraint klo ada data pasien nya g usah di delete tapi di update 
                    // klo g ada dia create 
                    DetailPasien detpasien = new DetailPasien();
                    var detailpas = await _detailPasien.getusername(obj.Username);
                    if (detailpas == null)
                    {
                        obj.IdPasien = "pasien" + obj.Username;
                        detpasien.IdPasien = obj.IdPasien;
                        detpasien.Username = obj.Username;
                        detpasien.Registrasi = DateTime.Today;
                        await _detailPasien.CreateAsync(detpasien);
                    }
                }
                Users user = new Users();
                user.Username = obj.Username;
                user.Email = obj.Email;
                await _userService.Updateuser(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.InnerException.Message}");
            }

            var data = await getpenggunausername(obj.Username);
            if (data != null)
            {
                try
                {
                    data.IdPasien = obj.IdPasien;
                    data.Alamat = obj.Alamat;
                    data.Nama = obj.Nama;
                    data.Gender = obj.Gender;
                    data.Umur = obj.Umur;
                    data.Kota = obj.Kota;
                    data.NoTelpon = obj.NoTelpon;
                    data.NoHP = obj.NoHP;
                    data.Email = obj.Email;
                    data.rolename = obj.rolename;
                    data.Prosentase = obj.Prosentase;
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

        public async Task Updatetenant(Pengguna obj)
        {
            var data = await getpenggunausername(obj.Username);
            if (data != null)
            {
                try
                {
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
