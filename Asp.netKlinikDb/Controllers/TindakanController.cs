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
    public class TindakanController : ControllerBase
    {
        private ITindakan _Tindakan;
        private IBarang _Barang;

        public TindakanController(ITindakan tindakan, IBarang Barang)
        {

            _Tindakan = tindakan;
            _Barang = Barang;
        }
        // GET: api/sorttransaksi/5
        [HttpGet("sorttransaksi/{IdTransaksi}")]
        [Authorize(Roles  = "Admin,Dokter")]
        public async Task<IActionResult> sorttransaksi(int IdTransaksi)
        {

            var model = await _Tindakan.DataTransaksi(IdTransaksi);
            foreach(var item in model)
            {
                var test = item.GigiRawat;
            }
            return Ok(model);

        }
        // PUT: api/Barangs/5
        [HttpPut("Transaksi_Selesai")]
        [Authorize(Roles  = "Dokter")]
        public async Task<IActionResult> Transaksi_Selesai(Tindakan tindakan,int Id)
        {
            try
            {
                
                await _Tindakan.Transaksi_Selesai(tindakan);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Barang
        [HttpGet]
        [Authorize(Roles = "Admin,Dokter")]
        public async Task<IEnumerable<Tindakan>>GetTindakan()
        {
            var models = await _Tindakan.GetAll();
            return models;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Dokter")]
        public async Task<IActionResult> Post([FromBody] Tindakan tindakan)
        {
            try
            {

                await _Tindakan.CreateAsync(tindakan);
                return Ok("Tambah Data Transaksi Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/KatBarang/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Tindakan.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Tindakan/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,Dokter")]
        public async Task<Tindakan> Get(int id)
        {

            var model = await _Tindakan.GetById(id);
            return model;
        }
        // PUT: api/Barangs/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Dokter")]
        public async Task<IActionResult> Put([FromBody] Tindakan Tindakan)
        {
            try
            {
                await _Tindakan.UpdateAsync(Tindakan);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}