using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class PenggajianDAL : IPenggajian
    {
        private AppDbContext _context;
        private IPengguna _pengguna;
        private IDetailPenggajian _detailPenggajian;
        private IDetailPegawai _detailPegawai;
        //identity 
        //role
        public PenggajianDAL(AppDbContext context, IPengguna pengguna, IDetailPenggajian detailPenggajian, IDetailPegawai detailPegawai)
        {
            _context = context;
            _pengguna = pengguna;
            _detailPenggajian = detailPenggajian;
            _detailPegawai = detailPegawai;
        }
        public async Task CreateAsync(Penggajian obj)
        {   //gaji tidak bisa waktu tanggal join / sebelum join
          
            var a = Convert.ToDateTime(obj.TanggalAwal);
            var b = Convert.ToDateTime(obj.TanggalAkhir);
            var total = (b - a).TotalDays.ToString();
            obj.MasaWaktu = total;
            // cek nama "" itu dokter atau bukan
            var testUser = await _pengguna.getpenggunausername(obj.Username);
            if (testUser.rolename != "Dokter")
            {
                throw new Exception("Pengguna ini bukanlah Seorang Dokter");
            }
            //detailpegawai + tenant id
            var datapegawai = _context.DetailPegawai.Where(x => x.Username == obj.Username).SingleOrDefault();
            if (datapegawai == null)
            {
                throw new Exception("Pengguna ini bukanlah Seorang Dokter");
            }
            obj.DetailPegawaiID = datapegawai.DetailPegawaiID;
            //search transaksi per tenant dulu + dokter
            var dataTransaksi = _context.Transaksi.Include(e => e.Tindakan).Where(t => t.TenantID == obj.TenantID && t.Username == obj.Username).ToList();
            if (dataTransaksi == null)
            {
                throw new Exception("Pengguna ini belum memiliki transaksi apapuun !");
            }
            //sort sesuai dengan Tanggal yang di pilih
            var Datatgl_transaksi = dataTransaksi.Where(x => x.Tanggal >= obj.TanggalAwal && x.Tanggal <= obj.TanggalAkhir).ToList();
            // Pada saat 
            DetailPenggajian detailgaji = new DetailPenggajian();

            foreach (var item in Datatgl_transaksi)
            {
                
                foreach(var biayaTrans in item.Tindakan)
                {
                    obj.TotalGaji = obj.TotalGaji + (biayaTrans.Biaya * biayaTrans.Persenan/100);
                   
                }
            }
            _context.Add(obj);
            await _context.SaveChangesAsync();
            detailgaji.IdGaji = obj.IdGaji;
            foreach (var test in Datatgl_transaksi)
            {
                
                detailgaji.IdTransaksi = test.IdTransaksi;
                _context.DetailPenggajian.Add(detailgaji);
                detailgaji.IdDetailGaji = 0;
                await _detailPenggajian.CreateAsync(detailgaji);
                //var dt_pegawai1 = await _detailPegawai.getusername(obj.Username);
                //var dt_pegawai = await _context.DetailPegawai.Where(r => r.Username == obj.Username).SingleOrDefaultAsync();
                datapegawai.Gaji = obj.TotalGaji;
                await _detailPegawai.UpdateAsync(datapegawai);
                //update by id ? 
                
                
            }
        }
        public async Task CreateGajiPerawat(Penggajian penggajian)
        {
            var Pengguna = await _pengguna.getpenggunausername(penggajian.Username);
            if (Pengguna.rolename == "Perawat")
            {
                try
                {
                    //tenantid
                    var datapegawai = _context.DetailPegawai.Where(x => x.Username == Pengguna.Username).SingleOrDefault();
                    if(datapegawai == null)
                    {
                        throw new Exception("Data user tidak di temukan");
                    }
                    penggajian.DetailPegawaiID = datapegawai.DetailPegawaiID;
                    penggajian.TanggalAwal = DateTime.Today;
                    penggajian.TanggalAkhir = DateTime.Today;
                    _context.Add(penggajian);
                    await _context.SaveChangesAsync();

                    //var dt_pegawai = await _context.DetailPegawai.Where(r => r.Username == penggajian.Username).SingleOrDefaultAsync();
                    datapegawai.Gaji = penggajian.TotalGaji;
                    await _detailPegawai.UpdateAsync(datapegawai);

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
                    _context.Penggajian.Remove(data);
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

       

        public async Task<IEnumerable<Penggajian>> GetAll()
        {
            var data = await(from r in _context.Penggajian.Include(r => r.Tenant)
                             orderby r.IdGaji ascending
                             select r).ToListAsync();
            foreach(var item in data)
            {
                var UbahToIDR = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", item.TotalGaji);
                item.Totaji = UbahToIDR;
            }
          
            return data;
        }

        public async Task<Penggajian> GetById(int id)
        {
            var data = await (from c in _context.Penggajian.Include(r => r.DetailPenggajian).ThenInclude(r => r.Transaksi).Include(r => r.Tenant)
                              where c.IdGaji == id
                              select c).SingleOrDefaultAsync();

            var UbahToIDR = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", data.TotalGaji);
            data.Totaji = UbahToIDR;
            return data;
        }

        

        public async Task UpdateAsync(Penggajian obj)
        {
            //must make sure that the idkatbarang is not null 
            var data = await GetById(obj.IdGaji);
            if (data != null)
            {
                try
                {
                    var a = Convert.ToDateTime(obj.TanggalAwal);
                    var b = Convert.ToDateTime(obj.TanggalAkhir);
                    var total = (b - a).TotalDays;
                    var testUser = await _pengguna.getpenggunausername(data.Username);
                    if (testUser.rolename != "Dokter")
                    {
                        throw new Exception("Pengguna ini bukanlah Seorang Dokter");
                    }
                    //tenant id
                    var datapegawai = _context.DetailPegawai.Where(x => x.Username == obj.Username).SingleOrDefault();
                    if(datapegawai == null)
                    {
                        throw new Exception("Pengguna ini bukanlah Seorang Dokter");
                    }
                    obj.DetailPegawaiID = datapegawai.DetailPegawaiID;
                    //search transaksi per tenant dulu + dokter
                    var dataTransaksi = _context.Transaksi.Include(e => e.Tindakan).Where(t => t.TenantID == obj.TenantID && t.Username == obj.Username).ToList();
                    if (dataTransaksi == null)
                    {
                        throw new Exception("Pengguna ini belum memiliki transaksi apapuun !");
                    }
                    //sort sesuai dengan Tanggal yang di pilih
                    var Datatgl_transaksi = dataTransaksi.Where(x => x.Tanggal >= obj.TanggalAwal && x.Tanggal <= obj.TanggalAkhir).ToList();
                    // Pada saat 
                    DetailPenggajian detailgaji = new DetailPenggajian();

                    foreach (var item in Datatgl_transaksi)
                    {

                        foreach (var biayaTrans in item.Tindakan)
                        {
                            obj.TotalGaji = obj.TotalGaji + (biayaTrans.Biaya * biayaTrans.Persenan / 100);

                        }
                    }
                    datapegawai.Gaji = obj.TotalGaji;
                    await _detailPegawai.UpdateAsync(datapegawai);
                    data.MasaWaktu = (data.TanggalAkhir - data.TanggalAwal).ToString();
                    data.TanggalAkhir = obj.TanggalAkhir;
                    data.TanggalAwal = obj.TanggalAwal;
                    data.TanggalGaji = obj.TanggalGaji;
                    data.TotalGaji = obj.TotalGaji;
                    await _context.SaveChangesAsync();
                    var Det_gaji = await _context.DetailPenggajian.Where(r => r.IdGaji == data.IdGaji).ToListAsync();
                    foreach(var deletedetail in Det_gaji)
                    {
                        await _detailPenggajian.Delete(deletedetail.IdDetailGaji);
                    }
                    detailgaji.IdGaji = obj.IdGaji;
                    foreach (var test in Datatgl_transaksi)
                    {
                        detailgaji.IdTransaksi = test.IdTransaksi;
                        _context.DetailPenggajian.Add(detailgaji);
                        detailgaji.IdDetailGaji = 0;
                        await _detailPenggajian.CreateAsync(detailgaji);

                    }


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
        //DELETE INI
        public async Task<IEnumerable<Penggajian>> GajiPerawatTenantID(string TenantID)
        {
            
            var data = await(from c in _context.Penggajian.Include(r => r.DetailPenggajian).Include(r => r.Tenant).Include(r => r.Pengguna)
                             where c.TenantID == TenantID & c.Pengguna.rolename == "Perawat"
                             select c).ToListAsync();

         
            foreach (var item in data)
            {
                var UbahToIDR = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", item.TotalGaji);
                item.Totaji = UbahToIDR;
            }
            //var sortperawat = data.Where(r=> r.Pengguna.ro)
            return data;
        }

        public async Task<IEnumerable<Penggajian>> DataGajiRoleTenannt(string tenantID, string rolename)
        {
            var data = await (from c in _context.Penggajian.Include(r => r.DetailPenggajian).Include(r => r.Tenant).Include(r=> r.Pengguna)
                              where c.TenantID == tenantID & c.Pengguna.rolename == rolename
                              select c).ToListAsync();
            foreach (var item in data)
            {
                var UbahToIDR = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", item.TotalGaji);
                item.Totaji = UbahToIDR;
            }
            return data;
        }

        public async Task<Penggajian> JadwalGajiPerawat(string Username)
        {
            //tenantid
            var dataperawat = await _context.Penggajian.Where(r => r.Username == Username).LastAsync();
            dataperawat.Tanggalbulandepan = dataperawat.TanggalGaji.AddMonths(1);
            return dataperawat;
        }

    }
}
