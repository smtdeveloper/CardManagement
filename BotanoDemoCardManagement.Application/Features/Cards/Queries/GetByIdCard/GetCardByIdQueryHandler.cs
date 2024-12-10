using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;

public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, GetCardByIdQueryResponse>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly CardBusinessRules _cardBusinessRules;
    public GetCardByIdQueryHandler(ICardRepository cardRepository, IMapper mapper, CardBusinessRules cardBusinessRules)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
        _cardBusinessRules = cardBusinessRules;
    }

    public async Task<GetCardByIdQueryResponse> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        Card? card = await _cardRepository.GetCardByIdAsync(request.Id, cancellationToken);
        await _cardBusinessRules.CheckIfCardIsNull(card);
        return _mapper.Map<GetCardByIdQueryResponse>(card);
    }

}