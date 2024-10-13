using Serilog;
using TM.Presentation;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddPresentation();

var app = builder.Build();
app.UsePresentation();
app.UseSerilogRequestLogging();
app.Run();
