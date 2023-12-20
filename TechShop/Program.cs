using TechShop.DataAccess;
using TechShop.Entities;
using TechShop.Exceptions;
using TechShop.UI;
using TechShop.Utils;
public class Program
{
    enum MainMenuChoice
    {
        CustomerManagement = 1,
        ProductManagement,
        OrderManagement,
        InventoryManagement,
        Exit
    }
    private static IGadgetsShop gadgetsShop = new GadgetsShopImpl();
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine($"{(int)MainMenuChoice.CustomerManagement}. Customer Management");
            Console.WriteLine($"{(int)MainMenuChoice.ProductManagement}. Product Management");
            Console.WriteLine($"{(int)MainMenuChoice.OrderManagement}. Order Management");
            Console.WriteLine($"{(int)MainMenuChoice.InventoryManagement}. Inventory Management");
            Console.WriteLine($"{(int)MainMenuChoice.Exit}. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                MainMenuChoice mainMenuChoice = (MainMenuChoice)choice;
                switch (mainMenuChoice)
                {
                    case MainMenuChoice.CustomerManagement:
                        CustomerManagementMenu();
                        break;
                    case MainMenuChoice.ProductManagement:
                        ProductManagementMenu();
                        break;
                    case MainMenuChoice.OrderManagement:
                        OrderManagementMenu();
                        break;
                    case MainMenuChoice.InventoryManagement:
                        InventoryManagementMenu();
                        break;
                    case MainMenuChoice.Exit:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a valid choice.");
            }

            Console.WriteLine();
        }
    }
    private static void CustomerManagementMenu()
    {
        CustomerManagement customerManagement = new CustomerManagement(gadgetsShop);
        customerManagement.RunCustomerManagement();
    }


    private static void ProductManagementMenu()
    {
    }

    private static void OrderManagementMenu()
    {
    }

    private static void InventoryManagementMenu()
    {
    }
}
