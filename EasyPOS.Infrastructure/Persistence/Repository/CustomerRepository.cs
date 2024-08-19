using EasyPOS.Domain.Customers;
using EasyPOS.Domain.Port;
using Microsoft.EntityFrameworkCore;

namespace EasyPOS.Infrastructure.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Customer customer)
        {
             _context.Customers.Add(customer);
        }

        public async Task<Customer?> GetByIdAsync(CustomerId id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
