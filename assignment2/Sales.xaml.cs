using farmLab05.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Windows.Markup;

namespace Admin
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        HttpClient client = new HttpClient();
        public Sales()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7227/api/ProductsContoller/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.updateProducts();
        }
        private async void updateProducts()
        {
            Products products = new Products();
            
            products.Name = Name.Text;
            float amount = float.Parse(amnt.Text);
            products.Amount -= amount;
           

            HttpResponseMessage response = await client.PutAsJsonAsync<Products>("UpdateProducts/", products);

            ServerStatus.Content = response.StatusCode;
            sale.Content = amount * products.Price;


        }

        private void View_Data_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
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
