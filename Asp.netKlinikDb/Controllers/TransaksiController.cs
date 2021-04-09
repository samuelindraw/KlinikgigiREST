using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private ITransaksi _Transaksi;
        private IJual _jual;
        private AppDbContext _context;

        public TransaksiController(ITransaksi transaksi,IJual jual, AppDbContext context)
        {

            _Transaksi = transaksi;
            _jual = jual;
            _context = context;
        }
        // GET: api/Transaksi
        [HttpGet]
        ///hapus authorized
        [Authorize(Roles  = "Admin, Dokter")]
        public async Task<IEnumerable<Transaksi>> Transaksi()
        {
            var Models = await _Transaksi.GetAll();
            return Models;
        }
        // GET: api/Transaksi/5
        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat,Pasien")]
        public async Task<Transaksi> Get(int Id)
        {
            var model = await _Transaksi.GetById(Id);
            return model;
        }
        // POST: api/Transaksi
        [HttpPost]
        [Authorize(Roles = "Admin,Dokter")]
        public async Task<IActionResult> Post([FromBody] Transaksi Transaksi)
        {
            try
            {
                await _Transaksi.CreateAsync(Transaksi);
             
                return StatusCode(200, Transaksi);
                //return Content(coba, Transaksi.IdPasien);
                //return Ok(Transaksi);
              

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Transaksi/5
        [HttpDelete("{Id}")]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                //var datajual1 = await _jual.getjualbyTransaksi(Id);
                var datajual =  _context.Jual.Where(r => r.IdTransaksi == Id).ToList();
                foreach (var item in datajual)
                {
                    await _jual.Delete(item.IdJual);
                }
                await _Transaksi.Delete(Id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Transaksi/5
        [HttpDelete("BatalTransaksi/{Id}")]
        [Authorize(Roles = "Admin,Dokter")]
        public async Task<IActionResult> BatalTransaksi(int Id)
        {
            try
            {
                var Tanggalan = await _Transaksi.GetById(Id);
                if (Tanggalan.Tanggal == DateTime.Today)
                {
                    var datajual = _context.Jual.Where(r => r.IdTransaksi == Id).ToList();
                    foreach (var item in datajual)
                    {
                        await _jual.Delete(item.IdJual);
                    }
                    await _Transaksi.Delete(Id);
                }
                else
                {
                    return BadRequest("Tidak boleh Transaksi sudah tidak dapat di batalkan");
                }
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Transaksi/5
        [HttpPut]
        [Authorize(Roles  = "Admin,Dokter")]
        public async Task<IActionResult> Put([FromBody] Transaksi Transaksi)
        {
            try
            {
                await _Transaksi.UpdateAsync(Transaksi);
                return StatusCode(200, Transaksi.IdTransaksi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}