using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class DataChannelName {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class PermissionOverwrite {
            public string id { get; set; }
            public string type { get; set; }
            public int allow { get; set; }
            public int deny { get; set; }
            public string allow_new { get; set; }
            public string deny_new { get; set; }
        }

        public class Root {
            public string id { get; set; }
            public string last_message_id { get; set; }
            public int type { get; set; }
            public string name { get; set; }
            public int position { get; set; }
            public string parent_id { get; set; }
            public string topic { get; set; }
            public string guild_id { get; set; }
            public List<PermissionOverwrite> permission_overwrites { get; set; }
            public bool nsfw { get; set; }
            public int rate_limit_per_user { get; set; }
            public DateTime? last_pin_timestamp { get; set; }
            public int? bitrate { get; set; }
            public int? user_limit { get; set; }
            public object rtc_region { get; set; }
        }


    }
}
