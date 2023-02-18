using farmLab05.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

namespace Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7227/api/ProductsContoller/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            this.saveProducts();
        }
        private async void saveProducts()
        {
            Products products = new Products();
            products.Id = int.Parse(IDT.Text);
            products.Name = NameT.Text;
            products.Amount =float.Parse(AmountT.Text);
            products.Price = float.Parse(PriceT.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync<Products>("AddProducts/", products);

            ServerStatus.Content = response.StatusCode;



        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            this.updateProducts();
        }

        private async void updateProducts()
        {
            Products products = new Products();
            products.Id = int.Parse(IDT.Text);
            products.Name = NameT.Text;
            products.Amount = float.Parse(AmountT.Text);
            products.Price = float.Parse(PriceT.Text);

            HttpResponseMessage response = await client.PutAsJsonAsync <Products>("UpdateProducts/", products);

            ServerStatus.Content = response.StatusCode;



        }



        private void viewData_Click(object sender, RoutedEventArgs e)
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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.deleteProducts();
        }

        private async void deleteProducts()
        {
            Products products = new Products();
            products.Id = int.Parse(IDT.Text);

            HttpResponseMessage response = await client.DeleteAsync("DeleteProducts/{id}");

            ServerStatus.Content = response.StatusCode;



        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            this.getAllProducts();
        }

        private async void getAllProducts()
        {
            Products products = new Products();
           // products.Id = int.Parse(IDT.Text);

            HttpResponseMessage response = await client.GetAsync("GetAllProductsByID/");

            ServerStatus.Content = response.StatusCode;



        }

        private void sales_Checked(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
        }
    }
}
