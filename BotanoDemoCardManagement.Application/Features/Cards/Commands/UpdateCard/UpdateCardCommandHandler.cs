using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using FluentValidation;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;

public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, UpdateCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;
    private readonly IValidator<UpdateCardCommand> _validator;

    public UpdateCardCommandHandler(IMapper mapper, ICardRepository cardRepository, IUnitOfWork unitOfWork, CardBusinessRules cardBusinessRules, IValidator<UpdateCardCommand> validator)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
        _cardBusinessRules = cardBusinessRules;
        _validator = validator;
    }

    public async Task<UpdateCardCommandResponse> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var card = await _cardRepository.GetByIdAsync(request.Id, cancellationToken);
        await _cardBusinessRules.CheckIfCardIsNull(card);

        card = _mapper.Map(request, card);

        var updatedCard = await _cardRepository.Update(card);
        await _unitOfWork.CommitAsync();
        var response = _mapper.Map<UpdateCardCommandResponse>(updatedCard);
        return response;

    }
}