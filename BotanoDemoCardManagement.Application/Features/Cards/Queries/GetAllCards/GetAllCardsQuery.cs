using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;

public record GetAllCardsQuery : IRequest<List<GetAllCardsQueryResponse>> { }
