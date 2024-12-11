using FluentValidation;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;

public class CompleteCardCommandValidator : AbstractValidator<CompleteCardCommand>
{
    public CompleteCardCommandValidator()
    {
        RuleFor(x => x.CardId)
            .NotEmpty().WithMessage("Card ID cannot be empty.");

        RuleFor(x => x.CompleteCardModel)
            .NotNull().WithMessage("CompleteCardModel cannot be null.");

        RuleForEach(x => x.CompleteCardModel.Answers)
            .SetValidator(new UserAnswerDtoValidator());
    }
}
public class UserAnswerDtoValidator : AbstractValidator<UserAnswerDto>
{
    public UserAnswerDtoValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Question ID cannot be empty.");

        RuleFor(x => x.ChoiceId)
            .NotEmpty().WithMessage("Choice ID cannot be empty.");
    }
}