using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Address a1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer c1 = new Customer("Alice Smith", a1);

        Address a2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Customer c2 = new Customer("Bob Johnson", a2);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Laptop", "P001", 1000, 1));
        o1.AddProduct(new Product("Mouse", "P002",25, 2));

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Keyboard", "P003", 50, 1));
        o2.AddProduct(new Product("Monitor", "P004", 200, 2));

        List<Order>orders = new List<Order> {o1, o2};

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");
            Console.WriteLine(new string('-', 40));
        }
    }
}