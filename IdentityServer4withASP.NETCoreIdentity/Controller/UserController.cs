using System;
using System.Threading.Tasks;
using APITest.Dto;
using IdentityServer4withASP.NETCoreIdentity.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4withASP.NETCoreIdentity.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUserAsync(UserCreateDto user, [FromServices] IUserService userService)
    {
        var result = await userService.CreateUser(user);
        return result ? CreatedAtAction(null,null) : BadRequest();
    }
}