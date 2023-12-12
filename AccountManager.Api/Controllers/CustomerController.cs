using AccountManager.Application.Customers.Query.GetDetailedCustomerInformation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get account information of customer
        /// </summary>
        /// <param name="customerId"customer id</param>
        /// <returns>Ok if account was opened</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DetailedCustomerResponse>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCustomerInformation(Guid customerId)
        {
            var query = new GetDetailedCustomerInformationQuery { CustomerId = customerId };
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
