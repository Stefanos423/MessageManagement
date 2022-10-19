using MessageManagement.Messages;
using MessageManagement.Models;
using MessageManagement.Tests.Unit.Mocks;
using MessageManagement.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageManagement.Tests.Unit
{
    public class MessageControllerTests
    {
        [Fact]
        public void MessageController_ShouldReturn201CreatedWhenValidationSucceeds()
        {
            var logger = new Logger<MessageController>(new LoggerFactory());
            var messageServiceMock = new MessageServiceMock();
            var validator = new AddMessageRequestValidator();
            var messageController = new MessageController(logger, messageServiceMock, validator);
            var request = new AddMessageRequest()
            {
                Content = "test"
            };

            var response = messageController.AddMessage(request);

            var createdResult = Assert.IsType<CreatedResult>(response);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            var message = createdResult.Value as Message;
            Assert.Equal("test", message?.Content);
        }

        [Fact]
        public void MessageController_ShouldReturn400BadRequestWhenValidationFails()
        {
            var logger = new Logger<MessageController>(new LoggerFactory());
            var messageServiceMock = new MessageServiceMock();
            var validator = new AddMessageRequestValidator();
            var messageController = new MessageController(logger, messageServiceMock, validator);

            var response = messageController.AddMessage(new AddMessageRequest());

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            var errors = Assert.IsAssignableFrom<IEnumerable<string>>(badRequestResult.Value);
            Assert.Single(errors);
            Assert.Equal("'Content' must not be empty.", errors.ToList()[0]);
        }
    }
}
