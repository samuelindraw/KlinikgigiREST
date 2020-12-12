using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private IBarang _Barang;
        public BarangController(IBarang Barang)
        {
            _Barang = Barang;
        }

        // GET: api/Barang
        [HttpGet]
        [Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Barang>> GetBarang()
        {
          
            var models = await _Barang.GetAll();
            return models;
        }
        [HttpGet("sortbystok")]
        [Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Barang>> sortbystok(string tenantID)
        {
            var models = await _Barang.sortbystok(tenantID);
            return models;
        }

        // GET: api/Barangs/5
        [HttpGet("{id}")]
        public async Task<Barang> Get(int id)
        {
            var model = await _Barang.GetById(id);
            return model;
        }
        // PUT: api/Barangs/5
        [HttpPut("{id}")]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] Barang Barang)
        {
            try
            {
                await _Barang.UpdateAsync(Barang);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Barangs
        [HttpPost]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Post([FromBody] Barang Barang)
        {
            try
            {
                await _Barang.CreateAsync(Barang);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getbarangtenantid/{TenantID}")]
        // GET: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant
        // Gunanya adalah data barang yang sudah tersort dengan tenant ID 
        [Authorize(Roles = "Admin, Dokter")]
        public async Task<IActionResult> getbarangtenantid(string TenantID)
        {

            var model = await _Barang.getbytenantid(TenantID);
            
            return Ok(model);

        }
        // DELETE: api/Barangs/5
        [HttpDelete("{id}")]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Barang.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
