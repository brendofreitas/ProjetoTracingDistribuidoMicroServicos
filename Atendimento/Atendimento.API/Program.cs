using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Atendimento.Infrastructure.DependencyInjection;
using Atendimento.Application.Services;
using Atendimento.Application.CasoDeUso.Cliente;
using Atendimento.Application.CasoDeUso.Pedido;
using Atendimento.Application.Interfaces;
using Atendimento.Infrastructure.External;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);


builder.Services.AddHttpClient<IDepositoService, DepositoApiClient>(client =>
{
    var apiEndpoint = builder.Configuration["Apideposito:Endpoint"];
    client.BaseAddress = new Uri(apiEndpoint);
});




builder.Services.AddOpenTelemetry()
    .WithTracing(tracer =>
    {
        var jaegerEndpoint = builder.Configuration["Jaeger:Endpoint"];
        tracer
             .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService("Atendimento")
                .AddAttributes(new Dictionary<string, object>
                {
                    { "service.name", "Atendimento" },
                    { "service.version", "1.0.0" }
                }))
            .SetSampler(new TraceIdRatioBasedSampler(0.2))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddNpgsql()
            .AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(jaegerEndpoint);
                options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
            });
    });

builder.Services.AddSession();
builder.Services.AddScoped<ObterTodosClientesUseCase>();
builder.Services.AddScoped<CriarClienteUseCase>();
builder.Services.AddScoped<ObterClienteComPedidosEInteracoesUseCase>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ObterClientePorEmailUseCase>();
builder.Services.AddScoped<CriarPedidoUseCase>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Atendimento}/{action=Index}/{id?}");


app.Run();
