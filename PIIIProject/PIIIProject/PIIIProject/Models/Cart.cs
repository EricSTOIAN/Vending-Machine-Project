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

        /// <summary>
        /// Default constructor (intializes the cartItems 
        /// list to a new list.)
        /// </summary>
        public Cart()
        {
            cartItems = new List<Product>();
        }

        /// <summary>
        /// Loops over the cartItems list and checks if the item exists in the list. 
        /// If it exists, it adds the quantity of the item to the cart. If it does not 
        /// exist, the product gets added to the cartItems list. 
        /// </summary>
        /// <param name="product"></param>
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

        /// <summary>
        /// Loops over the cartItems list and checks if the item exists in the list. 
        /// If it exists, it removes the product when a match is found, 
        /// breaking out of the loop afterward.
        /// </summary>
        /// <param name="product"></param>
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

        /// <summary>
        /// Clears the cart when the "Clear" option is selected.
        /// </summary>
        public void ClearCart()
        {
            cartItems.Clear();
        }

        /// <summary>
        /// Shows the items in the cart.
        /// </summary>
        /// <returns>Returns the cartItems list</returns>
        public List<Product> ItemsInCart()
        {
            return cartItems;
        }

        /// <summary>
        /// Calculates the total cost
        /// </summary>
        /// <returns>Returns the total cost after calculation. </returns>
        public decimal GetTotalCost()
        {
            decimal totalCost = 0;

            foreach (Product product in cartItems)
            {
                totalCost = totalCost + product.Price * product.Quantity;
            }
            return totalCost;
        }
    }
}
