using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class DataGuildName {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Emoji {
            public string name { get; set; }
            public List<object> roles { get; set; }
            public string id { get; set; }
            public bool require_colons { get; set; }
            public bool managed { get; set; }
            public bool animated { get; set; }
            public bool available { get; set; }
        }

        public class Sticker {
            public string id { get; set; }
            public string name { get; set; }
            public string tags { get; set; }
            public int type { get; set; }
            public int format_type { get; set; }
            public string description { get; set; }
            public string asset { get; set; }
            public bool available { get; set; }
            public string guild_id { get; set; }
        }

        public class Tags {
            public object premium_subscriber { get; set; }
            public string bot_id { get; set; }
        }

        public class Role {
            public string id { get; set; }
            public string name { get; set; }
            public int permissions { get; set; }
            public int position { get; set; }
            public int color { get; set; }
            public bool hoist { get; set; }
            public bool managed { get; set; }
            public bool mentionable { get; set; }
            public string icon { get; set; }
            public string unicode_emoji { get; set; }
            public string permissions_new { get; set; }
            public Tags tags { get; set; }
        }

        public class Root {
            public string id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
            public string splash { get; set; }
            public string discovery_splash { get; set; }
            public List<string> features { get; set; }
            public List<Emoji> emojis { get; set; }
            public List<Sticker> stickers { get; set; }
            public string banner { get; set; }
            public string owner_id { get; set; }
            public object application_id { get; set; }
            public string region { get; set; }
            public string afk_channel_id { get; set; }
            public int afk_timeout { get; set; }
            public string system_channel_id { get; set; }
            public bool widget_enabled { get; set; }
            public object widget_channel_id { get; set; }
            public int verification_level { get; set; }
            public List<Role> roles { get; set; }
            public int default_message_notifications { get; set; }
            public int mfa_level { get; set; }
            public int explicit_content_filter { get; set; }
            public object max_presences { get; set; }
            public int max_members { get; set; }
            public int max_video_channel_users { get; set; }
            public string vanity_url_code { get; set; }
            public int premium_tier { get; set; }
            public int premium_subscription_count { get; set; }
            public int system_channel_flags { get; set; }
            public string preferred_locale { get; set; }
            public string rules_channel_id { get; set; }
            public string public_updates_channel_id { get; set; }
            public object hub_type { get; set; }
            public bool premium_progress_bar_enabled { get; set; }
            public bool nsfw { get; set; }
            public int nsfw_level { get; set; }
            public bool embed_enabled { get; set; }
            public object embed_channel_id { get; set; }
        }


    }
}
