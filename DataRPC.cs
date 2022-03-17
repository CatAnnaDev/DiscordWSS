using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS
{

    // DataRPC myDeserializedClass = JsonConvert.DeserializeObject<DataRPC>(myJsonResponse);
    public class Activitys
    {
        public string name { get; set; }
        public int type { get; set; }
        public string url { get; set; }
    }

    public class Ds
    {
        public int since { get; set; }
        public List<Activitys> activities { get; set; }
        public string status { get; set; }
        public bool afk { get; set; }
    }

    public class DataRPC
    {
        public int op { get; set; }
        public Ds d { get; set; }
    }
}
