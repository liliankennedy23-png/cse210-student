using System;
using System.Collections.Generic;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA() => _country.ToLower() == "usa" || _country.ToLower() == "united states";
    public string GetFullAddress() => $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name => _name;
    public Address GetAddress() => _address;
    public bool IsInUSA() => _address.IsInUSA();
}

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name => _name;
    public string ProductId => _productId;
    public double TotalCost() => _price * _quantity;
    public string GetPackingInfo() => $"{_name} (ID: {_productId}) - Qty: {_quantity}, Unit Price: ${_price:F2}, Total: ${TotalCost():F2}";
}

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);
    public double CalculateSubtotal()
    {
        double subtotal = 0;
        foreach (var product in _products) subtotal += product.TotalCost();
        return subtotal;
    }

    public double CalculateShipping() => _customer.IsInUSA() ? 5 : 35;
    public double CalculateTotalPrice() => CalculateSubtotal() + CalculateShipping();

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products) label += "  " + product.GetPackingInfo() + "\n";
        return label;
    }

    public string GetShippingLabel() => $"Shipping Label:\nShip to: {_customer.Name}\n{_customer.GetAddress().GetFullAddress()}";

    public void DisplayInvoice()
    {
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine($"Subtotal: ${CalculateSubtotal():F2}");
        Console.WriteLine($"Shipping: ${CalculateShipping():F2}");
        Console.WriteLine($"Total Price: ${CalculateTotalPrice():F2}");
        Console.WriteLine(new string('-', 60));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        string[] customerNames = { "Alice Johnson", "Bob Smith", "Charlie Brown", "Diana Prince", "Eve Adams" };
        string[] streets = { "123 Main St", "456 Elm St", "789 Oak Ave", "101 Pine Rd", "202 Maple Dr" };
        string[] cities = { "Springfield", "Toronto", "New York", "Los Angeles", "Vancouver" };
        string[] states = { "IL", "ON", "NY", "CA", "BC" };
        string[] countries = { "USA", "Canada" };

        string[] productNames = { "Laptop", "Mouse", "Keyboard", "Headphones", "Monitor", "Tablet", "Charger" };

        List<Order> orders = new List<Order>();

        // Generate 2 random orders
        for (int i = 0; i < 2; i++)
        {
            string name = customerNames[rnd.Next(customerNames.Length)];
            Address address = new Address(
                streets[rnd.Next(streets.Length)],
                cities[rnd.Next(cities.Length)],
                states[rnd.Next(states.Length)],
                countries[rnd.Next(countries.Length)]
            );
            Customer customer = new Customer(name, address);

            Order order = new Order(customer);

            // Random number of products per order (2-4)
            int numProducts = rnd.Next(2, 5);
            for (int j = 0; j < numProducts; j++)
            {
                string productName = productNames[rnd.Next(productNames.Length)];
                string productId = "P" + rnd.Next(100, 999);
                double price = Math.Round(rnd.NextDouble() * 500 + 10, 2); // $10 - $510
                int quantity = rnd.Next(1, 4);
                order.AddProduct(new Product(productName, productId, price, quantity));
            }

            orders.Add(order);
        }

        // Display all orders
        foreach (var order in orders) order.DisplayInvoice();
    }
}
