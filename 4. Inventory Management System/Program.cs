using System;

namespace myApp
{
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    class Inventory
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product.Name))
            {
                Console.WriteLine("Product already exists. Use UpdateProduct to modify.");
            }
            else
            {
                products.Add(product.Name, product);
                Console.WriteLine($"Product {product.Name} added.");
            }
        }

        public void UpdateProduct(string name, int quantity, double price)
        {
            if (products.ContainsKey(name))
            {
                products[name].Quantity = quantity;
                products[name].Price = price;
                Console.WriteLine($"Product {name} updated.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void RemoveProduct(string name)
        {
            if (products.ContainsKey(name))
            {
                products.Remove(name);
                Console.WriteLine($"Product {name} removed.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void ListProducts()
        {
            Console.WriteLine("Product Inventory:");
            foreach (var product in products.Values)
            {
                Console.WriteLine($"{product.Name} - Quantity: {product.Quantity}, Price: {product.Price}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.AddProduct(new Product("Laptop", 10, 1000));
            inventory.AddProduct(new Product("Mouse", 50, 25));

            inventory.ListProducts();

            inventory.UpdateProduct("Laptop", 8, 950);
            inventory.ListProducts();

            inventory.RemoveProduct("Mouse");
            inventory.ListProducts();
        }
    }
}
