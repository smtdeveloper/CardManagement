using BotanoDemoCardManagement.Domain.Entities.Common;

namespace BotanoDemoCardManagement.Domain.Entities.CardEntities;

public class CardQuestionChoice : BaseEntity
{
    public Guid CardQuestionId { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }

    public CardQuestion CardQuestion { get; set; }
}
