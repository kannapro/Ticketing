using Microsoft.AspNetCore.Http;

namespace TM.Presentation.Handlers;

public static class HomeEndpointHandlers
{
    public static IResult HandleHome()
    {
        return Results.Ok("Welcome to Code Daze! 😀");
    }
}
