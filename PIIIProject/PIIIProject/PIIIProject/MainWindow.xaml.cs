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

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product> _products = new List<Product>(); //created a list (this is the current total list of items)
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_SnackClick(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddToCartClick(object sender, RoutedEventArgs e)
        {

        }

        private void btn_RemoveFromCartClick(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ShowCurrentClick(object sender, RoutedEventArgs e)
        {
            CurrentTotalWindow currentTotal = new CurrentTotalWindow();
            currentTotal.Show(); //shows the new currentTotal window
        }

        private void btn_DeleteOrderClick(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PayClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
