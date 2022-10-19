namespace MessageManagement.Models
{
    public class AddMessageRequest
    {
        public string Content { get; set; }

        public AddMessageRequest()
        {
            Content = "";
        }
    }
}
