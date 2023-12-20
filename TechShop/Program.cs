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
                        // Handle Customer Management menu
                        CustomerManagementMenu();
                        break;
                    case MainMenuChoice.ProductManagement:
                        // Handle Product Management menu
                        ProductManagementMenu();
                        break;
                    case MainMenuChoice.OrderManagement:
                        // Handle Order Management menu
                        OrderManagementMenu();
                        break;
                    case MainMenuChoice.InventoryManagement:
                        // Handle Inventory Management menu
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

            Console.WriteLine(); // Add a line break for readability
        }
    }
    private static void CustomerManagementMenu()
    {
        CustomerManagement customerManagement = new CustomerManagement(gadgetsShop);
        customerManagement.RunCustomerManagement();
    }


    private static void ProductManagementMenu()
    {
        // Implement the Product Management menu options here
        // You can create an instance of ProductManagement class and call its methods
    }

    private static void OrderManagementMenu()
    {
        // Implement the Order Management menu options here
        // You can create an instance of OrderManagement class and call its methods
    }

    private static void InventoryManagementMenu()
    {
        // Implement the Inventory Management menu options here
        // You can create an instance of InventoryManagement class and call its methods
    }
}
