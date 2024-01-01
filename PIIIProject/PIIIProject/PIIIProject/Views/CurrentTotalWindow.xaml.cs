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
                textBlock.Text = $"{product.Quantity}, {product.Name}, {product.Price}";

                ProductList.Children.Add(textBlock);
            }

        }
        

        private void btn_CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
