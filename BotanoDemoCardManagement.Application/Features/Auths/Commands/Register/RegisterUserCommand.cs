using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Auths.Commands.Register;

public class RegisterUserCommand : IRequest<RegisterUserCommandResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}