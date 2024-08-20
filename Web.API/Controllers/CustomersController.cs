using EasyPOS.Application.Customers.Create;
using EasyPOS.Application.Customers.Delete;
using EasyPOS.Application.Customers.GetAll;
using EasyPOS.Application.Customers.GetById;
using EasyPOS.Application.Customers.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ApiController
    {

        private readonly ISender _mediator;

        public CustomersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customerResult = await _mediator.Send(new GetAllCustomerQuery());
            return customerResult.Match(
                customers => Ok(customers),
                errors => Problem(errors)
                );
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customerResponse = await _mediator.Send(new GetByIdCustomerQuery(id));
            return customerResponse.Match(
                customer => Ok(customer),
                errors => Problem(errors)
                );
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            var createCustomerResult = await _mediator.Send(command);
            return createCustomerResult.Match(
                success => Ok(),
                errors => Problem(errors)
                );
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            if (updateCustomerCommand.Id != id)
            {
                List<Error> errors = new()
                {
                Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }
            var updateResult = await _mediator.Send(updateCustomerCommand);

            return updateResult.Match(
                success => Ok(),
                errors => Problem(errors)
                );
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteCustomerCommand(id));
            return deleteResult.Match(
                success => NoContent(),
                errors => Problem(errors)
                );
        }
    }
}
