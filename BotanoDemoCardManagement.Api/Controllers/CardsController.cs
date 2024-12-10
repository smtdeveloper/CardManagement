using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetAllCards;
using BotanoDemoCardManagement.Application.Features.Cards.Queries.GetByIdCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BotanoDemoCardManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCardsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCardByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCardCommand addCompanyQuery)
        {
            var result = await _mediator.Send(addCompanyQuery);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCardCommand updateCompanyQuery)
        {
            var result = await _mediator.Send(updateCompanyQuery);
            return Ok(result);
        }
    }
}