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
    public CardStatus Status { get; set; }
    public List<QuestionUpdateResponse> Questions { get; set; } = new List<QuestionUpdateResponse>();
}

public class QuestionUpdateResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }
    public List<ChoiceUpdateResponse> Choices { get; set; } = new List<ChoiceUpdateResponse>();
}

public class ChoiceUpdateResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }
}