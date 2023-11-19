using Data_Bas123.Contexts;
using Data_Bas123.Entities;

namespace Data_Bas123.Reposetories;

public class PricingUnitRepository : Repo<PricingUnitEntity>
{
    public PricingUnitRepository(DataContext context) : base(context)
    {
    }
}
