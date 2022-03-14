using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class Program {
        private static GlobalData _globalData;
        private static bool SaveReady;
        private static bool SaveImg;
        private static string SaveReady_dir_name;
        public static string Save_dir_name;
        public static string token;
        private static bool ResolveServerName;
        private static dynamic parsedJson;

        static void Main(string[] args) => new Program().Start().GetAwaiter();

        public async Task Start() {
            _globalData = new GlobalData();
            await InitializeGlobalDataAsync();
            init();
        }

        private static async Task InitializeGlobalDataAsync() {
            await _globalData.InitializeAsync();
        }

        private static void init() {

            SaveReady = GlobalData.Config.SaveReady;
            SaveReady_dir_name = GlobalData.Config.SaveReadyPath; // path where save
            SaveImg = GlobalData.Config.SaveImg;
            Save_dir_name = GlobalData.Config.SaveImgPath; // path where save 
            token = GlobalData.Config.Token;
            ResolveServerName = GlobalData.Config.ResolveServerName;


            try {

                string jsonData = @"{'op': 2,'d': {'token': '','properties': {'$os': 'windows','$browser': 'chrome','$device': 'pc'}}}";

                var socket = new ClientWebSocket();
                Logger.Log(Logger.LogLevel.info, "Connecting");
                socket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=9&encording=json"), CancellationToken.None).Wait();

                var buffer = new byte[1024];
                Logger.Log(Logger.LogLevel.info, "Receiving Data");
                var result = socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None).Result;

                var jsonParse = Encoding.UTF8.GetString(buffer, 0, result.Count);
                dynamic jsons = JToken.Parse(jsonParse.ToString());
                int hb = jsons["d"]["heartbeat_interval"] / 50;

                new Thread(() => heartbeat.Heartbeat(socket, hb)).Start();

                new Thread(() => Payload(socket, hb)).Start();

                void Payload(ClientWebSocket socket, int hb) {

                    Thread.Sleep(hb);
                    Logger.Log(Logger.LogLevel.info, "Sending Payload \nPlease WAIT");
                    Payload payload = JsonConvert.DeserializeObject<Payload>(jsonData);
                    payload.d.token = token;
                    Payload payloadCustom = new Payload {
                        op = payload.op,
                        d = payload.d,
                    };
                    var details = JsonConvert.SerializeObject(payloadCustom);
                    socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(details.ToString())), WebSocketMessageType.Text, true, CancellationToken.None).Wait();

                    while(true) {

                        if(!ResolveServerName)
                            Thread.Sleep(500);
                        var buffer = new ArraySegment<byte>(new byte[2048]);
                        if(result.CloseStatus.HasValue) {
                            Logger.Log(Logger.LogLevel.warning, "Closed; Status: " + result.CloseStatus + ", " + result.CloseStatusDescription);
                        } else {

                            try {
                                using(MemoryStream ms = new MemoryStream()) {
                                    do {
                                        result = socket.ReceiveAsync(buffer, CancellationToken.None).Result;
                                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                                    } while(!result.EndOfMessage);

                                    if(result.MessageType == WebSocketMessageType.Close)
                                        break;

                                    ms.Seek(0, SeekOrigin.Begin);

                                    string jsonss = Encoding.UTF8.GetString(ms.ToArray());
                                    parsedJson = JsonConvert.DeserializeObject(jsonss);

                                    if(parsedJson.t == "SESSIONS_REPLACE")
                                        return;

                                    if(parsedJson.t != null /*&& parsedJson.d.author?.bot == null*/) {
                                        if(parsedJson.t == "READY") {
                                            Logger.Log(Logger.LogLevel.info, $"Welcome {parsedJson.d.user.username}#{parsedJson.d.user.discriminator}\n");
                                            if(SaveReady) {
                                                Directory.CreateDirectory(Directory.GetCurrentDirectory() + SaveReady_dir_name);
                                                using(StreamWriter writetext = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory() + SaveReady_dir_name, "ReadyData.json"))) {
                                                    writetext.WriteLine(format_json(jsonss));
                                                }
                                                Logger.Log(Logger.LogLevel.info, $"ReadyData has been saved here : {Directory.GetCurrentDirectory() + $@"{SaveReady_dir_name}\ReadyData.json"}");
                                            }
                                        }
                                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonss);
                                        if(myDeserializedClass.d.content != null) {

                                            Console.WriteLine($"----------------------------------------------------------\n");
                                            if(ResolveServerName) {
                                                Console.WriteLine($"Server: {GCName.get_guild_name(myDeserializedClass.d.guild_id)}\nChannel: {GCName.get_channels_name(myDeserializedClass.d.guild_id, myDeserializedClass.d.channel_id)}");

                                                if(GCName.NSFW.Contains("True")) {
                                                    Logger.Log(Logger.LogLevel.red, GCName.NSFW);
                                                } else {
                                                    Logger.Log(Logger.LogLevel.green, GCName.NSFW);
                                                }
                                            }

                                            Logger.Log(Logger.LogLevel.green, $"{myDeserializedClass.d.author?.username}#{myDeserializedClass.d.author?.discriminator} : " + $"{(myDeserializedClass.d.content)}\n");




                                            string url_msg = $"https://discord.com/channels/{myDeserializedClass.d.guild_id}/{myDeserializedClass.d.channel_id}/{myDeserializedClass.d.nonce}\n";

                                            Logger.Log(Logger.LogLevel.blue, url_msg);


                                            string MakeLink(string txt) {
                                                foreach(Match item in Regex.Matches(txt, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?")) {
                                                    return item.Value;
                                                }
                                                return txt;
                                            }

                                            string ServerNameRegex(string txt) {
                                                if(txt.Contains("𝒦𝒾𝓃𝑔𝒹")) {
                                                    txt = "Kingdom";
                                                }
                                                foreach(Match item in Regex.Matches(txt, "[^a-zA-Z -_]+/g")) {
                                                    return item.Value;
                                                }
                                                return txt.Replace("|", "");
                                            }

                                            if(!Directory.Exists(Directory.GetCurrentDirectory() + Save_dir_name)) {
                                                try {
                                                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + Save_dir_name);
                                                }
                                                catch { }
                                            }

                                            void DL(string url) {
                                                Thread v = new Thread(() => DLImage.DownloadImageAsync(Environment.CurrentDirectory.ToString() + Save_dir_name, DLImage.RandomNumber(0, 5000).ToString(), ServerNameRegex(GCName.get_guild_name(myDeserializedClass.d.guild_id)), new Uri(url)).Wait());
                                                v.Start();
                                            }

                                            if(myDeserializedClass.d.content.Contains("https://") && SaveImg) {
                                                DL(MakeLink(myDeserializedClass.d.content));
                                            }

                                            if(myDeserializedClass.d.attachments != null && SaveImg) {
                                                foreach(var attachment in myDeserializedClass.d.attachments) {
                                                    DL(MakeLink(attachment.url));
                                                }

                                            }

                                            if(myDeserializedClass.d.embeds != null && SaveImg) {
                                                foreach(var attachment in myDeserializedClass.d.embeds) {
                                                    if(attachment.image != null) {
                                                        DL(MakeLink(attachment.image.url));
                                                    } else if(attachment.video != null) {
                                                        DL(MakeLink(attachment.video.url));
                                                    } else if(attachment.url != null && !attachment.url.Contains("redd.it")) {
                                                        DL(MakeLink(attachment.url));
                                                    }
                                                }
                                            }

                                            //File.AppendAllText(@"C:\Temp\csc.txt", parsedJson + Environment.NewLine);
                                        }
                                    }
                                }
                            }
                            catch(Exception ex) { Logger.Log(Logger.LogLevel.error, parsedJson.t + " ERROR\n" + ex.Message); }
                        }

                        static string format_json(string json) {
                            try {
                                dynamic parsedJson = JsonConvert.DeserializeObject(json.ToString());
                                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                            }
                            catch { return json.ToString(); }
                        }
                    }
                }
            }
            catch(Exception ex) {
                Logger.Log(Logger.LogLevel.error, ex.Message);
            }
        }
    }
}