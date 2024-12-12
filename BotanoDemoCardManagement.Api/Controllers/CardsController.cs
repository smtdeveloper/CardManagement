using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanoDemoCardManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardsController : BaseController
{
    public CardsController()
    {
    }

    /// <summary>
    /// Lists all cards.
    /// </summary>
    /// <remarks>
    /// Example request:
    /// GET /api/cards/list
    /// </remarks>
    /// <returns>A list of all cards.</returns>
    /// <response code="200">Cards were successfully retrieved.</response>
    /// <response code="500">An internal server error occurred.</response>
    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCardsQuery();
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves the details of a specific card by its ID.
    /// </summary>
    /// <param name="id">The unique ID of the card (UUID).</param>
    /// <remarks>
    /// Example request:
    /// GET /api/cards/detail/{id}
    /// </remarks>
    /// <returns>The details of the specified card.</returns>
    /// <response code="200">Card details were successfully retrieved.</response>
    /// <response code="404">The card was not found.</response>
    [HttpGet("detail/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCardByIdQuery(id);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Adds a new card.
    /// </summary>
    /// <remarks>
    /// Example Request:
    /// 
    /// POST /api/cards/add
    /// 
    /// Request Body:
    /// 
    /// json
    /// {
    ///     "cardName": "New Card",
    ///     "cardTypeId": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///     "imageUrl": "https://example.com/image.png",
    ///     "description": "This is the description of the new card.",
    ///     "status": "Active",
    ///     "questions": [
    ///         {
    ///             "text": "Question 1?",
    ///             "sortIndex": 1,
    ///             "choices": [
    ///                 {
    ///                     "text": "Choice A",
    ///                     "sortIndex": 1
    ///                 },
    ///                 {
    ///                     "text": "Choice B",
    ///                     "sortIndex": 2
    ///                 }
    ///             ]
    ///         }
    ///     ]
    /// }
    /// 
    /// </remarks>
    /// <param name="addCardCommand">The command containing details of the new card.</param>
    /// <returns>A success message.</returns>
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddCardCommand addCardCommand)
    {
        var result = await Mediator.Send(addCardCommand);
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing card.
    /// </summary>
    /// <param name="updateCardCommand">The command containing updated details of the card.</param>
    /// <remarks>
    /// Example request:
    /// PUT /api/cards/update
    /// 
    /// Request Body:
    /// json
    /// {
    ///     "Id": "Card UUID",
    ///     "CardName": "Updated Card Name",
    ///     "CardTypeId": "Card Type UUID",
    ///     "ImageUrl": "Updated Image URL",
    ///     "Description": "Updated Description",
    ///     "Status": "Card Status",
    ///     "Questions": [
    ///         {
    ///             "Id": "Question UUID",
    ///             "Text": "Question Text",
    ///             "SortIndex": 1,
    ///             "Choices": [
    ///                 {
    ///                     "Id": "Choice UUID",
    ///                     "Text": "Choice Text",
    ///                     "SortIndex": 1
    ///                 }
    ///             ]
    ///         }
    ///     ]
    /// }
    /// 
    /// </remarks>
    /// <returns>A success message.</returns>
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCardCommand updateCardCommand)
    {
        var result = await Mediator.Send(updateCardCommand);
        return Ok(result);
    }

    /// <summary>
    /// Completes a specific card.
    /// </summary>
    /// <param name="completeCardCommand">The command containing the card ID and user answers.</param>
    /// <remarks>
    /// Example request:
    /// POST /api/cards/complete  
    /// 
    /// Request Body:
    /// json
    /// {
    ///     "CardId": "Card UUID",
    ///     "CompleteCardModel": {
    ///         "Answers": [
    ///             {
    ///                 "QuestionId": "Question UUID",
    ///                 "ChoiceId": "Choice UUID"
    ///             }
    ///         ]
    ///     }
    /// }
    /// 
    /// </remarks>
    /// <returns>A success message.</returns>
    /// <response code="200">The card was successfully completed.</response>
    /// <response code="401">Unauthorized. The user is not authenticated.</response>
    [HttpPost("complete")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CompleteCard([FromBody] CompleteCardCommand completeCardCommand)
    {
        var result = await Mediator.Send(completeCardCommand);
        return Ok(result);
    }
}