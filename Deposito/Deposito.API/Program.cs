using Deposito.Application.CasosDeUso.Produto;
using Deposito.Application.Contracts;
using Deposito.Infrastructure.DependencyInjection;
using Deposito.Infrastructure.ExternalServices.Deposito;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);


builder.Services.AddHttpClient<IDepositoService, DepositoApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});

builder.Services.AddOpenTelemetry()
    .WithTracing(tracer =>
    {
        var jaegerEndpoint = builder.Configuration["Jaeger:Endpoint"];
        tracer
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Deposito.API"))
            .AddAspNetCoreInstrumentation()          
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(jaegerEndpoint);
                options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
            });
            
    });


builder.Services.AddScoped<ConsultarProdutoUseCase>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
