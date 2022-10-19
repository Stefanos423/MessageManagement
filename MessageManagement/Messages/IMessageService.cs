using MessageManagement.Models;

namespace MessageManagement.Messages
{
    public interface IMessageService
    {
        public Message AddMessage(string content);
    }
}
