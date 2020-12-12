using Asp.netKlinikDb.Models;
using Asp.netKlinikDb.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface IUser 
    {
        Task<User> Authenticate(string username, string password, string tenantid);
        Task AddUserToRole(Users usr);
        Task<IEnumerable<Users>> GetAll();
        //Task<IEnumerable<User>> getalldatauser();
        Task Register(Users usr);
        Task Updateuser(Users usr);
        Task EnableDisableduser(Users usr);
        Task TenantPengguna(TenantPengguna tenantPengguna);
        Task<TenantPengguna> tenantforusername(string tenantID, string username);
        Task addpengguna(Pengguna pengguna);
        Task<ApplicationUser> GetbyUsername(string username);
        Task<ApplicationUser> GetbyId(string Id);
        Task Delete(string username);
        Task<User> ForgetPassword(string Email);
        Task<ResetPasswordViewModel> ResetPassword(ResetPasswordViewModel model);
        Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model);
    }
}
