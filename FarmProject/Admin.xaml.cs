using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace FarmProject
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        SqlConnection con;
        public Admin()
        {
            InitializeComponent();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
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
                DataTable dataTable = new DataTable("farmTable");
                DA.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
              "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string query = "Insert into farmTable values(@ID, @Name, @Amount, @Price) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Amount", float.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@Price", float.Parse(price.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Perfectly to the database");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string query = "Update farmTable set Name=@Name, Amount=@Amount, Price=@Price Where ID=@ID ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Amount", float.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@Price", float.Parse(price.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Perfectly to the database");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Delete farmTable where ID=@ID";
                SqlCommand sqlCommand = new SqlCommand(Query, con);
                sqlCommand.Parameters.AddWithValue("@ID", int.Parse(id.Text));
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted properly");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void View_Data_Click(object sender, RoutedEventArgs e)
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
