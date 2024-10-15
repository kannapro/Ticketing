using Microsoft.AspNetCore.Builder;
using TM.Presentation.Handlers;

namespace TM.Presentation.Endpoints;

public class TicketEndpoint : IEndpoint
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapPost("/book-ticket", TicketEndpointHandlers.HandleBookTicket);
        app.MapGet("/get-ticket/{id:int}", TicketEndpointHandlers.HandleGetTicket);
        app.MapPut("/update-ticket/{id:int}", TicketEndpointHandlers.HandleUpdate);
        app.MapDelete("/cancel-ticket/{id:int}", TicketEndpointHandlers.HandleCancelticket);
    }
}
