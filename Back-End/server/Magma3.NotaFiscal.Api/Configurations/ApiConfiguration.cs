using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json.Serialization;

namespace Magma3.NotaFiscal.Api.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfig(this IServiceCollection services)
        {
            services
                .AddMvcCore(o =>
                {
                    o.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })                
                .AddCors(options =>
                {
                    options.AddPolicy("All",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                })
                .AddFormatterMappings();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseCors("All");
            app.UseHttpsRedirection();
            app.UseRouting();    
            app.MapControllers();
        }
    }
}