using PIIIProject.Models;
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
using System.Windows.Shapes;

namespace PIIIProject.Views
{
    /// <summary>
    /// Interaction logic for CurrentTotalWindow.xaml
    /// </summary>
    public partial class CurrentTotalWindow : Window
    {
        /// <summary>
        /// Loops through each product in the shopping cart, 
        /// skips items with a quantity of 0, and adds formatted 
        /// TextBlock elements to the UI element ProductList.
        /// </summary>
        public CurrentTotalWindow(Cart cart)
        {
            InitializeComponent();

            foreach(Product product in cart.ItemsInCart())
            {
                if(product.Quantity == 0)
                {
                    continue;
                }

                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 18;
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Text = $"{product.Quantity}, {product.Name}, {product.Price * product.Quantity}";

                ProductList.Children.Add(textBlock);
            }
        }
        
        /// <summary>
        /// Closes the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
