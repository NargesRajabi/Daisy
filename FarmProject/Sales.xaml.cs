using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace FarmProject
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SqlConnection con;
        public Sales()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double totalSales = 0;
                string connectionString =
                    "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Select Price From farmTable where Name=@Name";
                SqlCommand cmd = new SqlCommand(Query, con);
                
                cmd.Parameters.AddWithValue("@Name", Name.Text);
                cmd.Parameters.AddWithValue("@Amount", float.Parse(Amount.Text));
               
                double Pamount = double.Parse(Amount.Text);
                double productPrice = (double)cmd.ExecuteScalar();
                totalSales += Math.Round( Pamount * productPrice, 2);
                totalSale.Text = Convert.ToString( totalSales);

                

                SqlCommand updateInventoryCommand = new SqlCommand("UPDATE farmTable SET Amount=@Amount-"+ Pamount+"  Where Name =@Name "  , con);
                
                updateInventoryCommand.ExecuteNonQuery();

                con.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

      

        private void View_Data_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Select * from farmTable";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGrid.ItemsSource = DT.AsDataView();
                DataContext = DA;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
