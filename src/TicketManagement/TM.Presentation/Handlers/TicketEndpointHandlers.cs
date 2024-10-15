using Microsoft.AspNetCore.Http;
using TM.Domain.Entities;
using TM.Domain.Interfaces;

namespace TM.Presentation.Handlers;

public static class TicketEndpointHandlers
{
    public static async Task<IResult> HandleGetTicket(string id,IUnitOfWork _work, CancellationToken cancellationToken=default)
    {
        var ticket=await _work.tickets.GetAsync(id, cancellationToken);
        return Results.Ok(ticket);
    }
    public static async Task<IResult> HandleBookTicket(Ticket request, IUnitOfWork _work, CancellationToken cancellationToken = default)
    {
        var ticket = await _work.tickets.AddAsync(request, cancellationToken);
        return Results.Ok(ticket);
    }
    public static async Task<IResult> HandleUpdate(string id, Ticket request, IUnitOfWork _work, CancellationToken cancellationToken = default)
    {
        var ticket = await _work.tickets.UpdateAsync(id, request, cancellationToken);
        return Results.Ok(ticket);
    }
    public static async Task<IResult> HandleCancelticket(string id, IUnitOfWork _work, CancellationToken cancellationToken = default)
    {
        await _work.tickets.DeleteAsync(id, cancellationToken);
        return Results.Ok();
    }
}
