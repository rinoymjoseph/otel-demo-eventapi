namespace Otel.Demo.EventApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "EventApi";

        public const string URL_OTEL_EXPORTER = "otel_exporter_url";
        public const string URL_DATA_API = "data_api_url";

        public const string REQUEST_GET_EVENTS = "/eventdata/GetEvents";

        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS = "event_api_get_events_of_asset_requests";
        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_SUCCESS = "event_api_get_events_of_asset_requests_success";
        public const string COUNTER_EVENT_API_GET_EVENTS_OF_ASSET_REQUESTS_FAILURE = "event_api_get_events_of_asset_requests_failure";
    }
}
