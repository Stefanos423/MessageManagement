using FluentValidation;
using MessageManagement.Messages;
using MessageManagement.Validators;

namespace MessageManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<IMessageRepository, MessageRepository>();
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssemblyContaining<AddMessageRequestValidator>();
        }
    }
}
