using MessageManagement.Messages;
using MessageManagement.Tests.Unit.Mocks;

namespace MessageManagement.Tests.Unit
{
    public class MessageServiceTests
    {
        [Fact]
        public void MessageServiceShouldCallRepositoryFunction()
        {
            var repositoryMock = new MessageRepositoryMock();
            var service = new MessageService(repositoryMock);

            var result = service.AddMessage("test");

            Assert.Equal("test", result.Content);
        }
    }
}