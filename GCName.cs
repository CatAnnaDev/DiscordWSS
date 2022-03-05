using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Net;

namespace DiscordWSS {
    public class GCName {

        public static string get_guild_name(string GuildID) {
            WebRequest request = WebRequest.Create($"https://discord.com/api/guilds/{GuildID}");
            request.ContentType = "text/html; charset=utf-8";
            request.Method = "GET";
            request.Headers.Add("authorization", Program.token);
            request.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.264 Chrome/91.0.4472.164 Electron/13.4.0 Safari/537.36");
            request.Headers.Add("accept", "*/*");
            WebResponse response = request.GetResponse();
            using(Stream dataStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                DataGuildName.Root MDC = JsonConvert.DeserializeObject<DataGuildName.Root>(responseFromServer);
                return MDC.name;
            }
        }

        public static string get_channels_name(string GuildID, string ChannelID) {
            WebRequest request = WebRequest.Create($"https://discord.com/api/guilds/{GuildID}/channels");
            request.ContentType = "text/html; charset=utf-8";
            request.Method = "GET";
            request.Headers.Add("authorization", Program.token);
            request.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.264 Chrome/91.0.4472.164 Electron/13.4.0 Safari/537.36");
            request.Headers.Add("accept", "*/*");
            WebResponse response = request.GetResponse();
            using(Stream dataStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JArray jArray = JArray.Parse(responseFromServer);
                DataChannelName.Root MDC = JsonConvert.DeserializeObject<DataChannelName.Root>(jArray[jArray.Count() - 1].ToString());
                bool NSFW = true;
                for(int i =0; i < jArray.Count; i++) {

                    if(jArray[i]["id"].ToString() == ChannelID) {
                        if(MDC.nsfw)
                            NSFW = true;
                        else if(!MDC.nsfw)
                            NSFW = false;
                    }
                }
                return $"{MDC.name} \nNFSW ? {NSFW}";
            }
        }
    }
}
