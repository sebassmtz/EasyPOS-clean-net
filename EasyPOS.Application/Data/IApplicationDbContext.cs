using EasyPOS.Domain.Customers;
using Microsoft.EntityFrameworkCore;


namespace EasyPOS.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
