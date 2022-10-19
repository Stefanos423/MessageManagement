using MessageManagement.Messages;
using MessageManagement.Models;

namespace MessageManagement.Tests.Unit.Mocks
{
    public class MessageRepositoryMock : IMessageRepository
    {
        public Message AddMessage(string content)
        {
            return new Message(content)
            {
                Id = new Guid(),
                Date = new DateTime()
            };
        }
    }
}
