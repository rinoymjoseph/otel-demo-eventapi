using Otel.Demo.EventApi.Services.Interfaces;
using System.Text.Json.Nodes;

namespace Otel.Demo.EventApi.Services
{
    public class EventService : IEventService
    {
        private ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ITelemetryService _telemetryService;

        public EventService(ILogger<EventService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory,
           ITelemetryService telemetryService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _telemetryService = telemetryService;
        }

        public async Task<JsonArray?> GetEvents(string? assetId)
        {
            _logger.LogInformation($"Entering GetEvents : assetId -> {assetId}");
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetEvents");
            var dataApiUrl = _configuration.GetValue<string>(AppConstants.DATA_API_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{dataApiUrl}{AppConstants.REQUEST_GET_EVENTS}/{assetId}");
            var httpClient = _httpClientFactory.CreateClient();
            var httpResult = await httpClient.SendAsync(request);
            var response = await httpResult.Content.ReadAsStringAsync();
            httpResult.EnsureSuccessStatusCode();
            var eventData = JsonNode.Parse(response)?.AsArray();
            _logger.LogInformation($"Exiting GetEvents : assetId -> {assetId}");
            return eventData;
        }
    }
}
