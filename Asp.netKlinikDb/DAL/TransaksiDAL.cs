using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Asp.netKlinikDb.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class TransaksiDAL : ITransaksi
    {
        private AppDbContext _context;
        private IPengguna _pengguna;
        private UserManager<ApplicationUser> _userManager;
        private IUserRole _UserRole;

       


        public TransaksiDAL(AppDbContext context, IPengguna pengguna, IUserRole userrole, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _pengguna = pengguna;
            _UserRole = userrole;
            _userManager = userManager;
        }

        public async Task CreateAsync(Transaksi obj)
        {
            
            var datapasien = await _context.Pengguna.Where(r => r.IdPasien == obj.IdPasien).Include(r=>r.detailPasien).SingleOrDefaultAsync();
            IdentityOptions _option = new IdentityOptions();

            var searchuser = await _userManager.FindByNameAsync(datapasien.Username);
            var role = await _userManager.GetRolesAsync(searchuser);
            var rolename = (_option.ClaimsIdentity.RoleClaimType, role.SingleOrDefault()).Item2;

            
            if (datapasien != null && datapasien.rolename == rolename)
            {
                
                var dt_periksa = await _context.Transaksi.Where(r => r.IdPasien == obj.IdPasien && r.Tanggal == obj.Tanggal).ToListAsync();
                var datacount = dt_periksa.Count();
                if(dt_periksa.Count() <= 3)
                {
                    try
                    {
                        obj.DetailPasienID = datapasien.detailPasien.DetailPasienID;
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
                    throw new Exception("Data pemeriksaan pasien hari ini lebih dari 3x, harap di perhatikan ");
                }
            }
            else
            {
                throw new Exception("Data & Role User Pasien Tidak di temukan");
            }
        }

       

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                   
                    _context.Transaksi.Remove(data);
                   
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

        public async Task<IEnumerable<Transaksi>> GetAll()
        {

            var results = await (from t in _context.Transaksi.Include(r => r.Tenant)
                                orderby t.IdTransaksi
                                select t).ToListAsync();


            return results;
        }

        public async Task<Transaksi> GetById(int id)
        {
            var data = await (from c in _context.Transaksi.Include(r => r.Tenant).Include(r=>r.Pengguna).Include(r => r.DetailPasien).ThenInclude(r=>r.Pengguna).Include(r=> r.DetailPenggajian).
                              Include(r => r.Tindakan).
                              ThenInclude(r => r.Posisi).Include(r => r.Tindakan).ThenInclude(r => r.JenisTindakan).Include(r => r.Jual).ThenInclude(r => r.Barang)
                              where c.IdTransaksi == id
                              select c).SingleOrDefaultAsync();


            if (data == null)
            {
                throw new Exception("Data tidak ditemukan");
            }


            List<checkBoxItem> datachecked = new List<checkBoxItem>();
            foreach (var item in data.Tindakan)
            {
                var allgigi = _context.PosisiGigi.Select(vm => new checkBoxItem()
                {
                    id = vm.id,
                    gigiPosisi = vm.gigiPosisi,
                    kuadran = vm.kuadran,
                    IsChecked = vm.Posisi.Any(x => x.IdTindakan == item.IdTindakan) ? true : false
                }).ToList();
                datachecked = allgigi.Where(r => r.IsChecked == true).Select(chekd => new checkBoxItem()
                {
                    id = chekd.id,
                    gigiPosisi = chekd.gigiPosisi,
                    kuadran = chekd.kuadran,
                    IsChecked = chekd.IsChecked
                }).ToList();
                item.GigiRawat = datachecked;
                data.GigiRawat = item.GigiRawat;
            }

            return data;
        }
      
        public async Task UpdateAsync(Transaksi obj)
        {
            //must make sure that the idkatbarang is not null 
            var data = await GetById(obj.IdTransaksi);
            if (data != null)
            {
                try
                {
                    data.Anamnesis = obj.Anamnesis;
                    data.Tanggal = obj.Tanggal;
                    data.Resep = obj.Resep;
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
