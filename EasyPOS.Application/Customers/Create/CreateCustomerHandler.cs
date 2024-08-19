using EasyPOS.Domain.Customers;
using EasyPOS.Domain.Port;
using EasyPOS.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.Create
{
    internal sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Unit>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
                {
                    return Error.Validation("Customer.PhoneNumber", "Phone Number is not valid format");
                }

                if (Address.Create(request.Country,
                    request.Line1,
                    request.Line2,
                    request.City,
                    request.State,
                    request.zipCode) is not Address address)
                {
                    return Error.Validation("Customer.Address", "Address is not valid format");
                }

                var customer = new Customer(
                    new CustomerId(Guid.NewGuid()),
                    request.Name,
                    request.LastName,
                    request.Email,
                    phoneNumber,
                    address,
                    true
                    );

                _customerRepository.Add(customer);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure("CreateCustomer.Failure", ex.Message);
            }
        }
    }
}
