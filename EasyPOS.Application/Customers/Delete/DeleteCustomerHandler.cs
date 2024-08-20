

using EasyPOS.Domain.Customers;
using EasyPOS.Domain.Port;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.Delete
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ErrorOr<Unit>>
    {

        private IUnitOfWork _unitOfWork;
        private ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _customerRepository.GetByIdAsync(new CustomerId(request.Id)) is not Customer customer)
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
            }
            _customerRepository.Delete(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
