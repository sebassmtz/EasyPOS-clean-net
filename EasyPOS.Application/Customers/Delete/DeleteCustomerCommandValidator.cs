using FluentValidation;

namespace EasyPOS.Application.Customers.Delete
{
    public class DeleteCustomerCommandValidator: AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}
