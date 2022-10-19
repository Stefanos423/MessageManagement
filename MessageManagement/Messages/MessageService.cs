using MessageManagement.Models;

namespace MessageManagement.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Message AddMessage(string content)
        {
            return _repository.AddMessage(content);
        }
    }
}
