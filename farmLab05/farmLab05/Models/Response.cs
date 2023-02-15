namespace farmLab05.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public Products products { get; set; }

        public List<Products> listPros { get; set; }
    }
}
