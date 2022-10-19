using FluentValidation;
using MessageManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagement.Messages
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _service;
        private readonly IValidator<AddMessageRequest> _validator;

        public MessageController(ILogger<MessageController> logger, IMessageService service, IValidator<AddMessageRequest> validator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpPost(Name = "AddMessage")]
        public IActionResult AddMessage([FromBody] AddMessageRequest request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                _logger.LogError("Validation for adding message unsuccessful. {errors}", errors);
                return BadRequest(errors);
            }
            _logger.LogInformation("Validation for adding message successful.");
            var message = _service.AddMessage(request.Content);
            _logger.LogInformation("Message successfully added.");
            _logger.LogDebug("Message Id: {id}", message.Id);
            return Created("", message);
        }
    }
}