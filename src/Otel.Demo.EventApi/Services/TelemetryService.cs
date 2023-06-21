using Otel.Demo.EventApi.Services.Interfaces;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.EventApi.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly ActivitySource _activitySource;
        public static Meter _meter = new(AppConstants.OTEL_SERVCICE_NAME);
        private readonly Counter<long> _getEventsOfAssetReqCounter;
        private readonly Counter<long> _getEventsOfAssetReqSuccessCounter;
        private readonly Counter<long> _getEventsOfAssetReqFailureCounter;

        public TelemetryService()
        {
            _activitySource = new ActivitySource(AppConstants.OTEL_SERVCICE_NAME);
            _getEventsOfAssetReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS);
            _getEventsOfAssetReqSuccessCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_SUCCESS);
            _getEventsOfAssetReqFailureCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_FAILURE);
        }

        public ActivitySource GetActivitySource()
        {
            return _activitySource;            
        }

        public Counter<long> GetEventsOfAssetReqCounter()
        {
            return _getEventsOfAssetReqCounter;
        }

        public Counter<long> GetEventsOfAssetReqSuccessCounter()
        {
            return _getEventsOfAssetReqSuccessCounter;
        }

        public Counter<long> GetEventsOfAssetReqFailureCounter()
        {
            return _getEventsOfAssetReqFailureCounter;
        }
    }
}
