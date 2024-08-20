using EasyPOS.Application.Customers.Common;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.GetAll
{
    public record GetAllCustomerQuery() : IRequest<ErrorOr<IReadOnlyList<CustomerResponse>>>;
}
