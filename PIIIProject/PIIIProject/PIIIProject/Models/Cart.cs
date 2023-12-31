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

        public Cart()
        {
            cartItems = new List<Product>();
        }

        public void AddItemToCart(Product product)
        {

        }

        public void RemoveItemFromCart(Product product)
        {

        }

        public List<Product> ItemsInCart()
        {
            return cartItems;
        }
    }
}
