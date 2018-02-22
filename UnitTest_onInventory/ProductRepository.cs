using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_onInventory
{
    public class ProductRepository
    {
        public List<Product> products = new List<Product>();

        public ProductRepository(List<Product> prod)
        {
            products = prod;
        }

        //Method 1: Create a method to return total number of products in list.
        public int calculate_total_number_of_products()
        {
            return products.Count;
        }

        //Method 2: Create a method to add new product in list and return the list with added product.
        public List<Product> add_new_item_to_list(Product p)
        {
            products.Add(p);
            return products;
        }

        //Method 3: Create a method to find products by its type and return found products list.
        public List<Product> find_products_by_type(string type)
        {
            var type_products = products.FindAll(x => x.type == type);
            return type_products;
        }

        //Method 4: Create a method to delete product by its name and return list with deleted product.
        public List<Product> delete_product_from_list(string name)
        {
            products.Remove(products.Find(x => x.name == name));
            return products;
        }

        /*Method 5: Create a method to buy products by passing 
          its name and quantity and return total price of bought products.*/
        public double buy_products(string name, double quant)
        {
            double amount = 0;
            Product item = products.Find(x => x.name == name);
            amount = (item.price / item.quantity) * quant;
            return amount;
        }
        static void Main(string[] args)
        {
        }
    }
    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public Product(string n, double p, int q, string t)
        {
            name = n;
            price = p;
            quantity = q;
            type = t;
        }
        public string display()
        {
            return "Name: " + name + " Quantity: " + quantity + " Price: Rs." + price + " Type: " + type;
        }
    }
}
