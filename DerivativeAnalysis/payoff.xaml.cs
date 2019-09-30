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
using LiveCharts.Wpf;
using System.IO;
namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for payoff.xaml
    /// </summary>
    public partial class payoff : UserControl
    {
        static readonly string textFilex = @"C:\Users\Nk\Desktop\DerivativeAnalysis\DerivativeAnalysis\1_x.txt";
        static readonly string textFiley = @"C:\Users\Nk\Desktop\DerivativeAnalysis\DerivativeAnalysis\1_y.txt";

        public payoff()
        {
            InitializeComponent();
            LineSeries ls = new LineSeries() { DataLabels = true, Values = new ChartValues<ObservablePoint>(), LineSmoothness = 0, StrokeThickness = 1, PointGeometry = null, LabelPoint = point => "" };

            //double[] xvals = { 1.24, 4.42, 6.31, 9.57, 11.84, 13.21 };
            //double[] yvals = { 10.18, 4.29, 8.97, 7.33, 9.41, 9.41 };
            Double[] xvals = parseTextFile(textFilex);
            Double[] yvals = parseTextFile(textFiley);
            //Double[] xvals = { 411.23, 478.88, 546.54, 614.19, 681.84, 749.49, 817.15, 884.8, 952.45, 1020.11, 1087.76, 1155.41, 1223.07, 1290.72, 1358.37, 1426.02, 1493.68, 1561.33, 1628.98, 1696.64, 1764.29, 1831.94, 1899.6, 1967.25, 2034.9, 2102.55, 2170.21, 2237.86, 2305.51, 2373.17, 2440.82, 2508.47, 2576.13, 2643.78, 2711.43, 2779.08, 2846.74, 2914.39, 2982.04, 3049.7, 3117.35, 3185.0, 3252.66, 3320.31, 3387.96, 3455.61, 3523.27, 3590.92, 3658.57, 3726.23, 3793.88, 3861.53, 3929.19, 3996.84, 4064.49, 4132.14, 4199.8, 4267.45, 4335.1, 4402.76, 4470.41, 4538.06, 4605.72, 4673.37, 4741.02, 4808.67, 4876.33, 4943.98, 5011.63, 5079.29, 5146.94, 5214.59, 5282.25, 5349.9, 5417.55, 5485.2, 5552.86, 5620.51, 5688.16, 5755.82, 5823.47, 5891.12, 5958.78, 6026.43, 6094.08, 6161.73, 6229.39, 6297.04, 6364.69, 6432.35, 6500.0, 6567.65, 6635.31, 6702.96, 6770.61, 6838.26, 6905.92, 6973.57, 7041.22, 7108.88, 7176.53, 7244.18, 7311.84, 7379.49, 7447.14, 7514.79, 7582.45, 7650.1, 7717.75, 7785.41, 7853.06, 7920.71, 7988.37, 8056.02, 8123.67, 8191.32, 8258.98, 8326.63, 8394.28, 8461.94, 8529.59, 8597.24, 8664.9, 8732.55, 8800.2, 8867.85, 8935.51, 9003.16, 9070.81, 9138.47, 9206.12, 9273.77, 9341.43, 9409.08, 9476.73, 9544.38, 9612.04, 9679.69, 9747.34, 9815.0, 9882.65, 9950.3, 10017.96, 10085.61, 10153.26, 10220.91, 10288.57, 10356.22, 10423.87, 10491.53, 10559.18, 10626.83, 10694.49, 10762.14, 10829.79, 10897.44, 10965.1, 11032.75, 11100.4, 11168.06, 11235.71, 11303.36, 11371.02, 11438.67, 11506.32, 11573.97, 11641.63, 11709.28, 11776.93, 11844.59, 11912.24, 11979.89, 12047.55, 12115.2, 12182.85, 12250.5, 12318.16, 12385.81, 12453.46, 12521.12, 12588.77, 12656.42, 12724.08, 12791.73 };
            //Double[] yvals = { -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -426.6, -358.95, -291.29, -223.64, -155.99, -88.33, -20.68, 46.97, 114.62, 182.28, 249.93, 317.58, 385.24, 452.89, 520.54, 588.2, 655.85, 723.5, 791.15, 858.81, 926.46, 994.11, 1061.77, 1129.42, 1197.07, 1264.73, 1332.38, 1400.03, 1467.68, 1535.34, 1602.99, 1670.64, 1738.3, 1805.95, 1873.6, 1941.26, 2008.91, 2076.56, 2144.21, 2211.87, 2279.52, 2347.17, 2414.83, 2482.48, 2550.13, 2617.79, 2685.44, 2753.09, 2820.74, 2888.4, 2956.05, 3023.7, 3091.36, 3159.01, 3226.66, 3294.32, 3361.97, 3429.62, 3497.27, 3564.93, 3632.58, 3700.23, 3767.89, 3835.54, 3903.19, 3970.85, 4038.5, 4106.15, 4173.8, 4241.46, 4309.11, 4376.76, 4444.42, 4512.07, 4579.72, 4647.38, 4715.03, 4782.68, 4850.33, 4917.99, 4985.64, 5053.29, 5120.95, 5188.6, 5256.25, 5323.91, 5391.56, 5459.21, 5526.86, 5594.52, 5662.17, 5729.82, 5797.48, 5865.13 };
            Double max = yvals.Max();
            Double min = yvals.Min();
            Double range;
            if (max > (-min))
            {
                range = max;
            }
            else range = -min;
            for (int i = 0; i < xvals.Length; i++)
            {
                ls.Values.Add(new ObservablePoint
                {
                    X = xvals[i],
                    Y = yvals[i]
                });
            }
            cartesianChart1.Series.Add(ls);
            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new LiveCharts.Wpf.Separator() { Step = 2500, Stroke = Brushes.Gray },
                Title = "Spot Price"
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new LiveCharts.Wpf.Separator() { Step = 1000, Stroke = Brushes.Gray },
                Title = "P/L",
                MaxValue = range,
                MinValue = -range
            });
        }

        Double[] parseTextFile(String textfile) {
            Int32 length = 0;
            String[] values = new String[1000];
            
            using (StreamReader reader = new StreamReader(textfile))
            {
                String line = null;
                while (null != (line = reader.ReadLine()))
                {
                    values = line.Split(',');
                    length = values.Length;

                }
            }
            Double[] points = new Double[length];
            for (Int32 i = 0; i < length; i++)
            {

                points[i] = double.Parse(values[i]);
                //Console.WriteLine(points[i]);
            }
            return points;
        }

    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//namespace filepoints
//{
//    class Program
//    {
//        static readonly string textFile = @"C:\Users\Nk\Desktop\DerivativeAnalysis\DerivativeAnalysis\1_x.txt";
//        static void Main(string[] args)
//        {
//            int length = 0;
//            string[] values = new string[1000];
//            //double[] points = new double[100];
//            using (StreamReader reader = new StreamReader(textFile))
//            {
//                string line = null;
//                while (null != (line = reader.ReadLine()))
//                {
//                    values = line.Split(',');
//                    length = values.Length;

//                }

//                double[] points = new double[length];
//                for (int i = 0; i < length - 1; i++)
//                {

//                    points[i] = double.Parse(values[i]);
//                    Console.WriteLine(points[i]);
//                }
//            }
//            Console.ReadKey();
//        }
//    }
//}
