using System;
using System.Linq;
using System.Threading.Tasks;
using APITest.Dto;
using IdentityServer4withASP.NETCoreIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer4withASP.NETCoreIdentity.Services;

public class UserService : IUserService
{
    public  UserManager<ApplicationUser> _userManager;
    public  RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> CreateUser(UserCreateDto user)
    {
        var newUser = new ApplicationUser()
        {
            UserName = user.Email,
            Email = user.Email,
            EmailConfirmed = true
        };

        var resultIdentity = await _userManager.CreateAsync(newUser, user.Password);
        if (_roleManager.Roles.Any(x => x.Name == EnumRole.ADMIN.ToString()) is false)
        {
            await _roleManager.CreateAsync(new IdentityRole(EnumRole.ADMIN.ToString()));
        }

        await _userManager.AddToRoleAsync(newUser, EnumRole.ADMIN.ToString());
        return resultIdentity.Succeeded;
    }
}