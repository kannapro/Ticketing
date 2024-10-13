using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using TM.Presentation;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddPresentation();
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource=> resource.AddService("TM.Service"))
    .WithTracing(tracing =>
    {
        tracing
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddOtlpExporter(opt =>
            {
                opt.Endpoint = new Uri("http://localhost:9090/ingest/otlp/v1/traces");
                opt.Protocol = OtlpExportProtocol.HttpProtobuf;
            });

        
    });
var app = builder.Build();
app.UsePresentation();
app.UseSerilogRequestLogging();
app.Run();
