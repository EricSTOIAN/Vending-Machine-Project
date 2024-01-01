using PIIIProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using PIIIProject.Models;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Product clickedProduct;

        // initialize vending machine with the product.txt file
        private static List<Product> vmProducts = Utilities.LoadProducts("../../Models/products.txt"); 
        private static VendingMachine vendingMachine = new VendingMachine(vmProducts);

        private Cart cart = new Cart();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_SnackClick(object sender, RoutedEventArgs e)
        {
            string itemName = (sender as Button).Name;

            string text = ((sender as Button).Content as StackPanel).Children[1].GetValue(TextBlock.TextProperty) as string;
            string price = text.Remove(text.Length - 1, 1);
            decimal itemPrice = Convert.ToDecimal(price);

            uint itemQuantity = 1;

            Product t = new Product(itemName, itemPrice, itemQuantity);

            clickedProduct = new Product(itemName, itemPrice, itemQuantity);
        }

        private void btn_AddToCartClick(object sender, RoutedEventArgs e)
        {
            if(clickedProduct != null)
            {
                Product item = new Product(clickedProduct.Name, clickedProduct.Price, clickedProduct.Quantity); 

                if (vendingMachine.GetProduct(clickedProduct.Name).Quantity > 0)
                {
                    MessageBox.Show("Item: " + item.ToString() + " was added to the cart.");
                    cart.AddItemToCart(item);
                    vendingMachine.RemoveProduct(item);
                }
                else
                {
                    MessageBox.Show("Sorry, no more " + clickedProduct.Name + "in the vending machine!");
                }
            }
            else
            {
                MessageBox.Show("Please select an item first before adding to cart.");
            }

        }

        private void btn_RemoveFromCartClick(object sender, RoutedEventArgs e)
        {
            if (clickedProduct != null)
            {
                Product item = new Product(clickedProduct.Name, clickedProduct.Price, clickedProduct.Quantity);

                MessageBox.Show(item.ToString());

                foreach(Product product in cart.ItemsInCart())
                {
                    if (product.Name.ToLower() == item.Name.ToLower() && product.Quantity > 0)
                    {
                        cart.RemoveItemFromCart(product);
                        vendingMachine.AddProduct(product);
                        break;
                    }
                }
            }
        }

        private void btn_ShowCurrentClick(object sender, RoutedEventArgs e)
        {
            CurrentTotalWindow currentTotal = new CurrentTotalWindow(cart);
            currentTotal.Show(); //shows the new currentTotal window
        }

        private void btn_DeleteOrderClick(object sender, RoutedEventArgs e)
        {
            // add to the vending machine
            vendingMachine.AddProducts(cart.ItemsInCart());

            // clear cart
            cart.ClearCart();
        }

        private void btn_PayClick(object sender, RoutedEventArgs e)
        {
            PayTotal finalTotal = new PayTotal(cart);
            finalTotal.Show();
        }
    }
}
