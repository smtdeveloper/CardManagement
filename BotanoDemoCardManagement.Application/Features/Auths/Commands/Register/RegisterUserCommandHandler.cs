using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace BotanoDemoCardManagement.Application.Features.Auths.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = HashPassword(request.Password);
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = hashedPassword,
            CreatedDate = DateTime.UtcNow
        };
        var addedUser = await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync();
        if (addedUser != null)
        {
            return new RegisterUserCommandResponse { UserId = addedUser.Id };
        }
        throw new Exception("An error occurred during user registration.");
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}