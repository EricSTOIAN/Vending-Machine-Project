using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIIProject.Models
{
    public class VendingMachine
    {
        private List<Product> vmProducts;

        /// <summary>
        /// Default constructor (intializes the vmProducts list
        /// to a new list.)
        /// </summary>
        public VendingMachine()
        {
            vmProducts = new List<Product>();
        }

        /// <summary>
        /// Intializes the Vending Machine with a list of Product called 
        /// productList, if it is not null. If it is null, it creates 
        /// an empty list. 
        /// </summary>
        /// <param name="productList"></param>
        public VendingMachine(List<Product> productList)
        {
            if (productList != null)
            {
                vmProducts = productList;
            }
            else
            {
                vmProducts = new List<Product>();
            }
        }

        /// <summary>
        /// Loops through the vmProducts list and checks to see if 
        /// the product exists in the list. If it does, it adds 
        /// the quantity of the product to the list. If it does not 
        /// exist, the product gets added to the cartItems list. 
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            bool productExists = false;

            foreach (Product existingProduct in vmProducts)
            {
                if (existingProduct.Name.ToLower() == product.Name.Trim().ToLower())
                {
                    productExists = true;
                    existingProduct.Quantity += product.Quantity;
                    break;
                }
            }

            if (!productExists)
            {
                vmProducts.Add(product);
            }
        }

        /// <summary>
        /// Loops through the products list and vmProducts list and 
        /// checks to see if the product exists in the vmProducts 
        /// list. If it exists, it adds the quantity of the product 
        /// to the quantity of the vmProducts. 
        /// </summary>
        /// <param name="products"></param>
        public void AddProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                foreach (Product existingProduct in vmProducts)
                {
                    if (product.Name.ToLower() == existingProduct.Name.ToLower())
                    {
                        existingProduct.Quantity += product.Quantity;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Loops over the vmProducts list and checks to see if the 
        /// product exists in the vmProducts list. If it does, it returns 
        /// the product. If not, it returns null. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns the product if it exists</returns>
        public Product GetProduct(string name)
        {

            foreach (Product product in vmProducts)
            {
                if (product.Name.ToLower() == name.ToLower())
                {
                    return product;
                }
            }

            return null;
        }

        /// <summary>
        /// Loops over the vmProducts list and checks to see
        /// if the product exists or not. If it exists, it 
        /// then checks if the quantity of the product in 
        /// the list is greater than the quanity of product. 
        /// If it is, it removes the quanity of the product 
        /// from the list. If not, it throws an error. 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveProduct(Product product)
        {
            bool productExists = false;

            foreach (Product existingProduct in vmProducts)
            {
                if (existingProduct.Name.ToLower() == product.Name.ToLower())
                {
                    productExists = true;

                    if (existingProduct.Quantity > product.Quantity)
                    {
                        existingProduct.Quantity -= product.Quantity;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Value can't be more than the quantity in the vending machine.");
                    }
                }
            }
        }
    }
}
