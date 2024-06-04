using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IceInfoViewer.Utils
{
/*    {
    "connection": true,
    "serviceLevel": "AVAILABLE_SERVICE",
    "gpsStatus": "VALID",
    "internet": "HIGH",
    "latitude": 50.140208,
    "longitude": 8.326833,
    "tileY": 15,
    "tileX": -91,
    "series": "406",
    "serverTime": 1717501812835,
    "speed": 244.0,
    "trainType": "ICE",
    "tzn": "ICE4602",
    "wagonClass": "SECOND",
    "connectivity": {
        "currentState": "NO_INFO",
        "nextState": null,
        "remainingTimeSeconds": null
    },
    "bapInstalled": true
} */

    internal class IceInfo
    {
        [JsonProperty(PropertyName = "connection")]
        public bool Connection { get; set; }

        [JsonProperty(PropertyName = "serviceLevel")]
        public string ServiceLevel { get; set; }

        [JsonProperty(PropertyName = "gpsStatus")]
        public string GpsStatus { get; set; }

        [JsonProperty(PropertyName = "internet")]
        public string Internet { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "tileY")]
        public int TileY { get; set; }

        [JsonProperty(PropertyName = "tileX")]
        public int TileX { get; set; }

        [JsonProperty(PropertyName = "series")]
        public string Series { get; set; }

        [JsonProperty(PropertyName = "serverTime")]
        public long ServerTime { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "trainType")]
        public string TrainType { get; set; }

        [JsonProperty(PropertyName = "tzn")]
        public string Tzn { get; set; }

        [JsonProperty(PropertyName = "wagonClass")]
        public string WagonClass { get; set; }

        [JsonProperty(PropertyName = "connectivity")]
        public IceConnectivity Connectivity { get; set; }

        [JsonProperty(PropertyName = "bapInstalled")]
        public bool BapInstalled { get; set; }

        public class IceConnectivity
        {
            [JsonProperty(PropertyName = "currentState")]
            public string CurrentState { get; set; }

            [JsonProperty(PropertyName = "nextState")]
            public string NextState { get; set; }

            [JsonProperty(PropertyName = "remainingTimeSeconds")]
            public int? RemainingTimeSeconds { get; set; }
        }

    }
}
