using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using Otel.Demo.EventApi.Services.Interfaces;

namespace Otel.Demo.EventApi.Controllers
{
    [Route("event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private ILogger _logger;
        private readonly IEventService _eventService;
        private readonly ITelemetryService _telemetryService;

        public EventController(ILogger<EventController> logger, ITelemetryService telemetryService, IEventService eventService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
            _eventService = eventService;
        }

        [HttpGet("GetEventsOfAsset/{assetId}")]
        public async Task<IActionResult?> GetEventsOfAsset(string assetId = "4de1208e-d1b7-46a1-9743-8f2b39c3ad39")
        {
            _logger.LogInformation($"Entering GetEventsOfAsset : assetId -> {assetId}");
            _telemetryService.GetEventsOfAssetReqCounter().Add(1,
                new("Action", nameof(GetEventsOfAsset)),
                new("Controller", nameof(EventController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetEventsOfAsset = _telemetryService.GetActivitySource().StartActivity("GetEventsOfAsset");
            activity_GetEventsOfAsset?.SetTag("AssetId", assetId);
            activity_GetEventsOfAsset?.SetTag("ContextId", contextId);
            Baggage.SetBaggage("ContextId", contextId);

            try
            {
                _telemetryService.GetEventsOfAssetReqSuccessCounter().Add(1,
                    new("Action", nameof(GetEventsOfAsset)),
                    new("Controller", nameof(EventController)));
                var result = await _eventService.GetEvents(assetId);
                _logger.LogInformation($"Exiting GetEventsOfAsset : assetId -> {assetId}");
                return Ok(result);
            }
            catch (Exception)
            {
                _telemetryService.GetEventsOfAssetReqFailureCounter().Add(1,
                    new("Action", nameof(GetEventsOfAsset)),
                    new("Controller", nameof(EventController)));
                throw;
            }
        }
    }
}
