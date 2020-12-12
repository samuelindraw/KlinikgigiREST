using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class posisiGigiController : ControllerBase
    {
        private IposisiGigi _posisiGigi;
        public posisiGigiController(IposisiGigi posisiGigi)
        {
            _posisiGigi = posisiGigi;
        }

        // GET: api/Barang
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<PosisiGigi>> GetPosisiGigi()
        {

            var models = await _posisiGigi.GetAll();
            return models;
        }
        //public async Task<IActionResult> Post([FromBody] PosisiGigi PosisiGigi)
        //{
        //    try
        //    {
        //         await _posisiGigi.CreateAsync(PosisiGigi);
        //        //await _posisiGigi.CreateAsync(PosisiGigi);
        //        return Ok("Tambah Data Berhasil");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }

}