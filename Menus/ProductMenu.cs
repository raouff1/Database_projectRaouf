using Data_Bas123.Models;
using Data_Bas123.Services;

namespace Data_Bas123.Menus;

public class ProductMenu
{
    private readonly ProductService _productService;

    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ManageProducts()
    {
        Console.Clear();
        Console.WriteLine("Manage Products");
        Console.WriteLine("1. Display All Products");
        Console.WriteLine("2. Add Product");
        Console.WriteLine("3. Display All Pricing Units");

        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;

            case "3":
                await ListAllPricingUnitsAsync();
                break;
        }
    }
    public async Task ListAllAsync()
    {
        Console.Clear();

        var products = await _productService.GetAllAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductName} ({product.ProductCategory.CategoryName})");
            Console.WriteLine($"{product.ProductPrice} ({product.PricingUnit.Unit})");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    public async Task CreateAsync()
    {
        var form = new ProductRegistrationForm();

        Console.Clear();
        Console.Write("Product Name: ");
        form.ProductName = Console.ReadLine()!;

        Console.Write("Product Description: ");
        form.ProductDescription = Console.ReadLine()!;

        Console.Write("Product Category: ");
        form.ProductCategory = Console.ReadLine()!;

        Console.Write("Product Price (SEK): ");
        form.ProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.Write("Pricing Unit (st/pkt/tim): ");
        form.PricingUnit = Console.ReadLine()!;

        var result = await _productService.CreateProductAsync(form);
        if (result)
            Console.WriteLine("Product was created successfully.");
        else
            Console.WriteLine("Unable to create product");
    }

    public async Task ListAllPricingUnitsAsync()
    {
        Console.Clear();

        var units = await _productService.GetAllPricingUnitsAsync();
        foreach (var unit in units)
        {
            Console.WriteLine($"{unit.Unit}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
}