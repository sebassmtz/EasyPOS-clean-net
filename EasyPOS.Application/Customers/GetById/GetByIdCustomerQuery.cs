using EasyPOS.Application.Customers.Common;
using ErrorOr;
using MediatR;

namespace EasyPOS.Application.Customers.GetById
{
    public record GetByIdCustomerQuery(Guid Id) : IRequest<ErrorOr<CustomerResponse>>;
}
