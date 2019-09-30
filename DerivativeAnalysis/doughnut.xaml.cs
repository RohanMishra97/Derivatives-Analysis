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
using LiveCharts;
using LiveCharts.Defaults;
using System.Data.SqlClient;
using System.Data.Sql;
using LiveCharts.Wpf;
using System.Data;

namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for doughnut.xaml
    /// </summary>
    public partial class doughnut : UserControl
    {
        
        public doughnut()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection();
            fillChart();
            
            //{
            //    new PieSeries
            //    {
            //        Title = "Chrome",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(8989.99) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Mozilla",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(7878.8) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Opera",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(18) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Explorer",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
            //        DataLabels = true
            //    }
            //};

            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public void fillChart()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                Console.WriteLine("Database for filling charts Connected.");

                DataTable dt = new DataTable();
                string query = "Select strategy_name,capital_reqd from Strategy ";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                int i = 0;
                int num = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    
                    SeriesCollection.Add(new PieSeries
                    {
                        Title = row[0].ToString(),
                        Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(row[1])) },
                        DataLabels = true
                    });
                    Console.WriteLine("insdie doughnut");
                } //end of foreach


            }//end of using
        }

        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach (var series in SeriesCollection)
            {
                foreach (var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(0, 10);
                }
            }
        }

        private void AddSeriesOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            var c = SeriesCollection.Count > 0 ? SeriesCollection[0].Values.Count : 5;

            var vals = new ChartValues<ObservableValue>();

            for (var i = 0; i < c; i++)
            {
                vals.Add(new ObservableValue(r.Next(0, 10)));
            }

            SeriesCollection.Add(new PieSeries
            {
                Values = vals
            });
        }

        private void RemoveSeriesOnClick(object sender, RoutedEventArgs e)
        {
            if (SeriesCollection.Count > 0)
                SeriesCollection.RemoveAt(0);
        }

        private void AddValueOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            foreach (var series in SeriesCollection)
            {
                series.Values.Add(new ObservableValue(r.Next(0, 10)));
            }
        }

        private void RemoveValueOnClick(object sender, RoutedEventArgs e)
        {
            foreach (var series in SeriesCollection)
            {
                if (series.Values.Count > 0)
                    series.Values.RemoveAt(0);
            }
        }

        private void RestartOnClick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true, true);
        }
    }
}
