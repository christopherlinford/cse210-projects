using System;
using System.Collections.Generic;



class Program
{
    static void Main(string[] args)
    {
        // Order 1 USA 
        Address address1 = new Address("135 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Amy Jordan", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N100", 3.99, 3));
        order1.AddProduct(new Product("Pen", "P100", 1.50, 5));

        // Order 2 - International 
        Address address2 = new Address("468 Queen St", "Vancouver", "BC", "Canada");
        Customer customer2 = new Customer("Robert Links", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "B100", 45.00, 1));
        order2.AddProduct(new Product("Calculator", "C200", 119.99, 2));

        // Display results for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}\n");

        // Display results for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}\n");
    }
}
