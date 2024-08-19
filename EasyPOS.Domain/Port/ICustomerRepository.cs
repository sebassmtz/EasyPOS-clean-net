
using EasyPOS.Domain.Customers;

namespace EasyPOS.Domain.Port
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId id);
        Task Add(Customer customer);
    }
}
