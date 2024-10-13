using Microsoft.AspNetCore.Builder;

namespace TM.Presentation;

public interface IEndpoint
{
    void MapEndpoints(WebApplication app);
}
