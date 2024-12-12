using BotanoDemoCardManagement.Api.Controllers;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace BotanoDemoCardManagement.Api.Tests.Controllers;
public class CardControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly CardsController _controller;

    public CardControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _controller = new CardsController();        
    }

    [Fact]
    public async Task Add_ShouldReturnOkResult_WhenCommandIsValid()
    {
        // Arrange
        var addCardCommand = new AddCardCommand
        {
            CardName = "Flaming Phoenix",
            CardTypeId = Guid.Parse("d9b5f7a8-1c5b-4b99-b8e1-d045dd2f0a30"),
            ImageUrl = "https://example.com/images/flaming_phoenix.jpg",
            Description = "A mythical bird with fiery wings.",
            Status = CardStatus.NotStarted,
            Questions = new List<QuestionAddResponse>
            {
                new QuestionAddResponse
                {
                    Text = "What is the primary element of the Phoenix?",
                    SortIndex = 1,
                    Choices = new List<ChoiceAddResponse>
                    {
                        new ChoiceAddResponse { Text = "Fire", SortIndex = 1 },
                        new ChoiceAddResponse { Text = "Water", SortIndex = 2 }
                    }
                }
            }
        };

        var response = new AddCardCommandResponse { Id = Guid.NewGuid() };

        _mockMediator
            .Setup(m => m.Send(It.IsAny<AddCardCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.Add(addCardCommand);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<AddCardCommandResponse>(okResult.Value);
        Assert.Equal(response.Id, ((AddCardCommandResponse)okResult.Value).Id);

        _mockMediator.Verify(m => m.Send(It.Is<AddCardCommand>(cmd =>
            cmd.CardName == addCardCommand.CardName &&
            cmd.CardTypeId == addCardCommand.CardTypeId &&
            cmd.Description == addCardCommand.Description &&
            cmd.Status == addCardCommand.Status &&
            cmd.Questions.Count == addCardCommand.Questions.Count),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnOkResult_WhenCommandIsValid()
    {
        // Arrange
        var updateCardCommand = new UpdateCardCommand
        {
            Id = Guid.Parse("e3a7c4d5-9a8f-43b7-93c4-ec2b29b4b3a1"),
            CardName = "Flaming Phoenix Updated",
            CardTypeId = Guid.Parse("b2b9e8b7-4c72-4f5d-b8a6-223c8dd77e20"),
            ImageUrl = "https://example.com/images/flaming_phoenix_updated.jpg",
            Description = "An updated description for the Phoenix.",
            Status = CardStatus.NotStarted,
            Questions = new List<QuestionUpdateResponse>
                {
                    new QuestionUpdateResponse
                    {
                        Id = Guid.Parse("e3a7c4d5-9a8f-43b7-93c4-ec2b29b4b3a1"),
                        Text = "What is the primary element of the Phoenix?",
                        SortIndex = 1,
                        Choices = new List<ChoiceUpdateResponse>
                        {
                            new ChoiceUpdateResponse { Id = Guid.Parse("28a210c7-0d48-4ac8-8547-25a8307dffca"), Text = "Fire", SortIndex = 1 },
                            new ChoiceUpdateResponse { Id = Guid.Parse("48f3302e-e627-4cbf-a7a1-1af2c95cfc63"), Text = "Water", SortIndex = 2 }
                        }
                    }
                }
        };

        var response = new UpdateCardCommandResponse { Id = updateCardCommand.Id };

        _mockMediator
            .Setup(m => m.Send(It.IsAny<UpdateCardCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.Update(updateCardCommand);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<UpdateCardCommandResponse>(okResult.Value);
        Assert.Equal(response.Id, ((UpdateCardCommandResponse)okResult.Value).Id);

        _mockMediator.Verify(m => m.Send(It.Is<UpdateCardCommand>(cmd =>
            cmd.Id == updateCardCommand.Id &&
            cmd.CardName == updateCardCommand.CardName &&
            cmd.CardTypeId == updateCardCommand.CardTypeId &&
            cmd.Description == updateCardCommand.Description &&
            cmd.Status == updateCardCommand.Status &&
            cmd.Questions.Count == updateCardCommand.Questions.Count),
            It.IsAny<CancellationToken>()), Times.Once);
    }

}