using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Domain.Entities.Enums;
using MediatR;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;

public class CompleteCardCommandHandler : IRequestHandler<CompleteCardCommand, CompleteCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUserAnswerRepository _userAnswerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;

    public CompleteCardCommandHandler(
        IMapper mapper,
        ICardRepository cardRepository,
        IUserAnswerRepository userAnswerRepository,
        IUnitOfWork unitOfWork,
        CardBusinessRules cardBusinessRules)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _userAnswerRepository = userAnswerRepository;
        _unitOfWork = unitOfWork;
        _cardBusinessRules = cardBusinessRules;
    }

    public async Task<CompleteCardCommandResponse> Handle(CompleteCardCommand request, CancellationToken cancellationToken)
    {
        //// Kart kontrolü
        //var card = await _cardRepository.GetCardByIdAsync(request.CardId, cancellationToken);
        //_cardBusinessRules.CheckIfCardIsNull(card);

        //// Eksik sorular kontrolü
        //var unansweredQuestions = card.Questions
        //    .Where(q => !request.CompleteCardModel.Answers.Any(a => a.QuestionId == q.Id))
        //    .ToList();

        //if (unansweredQuestions.Any())
        //    throw new BusinessException("Kartın tamamlanması için tüm sorulara cevap verilmelidir.");

        //// Cevapları kaydet
        //foreach (var answer in request.CompleteCardModel.Answers)
        //{
        //    var existingAnswer = await _userAnswerRepository.GetUserAnswerAsync(request.CardId, answer.QuestionId, cancellationToken);
        //    if (existingAnswer == null)
        //    {
        //        _userAnswerRepository.Add(new UserAnswer
        //        {
        //            UserId = _cardBusinessRules.GetCurrentUserId(),
        //            CardId = request.CardId,
        //            QuestionId = answer.QuestionId,
        //            ChoiceId = answer.ChoiceId
        //        });
        //    }
        //    else
        //    {
        //        existingAnswer.ChoiceId = answer.ChoiceId;
        //    }
        //}

        //// Kart durumunu güncelle
        //card.Status = CardStatus.Done;
        //_cardRepository.Update(card);

        //await _unitOfWork.CommitAsync();

        return new CompleteCardCommandResponse
        {
            Success = true,
            Message = "Kart başarıyla tamamlandı."
        };
    }
}
