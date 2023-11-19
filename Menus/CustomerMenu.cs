using Data_Bas123.Models;
using Data_Bas123.Services;

namespace Data_Bas123.Menus;

public class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("Manage Customers");

        Console.WriteLine("1. Display All Customers");
        Console.WriteLine("2. Add Customer");
        Console.Write("Select one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;
        }
    }


    public async Task ListAllAsync()
    {
        Console.Clear();

        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode} {customer.Address.City}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
    public async Task CreateAsync()

    {
        var form = new CustomerRegistrationForm();

        Console.Clear();
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postal Code (xxx xx): ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Customer was created successfully.");
        else
            Console.WriteLine("Unable to create customer");
    }


}