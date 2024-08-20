
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.Delete
{
    public record DeleteCustomerCommand(Guid Id): IRequest<ErrorOr<Unit>>;
}
