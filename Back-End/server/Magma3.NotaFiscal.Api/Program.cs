using Magma3.NotaFiscal.Api.Configurations;
using Magma3.NotaFiscal.Application;
using Magma3.NotaFiscal.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfiguration();
app.UseSwaggerConfig();
app.Run();