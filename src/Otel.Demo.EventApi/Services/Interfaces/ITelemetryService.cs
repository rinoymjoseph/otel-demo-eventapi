using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.EventApi.Services.Interfaces
{
    public interface ITelemetryService
    {
        ActivitySource GetActivitySource();

        Counter<long> GetEventsOfAssetReqCounter();

        Counter<long> GetEventsOfAssetReqSuccessCounter();

        Counter<long> GetEventsOfAssetReqFailureCounter();
    }
}
