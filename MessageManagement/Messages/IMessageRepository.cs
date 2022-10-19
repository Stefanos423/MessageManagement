using MessageManagement.Models;

namespace MessageManagement.Messages
{
    public interface IMessageRepository
    {
        public Message AddMessage(string content);
    }
}
