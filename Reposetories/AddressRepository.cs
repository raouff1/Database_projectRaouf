using Data_Bas123.Contexts;
using Data_Bas123.Entities;

namespace Data_Bas123.Reposetories;

public class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
