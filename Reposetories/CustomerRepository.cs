using Data_Bas123.Contexts;
using Data_Bas123.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Bas123.Reposetories;

public class CustomerRepository : Repo<CustomerEntity>
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.Include(x => x.Address).ToListAsync();
    }
}