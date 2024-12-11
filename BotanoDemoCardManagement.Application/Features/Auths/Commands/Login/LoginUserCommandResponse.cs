namespace BotanoDemoCardManagement.Application.Features.Auths.Commands.Login;

public class LoginUserCommandResponse
{
    public string Token { get; set; }
    public DateTime TokenExpiration { get; set; }
}
