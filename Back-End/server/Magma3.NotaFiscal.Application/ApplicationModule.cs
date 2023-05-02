using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Magma3.NotaFiscal.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblyMediatrProject = AppDomain.CurrentDomain.Load("Magma3.NotaFiscal.Application");

            services.AddMediatR(o => { o.AddPipelineValidator(services, assemblyMediatrProject); }, assemblyMediatrProject);

            // mediatr - pipeline behavior
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}