using EasyPOS.Application.Customers.Common;
using EasyPOS.Domain.Customers;
using EasyPOS.Domain.Port;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.GetById
{
    internal sealed class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery,ErrorOr<CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }


        public async Task<ErrorOr<CustomerResponse>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            if(await _customerRepository.GetByIdAsync(new CustomerId(request.Id)) is not Customer customer)
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
            }
            return new CustomerResponse(
                customer.Id.Value,
                customer.FullName,
                customer.Email,
                customer.PhoneNumber.Value,
                new AddressResponse(
                    customer.Address.Country,
                    customer.Address.Line1,
                    customer.Address.Line2,
                    customer.Address.City,
                    customer.Address.State,
                    customer.Address.ZipCode
                    ),
                customer.Active);
        }
    }
}
