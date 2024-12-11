using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;

public class CompleteCardCommand : IRequest<CompleteCardCommandResponse>
{
    public Guid CardId { get; set; }
    public CompleteCardModel CompleteCardModel { get; set; }
}

public class CompleteCardModel
{
    public List<UserAnswerDto> Answers { get; set; }
}

public class UserAnswerDto
{
    public Guid QuestionId { get; set; }
    public Guid ChoiceId { get; set; }
}