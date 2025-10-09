using System;


class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create order 1 (USA)
        Order order1 = new Order(customer1);
        order1.SetProduct("Laptop", 1001, 999.99, 1);
        order1.SetProduct("Mouse", 1002, 29.99, 2);
        order1.SetProduct("Keyboard", 1003, 59.99, 1);

        // Create order 2 (Canada)
        Order order2 = new Order(customer2);
        order2.SetProduct("Monitor", 2001, 249.99, 1);
        order2.SetProduct("Webcam", 2002, 79.99, 3);

        // Display order details
        Console.WriteLine($"Order ID: {order1.GetOrderId()}");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.ProductLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.TotalCost():F2}\n");

        Console.WriteLine($"Order ID: {order2.GetOrderId()}");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.ProductLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.TotalCost():F2}");
    }
}

//added a feature, unique id to track orders display in output
