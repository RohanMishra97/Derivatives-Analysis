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
    /// Interaction logic for FutureBuy.xaml
    /// </summary>
    public partial class FutureBuy : Window
    {
        public FutureBuy(Futures x)
        {
            InitializeComponent();
            valueSecurityName.Text = x.Symbol;
            valueMktPrice.Text = x.Ltp.ToString();
            valueVwap.Text = x.Vwap.ToString();
            valueOi.Text = x.Oi.ToString();
            valueOiChange.Text = x.Oi_change.ToString();

            Dictionary<String, Int64> lot_dict = new Dictionary<string, long>();
            lot_dict.Add("YESBANK", 2200);
            lot_dict.Add("MARUTI", 75);
            lot_dict.Add("RELIANCE", 500);
            lot_dict.Add("AXISBANK", 1200);
            lot_dict.Add("BAJFINANCE", 250);
            lot_dict.Add("BPCL", 1800);
            lot_dict.Add("HDFC", 500);
            lot_dict.Add("HDFCBANK", 500);
            lot_dict.Add("ICICIBANK", 1375);
            lot_dict.Add("ITC", 2400);
            lot_dict.Add("LT", 375);
            lot_dict.Add("SBIN", 3000);
            lot_dict.Add("TATAMOTORS", 3000);
            lot_dict.Add("TATASTEEL", 1061);
            lot_dict.Add("TCS", 250);
            lot_dict.Add("TITAN", 750);
            lot_dict.Add("NIFTY", 75);
            lot_dict.Add("INFY", 1200);

            labelLotSize.Content = "x" + lot_dict[x.Symbol];
            valuePrice.Text = x.Ltp.ToString();
        }
        private void valueNoOfLots_TextChanged(object sender, TextChangedEventArgs e)
        {
            string numLots = valueNoOfLots.Text.ToString();
            string mktPrice = valuePrice.Text.ToString();
            String lotSize = labelLotSize.Content.ToString();
            lotSize = lotSize.Remove(0, 1);
            Console.WriteLine(lotSize);
            Int32 a = (numLots == "") ? 0 : Convert.ToInt32(numLots);
            Decimal b = (mktPrice == "") ? 0 : Convert.ToDecimal(mktPrice);
            Int32 c = (lotSize == "") ? 0 : Convert.ToInt32(lotSize);
            Decimal total = a * b * c;
            valueTotal.Text = total.ToString();
        }
    }
}
