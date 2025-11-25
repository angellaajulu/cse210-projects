using System.Collections.Generic;

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this. customer = customer;
    }
    public void AddProduct(Product p)
    {
        products.Add(p);
    }

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var p in products)
        {
            total += p.GetTotalCost();
        }
        double shipping = customer.LivesInUSA() ? 5 : 35;
        return total + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var p in products)
        {
            label += p.GetPackingInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}