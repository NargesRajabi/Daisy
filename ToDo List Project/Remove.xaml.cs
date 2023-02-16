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

namespace toDoWpf
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Window
    {
        public Remove()
        {
            InitializeComponent();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Delete Schedule where ID=@ID";
                SqlCommand sqlCommand = new SqlCommand(Query, con);
                sqlCommand.Parameters.AddWithValue("@ID", int.Parse(Id.Text));
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("activity removed from schedule.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void viewData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Select * from Schedule";
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
