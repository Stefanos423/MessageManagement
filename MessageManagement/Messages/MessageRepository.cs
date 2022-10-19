using MessageManagement.Models;

namespace MessageManagement.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly string _fileLocation;

        public MessageRepository(IConfiguration configuration)
        {
            var fileLocation = configuration.GetValue<string>("FileLocation");
            _fileLocation = string.IsNullOrEmpty(fileLocation) ? "./storage.txt" : fileLocation;
        }

        public Message AddMessage(string content)
        {
            var message = new Message(content)
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.ToUniversalTime()
            };

            using (var writer = File.AppendText(_fileLocation))
            {
                writer.WriteLine($"{message.Id}, {message.Date:dd/MM/yyyy HH:mm:ss}, {message.Content}");
            }

            return message;
        }
    }
}
