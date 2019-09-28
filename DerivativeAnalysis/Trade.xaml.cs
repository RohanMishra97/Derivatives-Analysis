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


namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for Trade.xaml
    /// </summary>
    public partial class Trade : Window
    {
        public Trade()
        {
            InitializeComponent();
        }
        private void valueNoOfLots_TextChanged(object sender, TextChangedEventArgs e)
        {

            int a = 0;
            string str = valueNoOfLots.Text;
            if (str == "")
            {
                a = 0;
            }
            else
            {
                a = Convert.ToInt32(str);

            }
            double total = a * 100 * (Convert.ToDouble(valuePrice.Text));
            valueTotal.Text = total.ToString();
        }
    }
}
