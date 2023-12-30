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
    /// Interaction logic for PayTotal.xaml
    /// </summary>
    public partial class PayTotal : Window
    {
        private decimal totalPrice = 0;
        public PayTotal(List<Product> products)
        {
            InitializeComponent();

            for (int i = 0; i < products.Count; i++)
            {
                totalPrice = totalPrice + products[i].Price;

                TextBlock myTextBlock = new TextBlock();
                myTextBlock.FontSize = 18;
                myTextBlock.FontWeight = FontWeights.Bold;
                myTextBlock.Text = products[i].Quantity + " " + products[i].Name + "... $" + products[i].Price;
            }

            //find out if user pays by cash or by card
        }

        private void rdb_CashClick(object sender, RoutedEventArgs e)
        {
            TextBlock cashAmount = new TextBlock();
            cashAmount.Text = "What type of bill will you pay with?";

            TextBox amount = new TextBox();
            amount.Name = "CashInput";
            amount.Width = 100;
            amount.Height = 20;
            //all of this is not tested, it might look disastrous.
        }

        private void rdb_CardClick(object sender, RoutedEventArgs e)
        {
            TextBlock totalTextBlock = new TextBlock();
            totalTextBlock.Text = "Total Cost: $" + totalPrice;

            TextBlock payedTextBlock = new TextBlock();
            payedTextBlock.Text = "Your amount has been payed! Enjoy your snacks!";
        }
    }
}
