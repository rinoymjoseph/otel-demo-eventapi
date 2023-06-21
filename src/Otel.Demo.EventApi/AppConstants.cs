namespace Otel.Demo.EventApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "EventApi";
        public const string OTEL_EXPORTER_URL = "Otel:ExporterUrl";
        public const string OTEL_ENABLE_LOGGING = "Otel:EnableLogging";
        public const string OTEL_ENABLE_TRACING = "Otel:EnableTracing";
        public const string OTEL_ENABLE_METRICS = "Otel:EnableMetrics";

        public const string DATA_API_URL = "DataApiUrl";

        public const string REQUEST_GET_EVENTS = "/eventdata/GetEvents";

        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS = "event_api_get_events_of_asset_requests";
        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_SUCCESS = "event_api_get_events_of_asset_requests_success";
        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_FAILURE = "event_api_get_events_of_asset_requests_failure";
    }
}
