using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class GlobalData {
        public static string ConfigPath { get; set; } = "Config.json";
        public static BotConfig Config { get; set; }

        public async Task InitializeAsync() {
            var json = string.Empty;

            if(!File.Exists(ConfigPath)) {
                json = JsonConvert.SerializeObject(GenerateNewConfig(), Formatting.Indented);
                File.WriteAllText("Config.json", json, new UTF8Encoding(false));
                Console.WriteLine("Please read Config.json");
                await Task.Delay(-1);
            }

            json = File.ReadAllText(ConfigPath, new UTF8Encoding(false));
            Config = JsonConvert.DeserializeObject<BotConfig>(json);
        }

        private static BotConfig GenerateNewConfig() => new BotConfig {
            //BOT
            Token = "TOKEN HERE",
            SaveImgPath = @"C://Path",
            SaveImg = true,
            SaveReadyPath = @"C://Path",
            SaveReady = false,
        };
    }
}
