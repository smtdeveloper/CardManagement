using BotanoDemoCardManagement.Domain.Entities.Common;

namespace BotanoDemoCardManagement.Domain.Entities.CardEntities;

public class CardType : BaseEntity
{    
    public string Name { get; set; }
    public ICollection<Card> Cards { get; set; }
}