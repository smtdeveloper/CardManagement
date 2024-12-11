using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using BotanoDemoCardManagement.Domain.Entities.Common;

namespace BotanoDemoCardManagement.Domain.Entities.UserEntities;

public class UserCardAnswer : BaseEntity
{
    public Guid UserId { get; set; } 
    public Guid CardId { get; set; } 
    public Guid CardQuestionId { get; set; } 
    public Guid CardQuestionChoiceId { get; set; }

    public User User { get; set; }
    public Card Card { get; set; }
    public CardQuestion CardQuestion { get; set; }
    public CardQuestionChoice CardQuestionChoice { get; set; }
}