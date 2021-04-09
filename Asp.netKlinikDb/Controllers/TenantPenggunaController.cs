using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantPenggunaController : ControllerBase
    {
        private ITenantPengguna _TenantPengguna;
        private IPengguna _pengguna;
        private IProsentase _prosentase;
        private AppDbContext _context;
        public TenantPenggunaController(AppDbContext context, ITenantPengguna tenantPengguna, IPengguna pengguna, IProsentase prosentase)
        {
            _TenantPengguna = tenantPengguna;
            _pengguna = pengguna;
            _prosentase = prosentase;
            _context = context;
        }
        // GET: api/TenantPengguna
        [HttpGet]
        public async Task<IEnumerable<TenantPengguna>> getall()
        {

            var Models = await _TenantPengguna.GetAll();
            return Models;
        }
        //opsi tenant pengguna di delete atau nggak .
        // POST: api/Pengguna
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] TenantPengguna tenantPengguna)
        {
            try
            {
                    await _TenantPengguna.CreateAsync(tenantPengguna);
                    var idPegawai = _context.DetailPegawai.Where(r => r.Username == tenantPengguna.Username).SingleOrDefault();
                    var datauser = await _pengguna.getpenggunausername(tenantPengguna.Username);
                    var jenistindakan =  _context.JenisTindakan.Where(r => r.TenantID == tenantPengguna.TenantID).ToList();
                    if (datauser.rolename == "Dokter")
                    {
                    //mengecek jika dokter ia akan ditambahkan dengan prosentase nya 
                        foreach (var item in jenistindakan)
                        {
                            Prosentase dt_pros = new Prosentase();
                            dt_pros.Username = datauser.Username;
                            dt_pros.IdJenisTindakan = item.IdJenisTindakan;
                            dt_pros.TenantID = tenantPengguna.TenantID;
                            dt_pros.Prosen = datauser.Prosentase;
                            dt_pros.DetailPegawaiID = idPegawai.DetailPegawaiID;
                            await _prosentase.CreateAsync(dt_pros);
                        }
                    }
                if (datauser.rolename == "Pasien")
                {
                    
                }
                else
                {
                    throw new Exception("Bukan data dokter");
                }
                return Ok("Tambah Data Berhasil");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/TenatnPengguna/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] TenantPengguna tenantPengguna)
        {
            try
            {
                await _TenantPengguna.UpdateAsync(tenantPengguna);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _TenantPengguna.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/TenantPengguna/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<TenantPengguna> Get(string id)
        {

            var model = await _TenantPengguna.GetbyTenantPenggunaID(id);
            return model;
        }
        [HttpGet("gettenantbyusername/{Username}")]
        [Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Admin,Dokter,Perawat")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> gettenantbyusername(string Username)
        {

            var model = await _TenantPengguna.getusertenantlist(Username);
            return Ok(model);

        }
        //tambah laporan ntar
        [HttpPut("EnableTenant/{Username}/{tenantID}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Enabled(string Username, string tenantID)
        {
            try
            {
                var user = _context.TenantPengguna.Where(r => r.Username == Username && r.TenantID == tenantID).SingleOrDefault();
                if (user.StatusTenant == true)
                {

                    user.StatusTenant = false;
                }
                else
                {
                    user.StatusTenant = true;
                    
                }
                await _TenantPengguna.UpdateAsync(user);
                return Ok("Status Users diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}