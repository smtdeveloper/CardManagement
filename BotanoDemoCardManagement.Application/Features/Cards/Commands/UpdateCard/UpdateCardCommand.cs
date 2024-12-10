using BotanoDemoCardManagement.Domain.Entities.Enums;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;

public class UpdateCardCommand : IRequest<UpdateCardCommandResponse>
{
    public Guid Id { get; set; }
    public string CardName { get; set; }
    public Guid CardTypeId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public CardStatus Status { get; set; }
}