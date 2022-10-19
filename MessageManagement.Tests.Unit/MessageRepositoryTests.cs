using MessageManagement.Messages;
using Microsoft.Extensions.Configuration;

namespace MessageManagement.Tests.Unit
{
    public class MessageRepositoryTests
    {
        private readonly IConfiguration _configurationMock;

        public MessageRepositoryTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"FileLocation", "./mock-storage.txt"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _configurationMock = configuration;
        }

        [Fact]
        public void MessageRepository_ShouldSaveDataOnFile()
        {
            File.WriteAllText(_configurationMock.GetValue<string>("FileLocation"), string.Empty);
            var messageRepository = new MessageRepository(_configurationMock);

            messageRepository.AddMessage("test");

            var fileContents = File.ReadAllText(_configurationMock.GetValue<string>("FileLocation"));
            var stringParts = fileContents.Split(", ");
            Assert.Equal(36, stringParts[0].Length);
            Assert.Equal("test", stringParts[2].Replace(Environment.NewLine, ""));
            // An assertion for near identical times needs to be added here.
            // xUnit does not support this out of the box.
            // A library like Fluent Assertions is recommended.
        }
    }
}
