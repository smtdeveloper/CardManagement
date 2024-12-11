using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Auths.Commands.Login;

public class LoginUserCommand : IRequest<LoginUserCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}