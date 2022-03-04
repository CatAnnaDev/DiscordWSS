using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace DiscordWSS {
    public class Program {

        static void Main(string[] args) {

            try {
                string token = "";

                string jsonData = @"{'op': 2,'d': {'token': '','properties': {'$os': 'windows','$browser': 'chrome','$device': 'pc'}}}";
               
                var socket = new ClientWebSocket();
                Console.WriteLine("Connecting");
                socket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=9&encording=json"), CancellationToken.None).Wait();

                var buffer = new byte[1024];
                Console.WriteLine("Receiving");
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
                    Console.WriteLine("Sending Payload");
                    Payload payload = JsonConvert.DeserializeObject<Payload>(jsonData);
                    payload.d.token = token;
                    Payload payloadCustom = new Payload {
                      op = payload.op,
                      d = payload.d,
                    };
                    var details = JsonConvert.SerializeObject(payloadCustom);
                    socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(details.ToString())), WebSocketMessageType.Text, true, CancellationToken.None).Wait();

                    while(true) {

                        Thread.Sleep(hb/2);
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

                                ms.Seek(0, System.IO.SeekOrigin.Begin);

                                string jsonss = Encoding.UTF8.GetString(ms.ToArray());
                                dynamic parsedJson = JsonConvert.DeserializeObject(jsonss);
                                if(parsedJson.t != null && parsedJson.t == "MESSAGE_CREATE" /*&& parsedJson.d.author?.bot == null*/) {
                                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonss);

                                    Console.WriteLine($"----------------------------------------------------------\n" +
                                        $"Received message: " +
                                        $"[{myDeserializedClass.s}] {myDeserializedClass.t} \n " +
                                        $"{myDeserializedClass.d.author?.username}#{myDeserializedClass.d.author?.discriminator} : " +
                                        $"{myDeserializedClass.d.content}");

                                    if(myDeserializedClass.d.attachments != null) {
                                        foreach(var attachment in myDeserializedClass.d.attachments) {
                                            Console.WriteLine($"Received message: {attachment.url}");
                                        }
                                        
                                    }

                                    if(myDeserializedClass.d.embeds != null) {
                                        foreach(var attachment in myDeserializedClass.d.embeds) {
                                            if(attachment.image != null)
                                                Console.WriteLine($"image : {attachment.image.url}");
                                            else if(attachment.video != null)
                                                Console.WriteLine($"vidéo : {attachment.video.url}");
                                            else if(attachment.url != null)
                                                Console.WriteLine($"url : {attachment.url}");
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