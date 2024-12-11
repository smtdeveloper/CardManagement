namespace BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;

public class GetCardByIdQueryResponse
{
    public CardModel Card { get; set; }   
}

public class CardModel
{
    public Guid Id { get; set; }
    public string CardName { get; set; }
    public string CardTypeName { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public List<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>();
}

public class QuestionResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }
    public List<ChoiceResponse> Choices { get; set; } = new List<ChoiceResponse>();
}

public class ChoiceResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int SortIndex { get; set; }
}