using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IceInfoViewer.Utils
{
    internal class IceInfoHelper
    {
        public static async Task<IceInfo> GetIceInfoAsync()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://iceportal.de"),
                DefaultRequestHeaders =
                {
                    { "Accept", "application/json" },
                    { "User-Agent", "IceInfoViewer" }
                }
            };

            //IceInfo response = await client.GetFromJsonAsync<IceInfo>("/api1/rs/status") ?? throw new Exception("Failed to fetch ice info");
            string response = await client.GetStringAsync("api1/rs/status") ?? throw new Exception("Failed to contact ice router, are you not connected to ICE Wi-Fi?");

            IceInfo iceInfo = JsonConvert.DeserializeObject<IceInfo>(response);

            return iceInfo;
        }
    }
}
