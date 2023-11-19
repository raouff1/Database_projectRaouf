using Data_Bas123.Contexts;
using Data_Bas123.Menus;
using Data_Bas123.Reposetories;
using Data_Bas123.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-8\Assignment\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30"));

        // Repositories
        services.AddScoped<AddressRepository>();
        services.AddScoped<CustomerRepository>();
        services.AddScoped<PricingUnitRepository>();
        services.AddScoped<ProductCategoryRepository>();
        services.AddScoped<ProductRepository>();

        // Services
        services.AddScoped<CustomerService>();
        services.AddScoped<ProductService>();

        // Menus
        services.AddScoped<CustomerMenu>();
        services.AddScoped<ProductMenu>();
        services.AddScoped<MainMenu>();


        var sp = services.BuildServiceProvider();
        var mainMenu = sp.GetRequiredService<MainMenu>();
        await mainMenu.StartAsync();
    }
}