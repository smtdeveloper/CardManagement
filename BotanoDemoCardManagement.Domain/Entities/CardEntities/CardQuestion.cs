using BotanoDemoCardManagement.Domain.Entities.Common;

namespace BotanoDemoCardManagement.Domain.Entities.CardEntities;

public class CardQuestion : BaseEntity
{
    public Guid CardId { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }

    public Card Card { get; set; }
    public ICollection<CardQuestionChoice> Choices { get; set; }
}