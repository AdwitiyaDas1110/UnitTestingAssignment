using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_onInventory;

namespace UnitTestProject_InventorySystem
{
    [TestClass]
    public class InventoryTest
    {
        //-----------------------Method 1 tests------------------------//
        //Test should assert total number of products to be 10.
        [TestMethod]
        public void list_count_should_be_10()
        {
           
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            int result = pR.calculate_total_number_of_products();
            Assert.AreEqual(10, result);
        }
        
        //Add one product using method 2. Then test should assert total number of products to be 11.
        [TestMethod]
        public void list_count_should_be_11_after_adding_an_item()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.add_new_item_to_list(new Product("Potato", 10, 50, "Root"));
            Assert.AreEqual(11, result.Count);
            
        }

        /* Delete zucchini and broccoli using method 4. Then 
         * test should assert total number of products to be 8.*/
        [TestMethod]
        public void list_count_should_be_8_after_removing_zucchini_and_broccoli()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.delete_product_from_list("broccoli");
            result = pR.delete_product_from_list("zucchini");
            Assert.AreEqual(8, result.Count);
        }

        
        
        //--------------------------------Method 2 tests----------------------------//
        //Add new product using method 2, then test should assert returned list length to be 11.
        [TestMethod]
        public void list_count_should_be_11_applied_on_Method2()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.add_new_item_to_list(new Product("Potato", 10, 50, "Root"));
            Assert.AreEqual(11, result.Count);
        }
        
        /* Add new product using method 2, then test should assert 
         * newly added product to be at last position of list.*/
        [TestMethod]
        public void item_should_be_added_to_end_of_list()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var p = new Product("Potato", 10, 50, "Root");
            var result = pR.add_new_item_to_list(p);
            int pos = result.IndexOf(p);
            Assert.AreEqual(result.Count - 1, pos);
        }


        //-----------------------Method 3 tests------------------------//
        /* Use method 3 to find Cruciferous products, then test 
         * should assert returned product list length to be 3.*/
        [TestMethod]
        public void number_of_cruciferous_items_should_be_3()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.find_products_by_type("Cruciferous");
            Assert.AreEqual(3, result.Count);
        }
        
        /* Use method 3 to find Marrow products, then test should assert 
         * returned product list must only contain marrow product type.*/
        [TestMethod]
        public void list_should_contain_only_marrow_items()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.find_products_by_type("Marrow");
            foreach(var item in result)
            {
                Assert.AreEqual("Marrow", item.type);
            }
        }


        //-------------------------------Method 4 tests------------------------//
        //Delete pumpkin using method 4, then test should assert returned list length to be 9.
        [TestMethod]
        public void list_count_should_be_9_after_deleting_pumpkin()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.delete_product_from_list("pumpkin");
            Assert.AreEqual(9, result.Count);
        }

        //Delete cabbage using method 4, then test should assert returned list must not contain cabbage.
        [TestMethod]
        public void list_should_not_contain_cabbage()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            var result = pR.delete_product_from_list("cabbage");
            Assert.AreEqual(false, result.Exists(x => x.name == "cabbage"));
        }


        //--------------------------------Method 5 tests--------------------------------//
        /* Use method 5 to buy grocery for making salad of your like, 
         * then test should assert total price to be x.*/
        [TestMethod]
        public void total_price_check()
        {
            var prod = make_product_list();
            ProductRepository pR = new ProductRepository(prod);
            double total_sum = 0;
            total_sum += pR.buy_products("lettuce", 2);
            total_sum += pR.buy_products("cabbage", 3);
            total_sum += pR.buy_products("garlic", 5);
            Assert.AreEqual(0.42+0.6+7.5, total_sum);
        }


        //Method to Initialize ProductRepository with fresh list of products every time
        public List<Product> make_product_list()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("lettuce", 10.5, 50, "Leafy green"));
            products.Add(new Product("cabbage", 20, 100, "Cruciferous"));
            products.Add(new Product("pumpkin", 30, 30, "Marrow"));
            products.Add(new Product("cauliflower", 10, 25, "Cruciferous"));
            products.Add(new Product("zucchini", 20.5, 50, "Marrow"));
            products.Add(new Product("yam", 30, 50, "Root"));
            products.Add(new Product("spinach", 10, 100, "Leafy green"));
            products.Add(new Product("broccoli", 20, 75, "Cruciferous"));
            products.Add(new Product("garlic", 30, 20, "Leafy green"));
            products.Add(new Product("silverbeet", 10, 50, "Marrow"));
            return products;
        }
    }
}
