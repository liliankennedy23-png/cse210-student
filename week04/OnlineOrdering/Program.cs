using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Lilian Kennedy", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P010", 1.50, 5));

        Address address2 = new Address("45 King Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alex Brown", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N100", 6.99, 3));
        order2.AddProduct(new Product("Backpack", "BP55", 39.99, 1));

        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
    }
}
