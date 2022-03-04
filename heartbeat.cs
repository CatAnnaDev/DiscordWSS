using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class heartbeat {

        public static void Heartbeat(ClientWebSocket socket, int hb) {
            Thread.CurrentThread.IsBackground = false;
            var heartbeatJSONs = @"{'op': 1,'d': 'null'}";
            var details = JObject.Parse(heartbeatJSONs);
            while(socket.State == WebSocketState.Open) {
                socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(details.ToString())), WebSocketMessageType.Text, true, CancellationToken.None).Wait();
                Thread.Sleep(hb);
            }

            Console.WriteLine(details.ToString());
        }


    }
}
