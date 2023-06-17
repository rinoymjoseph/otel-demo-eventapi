using Otel.Demo.EventApi.Services.Interfaces;
using System.Text.Json.Nodes;

namespace Otel.Demo.EventApi.Services
{
    public class EventService : IEventService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ITelemetryService _telemetryService;

        public EventService(IConfiguration configuration, IHttpClientFactory httpClientFactory,
           ITelemetryService telemetryService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _telemetryService = telemetryService;
        }

        public async Task<JsonArray?> GetEvents(string? assetId)
        {
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetEvents");
            var assetDBApiUrl = _configuration.GetValue<string>(AppConstants.URL_DATA_API);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{assetDBApiUrl}{AppConstants.REQUEST_GET_EVENTS}/{assetId}");
            var httpClient = _httpClientFactory.CreateClient();
            var httpResult = await httpClient.SendAsync(request);
            var response = await httpResult.Content.ReadAsStringAsync();
            httpResult.EnsureSuccessStatusCode();
            var eventData = JsonNode.Parse(response)?.AsArray();
            return eventData;
        }
    }
}
