using AutoMapper;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;

namespace BotanoDemoCardManagement.Application.Features.Cards.Profiles;

public class CardMappings : Profile
{
    public CardMappings()
    {
        CreateMap<CardQuestionChoice, ChoiceResponse>();
        CreateMap<CardQuestion, QuestionResponse>().ReverseMap();
        CreateMap<CardQuestionChoice, ChoiceResponse>().ReverseMap();
        CreateMap<CardQuestionChoice, ChoiceAddResponse>().ReverseMap();
        CreateMap<QuestionAddResponse, CardQuestion>().ReverseMap();
        CreateMap<Card, AddCardCommandResponse>().ReverseMap();

        CreateMap<UpdateCardCommand, Card>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions.Select(q => new CardQuestion
            {
                Id = q.Id,
                Text = q.Text,
                SortIndex = q.SortIndex,
                Choices = q.Choices.Select(c => new CardQuestionChoice
                {
                    Id = c.Id,
                    Text = c.Text,
                    SortIndex = c.SortIndex
                }).ToList()
            }).ToList()));

        CreateMap<Card, UpdateCardCommandResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddCardCommand, Card>()            
             .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions.Select(q => new CardQuestion
             {
                 Text = q.Text,
                 SortIndex = q.SortIndex,
                 Choices = q.Choices.Select(c => new CardQuestionChoice
                 {
                     Text = c.Text,
                     SortIndex = c.SortIndex
                 }).ToList()
             }).ToList()));

        CreateMap<QuestionAddResponse, CardQuestion>()
            .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));
        CreateMap<ChoiceAddResponse, CardQuestionChoice>();

        CreateMap<Card, GetAllCardsQueryResponse>()
            .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src))
            .ForPath(dest => dest.Card.Questions, opt => opt.MapFrom(src => src.Questions.OrderBy(q => q.SortIndex).ToList()));

        CreateMap<Card, GetCardByIdQueryResponse>()
            .ForMember(dest => dest.Card, opt => opt.MapFrom(src => src))
            .ForPath(dest => dest.Card.Questions, opt => opt.MapFrom(src => src.Questions.OrderBy(q => q.SortIndex).ToList()));

        CreateMap<Card, CardModel>()
            .ForMember(dest => dest.CardTypeName, opt => opt.MapFrom(src => src.CardType.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<CardQuestion, QuestionResponse>()
            .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices.OrderBy(c => c.SortIndex).ToList()));
    }
}