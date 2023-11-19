using Data_Bas123.Contexts;
using Data_Bas123.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Bas123.Reposetories;

public class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.PricingUnit)
            .Include(x => x.ProductCategory)
            .ToListAsync();
    }
}