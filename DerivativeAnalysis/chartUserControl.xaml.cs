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
using LiveCharts.Wpf;
namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for chartUserControl.xaml
    /// </summary>
    public partial class chartUserControl : UserControl
    {
        public chartUserControl()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                //new LineSeries
                //{
                //    Title = "Series 1",
                //    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                //},
                new LineSeries
                {
                    Title = "mera graph",
                    Values = new ChartValues<double> { -100.0, -100.0, -100.0, -100.0, -100.0,0.0,100.0,300.0 },
                    PointGeometry = DefaultGeometries.Circle
                }
                //new LineSeries
                //{
                //    Title = "Series 3",
                //    Values = new ChartValues<double> { 4,2,7,2,7 },
                //    PointGeometry = DefaultGeometries.Square,
                //    PointGeometrySize = 15
                //}
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            xvalues = new[] { 20.0, 21.0, 22.0, 23.0, 24.0, 25.0,26.0,30.0 };
            YFormatter = value => value.ToString();

            //modifying the series collection will animate and update the chart
            //SeriesCollection.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }
         public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public double[] xvalues { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public Func<double, string> XFormatter { get; set; }
    }
}
