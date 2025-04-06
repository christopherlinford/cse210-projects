using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string DisplayProduct()
    {
        return $"{name} (ID: {productId}) - ${price} x {quantity} = ${GetTotalCost()}";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += "- " + product.DisplayProduct() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetCustomerInfo();
    }
}

class Program
{
    static void Main()
    {
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.99, 2));

        Address addr2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Bob Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Headphones", "H789", 79.99, 1));
        order2.AddProduct(new Product("Keyboard", "K101", 49.99, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}\n");
        }
    }
}
