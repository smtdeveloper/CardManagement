using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;

public class AddCardCommandHandlers : IRequestHandler<AddCardCommand, AddCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;

    public AddCardCommandHandlers(IMapper mapper, ICardRepository companyRepository, IUnitOfWork unitOfWork, CardBusinessRules businessRules)
    {
        _mapper = mapper;
        _cardRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _cardBusinessRules = businessRules;
    }

    public async Task<AddCardCommandResponse> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        Card card = _mapper.Map<Card>(request); // Ensure proper mapping happens here.

        // Avoid adding questions and choices manually here if it's already handled in AutoMapper.
        await _cardBusinessRules.CheckIfCardIsNull(card);

        card.CreatedDate = DateTime.UtcNow;
        Card addedCard = await _cardRepository.AddAsync(card, cancellationToken);
        await _unitOfWork.CommitAsync();

        AddCardCommandResponse response = _mapper.Map<AddCardCommandResponse>(addedCard);

        return response;
    }
    


}