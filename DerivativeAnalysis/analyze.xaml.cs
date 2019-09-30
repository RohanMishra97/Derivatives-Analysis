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
    /// Interaction logic for analyze.xaml
    /// </summary>
    public partial class analyze : Window
    {
        Strategy st = null;
        List<Strategy> Strategies = null;
        public analyze(Strategy s)
        {
            st = s;
            InitializeComponent();
            valueMaxProfit.Text = s.Max_Profit.ToString();
            valueMaxLoss.Text = s.Max_Loss.ToString();
            valueCapReqd.Text = s.Capt_Reqd.ToString();
            valueBEP.Text = s.Bep.ToString();
            valueCurrPL.Text = s.Currrent_Pl.ToString();
            valueROI.Text = s.Roi.ToString();
            Strategies = new List<Strategy>();
            Strategies.Add(s);
            strategyTree.ItemsSource = Strategies;
        }

        private void AddPositionbutton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Derivative Analysis";
                connection.Open();
                String query = "UPDATE Strategy SET position = 1 WHERE strategy_id = " + st.Strategy_Id.ToString();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.Close();
                connection.Close();
                cmd.Dispose();
            }
        }
    }

}
