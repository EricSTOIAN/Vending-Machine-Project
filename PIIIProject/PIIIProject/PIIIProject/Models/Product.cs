using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIIProject.Models
{
    public class Product
    {
        private string _name = string.Empty;
        private decimal _price = 0;
        private uint _quantity = 0;

        /// <summary>
        /// Initializes  a product with a name, price
        /// and quantity. Next, it sets the properties 
        /// of the product using the provided parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Product(string name, decimal price, uint quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public uint Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public override string ToString()
        {
            return $"{Name} - ${Price} - Quantity: {Quantity}";
        }
    }
}
