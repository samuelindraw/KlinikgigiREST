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
    public class DetailPasienController : ControllerBase
    {
        private IDetailPasien _DetailPasien;
        //private IBarang _Barang;

        public DetailPasienController(IDetailPasien detailPasien)
        {

            _DetailPasien = detailPasien;
        }
        // GET: api/DetailPasien
        [HttpGet]
        [Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<DetailPasien>> GetDetailPasien()
        {
            var models = await _DetailPasien.GetAll();
            return models;
        }

        // ????????????
        [HttpGet("{Idpasien}/{tenantID}")]
        public async Task<DetailPasien> Get(string Idpasien, string tenantID)
        {
            var model = await _DetailPasien.getbyidpasien(Idpasien, tenantID);
            return model;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> Post([FromBody] DetailPasien DetailPasien)
        {
            try
            {
                await _DetailPasien.CreateAsync(DetailPasien);
                return Ok("Tambah Data Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _DetailPasien.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
        [HttpDelete("{Username}")]
        [Authorize(Roles = "Admin,Dokter,Perawat")]
        public async Task<IActionResult> DeleteUser(string Username)
        {
            try
            {
                await _DetailPasien.DeleteByuser(Username);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/DetailPasien/5
        [HttpPut]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Put([FromBody] DetailPasien DetailPasien)
        {
            try
            {
                await _DetailPasien.UpdateAsync(DetailPasien);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}