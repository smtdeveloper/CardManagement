using BotanoDemoCardManagement.Domain.Entities.Common;

namespace BotanoDemoCardManagement.Domain.Entities.UserEntities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<UserCardAnswer> UserCardAnswers { get; set; }
}