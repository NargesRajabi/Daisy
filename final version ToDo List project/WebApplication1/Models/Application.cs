using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace toDoApi.Models
{
    public class Application
    {
        public Response GetAllTasks(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Schedule", con);
            DataTable dt = new DataTable();
            List<Task> listtks = new List<Task>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Task task = new Task
                    {
                        Id = (int)dt.Rows[i]["Id"],
                        Activity = (string)dt.Rows[i]["Activity"],
                        DateTime = (string)dt.Rows[i]["DateTime"]
                    };


                    listtks.Add(task);
                }
            }
            if (listtks.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listTasks = listtks;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listTasks = null;
            }
            return response;
        }

        public Response GetTaskByID(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Schedule Where ID = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Task task = new Task();
                task.Id = (int)dt.Rows[0]["Id"];
                task.Activity = (string)dt.Rows[0]["Activity"];
                task.DateTime = (string)dt.Rows[0]["DateTime"];
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.task = task;


            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listTasks = null;
            }
            return response;
        }

        public Response AddTask(SqlConnection con, Task task)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into Schedule(Id, Activity, DateTime) " +
                "Values('" + task.Id + "','" + task.Activity + "', '" + task.DateTime +"') ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Added";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public Response UpdateTask(SqlConnection con, Task task)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Schedule set Activity='" + task.Activity + "', DateTime='" + task.DateTime + "' Where Id='" + task.Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Updated";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public Response DeleteTask(SqlConnection con, int Id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from Schedule Where ID = '" + Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "ID does not Exist!";
            }

            return response;
        }
      
    }
}
