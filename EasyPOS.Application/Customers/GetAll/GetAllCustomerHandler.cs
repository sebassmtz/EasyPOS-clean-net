using EasyPOS.Application.Customers.Common;
using EasyPOS.Domain.Customers;
using EasyPOS.Domain.Port;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.GetAll
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, ErrorOr<IReadOnlyList<CustomerResponse>>>
    {

        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository)); ;
        }

        public async Task<ErrorOr<IReadOnlyList<CustomerResponse>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

            return customers.Select(
                customer => new CustomerResponse(
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
                    customer.Active
                    )).ToList();
        }
    }
}
