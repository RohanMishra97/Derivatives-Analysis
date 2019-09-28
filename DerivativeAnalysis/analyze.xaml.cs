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
        DataSet vDs;
        SqlDataAdapter vAdap;
        public analyze()
        {
            InitializeComponent();
            getData();
        }
        void getData()
        {
            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString =
                    @"Data Source= NKS\SQLEXPRESS;Integrated Security=SSPI;" + "Initial Catalog=Recruitment";
                connection.Open();
                Console.WriteLine("connected to the database");

                string sql2 = "Select vFirstName,vLastName,cPhone,dDateOfApplication from Externalcandidate";
                vDs = new DataSet();
                vAdap = new SqlDataAdapter(sql2, connection);
                vAdap.Fill(vDs);

                this.dataGrid.DataContext = vDs.Tables[0];
                this.dataGrid.ItemsSource = vDs.Tables[0].DefaultView;

                string sql3 = "Select vFirstName,vLastName,cPhone, dDateOfApplication from Externalcandidate";
                vDs = new DataSet();
                vAdap = new SqlDataAdapter(sql3, connection);
                vAdap.Fill(vDs);

                this.dataGrid1.DataContext = vDs.Tables[0];
                this.dataGrid1.ItemsSource = vDs.Tables[0].DefaultView;
                connection.Close();

            }
        }
    }

}
