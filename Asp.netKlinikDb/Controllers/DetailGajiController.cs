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
    public class DetailGajiController : ControllerBase
    {
        private IDetailPenggajian _detailPenggajian;
        //private IBarang _Barang;

        public DetailGajiController(IDetailPenggajian detailpenggajian)
        {

            _detailPenggajian = detailpenggajian;
        }
        // POST: api/DetailBeli
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] DetailPenggajian detailPenggajian)
        {
            try
            {
                await _detailPenggajian.CreateAsync(detailPenggajian);
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
                await _detailPenggajian.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}