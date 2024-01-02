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
    /// Interaction logic for CashDialog.xaml
    /// </summary>
    public partial class CashDialog : Window
    {
        public uint FiveDollarOption { get; private set; }
        public uint TenDollarOption { get; private set; }
        public uint TwentyDollarOption { get; private set; }
        public uint FiftyDollarOption { get; private set; }
        public uint HundredDollarOption { get; private set; }

        public CashDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles user input for various dollar denominations by parsing 
        /// the input as unsigned integers and assigning the values to 
        /// respective properties. If parsing is successful, it sets 
        /// DialogResult to true and closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if(uint.TryParse(FiveDollar.Text, out uint fiveDollarCount))
            {
                FiveDollarOption = fiveDollarCount;
            }

            if(uint.TryParse(TenDollar.Text, out uint tenDollarCount))
            {
                TenDollarOption = tenDollarCount;
            }

            if(uint.TryParse(TwentyDollar.Text, out uint twentyDollarCount))
            {
                TwentyDollarOption = twentyDollarCount;
            }

            if(uint.TryParse(FiftyDollar.Text, out uint fiftyDollarCount))
            {
                FiftyDollarOption = fiftyDollarCount;
            }

            if(uint.TryParse(HundredDollar.Text, out uint hundredDollarCount))
            {
                HundredDollarOption = hundredDollarCount;
            }

            DialogResult = true;
            Close();
        }
    }
}
