using AccountManager.Application.Accounts.Commands.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create an account with command
        /// </summary>
        /// <param name="command">set account balance and customer</param>
        /// <returns>Ok if account was opened</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }
}
