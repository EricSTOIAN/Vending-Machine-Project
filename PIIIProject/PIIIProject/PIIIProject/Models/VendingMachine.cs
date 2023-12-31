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

        public VendingMachine()
        {
            vmProducts = new List<Product>();
        }

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

        public void AddProducts(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                vmProducts.Add(product);
            }

        }

        public Product GetProduct(string name)
        {

            foreach (Product product in vmProducts)
            {
                if (product.Name.ToLower() == name.Trim().ToLower())
                {
                    return product;
                }
            }

            return null;
        }

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
