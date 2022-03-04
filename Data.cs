using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class Data {
    }
    public class Member {
        public List<string> roles { get; set; }
        public object premium_since { get; set; }
        public bool pending { get; set; }
        public string nick { get; set; }
        public bool mute { get; set; }
        public DateTime joined_at { get; set; }
        public string hoisted_role { get; set; }
        public bool deaf { get; set; }
        public object communication_disabled_until { get; set; }
        public string avatar { get; set; }
    }

    public class Image {
        public int width { get; set; }
        public string url { get; set; }
        public string proxy_url { get; set; }
        public int height { get; set; }
    }

    public class Footer {
        public string text { get; set; }
    }

    public class Video {
        public int width { get; set; }
        public string url { get; set; }
        public string proxy_url { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail {
        public int width { get; set; }
        public string url { get; set; }
        public string proxy_url { get; set; }
        public int height { get; set; }
    }

    public class Provider {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Embed {
        public string type { get; set; }
        public string title { get; set; }
        public Image image { get; set; }
        public Footer footer { get; set; }
        public string description { get; set; }
        public int color { get; set; }
        public Video video { get; set; }
        public string url { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Provider provider { get; set; }
    }

    public class Author {
        public string username { get; set; }
        public int public_flags { get; set; }
        public string id { get; set; }
        public string discriminator { get; set; }
        public string avatar { get; set; }
    }

    public class Attachment {
        public int width { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public string proxy_url { get; set; }
        public string id { get; set; }
        public int height { get; set; }
        public string filename { get; set; }
        public string content_type { get; set; }
    }

    public class D {
        public int type { get; set; }
        public bool tts { get; set; }
        public DateTime timestamp { get; set; }
        public object referenced_message { get; set; }
        public bool pinned { get; set; }
        public string nonce { get; set; }
        public List<object> mentions { get; set; }
        public List<object> mention_roles { get; set; }
        public bool mention_everyone { get; set; }
        public Member member { get; set; }
        public string id { get; set; }
        public int flags { get; set; }
        public List<Embed> embeds { get; set; }
        public object edited_timestamp { get; set; }
        public string content { get; set; }
        public List<object> components { get; set; }
        public string channel_id { get; set; }
        public Author author { get; set; }
        public List<Attachment> attachments { get; set; }
        public string guild_id { get; set; }
    }

    public class Root {
        public string t { get; set; }
        public int s { get; set; }
        public int op { get; set; }
        public D d { get; set; }
    }


}
