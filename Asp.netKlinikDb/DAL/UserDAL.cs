using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Helper;
using Asp.netKlinikDb.Models;
using Asp.netKlinikDb.ViewModel;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class UserDAL : IUser
    {
        //THIS USER CONTROLER SEBAGAI ADMIN PAGE DARI ROLES DAN USER    
        private AppSettings _appSettings;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDbContext _context;
        private IUserRole _UserRole;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;


        public UserDAL(IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, AppDbContext context, SignInManager<ApplicationUser> signInManager, IUserRole userRole, IConfiguration configuration,
            IEmailSender emailSender)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
            _UserRole = userRole;
            _configuration = configuration;
            _emailSender = emailSender;

        }
        public async Task<User> Authenticate(string Username, string Password, string TenantID)
        {
            var userFind = await _userManager.CheckPasswordAsync(await _userManager.FindByNameAsync(Username), Password);
            ApplicationUser User = new ApplicationUser();
            User = await _userManager.FindByNameAsync(Username);

           
            // return null if user not found
            if (!userFind)
                return null;
             
            var user = new User
            {
                Username = Username
            };
            var userrole = await _userManager.FindByNameAsync(Username);     
            var role = await _userManager.GetRolesAsync(userrole);
            if (role.Count == 0)
            {
                
                throw new Exception("role tidak di temukan tolong assign role terlebih dahulu !");
            }
           
            IdentityOptions _option = new IdentityOptions();
            // authentication successful so generate jwt token
            // needed Role for creation of token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(_option.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token      = tokenHandler.WriteToken(token);
            // remove password before returning
            var rolename = (_option.ClaimsIdentity.RoleClaimType, role.SingleOrDefault()).Item2;
            user.rolename = rolename.ToString();
            user.Email = userrole.Email;
            if (User.IsEnabled != true)
            {
                if(user.rolename == "Admin")
                {
                    return user;
                }
                else
                {
                    throw new Exception("Akun ini di non-aktifkan");
                }
            }
            
            return user;
        }
        public async Task<IEnumerable<Users>> GetAll()
        {
            //ambil data dari identity user first
            var data = await (from r in _context.Users
                              orderby r.UserName ascending
                              select r).ToListAsync();
            // di tampung dalam model user
           
            var list =  (from user in _context.Users
                        select new Users
                        {
                            Id = user.Id,
                            Username = user.UserName,
                            Email = user.Email,
                            IsEnabled = user.IsEnabled
 
                        }).ToList();
            list.Select(async user =>
            {
                var userEntity = await _userManager.FindByIdAsync(user.Id);
                user.rolename = string.Join("; ", await _userManager.GetRolesAsync(userEntity));
                
            }).ToList();

            //select dari model user
            //how to keep run this code ? , while no debugging 
            return list;
        }
 
        public async Task Register(Users usr)
         {
            var user = new ApplicationUser { UserName = usr.Username, Email = usr.Email };

            var result = await _userManager.CreateAsync(user, usr.Password);
            //var pengguna = new Pengguna { Username = user.UserName, Email = user.Email };
            //var TenantPengguna = new TenantPengguna { Username = user.UserName, TenantID = usr.TenantID };
            if (!result.Succeeded)
                throw new Exception("Gagal menambah Pengguna");
           
           
        }
        //mengisi pengguna sekaligus pada saat registrasi
        public async Task addpengguna(Pengguna pengguna)
        {

            var _pengguna = new Pengguna { Username = pengguna.Username,Nama = pengguna.Nama,
                Email = pengguna.Email, IdPasien = pengguna.IdPasien,   
                TenantID = pengguna.TenantID, rolename = pengguna.rolename, Umur = pengguna.Umur,
            Kota = pengguna.Kota, Alamat = pengguna.Alamat, NoHP = pengguna.NoHP, NoTelpon = pengguna.NoTelpon, Prosentase = pengguna.Prosentase};
            try
            {
                var result = _context.Add(_pengguna);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        //untuk add tenant pertamakali saat registrasi
        public async Task TenantPengguna(TenantPengguna tenantPengguna)
        {

            var _tenantpengguna = new TenantPengguna { Username = tenantPengguna.Username, TenantID = tenantPengguna.TenantID };
            try
            {
                var result = _context.Add(_tenantpengguna);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }


        }
        //cek apakah user tergabung ke tenant yang di inginkan
        public async Task<TenantPengguna> tenantforusername(string Id, string Username)
        {
            var data = await (from c in _context.TenantPengguna.Include(r => r.Tenant)
                              where c.TenantID == Id && c.Username == Username
                              select c).SingleOrDefaultAsync();
            return data;
        }
        public async Task Update(Users usr)
        {
            var data = await _userManager.FindByNameAsync(usr.Username);
          
            if (data != null)
            {
                try
                {
                    data.UserName = usr.Username;
                    data.Email = usr.Email;
                    var result = await _userManager.UpdateAsync(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }
        public async Task Updateuser(Users usr)
        {
            var data = await _userManager.FindByNameAsync(usr.Username);

            if (data != null)
            {
                try
                {
                    data.UserName = usr.Username;
                    data.Email = usr.Email;
                    var result = await _userManager.UpdateAsync(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }

        public async Task Delete(string userName)
        {
            var data = await GetbyUsername(userName);
            
            if (data != null)
            {
                try
                {
                    _context.Users.Remove(data);
                    await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Tenant tidak ditemukan");
            }
        }
        public async Task<ApplicationUser> GetbyUsername(string UserName)
        {
            var data = await (from c in _context.Users
                              where c.UserName == UserName
                              select c).SingleOrDefaultAsync();


            return data;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task AddUserToRole(Users usr)
        {
            var user = await _userManager.FindByNameAsync(usr.Username);
            var check = await _userManager.GetRolesAsync(user);
            if (check.Count == 0)
            {   
                try
                {
                    await _userManager.AddToRoleAsync(user, usr.rolename);


                }
                catch (Exception ex)
                {
                    throw new Exception($"Error {ex.Message}");
                }

            }
            else
            {
                throw new Exception("User sudah berada dalam role lain");
            }
        }

        public async Task EnableDisableduser(Users usr)
        {
            var data = await _userManager.FindByNameAsync(usr.Username);
            
            if (data != null)
            {
                try
                {
                    data.UserName = usr.Username;
                    data.IsEnabled = usr.IsEnabled;
                    data.Status = usr.Status;
                    var result = await _userManager.UpdateAsync(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }

        public async Task<ApplicationUser> GetbyId(string Id)
        {
            var data = await (from c in _context.Users
                              where c.Id == Id
                              select c).SingleOrDefaultAsync();


            return data;
        }

        public async Task<ResetPasswordViewModel> ResetPassword(ResetPasswordViewModel model)
        {
                var user = await _userManager.FindByEmailAsync(model.Email);
                
                if (user == null)
                {
                    throw new Exception("User tidak ada yang menggunakan Email tersebut");
                }
            if (model.NewPassword != model.ConfirmPassword)
            {
                throw new Exception("Kedua Password tidak sama !");
            }


                var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
                string normalToken = Encoding.UTF8.GetString(decodedToken);

                var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);
                return new ResetPasswordViewModel
                {
                    Email = user.Email
                };

        }


        public async Task<User> ForgetPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                throw new Exception("User tidak ada yang menggunakan Email tersebut");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            //ini isi emal yang ketika di klik akan masuk ke sini 
            //harusnya bisa di bikin di front end

            string url = $"{_configuration["AppUrl"]}/user/resetpassword/?email={Email}&token={validToken}";
            //_config adalah alamat dari client yang akan di akses letaknya di appssettings.json
            var message = new Message(new String[] { Email }, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password '{validToken}' <a href='{url}'>Click here</a></p>");
            _emailSender.SendEmail(message);
            //EmailSender service untuk mengirim email _config email sender di urus di appsetinggs
            return new User
            {
                Email = user.Email
            };
        }

        public async Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (model is null)
                    throw new Exception("Data ini Kosong !");


                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                    throw new Exception("Username tidak terdaftar !");

                SignInResult checkOldPassword =
                    await _signInManager.PasswordSignInAsync(user.UserName, model.OldPassword, false, false);

                if (!checkOldPassword.Succeeded)
                    throw new Exception("Password lama tidak sesuai !");

                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                if (string.IsNullOrEmpty(resetToken))
                    throw new Exception("Error gagal generate token !");

                var result = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);
                if (!result.Succeeded)
                    throw new Exception("Gagal mengganti password");

                return new ChangePasswordViewModel
                {
                    Status = 200
                };

            }
            catch
            {
                throw new Exception("Error ada masalah !");
            }
        }
    }
}
