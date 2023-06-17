using System.Text.Json.Nodes;

namespace Otel.Demo.EventApi.Services.Interfaces
{
    public interface IEventService
    {
        Task<JsonArray?> GetEvents(string? assetId);
    }
}
