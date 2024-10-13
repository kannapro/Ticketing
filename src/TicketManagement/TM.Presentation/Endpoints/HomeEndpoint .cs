using Microsoft.AspNetCore.Builder;
using TM.Presentation.Handlers;

namespace TM.Presentation.Endpoints;

public class HomeEndpoint : IEndpoint
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/", HomeEndpointHandlers.HandleHome);
    }
}
