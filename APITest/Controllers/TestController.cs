using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Route("admin")]
    [Authorize(Roles = "ADMIN")]
    public ActionResult Get_admin()
    {
        var claims = User.Claims.Select(x => new {name = x.Type, value = x.Value}).ToList();
        return Ok(claims);
    }

    [HttpGet]
    [Route("user")]
    [Authorize(Roles = "USER")]
    public ActionResult Get_user()
    {
        var claims = User.Claims.Select(x => new {name = x.Type, value = x.Value}).ToList();
        return Ok(claims);
    }

    [HttpGet]
    [Authorize]
    public ActionResult Get_authorize()
    {
        var claims = User.Claims.Select(x => new {name = x.Type, value = x.Value}).ToList();
        return Ok(claims);
    }
}