using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class BotConfig {
        public string Token { get; set; }
        public string SaveImgPath { get; set; }
        public bool SaveImg { get; set; }
        public string SaveReadyPath { get; set; }
        public bool SaveReady { get; set; }

        public bool ResolveServerName { get; set; }
    }
}
