using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;

public class GetCardByIdQuery : IRequest<GetCardByIdQueryResponse>
{
    public Guid Id { get; set; }

    public GetCardByIdQuery(Guid id)
    {
        Id = id;
    }
}