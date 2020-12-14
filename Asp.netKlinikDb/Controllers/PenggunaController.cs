using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenggunaController : ControllerBase
    {
        private IPengguna _Pengguna;
        private IUserRole _UserRole;
        private IUser _userService;
        private IDetailPegawai _detailPegawai;
        private ITenantPengguna _tenantPengguna;


        public PenggunaController(IUser userService, IPengguna pengguna, IUserRole userRole, ITenantPengguna tenantPengguna, IDetailPegawai detailPegawai)
        {
            _Pengguna = pengguna;
            _UserRole = userRole;
            _userService = userService;
            _tenantPengguna = tenantPengguna;
            _detailPegawai = detailPegawai;
            
        }
        // GET: api/Tenant
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Pengguna>> getall()
        {
            
            var Models = await _Pengguna.GetAll();
            return Models;
        }
        //}
        // GET: api/User/5
        [HttpGet("getpenggunausername/{Username}")]
        //[Authorize(Roles = "Admin,Perawat,Dokter,Pasien")]
        public async Task<Pengguna> Get(string Username)
        {

            var model = await _Pengguna.getpenggunausername(Username);
            var usertenantlist = await _tenantPengguna.getusertenantlist(Username);
            model.TenantPengguna = usertenantlist;

            return model;
        }
        [HttpGet("getuserbyrole/{tenantID}/{rolename}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Pengguna>> getuserbyrole(string tenantID, string rolename)
        {
            var model = await _Pengguna.dataUserPerTenant(tenantID, rolename);
            return model;
        }
        [HttpGet("getlistpasien/{tenantID}/{rolename}")]
        [Authorize(Roles = "Admin, Dokter, Perawat")]
        public async Task<IEnumerable<Pengguna>> getlistpasien(string tenantID, string rolename)
        {
            var model = await _Pengguna.dataUserPerTenant(tenantID, rolename);
            return model;
        }
        [HttpGet("getidpasien/{IdPasien}/{tenantID}")]
        [Authorize(Roles = "Admin, Dokter, Perawat")]
        public async Task<Pengguna> getidpasien(string IdPasien,string tenantID)
        {
            var model = await _Pengguna.getIdPasien(IdPasien,tenantID);
            return model;
        }
        // PUT: api/Pengguna/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Dokter, Perawat")]
        public async Task<IActionResult> Put([FromBody] Pengguna Pengguna)
        {
            try
            {
                await _Pengguna.UpdateAsync(Pengguna);
                return Ok("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}