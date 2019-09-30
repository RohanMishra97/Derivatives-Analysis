using LiveCharts;
using LiveCharts.Wpf;
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
using System.Data.Sql;

namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for RowChart.xaml
    /// </summary>
    public partial class RowChart : UserControl
    {
        public SeriesCollection senderChart { get; set; }
        public double[] dataValues = null;
        public string[] dataLabels = null;
        public double maximum;
        public double minimum;


        public RowChart()
        {
            InitializeComponent();
            fillChart();
            updatMinMax();

            var doubleMapper = new LiveCharts.Configurations.CartesianMapper<double>()
            .X((value) => value)
            .Y((value, index) => index)
            .Fill((value, index) => (value > 0 ? Brushes.Green : Brushes.Red));

            LiveCharts.Charting.For<double>(doubleMapper, SeriesOrientation.Vertical);

            senderChart = new SeriesCollection();

            var rowSeries = new RowSeries() { Values = new ChartValues<double>(), DataLabels = true, Title = "P/L", MaxRowHeigth = 20 };
            var labels = this.dataLabels;

            foreach (var val in dataValues)
            {
                rowSeries.Values.Add(val);
            }

            this.senderChart.Add(rowSeries);

            chart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new LiveCharts.Wpf.Separator() { Step = 10 },
                Title = "P/L",
                MaxValue = maximum,
                MinValue = (-1) * maximum
            });

            Labels = dataLabels;
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public void fillChart()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                Console.WriteLine("Database for filling charts Connected.");

                DataTable dt = new DataTable();
                string query = "Select strategy_name,curr_pl from Strategy ";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                int i = 0;
                int num = dt.Rows.Count;
                dataValues = new double[num];
                dataLabels = new string[num];
                foreach (DataRow row in dt.Rows)
                {
                    String stName = row[0].ToString();
                    double pl = Convert.ToDouble(row[1]);
                    dataValues[i] = pl;
                    dataLabels[i] = stName;
                    i++;
                    Console.WriteLine("asdfasdf");
                } //end of foreach


            }//end of using
        }
        public void updatMinMax()
        {
            minimum = dataValues.Min();
            maximum = dataValues.Max();

            if (Math.Abs(minimum) > maximum)
            {
                maximum = Math.Abs(minimum);
            }
        }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
