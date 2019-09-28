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
        public MainWindow()
        {
            InitializeComponent();
            getData();
            List<Strategy> Strategie = new List<Strategy>();

            //Strategy strategy1 = new Strategy() {  = "SBI GAINERS", Dt = Convert.ToDateTime("08/15/2019") };
            //strategy1.Members.Add(new StrategyMember() { Name = "John Doe", Age = 42 });
            //strategy1.Members.Add(new StrategyMember() { Name = "Jane Doe", Age = 39 });
            //strategy1.Members.Add(new StrategyMember() { Name = "Sammy Doe", Age = 13 });
            //Strategie.Add(strategy1);

            //Strategy strategy2 = new Strategy() { Name = "TCS GAINERS", Dt = Convert.ToDateTime("08/15/2019") };
            //strategy2.Members.Add(new StrategyMember() { Name = "Mark Moe", Age = 31 });
            //strategy2.Members.Add(new StrategyMember() { Name = "Norma Moe", Age = 28 });
            //Strategie.Add(strategy2);

            strategyTree.ItemsSource = Strategie;
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
                optionPop.Show();
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
                futurePop.Show();

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
            dataGridFutures.Visibility = Visibility.Collapsed;
            menuForFutures.Visibility = Visibility.Collapsed;

            DashboardMenu.Visibility = Visibility.Collapsed;
            nonMenu.Visibility = Visibility.Visible;
            dataGridOptions.Visibility = Visibility.Visible;
            menuForOptions.Visibility = Visibility.Visible;
        }

        private void FutureButton_Click(object sender, RoutedEventArgs e)
        {
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
            nonMenu.Visibility = Visibility.Collapsed;
            DashboardMenu.Visibility = Visibility.Visible;
            
        }
    }
}
