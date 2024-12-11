using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace BotanoDemoCardManagement.Application.Features.Auths.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginUserCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
 
        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            return null; 
      
        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        var tokenExpiration = DateTime.UtcNow.AddDays(1);

        return new LoginUserCommandResponse { Token = token , TokenExpiration = tokenExpiration};
    }

    private bool VerifyPassword(string inputPassword, string storedPasswordHash)
    {
        using var sha256 = SHA256.Create();
        var hashedInputPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword)));
        return hashedInputPassword == storedPasswordHash;
    }
}