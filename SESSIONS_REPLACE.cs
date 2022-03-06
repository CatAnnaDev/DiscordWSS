using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {

    // SESSIONS_REPLACE myDeserializedClass = JsonConvert.DeserializeObject<SESSIONS_REPLACE>(myJsonResponse);
    public class ClientInfos {
        public int version { get; set; }
        public string os { get; set; }
        public string client { get; set; }
    }

    public class Z {
        public string status { get; set; }
        public string session_id { get; set; }
        public ClientInfos client_info { get; set; }
        public List<object> activities { get; set; }
    }

    public class SESSIONS_REPLACE {
        public string t { get; set; }
        public int s { get; set; }
        public int op { get; set; }
        public List<Z> d { get; set; }
    }


}
