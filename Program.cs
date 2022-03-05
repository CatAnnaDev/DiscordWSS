using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace DiscordWSS {
    public class Program {

        public static string Save_dir_name = @"/img"; // path where save 
        public static string token = "";

        static void Main(string[] args) {
            Console.ResetColor();
            try {
                
                string jsonData = @"{'op': 2,'d': {'token': '','properties': {'$os': 'windows','$browser': 'chrome','$device': 'pc'}}}";
               
                var socket = new ClientWebSocket();
                Console.WriteLine("Connecting");
                socket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=9&encording=json"), CancellationToken.None).Wait();

                var buffer = new byte[1024];
                Console.WriteLine("Receiving Data");
                var result = socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None).Result;

                var jsonParse = Encoding.UTF8.GetString(buffer, 0, result.Count);
                dynamic jsons = JToken.Parse(jsonParse.ToString());
                int hb = jsons["d"]["heartbeat_interval"] / 50;

                Thread t = new Thread(() => heartbeat.Heartbeat(socket, hb));
                t.Start();

                Thread v = new Thread(() => Payload(socket, hb));
                v.Start();

                void Payload(ClientWebSocket socket, int hb) {

                    Thread.Sleep(hb);
                    Console.WriteLine("Sending Payload \n Please WAIT");
                    Payload payload = JsonConvert.DeserializeObject<Payload>(jsonData);
                    payload.d.token = token;
                    Payload payloadCustom = new Payload {
                      op = payload.op,
                      d = payload.d,
                    };
                    var details = JsonConvert.SerializeObject(payloadCustom);
                    socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(details.ToString())), WebSocketMessageType.Text, true, CancellationToken.None).Wait();

                    while(true) {

                        Thread.Sleep(1500);
                        var buffer = new ArraySegment<byte>(new byte[2048]);
                        if(result.CloseStatus.HasValue) {
                            Console.WriteLine("Closed; Status: " + result.CloseStatus + ", " + result.CloseStatusDescription);
                        } else {

                            using(MemoryStream ms = new MemoryStream()) {
                                do {
                                    result = socket.ReceiveAsync(buffer, CancellationToken.None).Result;
                                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                                } while(!result.EndOfMessage);

                                if(result.MessageType == WebSocketMessageType.Close)
                                    break;

                                ms.Seek(0, SeekOrigin.Begin);

                                string jsonss = Encoding.UTF8.GetString(ms.ToArray());
                                dynamic parsedJson = JsonConvert.DeserializeObject(jsonss);
                                if(parsedJson.t != null && parsedJson.t == "MESSAGE_CREATE" /*&& parsedJson.d.author?.bot == null*/) {
                                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonss);

                                    Console.WriteLine($"----------------------------------------------------------\n");
                                    Console.WriteLine($"Server: {GCName.get_guild_name(myDeserializedClass.d.guild_id)}\nChannel: {GCName.get_channels_name(myDeserializedClass.d.guild_id, myDeserializedClass.d.channel_id)}");

                                    if(GCName.NSFW.Contains("True")) {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(GCName.NSFW);
                                        Console.ResetColor();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine(GCName.NSFW);
                                        Console.ResetColor();
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write($"{myDeserializedClass.d.author?.username}#{myDeserializedClass.d.author?.discriminator} : ");
                                    Console.WriteLine($"{(myDeserializedClass.d.content.Contains("https://") ? MakeLink(myDeserializedClass.d.content) : myDeserializedClass.d.content)}\n");
                                    Console.ResetColor();

                                    string url_msg = $"https://discord.com/channels/{myDeserializedClass.d.guild_id}/{myDeserializedClass.d.channel_id}/{myDeserializedClass.d.nonce}\n";

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine(url_msg);
                                    Console.ResetColor();


                                    string MakeLink(string txt) {
                                        foreach(Match item in Regex.Matches(txt, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?")) {
                                            return item.Value;
                                        }
                                        return txt;
                                    }

                                    if(myDeserializedClass.d.attachments != null) {
                                        try {
                                            foreach(var attachment in myDeserializedClass.d.attachments) {
                                                Console.WriteLine($"Received message: {attachment.url}");
                                                Thread v = new Thread(() => DLImage.DownloadImageAsync(Environment.CurrentDirectory.ToString() + Save_dir_name, DLImage.RandomNumber(0, 5000).ToString(), new Uri(attachment.url)).Wait());
                                                v.Start();
                                            }
                                        }
                                        catch(Exception ex) { Console.WriteLine("Can't Download this file \n{0}", ex.Message); };
                                        
                                    }

                                    if(myDeserializedClass.d.embeds != null) {
                                        foreach(var attachment in myDeserializedClass.d.embeds) {
                                            if(attachment.image != null) {
                                                try {
                                                    Console.WriteLine($"image : {attachment.image.url}");
                                                    Thread v = new Thread(() => DLImage.DownloadImageAsync(Environment.CurrentDirectory.ToString() + Save_dir_name, DLImage.RandomNumber(0, 5000).ToString(), new Uri(attachment.image.url)).Wait());
                                                    v.Start();
                                                }
                                                catch(Exception ex) { Console.WriteLine("Can't Download this file \n{0}", ex.Message); }

                                            } else if(attachment.video != null) {
                                                try {
                                                    Console.WriteLine($"vidéo : {attachment.video.url}");
                                                    Thread v = new Thread(() => DLImage.DownloadImageAsync(Environment.CurrentDirectory.ToString() + Save_dir_name, DLImage.RandomNumber(0, 5000).ToString(), new Uri(attachment.video.url)).Wait());
                                                    v.Start();
                                                }
                                                catch(Exception ex) { Console.WriteLine("Can't Download this file \n{0}", ex.Message); }
                                            } else if(attachment.url != null) {
                                                try {
                                                    Console.WriteLine($"url : {attachment.url}");
                                                    Thread v = new Thread(() => DLImage.DownloadImageAsync(Environment.CurrentDirectory.ToString() + Save_dir_name, DLImage.RandomNumber(0, 5000).ToString(), new Uri(attachment.url)).Wait());
                                                    v.Start();
                                                }
                                                catch(Exception ex) { Console.WriteLine("Can't Download this file \n{0}", ex.Message); }
                                            }
                                        }
                                    }

                                    File.AppendAllText(@"C:\Temp\csc.txt", parsedJson + Environment.NewLine);
                                }
                            }
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
                Console.WriteLine(ex.ToString());
            }
        }
    }
}