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
using System.Data.SqlClient;
using System.Data;
namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for FutureBuy.xaml
    /// </summary>
    public partial class FutureBuy : Window
    {
        String future_id;
        Int32 strat_id;
        String trade = "long";
        Futures o = null;
        public FutureBuy(Futures x)
        {
            o = x;
            InitializeComponent();
            fillCombo();
            future_id = x.Future_id.ToString();
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
        private void fillCombo()
        {
            String connectionString = @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from strategy where symbol = '"+o.Symbol+"'", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox.ItemsSource = dt.DefaultView;
            comboBox.DisplayMemberPath = "strategy_name";
            comboBox.SelectedValuePath = "strategy_id";
            cmd.Dispose();
            con.Close();
        }

        public void call_analyze_script(int strategy_id)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            String p2s = " script.py";
            startInfo.Arguments = "/C python " + p2s + " " + strategy_id.ToString();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(10000);
        }
        private void insert()
        {
            String connectionString = @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
            SqlConnection con = new SqlConnection(connectionString);
            int res = 0;
            String mktPrice = valuePrice.Text.ToString();
            Decimal b = (valuePrice.Text.ToString() == "") ? 0 : Convert.ToDecimal(valuePrice.Text.ToString());
            con.Open();
            String q = "INSERT INTO FutureTrade (future_id,buying_date,num_lots,margin_avail,strategy_id,symbol,trade_type, exercise_price) values(";
            q = q + "'" + future_id + "', " + "'" + DateTime.Now.ToString("M/d/yyyy") + "'," + valueNoOfLots.Text.ToString() + "," + (b * Convert.ToDecimal(0.1)).ToString() + "," + strat_id.ToString() + ", " + "'" + valueSecurityName.Text.ToString() + "'," + "'" + trade + "'" + "," + valuePrice.Text.ToString() + ")";
            //Console.WriteLine(q);
            SqlCommand cmd = new SqlCommand(q, con);
            res = cmd.ExecuteNonQuery();
            if (res < 0)
            {
                Console.WriteLine("Could Not Insert Trade");
            }
            cmd.Dispose();
            con.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            strat_id = Int32.Parse(comboBox.SelectedValue.ToString());
            insert();
            call_analyze_script(strat_id);
            this.Close();
        }
        private void set_sell(object sender, RoutedEventArgs e)
        {
            trade = "short";
        }
    }
}

