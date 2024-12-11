using BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;

namespace BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;

public class CardBusinessRules
{

    public async Task CheckIfCardIsNull(Card? company)
    {
        if (company == null)
        {
            throw new Exception("The card entity cannot be null.");
        }
    }

    public async Task CheckIfCardIsCompleted(Card card, List<UserAnswerDto> answers)
    {
        var unansweredQuestions = card.Questions
            .Where(q => !answers.Any(a => a.QuestionId == q.Id))
            .ToList();

        if (unansweredQuestions.Any())
        {
            throw new Exception("All questions must be answered to complete the card.");
        }
    }

}