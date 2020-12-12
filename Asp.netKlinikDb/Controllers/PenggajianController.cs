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
    public class PenggajianController : ControllerBase
    {
        private IPenggajian _Penggajian;
        private IDetailPenggajian _detailPenggajian;
        public PenggajianController(IPenggajian penggajian, IDetailPenggajian detailPenggajian)
        {
            _Penggajian = penggajian;
            _detailPenggajian = detailPenggajian;
        }
        // GET: api/Barang
        [HttpGet]
        [Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<Penggajian>> GetPenggajian()
        {

            var models = await _Penggajian.GetAll();
            return models;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<Penggajian> Get(int id)
        {
            var model = await _Penggajian.GetById(id);
            return model;
        }
        [HttpGet("GetJadwalPerawat/{Username}")]
        [Authorize(Roles = "Admin")]
        public async Task<Penggajian> GetJadwalPerawat(string Username)
        {
            //Username = "kezia";
            var model = await _Penggajian.JadwalGajiPerawat(Username);
            return model;
        }
        // POST: api/Barangs
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Penggajian penggajian)
        {
            try
            {
                await _Penggajian.CreateAsync(penggajian);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetDataGajibyroletenant/{tenantID}/{rolename}")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Penggajian>> getuserbyrole(string tenantID, string rolename)
        {
            var model = await _Penggajian.DataGajiRoleTenannt(tenantID, rolename);
            return model;
        }
        // POST: api/Barangs
        [HttpPost("GajiPerawat")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GajiPerawat([FromBody] Penggajian penggajian)
        {
            try
            {
                await _Penggajian.CreateGajiPerawat(penggajian);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Barangs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Penggajian.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Barangs/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] Penggajian penggajian)
        {
            try
            {
                await _Penggajian.UpdateAsync(penggajian);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}