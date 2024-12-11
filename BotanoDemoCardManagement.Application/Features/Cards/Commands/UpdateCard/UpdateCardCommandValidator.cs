using FluentValidation;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;

public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
{
    public UpdateCardCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Card ID cannot be empty.");

        RuleFor(x => x.CardName)
            .NotEmpty().WithMessage("Card name cannot be empty.")
            .Length(3, 100).WithMessage("Card name must be between 3 and 100 characters.");

        RuleFor(x => x.CardTypeId)
            .NotEmpty().WithMessage("Card type cannot be empty.");

    }
}