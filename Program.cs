using foodPantry;

FoodItem fi = new FoodItem();

string name = "";
string category = "";
int quantity = 0;
string expirationDate = "";

Console.WriteLine("Please enter the food item name: ");
name = Console.ReadLine();

Console.WriteLine("Please enter" + name + "'s Category: (e.g., 'Canned Goods', 'Dairy', 'Produce' ");
category = Console.ReadLine();

Console.WriteLine("Please enter the quantity of" + name +"to put on shelf ");
quantity = int.Parse(Console.ReadLine());

Console.WriteLine("Please enter the expiration date: ");
expirationDate = Console.ReadLine();


Console.Write(name);
