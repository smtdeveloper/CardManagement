using BotanoDemoCardManagement.Application.Features.Auths.Commands.Login;
using BotanoDemoCardManagement.Application.Features.Auths.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace BotanoDemoCardManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUser)
    {
        var response = await Mediator.Send(registerUser);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var response = await Mediator.Send(loginUserCommand);
        if (response == null)
         return Unauthorized("Invalid username or password.");
        
        return Ok(response);
    }
}