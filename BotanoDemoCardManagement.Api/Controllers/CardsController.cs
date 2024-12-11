using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanoDemoCardManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : BaseController
    {
        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCardsQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCardByIdQuery(id);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCardCommand addCompanyQuery)
        {
            var result = await Mediator.Send(addCompanyQuery);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCardCommand updateCompanyQuery)
        {
            var result = await Mediator.Send(updateCompanyQuery);
            return Ok(result);
        }


        [HttpPost("complete")]
        [Authorize]
        public async Task<IActionResult> CompleteCard([FromBody] CompleteCardCommand completeCardCommand)
        {
            var result = await Mediator.Send(completeCardCommand);
            return Ok(result);
        }

    }
}