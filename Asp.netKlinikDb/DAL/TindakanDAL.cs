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
    public class TindakanDAL : ITindakan
    {
        private AppDbContext _context;
        private IJenisTindakan _jenisTindakan;
        private ITransaksi _Transaksi;
        private IPengguna _pengguna;
        private IProsentase _prosentase;
        public TindakanDAL(AppDbContext context, ITransaksi transaksi, IJenisTindakan jenisTindakan,
            IPengguna pengguna, IProsentase prosentase)
        {
            _context = context;
            _Transaksi = transaksi;
            _jenisTindakan = jenisTindakan;
            _pengguna = pengguna;
            _prosentase = prosentase;
        }
        public async Task CreateAsync(Tindakan obj)
        {

            var dt_transaksi = 0;
            var datapasien = await DataTransaksi(obj.IdTransaksi);
            foreach (var data in datapasien)
            {

                if (data.Status == "Selesai")
                {
                    dt_transaksi = +1;
                }
            }
            if (dt_transaksi == 0)
            {
                //ambil tenant iD transaksi = tenant ID yang di gunakan oleh tindakan.
                //1.cek data transaksi yang di masukan, setelah di cari di lihat dan di bandingkan dengan tenant obj
                //tenant ID yang di ambil harus sesuai dengan tenantID pengguna(dokter) login.
                var tnt_transaksi = await _Transaksi.GetById(obj.IdTransaksi);// dan ID
                var tnt_pengguna = await _pengguna.getpenggunausername(tnt_transaksi.Username);
                var dt_JenisTindakanid = await _jenisTindakan.GetById(obj.IdJenisTindakan);
                if (tnt_pengguna.TenantID == obj.TenantID && tnt_transaksi.Tanggal == DateTime.Today)//&& dan tanggal dari transaksi = hari ini tidak boleh ngisi kemaren, datetimme (now) )
                {
                    if (tnt_transaksi.TenantID == tnt_pengguna.TenantID && dt_JenisTindakanid.TenantID == tnt_pengguna.TenantID)
                    {
                        var dt_prosentase = await _context.Prosentase.Where(r => r.Username == tnt_pengguna.Username).Include(r => r.JenisTindakan).ToListAsync();
                        var result = dt_prosentase.Where(e => e.IdJenisTindakan == obj.IdJenisTindakan).SingleOrDefault();

                        obj.Persenan = Convert.ToInt16(result.Prosen);
                        
                        _context.Add(obj);
                        await _context.SaveChangesAsync();
                        List<pilihGIgi> stc = new List<pilihGIgi>();
                        
                        foreach (var item in obj.GigiRawatK1)
                        {
                            
                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK2)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK3)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK4)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKI)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKII)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKIII)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKIV)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        //foreach (var item in stc)
                        var totalgigi = stc.Count();
                        obj.Biaya = obj.BiayaDasar * totalgigi;
                        obj.Posisi = stc;
                        obj.IdTindakan = obj.IdTindakan;
                        await UpdateAsync(obj);
                       
                    }

                }
                else
                {

                }

            }
            else
            {
                throw new Exception("Data Transaksi User Tidak Bisa di isi karena Transaksi telah Selesai");
            }


        }
        public async Task UpdateAsync(Tindakan obj)
        {
            var dt_transaksi = 0;
            var datapasien = await DataTransaksi(obj.IdTransaksi);
            foreach (var Datatr in datapasien)
            {

                if (Datatr.Status == "Selesai")
                {
                    dt_transaksi = +1;
                }
            }
            if (dt_transaksi == 0)
            {
                var tnt_transaksi = await _Transaksi.GetById(obj.IdTransaksi);// dan ID
                var tnt_pengguna = await _pengguna.getpenggunausername(tnt_transaksi.Username);
                var dt_JenisTindakanid = await _jenisTindakan.GetById(obj.IdJenisTindakan);
                if (tnt_pengguna.TenantID == obj.TenantID && tnt_transaksi.Tanggal == DateTime.Today)//&& dan tanggal dari transaksi = hari ini tidak boleh ngisi kemaren, datetimme (now) )
                {
                    if (tnt_transaksi.TenantID == tnt_pengguna.TenantID && dt_JenisTindakanid.TenantID == tnt_pengguna.TenantID)
                    {
                       
                        var dt_prosentase = await _context.Prosentase.Where(r => r.Username == tnt_pengguna.Username && r.TenantID == obj.TenantID).ToListAsync();
                        var result = dt_prosentase.Where(e => e.IdJenisTindakan == obj.IdJenisTindakan).SingleOrDefault();

                        obj.Persenan = Convert.ToInt16(result.Prosen);
                      
                        List<pilihGIgi> stc = new List<pilihGIgi>();

                        foreach (var item in obj.GigiRawatK1)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK2)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK3)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatK4)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKI)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKII)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKIII)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        foreach (var item in obj.GigiRawatKIV)
                        {

                            if (item.IsChecked == true)
                            {
                                stc.Add(new pilihGIgi() { IdTindakan = obj.IdTindakan, idposisiGigi = item.id });
                            }

                        }
                        var Gigiselection = stc.Count();
                        obj.Biaya = obj.BiayaDasar * Gigiselection;
                        obj.Posisi = stc;
                    }
                    else
                    {
                        throw new Exception("Data Update GAGAL");
                    }

                    var data = await GetById(obj.IdTindakan);
                    if (data != null)
                    {
                        try
                        {
                            data.IdJenisTindakan = obj.IdJenisTindakan;
                            data.Persenan = obj.Persenan;
                            data.Biaya = obj.Biaya;
                            data.Diagnosis = obj.Diagnosis;
                            data.BiayaDasar = obj.BiayaDasar;
                            data.Status = obj.Status;
                            data.Posisi = obj.Posisi;
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
        public async Task<IEnumerable<Tindakan>> DataTransaksi(int IdTransaksi)
        {
            var data = await (from c in _context.Tindakan.Include(r => r.JenisTindakan).Include(r => r.Tenant)
                                 .Include(r => r.Posisi).ThenInclude(r => r.PosisiGigi)
                              where c.IdTransaksi == IdTransaksi
                              select c).ToListAsync();


            List<checkBoxItem> datachecked = new List<checkBoxItem>();
            foreach (var item in data)
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

            }

            return data;
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.Tindakan.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Tindakan tidak ditemukan");
            }
        }

        public async Task<IEnumerable<Tindakan>> GetAll()
        {
            var results = await(from t in _context.Tindakan.Include(r => r.Transaksi).Include(r => r.JenisTindakan).Include(r => r.Tenant)
                                .Include(r => r.Posisi)
                                orderby t.IdTindakan
                                select t).ToListAsync(); 
            return results;
        }

        public async Task<Tindakan> GetById(int id)
        {
            var data = await (from c in _context.Tindakan.Include(r => r.Transaksi).Include(r => r.JenisTindakan).Include(r => r.Tenant)
                                 .Include(r => r.Posisi).ThenInclude(r => r.PosisiGigi)
                             where c.IdTindakan == id
                             select c).SingleOrDefaultAsync();

            var allgigi = _context.PosisiGigi.Select(vm => new checkBoxItem()
            {
                id = vm.id,
                gigiPosisi = vm.gigiPosisi,
                kuadran = vm.kuadran,
                IsChecked = vm.Posisi.Any(x => x.IdTindakan == data.IdTindakan) ? true : false
            }).ToList();
            data.GigiRawat = allgigi;
            return data;
        }
        public async Task Transaksi_Selesai(Tindakan tindakan)
        {
            var Id = tindakan.IdTransaksi;
            var transaksi = await _Transaksi.GetById(Id);
            //Tindakan data = new Tindakan();
            foreach (var item in transaksi.Tindakan)
            {
                if (item.Status == "belum")
                {
                    try
                    {
                        var data = await GetById(item.IdTindakan);
                        data.Status = "Selesai";
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.InnerException.Message);
                    }

                }
            }
        }
    }
}
