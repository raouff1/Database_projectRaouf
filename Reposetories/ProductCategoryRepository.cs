using Data_Bas123.Contexts;
using Data_Bas123.Entities;

namespace Data_Bas123.Reposetories;

public class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}