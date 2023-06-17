using Otel.Demo.EventApi.Services.Interfaces;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.EventApi.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly ActivitySource _activitySource;
        public static Meter _meter = new(AppConstants.OTEL_SERVCICE_NAME);
        private readonly Counter<long> _getEventsOfAssetCounter;

        public TelemetryService()
        {
            _activitySource = new ActivitySource(AppConstants.OTEL_SERVCICE_NAME);
            _getEventsOfAssetCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_EVENT_GET_EVENTS_OF_ASSET);
        }

        public ActivitySource GetActivitySource()
        {
            return _activitySource;            
        }

        public Counter<long> GetEventsOfAssetReqCounter()
        {
            return _getEventsOfAssetCounter;
        }
    }
}
