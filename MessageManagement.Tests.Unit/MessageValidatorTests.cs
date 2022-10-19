using MessageManagement.Models;
using MessageManagement.Validators;

namespace MessageManagement.Tests.Unit
{
    public class MessageValidatorTests
    {
        [Fact]
        public void MessageValidator_ShouldNotErrorWhenMessageIs255CharactersOrLess()
        {
            var validator = new AddMessageRequestValidator();
            var request = new AddMessageRequest()
            {
                Content = "test"
            };
            var result = validator.Validate(request);

            Assert.Empty(result.Errors);
        }

        [Fact]
        public void MessageValidator_ShouldErrorWhenMessageIsLonderThan255Characters()
        {
            var validator = new AddMessageRequestValidator();
            var content = new string('a', 256);
            var request = new AddMessageRequest()
            {
                Content = content
            };

            var result = validator.Validate(request);

            Assert.Single(result.Errors);
            Assert.Equal("The length of 'Content' must be 255 characters or fewer. You entered 256 characters.", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void MessageValidator_ShouldErrorWhenMessageIsEmtpty()
        {
            var validator = new AddMessageRequestValidator();

            var result = validator.Validate(new AddMessageRequest());

            Assert.Single(result.Errors);
            Assert.Equal("'Content' must not be empty.", result.Errors[0].ErrorMessage);
        }
    }
}
