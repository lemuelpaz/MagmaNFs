using FluentValidation;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Magma3.NotaFiscal.Application.Mediator
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatRServiceConfiguration> c, Assembly assembly)
        {
            services.AddMediatR(c, assembly);
            return services;
        }

        public static void AddPipelineValidator(this IServiceCollection services, Assembly assembly)
        {
            var vs = AssemblyScanner.FindValidatorsInAssembly(assembly);

            foreach (var v in vs)
                services.AddScoped(v.InterfaceType, v.ValidatorType);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void AddPipelineValidator(this MediatRServiceConfiguration c, IServiceCollection services, Assembly assembly)
        {
            var vs = AssemblyScanner.FindValidatorsInAssembly(assembly);

            foreach (var v in vs)
                services.AddScoped(v.InterfaceType, v.ValidatorType);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}