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
    /// Interaction logic for PayTotal.xaml
    /// </summary>
    public partial class PayTotal : Window
    {
        private decimal totalPrice = 0;
        private Cart cart;

        /// <summary>
        /// Loops over each product in the shopping cart and then, 
        /// if the quantity of the product is 0, it skips it. 
        /// Otherwise, it creates a "TextBlock" containing the 
        /// quantity, name and total price and adds it to the 
        /// UI element ProductList. 
        /// </summary>
        /// <param name="cart"></param>
        public PayTotal(Cart cart)
        {
            InitializeComponent();

            this.cart = cart;

            foreach(Product product in cart.ItemsInCart())
            {
                if (product.Quantity == 0)
                {
                    continue;
                }

                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 16;
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Text = $"{product.Quantity}, {product.Name}, {product.Price * product.Quantity}";

                ProductList.Children.Add(textBlock);
            }
        }
        /// <summary>
        /// Handles cash payments, processing user input through a dialog. 
        /// It displays the total cost, amount received, and change, 
        /// along with a breakdown of the change in various denominations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_CashClick(object sender, RoutedEventArgs e)
        {
            const int FIVE_DOLLAR = 5;
            const int TEN_DOLLAR = 10;
            const int TWENTY_DOLLAR = 20;
            const int FIFTY_DOLLAR = 50;
            const int HUNDRED_DOLLAR = 100;
            const int ONE_DOLLAR = 1;
            const int TWO_DOLLAR = 2;
            const int QUARTER = 25;
            const int DIME = 10;
            const int NICKEL = 5;

            decimal totalCost = cart.GetTotalCost();
            TotalCostCash.Text = totalCost.ToString();
            

            CashDialog cashDialog = new CashDialog();

            if(cashDialog.ShowDialog() == true)
            {
                CostInfoCash.Visibility = Visibility.Visible;
                CostInfoCard.Visibility = Visibility.Collapsed;

                uint fiveDollar = cashDialog.FiveDollarOption;
                uint tenDollar = cashDialog.TenDollarOption;
                uint twentyDollar = cashDialog.TwentyDollarOption;
                uint fiftyDollar = cashDialog.FiftyDollarOption;
                uint hundredDollar = cashDialog.HundredDollarOption;

                TotalCostCash.Text = totalCost.ToString();

                decimal amountReceived = (FIVE_DOLLAR * fiveDollar) + (TEN_DOLLAR * tenDollar) + (TWENTY_DOLLAR * twentyDollar) + (FIFTY_DOLLAR * fiftyDollar) + (HUNDRED_DOLLAR * hundredDollar);
                AmountReceived.Text = amountReceived.ToString();
                decimal totalChange = amountReceived - totalCost;
                CashChange.Text = totalChange.ToString();

                StringBuilder breakdown = new StringBuilder();


                // 100 
                int countChange = (int)(totalChange / HUNDRED_DOLLAR);
                decimal remainder = totalChange % HUNDRED_DOLLAR; ;

                if(countChange >= 1)
                {
                    remainder = totalChange % HUNDRED_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${HUNDRED_DOLLAR} bill(s)");
                }

                // 50
                countChange = (int)(remainder / FIFTY_DOLLAR);
                if (countChange >= 1)
                {
                    remainder = remainder % FIFTY_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${FIFTY_DOLLAR} bill(s)");
                }

                // 20
                countChange = (int)(remainder / TWENTY_DOLLAR);
                if(countChange >= 1)
                {
                    remainder = remainder % TWENTY_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${TWENTY_DOLLAR} bill(s)");
                }

                // 10
                countChange = (int)(remainder / TEN_DOLLAR);
                if(countChange >= 1)
                {
                    remainder = remainder % TEN_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${TEN_DOLLAR} bill(s)");
                }

                // 5
                countChange = (int)(remainder / FIVE_DOLLAR);
                if(countChange >= 1)
                {
                    remainder = remainder % FIVE_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${FIVE_DOLLAR} bill(s)");
                }

                // 2
                countChange = (int)(remainder / TWO_DOLLAR);
                if (countChange >= 1)
                {
                    remainder = remainder % TWO_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${TWO_DOLLAR} coin(s)");
                }

                // 1
                countChange = (int)(remainder / ONE_DOLLAR);
                if (countChange >= 1)
                {
                    remainder = remainder % ONE_DOLLAR;
                    breakdown.AppendLine($"{countChange} ${ONE_DOLLAR} coin(s)");
                }

                // 25 cents quarter

                countChange = (int) (remainder * 100) / QUARTER;
                if (countChange >= 1)
                {
                    remainder = (remainder * 100) % QUARTER;
                    breakdown.AppendLine($"{countChange} ${QUARTER} coin(s)");
                }

                // 10 cents dime
                countChange = (int)(remainder * 100) / DIME;
                if (countChange >= 1)
                {
                    remainder = (remainder * 100) % DIME;
                    breakdown.AppendLine($"{countChange} ${DIME} coin(s)");
                }

                // 5 cents nickel
                countChange = (int)(remainder * 100) / NICKEL;
                if (countChange >= 1)
                {
                    remainder = (remainder * 100) % NICKEL;
                    breakdown.AppendLine($"{countChange} ${NICKEL} coin(s)");
                }

                ChangeBreakdown.Text = breakdown.ToString();

            }
        }

        /// <summary>
        /// Handles card payments, displaying the total cost and relevant UI elements. 
        /// It checks if the total cost meets a minimum requirement of $5; otherwise, 
        /// it shows a message indicating the minimum amount.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_CardClick(object sender, RoutedEventArgs e)
        {
            const decimal MIN_COST = 5.00m;
            decimal totalCost = cart.GetTotalCost();

            if(totalCost >= MIN_COST)
            {
                TotalCostCard.Text = totalCost.ToString();
                CostInfoCard.Visibility = Visibility.Visible;
                CostInfoCash.Visibility = Visibility.Collapsed;

            }
            else
            {
                MessageBox.Show("Total cost must be at least $5.");
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
