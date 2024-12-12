using BotanoDemoCardManagement.Application.Features.Auths.Commands.Login;
using BotanoDemoCardManagement.Application.Features.Auths.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotanoDemoCardManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerUser">The command containing the user registration details.</param>
    /// <remarks>
    /// Example Request:
    /// 
    /// POST /api/auth/register
    /// 
    /// Request Body:
    /// json
    /// {
    ///     "username": "exampleuser",
    ///     "email": "example@example.com",
    ///     "password": "SecurePassword123"
    /// }
    /// 
    /// </remarks>
    /// <returns>A success message with user registration details.</returns>
    /// <response code="200">User registered successfully.</response>
    /// <response code="400">Invalid input provided.</response>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUser)
    {
        var response = await Mediator.Send(registerUser);
        return Ok(response);
    }

    /// <summary>
    /// Authenticates a user and generates a token.
    /// </summary>
    /// <param name="loginUserCommand">The command containing login credentials.</param>
    /// <remarks>
    /// Example Request:
    /// 
    /// POST /api/auth/login
    /// 
    /// Request Body:
    /// json
    /// {
    ///     "email": "example@example.com",
    ///     "password": "SecurePassword123"
    /// }
    /// 
    /// </remarks>
    /// <returns>A token if the login is successful.</returns>
    /// <response code="200">Login successful. Returns an authentication token.</response>
    /// <response code="401">Unauthorized. Invalid username or password.</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var response = await Mediator.Send(loginUserCommand);
        if (response == null)
            return Unauthorized("Invalid username or password.");

        return Ok(response);
    }
}