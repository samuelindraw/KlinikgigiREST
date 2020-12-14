using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Asp.netKlinikDb.ViewModel;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Asp.netKlinikDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUser _userService;
        private IPengguna _Pengguna;
        private IDetailPasien _detailPasien;
        private IDetailPegawai _detailPegawai;
        private ITenantPengguna _tenantPengguna;
        private IJenisTindakan _JenisTindakan;
        private IEmailSender _emailSender;
        private AppDbContext _context;


        private UserManager<ApplicationUser> _userManager;
        private IProsentase  _prosentase;


        public UserController(IUser userService, UserManager<ApplicationUser> userManager, 
            IPengguna pengguna, IDetailPasien detailpasien, 
            IDetailPegawai detailPegawai, ITenantPengguna tenantPengguna,
            IProsentase prosentase,IJenisTindakan jenisTindakan, IEmailSender emailSender,IConfiguration configuration,
            AppDbContext context)
        {
            _userManager = userManager;
            _userService = userService;
            _Pengguna = pengguna;
            _detailPasien = detailpasien;
            _detailPegawai = detailPegawai;
            _tenantPengguna = tenantPengguna;
            _prosentase = prosentase;
            _JenisTindakan = jenisTindakan;
            _emailSender = emailSender;
            _context = context;
            
        

        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]User userParam)
        {
            try
            {
                var user = await _userService.Authenticate(userParam.Username, userParam.Password, userParam.TenantID);
                if (user == null)
                {
                    return BadRequest("Username atau Password anda Salah !!");
                }
                // kenapa menggunkan user yang merupaka output dari authenticate ? supaya tau klo usernya ada //doublecheck
                // menggunakan handler bahwa 1 usernama hanya akan ada di 1 tenant yang sama tetpi bisa  di tenant yang lain ...
                //var tenant = await _userService.tenantforusername(userParam.TenantID, user.Username);
                var tenantpengguna =  _context.TenantPengguna.Where(r => r.Username == user.Username && r.TenantID == userParam.TenantID).Include(r => r.Tenant).SingleOrDefault();
                if(tenantpengguna.StatusTenant == false)
                {
                    return BadRequest("User " + user.Username + " di tenant ini tidak aktif");
                }
 
                else
                {
                    
                    //sebagai pertanda user login di tenant mana 
                    user.TenantID = tenantpengguna.TenantID;
                    user.TenantName = tenantpengguna.Tenant.TenantName;
                    Pengguna updatetenant = new Pengguna();
                    updatetenant.Username = user.Username;
                    updatetenant.TenantID = tenantpengguna.TenantID;
                    await _Pengguna.Updatetenant(updatetenant);
                }

                var message = new Message(new String[] { user.Email }, "Notifikasi login", "<h1>Hey!  " + userParam.Username + ", Anda login di akun ini !</h1><p> Anda login di waktu " + DateTime.Now + "</p>");
                _emailSender.SendEmail(message);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //gunanay untuk registrasi
        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Users userModel)
        {
            try
            {
                
                await _userService.Register(userModel);
                await _userService.AddUserToRole(userModel);
                //ambil data role dari yang udah ada 
                // masukan ke pengguna....
                Pengguna pengguna = new Pengguna();
                pengguna.Username = userModel.Username;
                pengguna.Email = userModel.Email;
                pengguna.Nama = userModel.Nama;
                pengguna.TenantID = userModel.TenantID;
                pengguna.rolename = userModel.rolename;
                pengguna.Alamat = userModel.Alamat;
                pengguna.Kota = userModel.Kota;
                pengguna.NoHP = userModel.NoHp;
                pengguna.NoTelpon = userModel.NoTelpon;
                pengguna.Prosentase = userModel.Prosentase;
                pengguna.Umur = userModel.umur;
                if(pengguna.rolename == "Dokter" || pengguna.rolename == "Pasien")
                {
                    pengguna.Prosentase = userModel.Prosentase;
                }
                else
                {
                    pengguna.Prosentase = 0;
                }
                ////test it will it be okey if there same username again ? 
               
                if (userModel.rolename == "Pasien")
                {
                    pengguna.IdPasien = "Pasien" + pengguna.Username;
                    await _userService.addpengguna(pengguna);
                    DetailPasien detailpasien = new DetailPasien();
                    detailpasien.Registrasi = DateTime.Today;
                    detailpasien.IdPasien = pengguna.IdPasien;
                    detailpasien.Username = pengguna.Username;
                    detailpasien.RwPenyakit = userModel.RwPenyakit;
                    detailpasien.Registrasi = userModel.Registrasi;
                    await _detailPasien.CreateAsync(detailpasien);
                }
                else
                {
                    pengguna.IdPasien = null;
                    var tenant = userModel.TenantID;
                    pengguna.TenantID = tenant;
                    await _userService.addpengguna(pengguna);
                    DetailPegawai detailPegawai = new DetailPegawai();
                    detailPegawai.Username = pengguna.Username;
                    detailPegawai.TanggalJoin = DateTime.Today;
                    detailPegawai.Jabatan = userModel.rolename;
                    if (pengguna.rolename == "Perawat")
                    {
                        detailPegawai.Gaji = userModel.Gaji;
                    }
                    await _detailPegawai.CreateAsync(detailPegawai);
                    if (pengguna.rolename == "Dokter")
                    {
                        var dt_prosen = await _prosentase.getbytenantid(userModel.TenantID);
                        var dt_jenisTindakan = await _JenisTindakan.getbytenantid(userModel.TenantID);
                        foreach (var dt_jenis in dt_jenisTindakan)
                        {
                            Prosentase prosen = new Prosentase();
                            prosen.Username = userModel.Username;
                            prosen.IdJenisTindakan = dt_jenis.IdJenisTindakan;
                            prosen.Prosen = userModel.Prosentase;
                            prosen.TenantID = userModel.TenantID;
                            prosen.DetailPegawaiID = detailPegawai.DetailPegawaiID;
                            await _prosentase.CreateAsync(prosen);
                        }

                        
                    }
                  
                }
                TenantPengguna tenantPengguna = new TenantPengguna();
                tenantPengguna.Username = userModel.Username;
                tenantPengguna.TenantID = userModel.TenantID;
                await _userService.TenantPengguna(tenantPengguna);
                return Ok("Pendaftaran Anda Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegisterPasien")]
        [Authorize(Roles = "Admin, Dokter, Perawat")]
        public async Task<IActionResult> Register([FromBody] Users userModel)
        {
            try
            {
                await _userService.Register(userModel);
                await _userService.AddUserToRole(userModel);
                Pengguna pengguna = new Pengguna();
                pengguna.Username = userModel.Username;
                pengguna.Email = userModel.Email;
                pengguna.Nama = userModel.Nama;
                pengguna.TenantID = userModel.TenantID;
                pengguna.rolename = userModel.rolename;
                pengguna.Alamat = userModel.Alamat;
                pengguna.Kota = userModel.Kota;
                pengguna.NoHP = userModel.NoHp;
                pengguna.NoTelpon = userModel.NoTelpon;
                pengguna.Prosentase = userModel.Prosentase;
                pengguna.Umur = userModel.umur;
                pengguna.Prosentase = 0;
                pengguna.IdPasien = "Pasien" + pengguna.Username;
                await _userService.addpengguna(pengguna);
                



                DetailPasien detailpasien = new DetailPasien();
                detailpasien.Registrasi = DateTime.Today;
                detailpasien.IdPasien = pengguna.IdPasien;
                detailpasien.Username = pengguna.Username;
                detailpasien.RwPenyakit = userModel.RwPenyakit;
                detailpasien.Registrasi = userModel.Registrasi;
                await _detailPasien.CreateAsync(detailpasien);


                TenantPengguna tenantPengguna = new TenantPengguna();
                tenantPengguna.Username = userModel.Username;
                tenantPengguna.TenantID = userModel.TenantID;
                await _userService.TenantPengguna(tenantPengguna);
                return Ok("Pendaftaran Anda Berhasil");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getall")]
       // [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Users>> GetUsers()
        { 

            var models = await _userService.GetAll();
         
            return models;
        }
        [HttpPut("Enable/{Username}")]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Enabled(string Username)
        {
            try
            {
                Users users = new Users();
                ApplicationUser user = new ApplicationUser();
                user = await _userService.GetbyUsername(Username);
                users.Username = user.UserName;
                if(user.IsEnabled == true )
                {
                   
                    users.IsEnabled = false;
                    users.Status = false;
                }
                else
                {
                    users.IsEnabled = true;
                    users.Status = true;
                }
                await _userService.EnableDisableduser(users);
                return Ok("Status Users diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //// GET: api/User/5
        //[HttpGet("getuserbyusername/{userName}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<ApplicationUser> Get(string userName)
        //{
        //    var model = await _userService.GetbyUsername(userName);
        //    return model;
        //}
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody]EmailForget emailForget)
        {
                var result = await _userService.ForgetPassword(emailForget.Email);
                if (result.Email == emailForget.Email)
                    return Ok("Password telah di reset silahkan cek Email anda !"); // 200
           
          

            return BadRequest("Kesalahan"); // 400
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ChangePassword(model);

                if (result.Status == 200)
                    return Ok("Password anda telah terubah, silahkan melakukan login kembali");


            }
            return BadRequest("Some properties are not valid");
        }
        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPassword(model);

                if (result.Email == model.Email)
                    return Ok("Password anda telah terubah, silahkan melakukan login kembali");

               
            }

            return BadRequest("Some properties are not valid");
        }
        // DELETE: api/User/5
        // masih manual optional untuk jaga jaga jika data ingin di delete permanen 
        [HttpDelete("{Username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>Delete(string Username)
        {
           
            try
            {
                
                Pengguna pengguna = new Pengguna();
                pengguna = await _Pengguna.getpenggunausername(Username);
                if(pengguna != null)
                {
                    if (pengguna.rolename == "Pasien")
                    {
                        var cekpasien = await _detailPasien.getusername(Username);
                        if (cekpasien != null)
                        {
                            await _detailPasien.DeleteByuser(Username);
                        }

                    }
                    else
                    {
                        await _prosentase.Deletebyusername(Username);
                        var TenantUser = await _tenantPengguna.getusertenantlist(Username);
                        foreach (var item in TenantUser)
                        {
                            await _tenantPengguna.Delete(item.TenantPenggunaID);
                        }
                        //detail gaji to
                        //pengajian
                        var cekpegawai = await _detailPegawai.getusername(Username,pengguna.TenantID);
                        if (cekpegawai != null)
                        {
                            await _detailPegawai.DeleteByuser(Username);
                        }

                    }
                }
                var tenant = await _tenantPengguna.getusertenantlist(Username);
                foreach (var data in tenant)
                {
                    await _tenantPengguna.Delete(data.TenantPenggunaID);
                }
                await _Pengguna.DeletebyUser(pengguna.Username);
                await _userService.Delete(Username);


                //delete data pengguna sekalian 
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}