using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Properties {
        [JsonProperty("$os")]
        public string Os { get; set; }

        [JsonProperty("$browser")]
        public string Browser { get; set; }

        [JsonProperty("$device")]
        public string Device { get; set; }
    }

    public class A {
        public string token { get; set; }
        public Properties properties { get; set; }
    }

    public class Payload {
        public int op { get; set; }
        public A d { get; set; }
    }
}
