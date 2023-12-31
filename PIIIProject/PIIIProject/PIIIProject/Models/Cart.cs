using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIIProject.Models
{
    public class Cart
    {
        private List<Product> cartItems;
        private VendingMachine vendingMachine;

        public Cart()
        {
            cartItems = new List<Product>();
        }


        public void AddItemToCart(Product product)
        {
            bool productExists = false;

            foreach (Product existingItem in cartItems)
            {
                if (existingItem.Name == product.Name)
                {
                    productExists = true;
                    existingItem.Quantity += product.Quantity;
                    break;
                }
            }

            if (!productExists)
            {
                cartItems.Add(product);
            }
        }

        public void RemoveItemFromCart(Product product)
        {
            bool productExists = false;

            foreach (Product existingItem in cartItems)
            {
                if (existingItem.Name == product.Name)
                {
                    if (existingItem.Quantity >= product.Quantity)
                    {
                        productExists = true;
                        existingItem.Quantity -= product.Quantity;

                        break;
                    }
                    else
                    {
                        throw new Exception("Product quantity is greater than list quantity.");
                    }
                }
            }

            if(!productExists)
            {
                throw new Exception("Item does not exist.");
            }

        }


        public List<Product> ItemsInCart()
        {
            return cartItems;
        }
    }
}
