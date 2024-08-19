
using EasyPOS.Domain.Customers;

namespace EasyPOS.Domain.Port
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId id);
        void Add(Customer customer);
    }
}
