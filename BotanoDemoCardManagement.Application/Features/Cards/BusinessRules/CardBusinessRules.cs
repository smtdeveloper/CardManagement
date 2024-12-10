using BotanoDemoCardManagement.Domain.Entities.CardEntities;

namespace BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;

public class CardBusinessRules
{

    public async Task CheckIfCompanyIsNull(Card? company)
    {
        if (company == null)
        {
            throw new Exception("The card entity cannot be null.");
        }
    }
}