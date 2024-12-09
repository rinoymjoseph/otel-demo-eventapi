# Otel Demo Event Api

## Overview

Otel Demo Event Api is a .NET 8.0 web API that provides event data for assets. It leverages OpenTelemetry for metrics, logging, and tracing, and integrates with Azure Container Registry for containerization.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [API Endpoints](#api-endpoints)
- [Configuration](#configuration)
- [Telemetry](#telemetry)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker
- Azure Container Registry (optional)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-repo/otel-demo-event-api.git
    cd otel-demo-event-api
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

4. Run the project:
    ```sh
    dotnet run --project src/Otel.Demo.EventApi/Otel.Demo.EventApi.csproj
    ```

## Usage

### API Endpoints

#### Get Events of Asset

- **URL:** `/event/GetEventsOfAsset/{assetId}`
- **Method:** `GET`
- **Description:** Retrieves events for a specified asset.
- **Parameters:**
  - `assetId` (string): The ID of the asset.
- **Response:**
  - `200 OK`: Returns a JSON array of events.
  - `400 Bad Request`: If the request is invalid.

## Configuration

Configuration settings are located in `appsettings.json` and `appsettings.Development.json`.

### Example `appsettings.json`

```json
{
  "Otel": {
    "ExporterUrl": "http://192.168.0.150:30031",
    "EnableMetrics": true,
    "EnableLogging": true,
    "EnableTracing": false
  },
  "DataApiUrl": "https://localhost:5024",
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft": "Warning",
      "System.Net.Http.HttpClient": "Warning",
      "Otel.Demo.EventApi": "Warning"
    }
  },
  "AllowedHosts": "*"
}