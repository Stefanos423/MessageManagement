namespace MessageManagement.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public Message(string content)
        {
            Content = content;
        }
    }
}