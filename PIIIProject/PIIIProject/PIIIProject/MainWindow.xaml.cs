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

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> _products = new List<Product>(); //created a list (this is the current total list of items)
        private List<Product> _vendingMachine = Utilities.LoadProducts("filePath"); //input the ACTUAL filepath here, I haven't created it yet.
        private Product clickedProduct;
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

            clickedProduct = new Product(itemName, itemPrice, itemQuantity);
        }

        private void btn_AddToCartClick(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < _vendingMachine.Count; i++)
            {
                if(clickedProduct.Name == _vendingMachine[i].Name && _vendingMachine[i].Quantity > 0)
                {
                    _vendingMachine[i].Quantity--;
                    for (int j = 0; j < _products.Count; j++)
                    {
                        if (_products[j].Name == clickedProduct.Name) 
                        {
                            _products[j].Quantity++;
                            break;
                        }
                    }
                    _products.Append(clickedProduct);
                }
            }
        }

        private void btn_RemoveFromCartClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _vendingMachine.Count; i++)
            {
                for (int j = 0; j < _products.Count; j++)
                {
                    if (clickedProduct.Name == _vendingMachine[i].Name && _products[j].Name == clickedProduct.Name)
                    {
                        _vendingMachine[i].Quantity++;
                        if (_products[j].Quantity > 1)
                        {
                            _products[j].Quantity--;
                            break;
                        }
                        _products.Remove(clickedProduct);
                    }
                }
            }
        }

        private void btn_ShowCurrentClick(object sender, RoutedEventArgs e)
        {
            CurrentTotalWindow currentTotal = new CurrentTotalWindow(_products);
            currentTotal.Show(); //shows the new currentTotal window
        }

        private void btn_DeleteOrderClick(object sender, RoutedEventArgs e)
        {
            if (_products.Count > 0)
                _products.Clear();
        }

        private void btn_PayClick(object sender, RoutedEventArgs e)
        {
            PayTotal finalTotal = new PayTotal();
            finalTotal.Show();
        }
    }
}
