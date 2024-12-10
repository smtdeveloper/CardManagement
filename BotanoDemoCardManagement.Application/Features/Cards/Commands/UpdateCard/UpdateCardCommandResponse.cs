using BotanoDemoCardManagement.Domain.Entities.Enums;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;

public class UpdateCardCommandResponse
{
    public string CardName { get; set; }
    public Guid CardTypeId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public CardStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}