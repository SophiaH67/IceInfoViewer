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
        [JsonProperty(PropertyName = "speed")]
        public float Speed { get; set; }

    }
}
