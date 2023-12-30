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
        public CurrentTotalWindow(List<Product> products)
        {
            InitializeComponent();

            for(int i = 0; i < products.Count; i++)
            {
                TextBlock myTextBlock = new TextBlock();
                myTextBlock.FontSize = 18;
                myTextBlock.FontWeight = FontWeights.Bold;
                myTextBlock.Text = products[i].Quantity + " " + products[i].Name + "... $" + products[i].Price;
            }
        }

        private void btn_CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
