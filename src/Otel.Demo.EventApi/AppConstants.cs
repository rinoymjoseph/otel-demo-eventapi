﻿namespace Otel.Demo.EventApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "EventApi";

        public const string URL_OTEL_EXPORTER = "otel_exporter_url";
        public const string URL_ASSETDB_API = "assetdb_api_url";

        public const string REQUEST_GET_EVENTS = "/assetdb/GetEvents";

        public const string COUNTER_EVENT_GET_EVENTS_OF_ASSET = "event_api_get_events_of_asset_requests";
    }
}