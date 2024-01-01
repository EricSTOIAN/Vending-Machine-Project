using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                if (existingItem.Name.ToLower() == product.Name.ToLower())
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
            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].Name.ToLower() == product.Name.ToLower())
                {
                    cartItems.RemoveAt(i);
                    break;
                }
            }
        }

        public void ClearCart()
        {
            cartItems.Clear();
        }

        public List<Product> ItemsInCart()
        {
            return cartItems;
        }
    }
}
