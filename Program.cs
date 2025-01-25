using System;
using System.Collections.Generic;
using foodPantry;

namespace Mission3
{
    class Program
    {
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Food Bank Inventory System ---");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Donate Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("\nSelect an option: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DonateFoodItem();
                        break;
                    case "3":
                        PrintInventory();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.WriteLine("Please enter the food item name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Please enter " + name + "'s Category: (e.g., 'Canned Goods', 'Dairy', 'Produce') ");
                string category = Console.ReadLine();

                Console.WriteLine("Please enter the quantity of " + name + " to put on shelf ");
                int quantity = int.Parse(Console.ReadLine());
                if (quantity < 0) throw new Exception("Quantity cannot be negative.");

                Console.WriteLine("Please enter the expiration date: (mm/dd/yyyy) ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                inventory.Add(newItem);

                Console.WriteLine($"{name} is added to the inventory.");
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please ensure quantity is a number and date is in the correct format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        static void DonateFoodItem()
        {
            Console.Write("Enter the name of the food item to donate: ");
            string name = Console.ReadLine();

            FoodItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                inventory.Remove(itemToRemove);
                Console.WriteLine($"{name} has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"No item with the name '{name}' was found.");
            }
        }

        static void PrintInventory()
        {
            Console.WriteLine("\n--- Current Food Items ---");
            if (inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
            }
            else
            {
                foreach (FoodItem item in inventory)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
