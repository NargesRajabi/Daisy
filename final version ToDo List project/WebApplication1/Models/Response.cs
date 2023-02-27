namespace toDoApi.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public Task task { get; set; }

        public List<Task> listTasks { get; set;}

      
    }
}
