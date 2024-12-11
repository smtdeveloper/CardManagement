using BotanoDemoCardManagement.Domain.Entities.Common;
using BotanoDemoCardManagement.Domain.Entities.Enums;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;

namespace BotanoDemoCardManagement.Domain.Entities.CardEntities;

public class Card : BaseEntity
{
    public string CardName { get; set; }
    public Guid CardTypeId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; } = false;
    public CardStatus Status { get; set; } = CardStatus.NotStarted;

    public CardType CardType { get; set; }
    public ICollection<UserCardAnswer> UserCardAnswers { get; set; }
    public ICollection<CardQuestion> Questions { get; set; }
}