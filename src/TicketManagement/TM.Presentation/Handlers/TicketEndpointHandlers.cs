using Microsoft.AspNetCore.Http;
using TM.Presentation.DTO;

namespace TM.Presentation.Handlers;

public static class TicketEndpointHandlers
{
    public static IResult HandleGetTicket(int id)
    {
        return Results.Ok($"Welcome to Code Daze! 😀, Ticket booked {id}");
    }
    public static IResult HandleBookTicket(Ticket request)
    {
        return Results.Ok(new { message = "Welcome to Code Daze! 😀, Ticket booking received", data=request });
    }
    public static IResult HandleUpdate(int id, Ticket request)
    {
        return Results.Ok(new { message = $"Welcome to Code Daze! 😀, Ticket booking updated {id}", data = request });
    }
    public static IResult HandleCancelticket(int id)
    {
        return Results.Ok($"Welcome to Code Daze! 😀, Ticket booking canceled {id}");
    }
}
