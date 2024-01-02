using PIIIProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PIIIProject
{
    public class Utilities
    {
        /// <summary>
        /// Reads a file containing product data (name, price, quantity) 
        /// and returns a list of Product objects. If the file or data 
        /// format is invalid, it returns null.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Returns a list of products</returns>
        public static List<Product> LoadProducts(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            List<Product> products = new List<Product>();

            string[] fileContents = File.ReadAllLines(filePath);


            foreach (string line in fileContents)
            {
                string[] values = line.Split(',');

                if (values.Length != 3)
                    continue;

                string name = values[0];
                decimal price = decimal.Parse(values[1]);
                uint quantity = uint.Parse(values[2]);

                Product product = new Product(name, price, quantity);

                products.Add(product);
            }
            return products;
        }
    }
}
