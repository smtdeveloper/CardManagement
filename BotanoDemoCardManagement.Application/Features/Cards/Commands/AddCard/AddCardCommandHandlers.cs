using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;

public class AddCardCommandHandlers : IRequestHandler<AddCardCommand, AddCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;
    private readonly IValidator<AddCardCommand> _validator;

    public AddCardCommandHandlers(IMapper mapper, ICardRepository companyRepository, IUnitOfWork unitOfWork, CardBusinessRules businessRules, IValidator<AddCardCommand> validator)
    {
        _mapper = mapper;
        _cardRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _cardBusinessRules = businessRules;
        _validator = validator;
    }

    public async Task<AddCardCommandResponse> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        Card card = _mapper.Map<Card>(request);
        await _cardBusinessRules.CheckIfCardIsNull(card);

        card.CreatedDate = DateTime.UtcNow;
        Card addedCard = await _cardRepository.AddAsync(card, cancellationToken);
        await _unitOfWork.CommitAsync();

        AddCardCommandResponse response = _mapper.Map<AddCardCommandResponse>(addedCard);
        return response;
    }
    
}