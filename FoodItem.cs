namespace foodPantry;

public class FoodItem
{
    public string Name;
    public string Category;
    public int Quantity;
    public DateTime ExpirationDate;

    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity >= 0 ?  quantity : throw new ArgumentException("Quantity must be greater than zero");
        ExpirationDate = expirationDate;
    }

    public bool IsExpired()
    {
        return ExpirationDate < DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Name} - {Category} - {Quantity} units - Expires on {ExpirationDate:MM/dd/yyyy}";
    }
}