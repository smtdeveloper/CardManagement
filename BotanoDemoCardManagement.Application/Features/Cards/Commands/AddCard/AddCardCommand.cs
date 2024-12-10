using BotanoDemoCardManagement.Domain.Entities.Enums;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;

public class AddCardCommand : IRequest<AddCardCommandResponse>
{
    public string CardName { get; set; }
    public Guid CardTypeId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public CardStatus Status { get; set; }
    public List<QuestionAddResponse> Questions { get; set; } = new List<QuestionAddResponse>();
}

public class QuestionAddResponse
{
    public string Text { get; set; }
    public int SortIndex { get; set; }
    public List<ChoiceAddResponse> Choices { get; set; } = new List<ChoiceAddResponse>();
}

public class ChoiceAddResponse
{
    public string Text { get; set; }
    public int SortIndex { get; set; }
}