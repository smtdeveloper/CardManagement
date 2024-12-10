using AutoMapper;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using MediatR;
using System.Linq.Expressions;

namespace BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;

public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, List<GetAllCardsQueryResponse>>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
   
    public GetAllCardsQueryHandler(ICardRepository companyRepository, IMapper mapper)
    {
        _cardRepository = companyRepository;
        _mapper = mapper;
      
    }

    public async Task<List<GetAllCardsQueryResponse>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
    {
        List<Card> cards = await _cardRepository.GetCardAllAsync(cancellationToken);
        List<GetAllCardsQueryResponse> getAllCardsQueryResponse = _mapper.Map<List<GetAllCardsQueryResponse>>(cards);
        return getAllCardsQueryResponse;
    }
}