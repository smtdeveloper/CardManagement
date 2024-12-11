using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Domain.Entities.Enums;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;

public class CompleteCardCommandHandler : IRequestHandler<CompleteCardCommand, CompleteCardCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUserAnswerRepository _userAnswerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CardBusinessRules _cardBusinessRules;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IValidator<CompleteCardCommand> _validator;

    public CompleteCardCommandHandler(
        IMapper mapper,
        ICardRepository cardRepository,
        IUserAnswerRepository userAnswerRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        CardBusinessRules cardBusinessRules,
        IValidator<CompleteCardCommand> validator)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _userAnswerRepository = userAnswerRepository;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _cardBusinessRules = cardBusinessRules;
        _validator = validator;
        
    }

    public async Task<CompleteCardCommandResponse> Handle(CompleteCardCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var card = await _cardRepository.GetCardByIdAsync(request.CardId, cancellationToken);
        await _cardBusinessRules.CheckIfCardIsNull(card);
        await _cardBusinessRules.CheckIfCardIsCompleted(card, request.CompleteCardModel.Answers);

        foreach (var answer in request.CompleteCardModel.Answers)
        {
            var existingAnswer = await _userAnswerRepository.GetUserAnswerAsync(request.CardId, answer.QuestionId, cancellationToken);
            if (existingAnswer == null)
            {
                await _userAnswerRepository.AddAsync(new UserCardAnswer
                {
                    UserId = GetCurrentUserId(),
                    CardId = request.CardId,
                    CardQuestionId = answer.QuestionId,
                    CardQuestionChoiceId = answer.ChoiceId
                }, cancellationToken);

            }
            else
            {
                existingAnswer.CardQuestionChoiceId = answer.ChoiceId;
            }
        }

        card.Status = CardStatus.Done;
        _cardRepository.Update(card);
        await _unitOfWork.CommitAsync();

        return new CompleteCardCommandResponse
        {
            Success = true,
            Message = "The card has been completed successfully."
        };
    }

    public Guid GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            throw new UnauthorizedAccessException("Failed to retrieve user ID.");
        }
        return Guid.Parse(userId);
    }
}