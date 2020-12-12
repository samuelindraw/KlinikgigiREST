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
    public class JenisTindakanController : ControllerBase
    {
        private IJenisTindakan _JenisTindakan;

        public JenisTindakanController(IJenisTindakan _jenisTindakan)
        {
            _JenisTindakan = _jenisTindakan;
        }

        // GET: api/jenistindakan
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<JenisTindakan>> GetKatJenis()
        {

            var Models = await _JenisTindakan.GetAll();
            return Models;
        }

        // GET: api/JenisTindakan/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Dokter")]
        public async Task<JenisTindakan> Get(int id)
        {

            var model = await _JenisTindakan.GetById(id);
            return model;
        }
        //ganti route name 
        [HttpGet("getkatjenistindakanbytenantid/{tenantID}")]
        [Authorize(Roles = "Admin,Dokter")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> getkatjenistindakanbytenantid(string TenantID)
        {

            var model = await _JenisTindakan.getbytenantid(TenantID);
            return Ok(model);

        }
        [HttpGet("sort-id-katjenis/{Id}")]
        [Authorize(Roles = "Admin,Dokter")]
        // POST: api/getbarangbytenantid/ PAKE ROUTE AGAR AKSES NYA TIDAK NUMPUK DENGAN GET ID
        // CEK apakah id kat barang sudah sesuai dengan Tenant s
        public async Task<IActionResult> sortIdKatjenis(int Id)
        {

            var model = await _JenisTindakan.getidkatjenis(Id);
            return Ok(model);

        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] JenisTindakan jenisTindakan)
        {
            try
            {
                await _JenisTindakan.UpdateAsync(jenisTindakan);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/KatBarang
        [HttpPost]
        [Authorize(Roles = "Admin")]
        //TIDAK BISA CREATE JIKA DATA KATBARANG DI TENANT YANG SAMA 
        public async Task<IActionResult> Post([FromBody] JenisTindakan JenisTindakan)
        {
            try
            {

                await _JenisTindakan.CreateAsync(JenisTindakan);
                return Ok("Tambah Data Berhasil");
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
                await _JenisTindakan.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}