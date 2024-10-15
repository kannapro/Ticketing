using Microsoft.AspNetCore.Builder;

namespace TM.Presentation;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        var enpointTypes = typeof(EndpointExtensions).Assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t.IsClass);

        foreach(var type in enpointTypes)
        {
            var endpoint = Activator.CreateInstance(type) as IEndpoint;
            endpoint?.MapEndpoints(app);
        }
    }
}
