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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public partial class MainWindow : Window
    {
        DataSet vDs;
        SqlDataAdapter vAdap;
        List<Strategy> Strategies = null;
        public MainWindow()
        {
            InitializeComponent();
            getData();
            Strategies = FillStrategy();
            strategyTree.ItemsSource = Strategies;
        }

        public List<Strategy> FillStrategy()
        {
            List<Strategy> res = new List<Strategy>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                Console.WriteLine("Database Connected.");

                DataTable dt = new DataTable();
                string query = "Select * from Strategy";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    int stId = Convert.ToInt32(row[0]);
                    Console.WriteLine(row[1]);
                    Console.WriteLine(row[9]);
                    Console.WriteLine(row[10]);

                    Strategy strategy1 = new Strategy(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]),
                        row[3].ToString(), Convert.ToDecimal(row[4]), Convert.ToDecimal(row[5]), Convert.ToDecimal(row[6]),
                      row[7].ToString(), row[8].ToString(), Convert.ToDecimal(row[9]), Convert.ToDecimal(row[10]), 0);



                    string queryOpt = "Select * from OptionTrade where strategy_id = " + $"{stId}";
                    SqlCommand cmdOpt = new SqlCommand(queryOpt, connection);
                    SqlDataAdapter sdaOpt = new SqlDataAdapter(cmdOpt);
                    DataTable dtOpt = new DataTable();
                    sdaOpt.Fill(dtOpt);
                    foreach (DataRow rowOpt in dtOpt.Rows)
                    {
                        strategy1.Option_Trades.Add(new OptionTrade
                        {
                            Opt_trade_id = Convert.ToInt32(rowOpt[7]),
                            Option_id = rowOpt[0].ToString(),
                            Buying_date = rowOpt[1].ToString(),
                            Num_lots = Convert.ToInt32(rowOpt[2]),
                            Premium = Convert.ToDecimal(rowOpt[3]),
                            Strategy_id = Convert.ToInt32(rowOpt[4]),
                            Symbol = rowOpt[5].ToString(),
                            Trade_type = rowOpt[6].ToString()
                        });
                    }

                    string queryFut = "Select * from FutureTrade where strategy_id = " + $"{stId}";
                    SqlCommand cmdfut = new SqlCommand(queryFut, connection);
                    SqlDataAdapter sdafut = new SqlDataAdapter(cmdfut);
                    DataTable dtFut = new DataTable();
                    sdafut.Fill(dtFut);
                    foreach (DataRow rowFut in dtFut.Rows)
                    {
                        strategy1.Future_Trades.Add(new FutureTrade
                        {
                            Fut_trade_id = Convert.ToInt32(rowFut[8]),
                            Future_id = rowFut[0].ToString(),
                            Buying_date = rowFut[1].ToString(),
                            Num_lots = Convert.ToInt32(rowFut[2]),
                            Margin_avail = Convert.ToInt64(rowFut[3]),
                            Strategy_id = Convert.ToInt32(rowFut[4]),
                            Symbol = rowFut[5].ToString(),
                            Trade_type = rowFut[6].ToString(),
                            Exercise_price = Convert.ToDecimal(rowFut[7])
                        });
                    }


                    res.Add(strategy1);
                } //end of foreach
                return res;
            }
        }

        private void addStrategyBtn_Click(object sender, RoutedEventArgs e)
        {
            //add strategy to the database here
            String strategy_name = newStrategy.Text;
            Decimal x = new Decimal(0.00);
            string y = "";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                Console.WriteLine("Database Connected.");

                string query = $"insert into Strategy(strategy_name, user_id, symbol, max_profit, max_loss, capital_reqd,expiry_date, bep, roi, curr_pl, position) values('{strategy_name}', 1,'{y}'," + x.ToString() + "," + x.ToString() + "," + x.ToString() + ", '30/09/2019', " + x.ToString() + ", " + x.ToString() + ", " + x.ToString() +  ",0)";
                Console.WriteLine(query);

                SqlCommand cmd = new SqlCommand(query, connection);
                int res = cmd.ExecuteNonQuery();
                if (res < 0)
                {
                    Console.WriteLine("cant insert");
                }
                else
                {
                    Console.WriteLine("inserted succefully");

                }
                //Strategies = null;
                //Strategies = FillStrategy();
                strategyTree.ItemsSource = FillStrategy();
            }
        }
        private void analyse_Click(object sender, RoutedEventArgs e)
        {
            int a = strategyTree.Items.IndexOf(strategyTree.SelectedItem);
            Strategy st = Strategies[a];
            string name = st.Strategy_Name;
            analyze obj = new analyze(st);
            obj.Show();
           
           // MessageBox.Show(name);
        }

        public DataSet from_sql(string TableName, String[] Columns, String[] Filters, Boolean orderBy = true) {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                Console.WriteLine("Database Connected.");

                //Query Formation
                StringBuilder sb = new StringBuilder("SELECT ");
                if (Columns.GetLength(0) == 0)
                {
                    sb.Append("* FROM ");
                    sb.Append(TableName);
                }
                else {
                    foreach(String colName in Columns)
                    {
                        sb.Append(colName);
                        sb.Append(",");
                    }
                    sb.Remove(sb.Length-1,1);
                    sb.Append(" FROM ");
                    sb.Append(TableName);
                }
                if (Filters.GetLength(0) > 0)
                {
                    sb.Append(" WHERE ");
                    if (Filters.GetLength(0) > 1)
                    {
                        foreach (String filter in Filters)
                        {
                            sb.Append(filter);
                            sb.Append(" AND ");
                        }
                        sb.Remove(sb.Length - 6, 6);
                    }
                    else {
                        sb.Append(Filters[0]);
                    }
                }
                if (orderBy) {
                    sb.Append(" ORDER BY 'volume' DESC ");
                }
                String query = sb.ToString();
                Console.WriteLine(query);

                vDs = new DataSet();
                vAdap = new SqlDataAdapter(query, connection);
                vAdap.Fill(vDs);
                connection.Close();
                return vDs;
            }
        }
        void getData()
        {
            String[] cols = { };
            String[] fils = { };
            vDs = from_sql("Options", cols, fils);
            this.dataGridOptions.DataContext = vDs.Tables[0];
            this.dataGridOptions.ItemsSource = vDs.Tables[0].DefaultView;  //this fills data in options datagrid
            dataGridOptions.Columns[1].Visibility = Visibility.Collapsed;
            dataGridOptions.Columns[5].Visibility = Visibility.Collapsed;
            dataGridOptions.Columns[6].Visibility = Visibility.Collapsed;
            dataGridOptions.Columns[7].Visibility = Visibility.Collapsed;
            dataGridOptions.Columns[9].Visibility = Visibility.Collapsed;
            dataGridOptions.Columns[11].Visibility = Visibility.Collapsed;

            //String[] cols = { };
            //String[] fils = { };
            vDs = from_sql("Futures", cols, fils);
            this.dataGridFutures.DataContext = vDs.Tables[0];
            this.dataGridFutures.ItemsSource = vDs.Tables[0].DefaultView;  //this fills data in options datagrid
            dataGridFutures.Columns[1].Visibility = Visibility.Collapsed;
            dataGridFutures.Columns[5].Visibility = Visibility.Collapsed;
            dataGridFutures.Columns[6].Visibility = Visibility.Collapsed;
            dataGridFutures.Columns[7].Visibility = Visibility.Collapsed;

            vDs = from_sql("Company", cols, fils, false);
            this.liveTicker.DataContext = vDs.Tables[0];
            this.liveTicker.ItemsSource = vDs.Tables[0].DefaultView;

        }
        private void dataGridOptions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row = gd.SelectedItem as DataRowView;
            if (row != null)
            {
                //int x = 10;
                String opt_id = row[0].ToString();
                String symbol = row[1].ToString();
                string expiry_date = row[2].ToString();
                Decimal ltp = Convert.ToDecimal(row[3]);
                Int64 oi = Convert.ToInt64(row[4]);
                Int64 oichange = Convert.ToInt64(row[5]);
                Int64 volume = Convert.ToInt64(row[6]);
                String optype = row[7].ToString();
                Decimal pchange = Convert.ToDecimal(row[8]);
                Decimal strikeprice = Convert.ToDecimal(row[9]);
                Decimal iv = Convert.ToDecimal(row[10]);
                Options o = new DerivativeAnalysis.Options(opt_id, symbol, expiry_date, ltp, oi, oichange, volume, optype, pchange, strikeprice, iv);
                OptionBuy optionPop = new OptionBuy(o);
                optionPop.ShowDialog();
                Strategies = FillStrategy();
                strategyTree.ItemsSource = Strategies;
            }
        }
        private void dataGridFuturess_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row = gd.SelectedItem as DataRowView;
            if (row != null)
            {
                Futures f = new DerivativeAnalysis.Futures(row[0].ToString(), row[1].ToString(), row[2].ToString(), Convert.ToDecimal(row[3]), Convert.ToInt64(row[4]), Convert.ToInt64(row[5]), Convert.ToInt64(row[6]), Convert.ToDecimal(row[7]));
                FutureBuy futurePop = new FutureBuy(f);
                futurePop.ShowDialog();
                //Console.WriteLine("Future Buy is closed");
                //this.Strategies = null;
                Strategies = FillStrategy();
                strategyTree.ItemsSource = Strategies;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OptionFutures obj = new OptionFutures();
            obj.Show();
            this.Hide();
        }


        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            OptionButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF43444F"));
            FutureButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            DashboardButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            dataGridFutures.Visibility = Visibility.Collapsed;
            menuForFutures.Visibility = Visibility.Collapsed;

            DashboardMenu.Visibility = Visibility.Collapsed;
            nonMenu.Visibility = Visibility.Visible;
            dataGridOptions.Visibility = Visibility.Visible;
            menuForOptions.Visibility = Visibility.Visible;
        }

        private void FutureButton_Click(object sender, RoutedEventArgs e)
        {
            FutureButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF43444F"));
            OptionButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            DashboardButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            dataGridOptions.Visibility = Visibility.Collapsed;
            menuForOptions.Visibility = Visibility.Collapsed;

            DashboardMenu.Visibility = Visibility.Collapsed;
            nonMenu.Visibility = Visibility.Visible;

            dataGridFutures.Visibility = Visibility.Visible;
            menuForFutures.Visibility = Visibility.Visible;
        }

        private void searchOption_TextChanged(object sender, TextChangedEventArgs e)
        {
            (dataGridOptions.DataContext as DataTable).
                DefaultView.RowFilter = string.Format("symbol like '{0}%'", searchOption.Text);

            ///code for filters



        }
        private void searchFuture_TextChanged(object sender, TextChangedEventArgs e)
        {
            (dataGridFutures.DataContext as DataTable).
                DefaultView.RowFilter = string.Format("symbol like '{0}%'", searchFuture.Text);
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF43444F"));
            FutureButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            OptionButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF343540"));
            nonMenu.Visibility = Visibility.Collapsed;
            DashboardMenu.Visibility = Visibility.Visible;
            
        }
    }
}
