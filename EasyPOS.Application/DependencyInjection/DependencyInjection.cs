using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EasyPOS.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicattion(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
            return services;
        }
    }
}
