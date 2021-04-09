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
    public class JualController : ControllerBase
    {
        private IJual _jual;
        private IBarang _Barang;
        public JualController(IJual jual, IBarang Barang)
        {
            _jual = jual;
            _Barang = Barang;
        }
        // POST: api/Barangs
        [HttpPost]
        [Authorize(Roles = "Admin, Dokter")]
        public async Task<IActionResult> Post([FromBody] Jual Jual)
        {
            try
            {
                await _jual.CreateAsync(Jual);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Barang
        [HttpGet]
        [Authorize(Roles  = "Admin, Dokter, Perawat")]
        public async Task<IEnumerable<Jual>> GetJual()
        {

            var models = await _jual.GetAll();
            return models;
        }
        // PUT: api/Jual/5
        [HttpPut]
        [Authorize(Roles = "Admin, Dokter, Perawat")]
        public async Task<IActionResult> Put([FromBody] Jual jual)
        {
            try
            {

                await _jual.UpdateAsync(jual);
                return Ok("Data berhasil diupdate");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Dokter")]
        public async Task<Jual> Get(int id)
        {
            var model = await _jual.GetById(id);
            return model;
        }

        // DELETE: api/Jual/5
        [HttpDelete("{id}")]
        [Authorize(Roles  = "Admin, Dokter")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _jual.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}