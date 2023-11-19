namespace Data_Bas123.Menus;

public class MainMenu
{
    private readonly CustomerMenu _customerMenu;
    private readonly ProductMenu _productMenu;

    public MainMenu(CustomerMenu customerMenu, ProductMenu productMenu)
    {
        _customerMenu = customerMenu;
        _productMenu = productMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Manage Customers");
            Console.WriteLine("2. Manage Products");

            Console.Write("Select one option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;

                case "2":
                    await _productMenu.ManageProducts();
                    break;
            }
        }
        while (true);
    }

}