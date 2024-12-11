using FluentValidation;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;

public class AddCardCommandValidator : AbstractValidator<AddCardCommand>
{
    public AddCardCommandValidator()
    {
        RuleFor(x => x.CardName)
            .NotEmpty().NotNull().WithMessage("Card name cannot be empty.")
            .Length(3, 100).WithMessage("Card name must be between 3 and 100 characters.");

        RuleFor(x => x.CardTypeId)
            .NotEmpty().NotNull().WithMessage("Card type cannot be empty."); 
       
    }
}