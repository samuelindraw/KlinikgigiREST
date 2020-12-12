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
    public class pilihgigiController : ControllerBase
    {
        private IpilihGIgi _pilihGIgi;
        public pilihgigiController(IpilihGIgi pilihGIgi)
        {
            _pilihGIgi = pilihGIgi;
        }

        // GET: api/Barang
        [HttpGet]
        //[Authorize(Roles  = "Admin")]
        public async Task<IEnumerable<pilihGIgi>> GetPilihGIgi()
        {

            var models = await _pilihGIgi.GetAll();
            return models;
        }
    }
}