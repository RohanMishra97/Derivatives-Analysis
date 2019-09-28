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
using System.Data.SqlClient;
using System.Data;

namespace DerivativeAnalysis
{
    /// <summary>
    /// Interaction logic for OptionFutures.xaml
    /// </summary>
    public partial class OptionFutures : Window
    {
        DataSet vDs;
        SqlDataAdapter vAdap;
        public OptionFutures()
        {
            InitializeComponent();
            getData();
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (dataGridOptions.DataContext as DataTable).
                DefaultView.RowFilter = string.Format("cCandidateCode like '{0}%'", textBox.Text);
        }
        void getData()
        {
            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Recruitment";
                connection.Open();
                Console.WriteLine("connected to the database");

                string sql2 = "Select * from Externalcandidate";
                vDs = new DataSet();
                vAdap = new SqlDataAdapter(sql2, connection);
                vAdap.Fill(vDs);

                this.dataGridOptions.DataContext = vDs.Tables[0];
                this.dataGridOptions.ItemsSource = vDs.Tables[0].DefaultView;  //this fills data in options datagrid

                string sql3 = "Select cCandidateCode,vFirstName,vLastName from Externalcandidate";
                vDs = new DataSet();
                vAdap = new SqlDataAdapter(sql2, connection);
                vAdap.Fill(vDs);

                this.dataGridFutures.DataContext = vDs.Tables[0];
                this.dataGridFutures.ItemsSource = vDs.Tables[0].DefaultView;


                connection.Close();

            }
        }



        private void dataGridOptions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row = gd.SelectedItem as DataRowView;
            if (row != null)
            {
                Trade optionPop = new Trade();
                optionPop.Show();

            }
        }
        private void dataGridFuturess_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row = gd.SelectedItem as DataRowView;
            if (row != null)
            {
                Trade optionPop = new Trade(); //change is needed here to pop futures window
                optionPop.Show();

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGridFutures.Visibility = Visibility.Collapsed;
            menuForFutures.Visibility = Visibility.Collapsed;
            dataGridOptions.Visibility = Visibility.Visible;
            menuForOptions.Visibility = Visibility.Visible;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            dataGridOptions.Visibility = Visibility.Collapsed;
            menuForOptions.Visibility = Visibility.Collapsed;
            dataGridFutures.Visibility = Visibility.Visible;
            menuForFutures.Visibility = Visibility.Visible;
        }
    }
}
