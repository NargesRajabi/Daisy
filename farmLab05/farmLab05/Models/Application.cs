using System.Data.SqlClient;
using System.Data;

namespace farmLab05.Models
{
    public class Application
    {
        public Response GetAllProducts(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from farmTable", con);
            DataTable dt = new DataTable();
            List<Products> listPrducts = new List<Products>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products products = new Products();
                    products.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                    products.Name = dt.Rows[i]["Name"].ToString();
                    products.Amount = float.Parse(dt.Rows[i]["Amount"].ToString());
                    products.Price = float.Parse(dt.Rows[i]["Price"].ToString());

                    listPrducts.Add(products);
                }
            }
            if (listPrducts.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listPros = listPrducts;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listPros = null;
            }
            return response;
        }

        public Response GetAllProductsByID(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from farmTable Where ID = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Products products = new Products();
                products.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                products.Name = dt.Rows[0]["Name"].ToString();
                products.Amount = float.Parse(dt.Rows[0]["Amount"].ToString());
                products.Price = float.Parse(dt.Rows[0]["Price"].ToString());
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.products = products;


            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listPros = null;
            }
            return response;
        }

        public Response AddProducts(SqlConnection con, Products products)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into farmTable(ID, Name, Amount, Price) Values( '" + products.Id + "','" + products.Name + "', '" + products.Amount + "', '" + products.Price + "') ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Added";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public Response UpdateProducts(SqlConnection con, Products products)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update farmTable set Name='" + products.Name + "', Amount='" + products.Amount + "', Price='" + products.Price + "' Where Id='" + products.Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Updated";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public Response DeleteProducts(SqlConnection con, int Id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from farmTable Where Id='" + Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Product Deleted";
            }

            return response;
        }
    }
}
