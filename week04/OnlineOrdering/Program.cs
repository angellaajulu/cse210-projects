using System;

class Program
{
    static void Main(string[] args)
    {
        // -------- Order 1 (USA Customer) --------
        Address address1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P100", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "P101", 19.99, 2));

        // -------- Order 2 (Non-USA Customer) --------
        Address address2 = new Address("45 Market Road", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Robert King", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Desk Lamp", "P200", 29.99, 1));
        order2.AddProduct(new Product("Notebook Set", "P201", 12.50, 3));
        order2.AddProduct(new Product("Backpack", "P202", 45.00, 1));

        // -------- Display Output --------
        DisplayOrder(order1);
        Console.WriteLine("---------------------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Total Price: ${order.GetTotalCost()}\n");
    }
}