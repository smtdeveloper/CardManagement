using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;

public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, UpdateCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;

    public UpdateCardCommandHandler(IMapper mapper, ICardRepository cardRepository, IUnitOfWork unitOfWork, CardBusinessRules cardBusinessRules)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
        _cardBusinessRules = cardBusinessRules;
    }

    public async Task<UpdateCardCommandResponse> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        var company = await _cardRepository.GetByIdAsync(request.Id, cancellationToken);
        await _cardBusinessRules.CheckIfCompanyIsNull(company);

        company = _mapper.Map(request, company);
        var updatedCompany = await _cardRepository.Update(company!);
        await _cardBusinessRules.CheckIfCompanyIsNull(updatedCompany);

        UpdateCardCommandResponse response = _mapper.Map<UpdateCardCommandResponse>(company);
        return response;
    }

}